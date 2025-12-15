using Rmc.Clases;
using Rmc.EntityFramework;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rmc.Controllers
{
    class POController
    {
        public bool POExisteEnWainari(string numeroPO)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
            {
                string query = "SELECT COUNT(*) FROM wai_POS WHERE pos_numero = @po";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@po", numeroPO);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool InsertarPOS(string numero, int bodegaId, DateTime fecha, string creador)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
            {
                string query = @"
                                INSERT INTO wai_POS 
                                    (
		                                pos_numero, 
		                                pos_bodega_id, 
		                                pos_ajuste, 
		                                pos_estado, 
		                                pos_fecha, 
		                                pos_creador
	                                )
                                VALUES 
                                    (
		                                @numero, 
		                                @bodegaId, 
		                                @ajuste, 
		                                @estado, 
		                                @fecha, 
		                                @creador
	                                )";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@bodegaId", bodegaId);
                    cmd.Parameters.AddWithValue("@ajuste", 0);
                    cmd.Parameters.AddWithValue("@estado", "A");
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@creador", creador);
                        
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool InsertarFacturaDetalle(int facId, ProductosFactura producto)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
            {
                string query = @"
                                INSERT INTO wai_Factura_Detalle (
                                    facd_fac_id, facd_item_id, facd_cantidad, facd_peso,
                                    facd_lote, facd_prioridad, facd_fecha_caducidad,
                                    facd_no_conforme, facd_usuario_crea, facd_fecha_crea
                                )
                                VALUES (
                                    @facId, @itemId, @cantidad, @peso,
                                    @lote, @prioridad, @fechaCaducidad,
                                    @noConforme, @usuario, GETDATE())";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@facId", facId);
                    cmd.Parameters.AddWithValue("@itemId", producto.facd_item_id);
                    cmd.Parameters.AddWithValue("@cantidad", producto.facd_cantidad);
                    cmd.Parameters.AddWithValue("@peso", producto.facd_peso);
                    cmd.Parameters.AddWithValue("@lote", string.IsNullOrWhiteSpace(producto.facd_lote) ? DBNull.Value : (object)producto.facd_lote);
                    cmd.Parameters.AddWithValue("@prioridad", producto.facd_prioridad);
                    cmd.Parameters.AddWithValue("@fechaCaducidad", DateTime.Now); // valor por defecto
                    cmd.Parameters.AddWithValue("@noConforme", 0);
                    cmd.Parameters.AddWithValue("@usuario", Environment.UserName);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public int? ObtenerItemIdPorCodigo(string codigo)
        {
            using (var db = new ES_SOCKSEntities2())
            {
                var item = db.wai_Item.FirstOrDefault(x => x.ite_codigo == codigo);
                return item?.ite_id;
            }
        }

        public int ObtenerCodigo(string Letra, string Codigo)
        {
            try
            {
                using (ES_SOCKSEntities2 dbt = new ES_SOCKSEntities2())
                {
                    int numero = 0;
                    switch (Letra)
                    {
                        case "PO":
                            numero = (from x in dbt.wai_POS
                                      where x.pos_numero == Codigo
                                      select x).Count();
                            break;
                        case "FA":
                            numero = (from x in dbt.wai_Factura
                                      where x.fac_numero == Codigo
                                      select x).Count();
                            break;
                        default:
                            break;
                    }
                    return numero;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ValidarFactura(string opcion, int ObjetoID)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "";
                    if (opcion == "FA")
                    {
                        Consulta = "SELECT ISNULL(SUM(facd_cantidad),0) FROM wai_Factura_Detalle WHERE facd_fac_id=" + ObjetoID;
                    }
                    else if (opcion == "Pk")
                    {
                        Consulta = "Select COUNT(pac_id) FROM wai_Pack_List WHERE pac_factura_detalle_id=" + ObjetoID;
                    }
                    var resultado = db.Database.SqlQuery<int>(Consulta).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PrioridadPO> ObtenerUltimaPrioridad(int ProductoID)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT TOP 1 POS.pos_semana AS Semana, DET.facd_prioridad AS Prioridad,fac.fac_id AS FacID," +
                                      "          pos.pos_numero AS NumeroPO,det.facd_fecha_crea AS Fecha                           " +
                                      " FROM wai_Factura  fac                                                                      " +
                                      " INNER JOIN                                                                                 " +
                                      " wai_Factura_Detalle DET ON fac.fac_id= det.facd_fac_id                                     " +
                                      " INNER JOIN wai_POS POS  ON POS.pos_id= FAC.fac_pos_id                                      " +
                                      " WHERE DET.facd_item_id =" + ProductoID + " AND DET.facd_prioridad>0                        " +
                                      " ORDER BY facd_fecha_crea DESC                                                              ";

                    var Resultado = db.Database.SqlQuery<PrioridadPO>(consulta).ToList();
                    return Resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<wai_POS> ObtenerPOS(int Bodega, String Estado)
        {
            try
            {
                string Filtro = "";
                if (Estado == "A")
                {
                    Filtro = "AND  pos_estado ='A'";
                }
                else if (Estado == "C")
                {
                    Filtro = "AND  pos_estado ='C'";
                }
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "SELECT * FROM wai_POS WHERE pos_bodega_id = " + Bodega + " " + Filtro;

                    var Resultado = db.Database.SqlQuery<wai_POS>(Consulta).ToList();

                    return Resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<wai_Factura> ObtenerFacuras(int POId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT * FROM wai_Factura WHERE fac_pos_id=" + POId;

                    var resultado = db.Database.SqlQuery<wai_Factura>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ProductosFactura> ObtenerProductosFactura(int IdFactura)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = " SELECT FD.facd_id  , FD.facd_item_id, I.ite_codigo, I.ite_descripcion, FD.facd_cantidad, " +
                                     "        FD.facd_peso, FD.facd_lote, FD.facd_prioridad,FD.facd_fecha_caducidad,         " +
                                     " (Select COUNT(pac_id) FROM wai_Pack_List WHERE pac_factura_detalle_id =FD.facd_id) " +
                                     " AS CantidadPackList    " +
                                     " FROM wai_Factura_Detalle AS FD                                                           " +
                                     " INNER JOIN wai_Item I ON I.ite_id=FD.facd_item_id                                        " +
                                     " WHERE FD.facd_fac_id='" + IdFactura + "'";
                    var resultado = db.Database.SqlQuery<ProductosFactura>(Consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int PO_CRUD(int Accion, wai_POS ObjetoPO)
        {
            try
            {
                string resultado = "";
                var Fecha = ConsultasSql.ObtenerFechaServer();

                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    if (Accion == 1)
                    {
                        var parametros = new[]
                        {
                            new SqlParameter("@usuario", Environment.UserName),
                            new SqlParameter("@accion", "C"),
                            new SqlParameter("@idPO", ObjetoPO.pos_id),
                            new SqlParameter("@numeroPO", ObjetoPO.pos_numero),
                            new SqlParameter("@proveedorID", ObjetoPO.pos_proveedor_id),
                            new SqlParameter("@bodegaID", ObjetoPO.pos_bodega_id),
                            new SqlParameter("@estado", ObjetoPO.pos_estado == "A" ? 0 : 1),
                            new SqlParameter("@semana", ObjetoPO.pos_semana),
                            new SqlParameter("@fecha", Fecha),
                            new SqlParameter("@creador", ObjetoPO.pos_creador)
                        };

                        resultado = db.Database.SqlQuery<string>("EXEC usp_wai_POS_CRUD @usuario, @accion, @idPO, @numeroPO, @proveedorID, @bodegaID, @estado, @semana, @fecha, @creador", parametros).FirstOrDefault();
                    }
                    else if (Accion == 2)
                    {
                        var registro = db.wai_POS.FirstOrDefault(x => x.pos_id == ObjetoPO.pos_id);
                        if (registro != null)
                        {
                            db.wai_POS.Remove(registro);
                            db.SaveChanges();
                            resultado = "OK";
                        }
                    }
                }

                return resultado == "OK" ? 1 : 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // INSERTAR, ACTUALIZAR Y ELIMINAR FACTURA
        public int FacturaCRUD(int Accion, wai_Factura factura)
        {
            try
            {
                string resultado = "";
                var Fecha = ConsultasSql.ObtenerFechaServer();
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    //INSERTAR
                    if (Accion == 1)
                    {
                        factura.fac_fecha_crea = Fecha;
                        factura.fac_fecha = Fecha;
                        factura.fac_usuario_crea = Environment.UserName;
                        db.wai_Factura.Add(factura);
                        db.SaveChanges();
                        resultado = "OK";
                    }
                    //ACTUALIZAR
                    else if (Accion == 2)
                    {
                        var Registro = db.wai_Factura.Where(x => x.fac_id == factura.fac_id).FirstOrDefault();
                        if (Registro != null)
                        {
                            Registro.fac_numero = factura.fac_numero;
                            Registro.fac_paquetes = factura.fac_paquetes;
                            Registro.fac_medida = factura.fac_medida;
                            Registro.fac_libras = factura.fac_libras;
                            Registro.fac_fecha_mod = Fecha;
                            Registro.fac_usuario_mod = Environment.UserName;

                            db.SaveChanges();
                            resultado = "OK";
                        }
                    }
                    //ELIMINAR
                    else if (Accion == 3)
                    {
                        var Registro = db.wai_Factura.Where(x => x.fac_id == factura.fac_id).FirstOrDefault();
                        if (Registro != null)
                        {
                            db.wai_Factura.Remove(Registro);
                            db.SaveChanges();
                            resultado = "OK";
                        }
                    }
                }
                return resultado == "OK" ? 1 : 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // INSERTAR, ACTUALIZAR Y ELIMINAR FACTURA DETALLE
        public int FacturaProductoCRUD(int Accion, int FacturaID, ProductosFactura FacProducto)
        {
            try
            {
                string resultado = "";
                var Fecha = ConsultasSql.ObtenerFechaServer();
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    //INSERTAR / ACTUALIZAR
                    if (Accion == 1)
                    {
                        resultado = db.usp_wai_Factura_Detalle_CRUD(Environment.UserName, "C", FacProducto.facd_id, FacturaID,
                                                          FacProducto.facd_item_id, FacProducto.facd_cantidad, FacProducto.facd_peso, FacProducto.facd_lote,
                                                          FacProducto.facd_prioridad, Fecha, 0).First();
                    }
                    //ELIMINAR
                    else if (Accion == 2)
                    {
                        resultado = db.usp_wai_Factura_Detalle_CRUD(Environment.UserName, "D", FacProducto.facd_id, FacturaID,
                                                         FacProducto.facd_item_id, FacProducto.facd_cantidad, FacProducto.facd_peso, FacProducto.facd_lote,
                                                         FacProducto.facd_prioridad, Fecha, 0).First();
                    }
                }
                return resultado == "OK" ? 1 : 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Estampa> ObtenerEstampaImpresion(int opcion, int DetalleFacID = 0, string PackListID = "")
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "";
                    if (opcion == 1)
                    {
                        consulta = " SELECT                                                                     " +
                                   "  PL.pac_id,                                                                " +
                                   "	PL.pac_impreso,                                                         " +
                                   "	PO.pos_numero,                                                          " +
                                   "	F.fac_numero,                                                           " +
                                   "	I.ite_codigo,                                                           " +
                                   "	I.ite_descripcion,                                                      " +
                                   "	P.pro_nombre,                                                           " +
                                   "	PL.pac_libras,                                                          " +
                                   "	FD.facd_lote,                                                           " +
                                   "	PL.pac_prov_pack_id,                                                    " +
                                   " ISNULL(PL.pac_localidad_id,0) AS Localidad,                                " +
                                   "	PO.pos_semana,                                                          " +
                                   "	B.bod_descripcion,                                                      " +
                                   "	GETDATE() AS FECHA,                                                     " +
                                   "UPPER(f.fac_medida) AS Medida                                               " +
                                   "FROM wai_Pack_List PL                                                       " +
                                   "INNER JOIN wai_Factura_Detalle FD ON FD.facd_id= PL.pac_factura_detalle_id  " +
                                   "INNER JOIN wai_Factura F ON F.fac_id = FD.facd_fac_id                       " +
                                   "INNER JOIN wai_Item I ON I.ite_id = FD.facd_item_id                         " +
                                   "INNER JOIN wai_POS PO ON PO.pos_id = F.fac_pos_id                           " +
                                   "INNER JOIN wai_Proveedor P ON P.pro_id = PO.pos_proveedor_id                " +
                                   "INNER JOIN wai_Bodegas B ON B.bod_id = I.ite_bodega_id                      " +
                                   "WHERE PL.pac_factura_detalle_id=" + DetalleFacID;
                    }
                    else if (opcion == 2)
                    {

                        consulta = " SELECT                                                                      " +
                                  "                                                                             " +
                                  "     PL.pac_id,                                                              " +
                                  " 	PO.pos_numero,                                                          " +
                                  " 	F.fac_numero,                                                           " +
                                  " 	I.ite_codigo,                                                           " +
                                  " 	I.ite_descripcion,                                                      " +
                                  " 	P.pro_nombre,                                                           " +
                                  " 	PL.pac_libras - ISNULL(PL.pac_libras_salida,0) as pac_libras,           " +
                                  " 	FD.facd_lote,                                                           " +
                                  " 	PL.pac_prov_pack_id,                                                    " +
                                  " 	ISNULL(PL.pac_localidad_id,0) AS Localidad,                             " +
                                  " 	PO.pos_semana,                                                          " +
                                  " 	B.bod_descripcion,                                                      " +
                                  " 	GETDATE() AS FECHA,                                                     " +
                                  " UPPER(f.fac_medida) AS Medida                                               " +
                                  " FROM wai_Pack_List PL                                                       " +
                                  " INNER JOIN wai_Factura_Detalle FD ON FD.facd_id= PL.pac_factura_detalle_id  " +
                                  " INNER JOIN wai_Factura F ON F.fac_id = FD.facd_fac_id                       " +
                                  " INNER JOIN wai_Item I ON I.ite_id = FD.facd_item_id                         " +
                                  " INNER JOIN wai_POS PO ON PO.pos_id = F.fac_pos_id                           " +
                                  " INNER JOIN wai_Proveedor P ON P.pro_id = PO.pos_proveedor_id                " +
                                  " INNER JOIN wai_Bodegas B ON B.bod_id = I.ite_bodega_id                      " +
                                  " WHERE CONVERT(VARCHAR,PL.pac_id)='" + PackListID + "'";

                    }
                    var resultado = db.Database.SqlQuery<Estampa>(consulta).ToList();
                    return resultado;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EstampaProv> ObtenerEstampaProv(string PackListID)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT                                                                     " +
                                  "                                                                             " +
                                  "     PL.pac_prov_pack_id,                                                    " +
                                  " 	PO.pos_numero,                                                          " +
                                  " 	F.fac_numero,                                                           " +
                                  " 	I.ite_codigo,                                                           " +
                                  " 	I.ite_descripcion,                                                      " +
                                  " 	P.pro_nombre,                                                           " +
                                  " 	PL.pac_libras - ISNULL(PL.pac_libras_salida,0) as pac_libras,           " +
                                  " 	FD.facd_lote,                                                           " +
                                  " 	PL.pac_id,                                                              " +
                                  " 	ISNULL(PL.pac_localidad_id,0) AS Localidad,                             " +
                                  " 	PO.pos_semana,                                                          " +
                                  " 	B.bod_descripcion,                                                      " +
                                  " 	GETDATE() AS FECHA,                                                     " +
                                  " UPPER(f.fac_medida) AS Medida                                               " +
                                  " FROM wai_Pack_List PL                                                       " +
                                  " INNER JOIN wai_Factura_Detalle FD ON FD.facd_id= PL.pac_factura_detalle_id  " +
                                  " INNER JOIN wai_Factura F ON F.fac_id = FD.facd_fac_id                       " +
                                  " INNER JOIN wai_Item I ON I.ite_id = FD.facd_item_id                         " +
                                  " INNER JOIN wai_POS PO ON PO.pos_id = F.fac_pos_id                           " +
                                  " INNER JOIN wai_Proveedor P ON P.pro_id = PO.pos_proveedor_id                " +
                                  " INNER JOIN wai_Bodegas B ON B.bod_id = I.ite_bodega_id                      " +
                                  " WHERE CONVERT(VARCHAR,PL.pac_id)='" + PackListID + "'";

                    var resultado = db.Database.SqlQuery<EstampaProv>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la estampa del proveedor: " + ex.Message, ex);
            }
        }

    }
}
