using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;
// CREADO POR DAVID AYALA
namespace Rmc.MaterialEmpaque
{
    public partial class MaterialDeBodega : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        public MaterialDeBodega()
        {
            InitializeComponent();
			LlenarDatosSLSCEN();
            rgbCredenciales.Visible = true;
            //GridInventarioBodega.CellFormatting += GridInventarioBodega_CellFormatting;
        }
        string pwdAS400;
        string usuarioAS400;

        private bool ValidarCredenciales(string usuario, string contraseña)
        {
            string strCnn = "DSN=SLSCEN;UID=" + usuario + ";PWD=" + contraseña + ";";
            try
            {
                using (OdbcConnection connection = new OdbcConnection(strCnn))
                {
                    connection.Open();
                    return true; // Las credenciales son válidas y la conexión se realizó con éxito
                }
            }
            catch (Exception ex)
            {
                // Si hay alguna excepción, las credenciales no son válidas o hubo un error de conexión
                return false;
            }
        }
        private void LlenarDatosSLSCEN()
        {
            radButton1.Enabled = false;
            BtnImprimir.Enabled = false;
            // Verifica si el usuario o la contraseña están vacíos
            if (string.IsNullOrEmpty(usuarioAS400) || string.IsNullOrWhiteSpace(pwdAS400))
            {
                //MessageBox.Show("Por favor ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                mtxtPwd.Text = "";
                return;
            }
            // Validar las credenciales antes de continuar
            if (!ValidarCredenciales(usuarioAS400, pwdAS400))
            {
                // Las credenciales no son válidas, muestra un mensaje de error o toma alguna acción
                // Por ejemplo:
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                mtxtPwd.Clear();
                rgbCredenciales.Visible = true;
                return;
            }
            label1.Text         = "0";
            string strCnn       = "DSN=SLSCEN;UID=" + usuarioAS400 + ";PWD=" + pwdAS400 + ";";
            OdbcConnection s    = new OdbcConnection(strCnn);
            DataTable dtSource  = new DataTable();
           
            //Crea las columnas del RadGridView
            GridInventarioBodega.Columns.Clear();
            label1.Text = null;
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTWH", HeaderText                   = "LOCALIDAD" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTPART", HeaderText                 = "ITEM" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTLOT#", HeaderText                 = "NUM. LOTE" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTPRS", HeaderText                  = "LTPRS" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTDZPR", HeaderText                 = "LTDZPR" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTQTY", HeaderText                  = "CANTIDAD" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTMFST", HeaderText                 = "MANIFIESTO" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTORD", HeaderText                  = "ORDEN" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTSTAT", HeaderText                 = "ESTATUS" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "LTRUSR", HeaderText                 = "USUARIO" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "RECIBIDO", HeaderText               = "FECHA DE RECIBIDO" });
            GridInventarioBodega.Columns.Add(new GridViewTextBoxColumn() { FieldName = "PERMANENCIA_EN_BODEGA", HeaderText  = "ANTIGÜEDAD EN BODEGA" });

            string Query = @"    
                SELECT 
                    LTLOC# AS LTWH,
                    LTPART,
                    LTLOT#,
                    LTPRS,
                    LTDZPR,
                    LTQTY,
                    LTMFST,
                    LTORD,
                    LTSTAT,
                    LTRUSR,
                    DATE( LEFT( LTRCVD, 4 ) || '-' || SUBSTRING( LTRCVD, 5, 2 ) || '-' || RIGHT( LTRCVD, 2 ) ) AS RECIBIDO,
	                DAYS( CURDATE( ) ) - DAYS( DATE( LEFT( LTRCVD, 4 ) || '-' || SUBSTRING( LTRCVD, 5, 2 ) || '-' || RIGHT( LTRCVD, 2 ) ) ) AS PERMANENCIA_EN_BODEGA
                FROM
                    SLSCEN.OSSPRDDTA.LTMSTP00 LTMSTP00
                WHERE
                    LTLOC# NOT IN( 'WIP', 'RECID', 'CYCLE', '' )
                AND LTSTAT<> 'X'
                ORDER BY 11";
             s.Open();
            OdbcDataAdapter D               = new OdbcDataAdapter(Query,s);
            D.Fill(dtSource);
            BindingSource bs                = new BindingSource();
            bs.DataSource                   = dtSource;
            GridInventarioBodega.DataSource = bs;
            label1.Text                     = GridInventarioBodega.Rows.Count.ToString();
            radButton1.Enabled              = true;
            BtnImprimir.Enabled             = true;
            s.Close();
        }
      
        private void radButton1_Click(object sender, EventArgs e)
        {
            LlenarDatosSLSCEN();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            sc.ExportarGrid(this.GridInventarioBodega);
        }

        private void btnAceptarSLSCEN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(mtxtPwd.Text))
            {
                MessageBox.Show("Ingrese los datos requeridos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarioAS400            = txtUsuario.Text.Trim();
            pwdAS400                = mtxtPwd.Text.Trim();
            rgbCredenciales.Visible = false;
            LlenarDatosSLSCEN();
        }

        private void btnSalirContasenia_Click(object sender, EventArgs e)
        {
            rgbCredenciales.Visible = false;
        }
    }
}
