using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rmc.MaterialEmpaque.Inventario
{
    public class TransferService
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;

        #region Transfer Operations

        public bool TransferItem(string itemCode, decimal quantity, int sourceWarehouseId, int destinationWarehouseId, string currentUser, string description = "")
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sourceItem = GetItemByCodeAndWarehouse(itemCode, sourceWarehouseId, connection, transaction);
                        if (sourceItem == null)
                        {
                            throw new Exception($"El item '{itemCode}' no existe en la bodega de origen.");
                        }

                        if (sourceItem.TotalQuantity < quantity)
                        {
                            throw new Exception($"Stock insuficiente. Disponible: {sourceItem.TotalQuantity:N2}, Solicitado: {quantity:N2}");
                        }

                        if (quantity <= 0)
                        {
                            throw new Exception("La cantidad a transferir debe ser mayor que cero.");
                        }

                        if (!UpdateItemQuantity(sourceItem.ItemID, -quantity, connection, transaction))
                        {
                            throw new Exception("Error al descontar del inventario de origen.");
                        }

                        var destinationItem = GetItemByCodeAndWarehouse(itemCode, destinationWarehouseId, connection, transaction);
                        if (destinationItem != null)
                        {
                            if (!UpdateItemQuantity(destinationItem.ItemID, quantity, connection, transaction))
                            {
                                throw new Exception("Error al actualizar el inventario de destino.");
                            }
                        }
                        else
                        {
                            if (!CreateItemInWarehouse(sourceItem, destinationWarehouseId, quantity, currentUser, connection, transaction))
                            {
                                throw new Exception("Error al crear el item en la bodega de destino.");
                            }
                        }

                        if (!LogTransfer(itemCode, quantity, sourceWarehouseId, destinationWarehouseId, description, currentUser, connection, transaction))
                        {
                            throw new Exception("Error al registrar la transferencia en el historial.");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Warehouse> GetAvailableDestinations(int currentWarehouseId)
        {
            var warehouses = new List<Warehouse>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"SELECT WarehouseID, WarehouseCode, WarehouseName, Description, IsMain 
                                FROM pmc_Warehouse 
                                WHERE WarehouseID != @CurrentWarehouseID
                                ORDER BY WarehouseName";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CurrentWarehouseID", currentWarehouseId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                warehouses.Add(new Warehouse
                                {
                                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                                    WarehouseCode = reader.GetString(reader.GetOrdinal("WarehouseCode")),
                                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                    IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener bodegas disponibles: {ex.Message}", ex);
            }
            return warehouses;
        }

        public ItemInv GetItemByCodeAndWarehouse(string code, int warehouseId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return GetItemByCodeAndWarehouse(code, warehouseId, connection, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el item: {ex.Message}", ex);
            }
        }

        #endregion

        #region Private Methods

        private ItemInv GetItemByCodeAndWarehouse(string code, int warehouseId, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                    SELECT 
                        i.ItemID, 
                        i.Code, 
                        i.TotalQuantity, 
                        i.Location, 
                        i.BoxID,
                        COALESCE(sb.sub_descripcion, 'SIN DESCRIPCIÓN') as Description
                    FROM pmc_InventoryPreparation i
                    LEFT JOIN pmc_Subida_BOM sb ON i.Code = sb.sub_producto
                    WHERE i.Code = @Code AND i.WarehouseID = @WarehouseID";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@WarehouseID", warehouseId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ItemInv
                        {
                            ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                            Code = reader.GetString(reader.GetOrdinal("Code")),
                            TotalQuantity = reader.GetDecimal(reader.GetOrdinal("TotalQuantity")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            BoxID = reader.GetString(reader.GetOrdinal("BoxID")),
                            Description = reader.GetString(reader.GetOrdinal("Description"))
                        };
                    }
                }
            }
            return null;
        }

        private bool UpdateItemQuantity(int itemId, decimal quantityChange, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                UPDATE pmc_InventoryPreparation 
                SET TotalQuantity = TotalQuantity + @QuantityChange,
                    ModifiedDate = GETDATE(),
                    ModifiedBy = @ModifiedBy
                WHERE ItemID = @ItemID AND (TotalQuantity + @QuantityChange) >= 0";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ItemID", itemId);
                command.Parameters.AddWithValue("@QuantityChange", quantityChange);
                command.Parameters.AddWithValue("@ModifiedBy", "System");

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        private bool CreateItemInWarehouse(ItemInv sourceItem, int destinationWarehouseId, decimal quantity, string currentUser, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                INSERT INTO pmc_InventoryPreparation 
                    (Code, TotalQuantity, Location, BoxID, CreatedBy, ModifiedBy, WarehouseID)
                VALUES 
                    (@Code, @TotalQuantity, @Location, @BoxID, @CreatedBy, @ModifiedBy, @WarehouseID)";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Code", sourceItem.Code);
                command.Parameters.AddWithValue("@TotalQuantity", quantity);
                command.Parameters.AddWithValue("@Location", sourceItem.Location);
                command.Parameters.AddWithValue("@BoxID", sourceItem.BoxID);
                command.Parameters.AddWithValue("@CreatedBy", currentUser);
                command.Parameters.AddWithValue("@ModifiedBy", currentUser);
                command.Parameters.AddWithValue("@WarehouseID", destinationWarehouseId);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        private bool LogTransfer(string itemCode, decimal quantity, int sourceWarehouseId, int destinationWarehouseId, string description, string currentUser, SqlConnection connection, SqlTransaction transaction)
        {
            string sourceName = GetWarehouseName(sourceWarehouseId, connection, transaction);
            string destinationName = GetWarehouseName(destinationWarehouseId, connection, transaction);

            var query = @"
                INSERT INTO pmc_InventoryTransfers 
                    (Code, Quantity, Origin, Destination, Description, CreatedBy)
                VALUES 
                    (@Code, @Quantity, @Origin, @Destination, @Description, @CreatedBy)";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Code", itemCode);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Origin", sourceName);
                command.Parameters.AddWithValue("@Destination", destinationName);
                command.Parameters.AddWithValue("@Description", description ?? $"Transferencia - {DateTime.Now:dd/MM/yyyy HH:mm}");
                command.Parameters.AddWithValue("@CreatedBy", currentUser);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        private string GetWarehouseName(int warehouseId, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "SELECT WarehouseName FROM pmc_Warehouse WHERE WarehouseID = @WarehouseID";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@WarehouseID", warehouseId);
                var result = command.ExecuteScalar();
                return result?.ToString() ?? $"Bodega {warehouseId}";
            }
        }

        #endregion
    }
}