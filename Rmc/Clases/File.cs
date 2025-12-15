using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Pmc.Clases
{
    class File
    
    {
        //ruta del archivo
        String path;
        //datatable
        DataTable dt = new DataTable();

        //contructor
        public File(String p)
        {
            path = p;

            //al instanciar la clase, directamente evalua que tipo de archivo es y ejecuta 
            //la respectiva funcion para obtener sus registros
            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    //si es archivo de excel
                    if (Path.GetExtension(path) == ".xls" || Path.GetExtension(path) == ".xlsx")
                    {
                        dt = GetDataTableXLS(path, GetExcelSheetNames(path)[0]);
                    }
                    //si es archivo separado por coma CSV
                    else if (Path.GetExtension(path) == ".csv")
                    {
                        dt = GetDataTableCSV(path);
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al leer la información que contiene el archivo.\n\nEl formato no es el correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //funcion que retorna el conjunto de datos contenidos en un archivo de excel
        private DataTable GetDataTableXLS(String path, String hoja)
        {
            DataTable dtXLS = new DataTable();
            OleDbConnection con = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");
            String query = "Select * from [" + hoja + "]";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(hoja))
            {
                System.Windows.MessageBox.Show("No hay una hoja para leer", "ERROR", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    da.Fill(ds, hoja);
                    con.Close();
                    dt = ds.Tables[0];

                    dtXLS = dt;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", "ERROR", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }

            return dtXLS;
        }

        private String[] GetExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = new OleDbConnection();
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                String connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                  "Data Source=" + excelFile + ";Extended Properties=Excel 12.0;";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }


                return excelSheets;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        //--- MODIFICAR

        //funcion que retorna los registros de un archivo separado por coma
        private DataTable GetDataTableCSV(String path)
        {
            DataTable dtCSV = new DataTable();

            try
            {
                StreamReader str = new StreamReader(path);
                List<String> lineas = new List<String>();
                String r;

                while ((r = str.ReadLine()) != null)
                {
                    lineas.Add(r);
                }

                char[] ch = new char[] { ',' };

                dtCSV.Columns.Add("Style");
                dtCSV.Columns.Add("Qty");

                int indexLinea = 0;
                foreach (String s in lineas)
                {
                    if (indexLinea > 0)
                    {
                        String[] linea = s.Split(ch);
                        DataRow row = dtCSV.NewRow();
                        for (int i = 0; i < linea.Length; i++)
                        {
                            row[i] = linea[i];
                        }

                        dtCSV.Rows.Add(row);
                    }
                    indexLinea++;
                }


            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error al intentar obtener los registro del documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtCSV;
        }

        //funcion que retorna el datatable obtenido por cualquiera de las funciones
        public DataTable GetDataTable()
        {
            return dt;
        }

    }
}
