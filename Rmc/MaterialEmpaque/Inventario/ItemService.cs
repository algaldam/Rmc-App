using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Rmc.MaterialEmpaque.Inventario
{
    public class ItemService
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;

        #region Warehouse Operations

        public List<Warehouse> GetAllWarehouses()
        {
            var warehouses = new List<Warehouse>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"SELECT WarehouseID, WarehouseCode, WarehouseName, Description, IsMain 
                        FROM pmc_Warehouse 
                        ORDER BY WarehouseName";

                    using (var command = new SqlCommand(query, connection))
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
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las bodegas: {ex.Message}", ex);
            }
            return warehouses;
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"SELECT WarehouseID, WarehouseCode, WarehouseName, Description, IsMain 
                                FROM pmc_Warehouse 
                                WHERE WarehouseID = @WarehouseID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WarehouseID", warehouseId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Warehouse
                                {
                                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                                    WarehouseCode = reader.GetString(reader.GetOrdinal("WarehouseCode")),
                                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                    IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la bodega: {ex.Message}", ex);
            }
            return null;
        }

        #endregion

        #region CRUD Operations

        public List<ItemInv> GetAllItems(int warehouseId)
        {
            var items = new List<ItemInv>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                        SELECT
                            IT.ItemID,
                            IT.Code,
                            SB.sub_descripcion AS Description,
                            SB.MaterialType,
                            IT.TotalQuantity,
                            IT.Location,
                            IT.BoxID,
                            IT.CreatedDate,
                            IT.CreatedBy,
                            LEFT(EM.Emp_Nombres, CHARINDEX(' ', EM.Emp_Nombres + ' ') - 1) + ' ' +
                            LEFT(EM.Emp_Apellidos, CHARINDEX(' ', EM.Emp_Apellidos + ' ') - 1) AS Name,
                            IT.ModifiedDate,
                            IT.ModifiedBy,
                            IT.WarehouseID,
                            W.WarehouseName
                        FROM pmc_InventoryPreparation IT
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                MIN(sub_TypeMaterials) AS MaterialType,
                                MIN(sub_descripcion) AS sub_descripcion
                            FROM pmc_Subida_BOM
                            GROUP BY sub_producto
                        ) SB ON IT.Code = SB.sub_producto
                        INNER JOIN mst_Empleados EM ON IT.CreatedBy = EM.Emp_ID
                        INNER JOIN pmc_Warehouse W ON IT.WarehouseID = W.WarehouseID
                        WHERE IT.WarehouseID = @WarehouseID
                        ORDER BY IT.CreatedDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WarehouseID", warehouseId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new ItemInv
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Code = reader.GetString(reader.GetOrdinal("Code")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "No disponible" : reader.GetString(reader.GetOrdinal("Description")),
                                    MaterialType = reader.IsDBNull(reader.GetOrdinal("MaterialType")) ? "No disponible" : reader.GetString(reader.GetOrdinal("MaterialType")),
                                    TotalQuantity = reader.GetDecimal(reader.GetOrdinal("TotalQuantity")),
                                    Location = reader.GetString(reader.GetOrdinal("Location")),
                                    BoxID = reader.GetString(reader.GetOrdinal("BoxID")),
                                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                    CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    ModifiedDate = reader.IsDBNull(reader.GetOrdinal("ModifiedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifiedDate")),
                                    ModifiedBy = reader.IsDBNull(reader.GetOrdinal("ModifiedBy")) ? null : reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los items: {ex.Message}", ex);
            }

            return items;
        }

        public ItemInv GetItemById(int itemId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                        SELECT
                            IT.ItemID,
                            IT.Code,
                            SB.sub_descripcion AS Description,
                            SB.MaterialType,
                            IT.TotalQuantity,
                            IT.Location,
                            IT.BoxID,
                            IT.CreatedDate,
                            IT.CreatedBy,
                            IT.ModifiedDate,
                            IT.ModifiedBy,
                            IT.WarehouseID,
                            W.WarehouseName
                        FROM pmc_InventoryPreparation IT
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                MIN(sub_TypeMaterials) AS MaterialType,
                                MIN(sub_descripcion) AS sub_descripcion
                            FROM pmc_Subida_BOM
                            GROUP BY sub_producto
                        ) SB ON IT.Code = SB.sub_producto
                        INNER JOIN pmc_Warehouse W ON IT.WarehouseID = W.WarehouseID
                        WHERE IT.ItemID = @ItemID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ItemInv
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Code = reader.GetString(reader.GetOrdinal("Code")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "No disponible" : reader.GetString(reader.GetOrdinal("Description")),
                                    MaterialType = reader.IsDBNull(reader.GetOrdinal("MaterialType")) ? "No disponible" : reader.GetString(reader.GetOrdinal("MaterialType")),
                                    TotalQuantity = reader.GetDecimal(reader.GetOrdinal("TotalQuantity")),
                                    Location = reader.GetString(reader.GetOrdinal("Location")),
                                    BoxID = reader.GetString(reader.GetOrdinal("BoxID")),
                                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                    CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy")),
                                    ModifiedDate = reader.IsDBNull(reader.GetOrdinal("ModifiedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifiedDate")),
                                    ModifiedBy = reader.IsDBNull(reader.GetOrdinal("ModifiedBy")) ? null : reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el item: {ex.Message}", ex);
            }

            return null;
        }

        public bool InsertItem(ItemInv item, string currentUser)
        {
            var validationResult = ValidateItem(item);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            if (CodeExists(item.Code, item.WarehouseID))
            {
                throw new Exception("El código del item ya existe en esta bodega.");
            }

            var bomInfo = GetBomInfo(item.Code);
            if (bomInfo != null)
            {
                item.Description = bomInfo.Description;
                item.MaterialType = bomInfo.MaterialType;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                        INSERT INTO pmc_InventoryPreparation 
                            (Code, TotalQuantity, Location, BoxID, CreatedBy, ModifiedBy, WarehouseID)
                        VALUES 
                            (@Code, @TotalQuantity, @Location, @BoxID, @CreatedBy, @ModifiedBy, @WarehouseID)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", item.Code);
                        command.Parameters.AddWithValue("@TotalQuantity", item.TotalQuantity);
                        command.Parameters.AddWithValue("@Location", item.Location);
                        command.Parameters.AddWithValue("@BoxID", item.BoxID);
                        command.Parameters.AddWithValue("@CreatedBy", currentUser);
                        command.Parameters.AddWithValue("@ModifiedBy", currentUser);
                        command.Parameters.AddWithValue("@WarehouseID", item.WarehouseID);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de unique key
                {
                    throw new Exception("El código del item ya existe en esta bodega.");
                }
                throw new Exception($"Error al insertar el item: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar el item: {ex.Message}", ex);
            }
        }

        public bool UpdateItem(ItemInv item, string currentUser)
        {
            var validationResult = ValidateItem(item);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            // Validar unicidad del código excluyendo el item actual
            if (CodeExists(item.Code, item.WarehouseID, item.ItemID))
            {
                throw new Exception("El código del item ya existe en esta bodega.");
            }

            var bomInfo = GetBomInfo(item.Code);
            if (bomInfo != null)
            {
                item.Description = bomInfo.Description;
                item.MaterialType = bomInfo.MaterialType;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                        UPDATE pmc_InventoryPreparation 
                        SET 
                            Code = @Code,
                            TotalQuantity = @TotalQuantity,
                            Location = @Location,
                            BoxID = @BoxID,
                            ModifiedDate = GETDATE(),
                            ModifiedBy = @ModifiedBy,
                            WarehouseID = @WarehouseID
                        WHERE ItemID = @ItemID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", item.ItemID);
                        command.Parameters.AddWithValue("@Code", item.Code);
                        command.Parameters.AddWithValue("@TotalQuantity", item.TotalQuantity);
                        command.Parameters.AddWithValue("@Location", item.Location);
                        command.Parameters.AddWithValue("@BoxID", item.BoxID);
                        command.Parameters.AddWithValue("@ModifiedBy", currentUser);
                        command.Parameters.AddWithValue("@WarehouseID", item.WarehouseID);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de unique key
                {
                    throw new Exception("El código del item ya existe en esta bodega.");
                }
                throw new Exception($"Error al actualizar el item: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el item: {ex.Message}", ex);
            }
        }

        public bool DeleteItem(int itemId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "DELETE FROM pmc_InventoryPreparation WHERE ItemID = @ItemID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el item: {ex.Message}", ex);
            }
        }

        #endregion

        #region Validation

        public ValidationResult ValidateItem(ItemInv item)
        {
            // Validar código
            if (string.IsNullOrWhiteSpace(item.Code))
            {
                return ValidationResult.Error("El código es requerido.");
            }

            if (item.Code.Length > 50)
            {
                return ValidationResult.Error("El código no puede tener más de 50 caracteres.");
            }

            // Validar cantidad
            if (item.TotalQuantity < 0)
            {
                return ValidationResult.Error("La cantidad no puede ser negativa.");
            }

            if (item.TotalQuantity > 999999999.99m)
            {
                return ValidationResult.Error("La cantidad excede el límite permitido.");
            }

            // Validar ubicación
            if (string.IsNullOrWhiteSpace(item.Location))
            {
                return ValidationResult.Error("La ubicación es requerida.");
            }

            if (item.Location.Length > 10)
            {
                return ValidationResult.Error("La ubicación no puede tener más de 10 caracteres.");
            }

            // Validar ID de caja
            if (string.IsNullOrWhiteSpace(item.BoxID))
            {
                return ValidationResult.Error("El ID de la caja es requerido.");
            }

            if (item.BoxID.Length > 20)
            {
                return ValidationResult.Error("El ID de la caja no puede tener más de 20 caracteres.");
            }

            // Validar bodega
            if (item.WarehouseID <= 0)
            {
                return ValidationResult.Error("La bodega es requerida.");
            }

            return ValidationResult.Success();
        }

        public bool CodeExists(string code, int warehouseId, int? excludeItemId = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT COUNT(1) FROM pmc_InventoryPreparation WHERE Code = @Code AND WarehouseID = @WarehouseID";

                    if (excludeItemId.HasValue)
                    {
                        query += " AND ItemID != @ItemID";
                    }

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code.Trim());
                        command.Parameters.AddWithValue("@WarehouseID", warehouseId);

                        if (excludeItemId.HasValue)
                        {
                            command.Parameters.AddWithValue("@ItemID", excludeItemId.Value);
                        }

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar el código: {ex.Message}", ex);
            }
        }

        #endregion

        #region BOM Integration

        public bool CodeExistsInBom(string code)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT COUNT(1) FROM pmc_Subida_BOM WHERE sub_producto = @Code";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code.Trim());
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar el código en BOM: {ex.Message}", ex);
            }
        }

        #endregion

        #region Search and Filter

        public List<ItemInv> SearchItems(string searchTerm, int warehouseId)
        {
            var items = new List<ItemInv>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                            SELECT
                                IT.ItemID,
                                IT.Code,
                                SB.sub_descripcion AS Description,
                                SB.MaterialType,
                                IT.TotalQuantity,
                                IT.Location,
                                IT.BoxID,
                                IT.CreatedDate,
                                IT.CreatedBy,
                                IT.ModifiedDate,
                                IT.ModifiedBy,
                                IT.WarehouseID,
                                W.WarehouseName
                            FROM pmc_InventoryPreparation IT
                            LEFT JOIN (
                                SELECT 
                                    sub_producto, 
                                    MIN(sub_TypeMaterials) AS MaterialType,
                                    MIN(sub_descripcion) AS sub_descripcion
                                FROM pmc_Subida_BOM
                                GROUP BY sub_producto
                            ) SB ON IT.Code = SB.sub_producto
                            INNER JOIN pmc_Warehouse W ON IT.WarehouseID = W.WarehouseID
                            WHERE 
                                IT.WarehouseID = @WarehouseID AND  -- FILTRO CRÍTICO POR BODEGA
                                (IT.Code LIKE @SearchTerm OR 
                                 SB.sub_descripcion LIKE @SearchTerm OR
                                 SB.MaterialType LIKE @SearchTerm OR
                                 IT.Location LIKE @SearchTerm OR
                                 IT.BoxID LIKE @SearchTerm)
                            ORDER BY IT.CreatedDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WarehouseID", warehouseId); // Usar el parámetro
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new ItemInv
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Code = reader.GetString(reader.GetOrdinal("Code")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "No disponible" : reader.GetString(reader.GetOrdinal("Description")),
                                    MaterialType = reader.IsDBNull(reader.GetOrdinal("MaterialType")) ? "No disponible" : reader.GetString(reader.GetOrdinal("MaterialType")),
                                    TotalQuantity = reader.GetDecimal(reader.GetOrdinal("TotalQuantity")),
                                    Location = reader.GetString(reader.GetOrdinal("Location")),
                                    BoxID = reader.GetString(reader.GetOrdinal("BoxID")),
                                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                    CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy")),
                                    ModifiedDate = reader.IsDBNull(reader.GetOrdinal("ModifiedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifiedDate")),
                                    ModifiedBy = reader.IsDBNull(reader.GetOrdinal("ModifiedBy")) ? null : reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar items: {ex.Message}", ex);
            }

            return items;
        }

        #endregion

        #region Data Export

        public DataTable GetItemsDataTable(int warehouseId)
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                        SELECT
                            IT.Code as 'Código',
                            SB.sub_descripcion as 'Descripción',
                            SB.MaterialType as 'Tipo Material',
                            IT.TotalQuantity as 'Cantidad',
                            IT.Location as 'Ubicación',
                            IT.BoxID as 'ID Caja',
                            IT.CreatedDate as 'Fecha Creación',
                            IT.CreatedBy as 'Creado Por',
                            W.WarehouseName as 'Bodega'
                        FROM pmc_InventoryPreparation IT
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                MIN(sub_TypeMaterials) AS MaterialType,
                                MIN(sub_descripcion) AS sub_descripcion
                            FROM pmc_Subida_BOM
                            GROUP BY sub_producto
                        ) SB ON IT.Code = SB.sub_producto
                        INNER JOIN pmc_Warehouse W ON IT.WarehouseID = W.WarehouseID
                        WHERE IT.WarehouseID = @WarehouseID
                        ORDER BY IT.CreatedDate DESC";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@WarehouseID", warehouseId);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos para exportar: {ex.Message}", ex);
            }

            return dataTable;
        }

        #endregion

        #region AutoComplete Methods
        public BomInfo GetBomInfo(string code)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                    SELECT 
                        MIN(sub_descripcion) AS Description,
                        MIN(sub_TypeMaterials) AS MaterialType
                    FROM pmc_Subida_BOM 
                    WHERE sub_producto = @Code
                    GROUP BY sub_producto";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new BomInfo
                                {
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        "No disponible" : reader.GetString(reader.GetOrdinal("Description")),
                                    MaterialType = reader.IsDBNull(reader.GetOrdinal("MaterialType")) ?
                                        "No disponible" : reader.GetString(reader.GetOrdinal("MaterialType"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener información BOM: {ex.Message}");
            }

            return null;
        }

        public List<string> GetAllItemCodesForWarehouse(int warehouseId)
        {
            var itemCodes = new List<string>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"
                SELECT DISTINCT Code 
                FROM pmc_InventoryPreparation 
                WHERE WarehouseID = @WarehouseID 
                ORDER BY Code";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WarehouseID", warehouseId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemCodes.Add(reader.GetString(reader.GetOrdinal("Code")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener códigos para autocompletado: {ex.Message}");
            }

            return itemCodes;
        }
        #endregion
    }

    #region Supporting Classes

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Success()
        {
            return new ValidationResult { IsValid = true };
        }

        public static ValidationResult Error(string message)
        {
            return new ValidationResult { IsValid = false, ErrorMessage = message };
        }
    }

    public class BomInfo
    {
        public string Description { get; set; }
        public string MaterialType { get; set; }
    }

    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }

        public override string ToString()
        {
            return WarehouseName;
        }
    }

    #endregion
}