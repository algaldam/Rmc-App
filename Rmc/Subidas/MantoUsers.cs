using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Subidas
{
    public partial class MantoUsers : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        public MantoUsers()
        {
            InitializeComponent();
        }
        public void llenarGrid()
        {
            string SQL = @"SELECT
                           R.requester_id AS Codigo,
                           R.requester_carnet AS CodigoFull,
                           CONCAT(M.Emp_Nombres COLLATE DATABASE_DEFAULT , ' ', M.Emp_Apellidos COLLATE DATABASE_DEFAULT ) AS Nombre,
                           m.Emp_Turno as Turno,
                           R.requester_user_mod AS ModificadoPor,
                           R.requester_fecha_mod AS Fecha,
                           COALESCE(R.requester_request, '') AS Solicitante
                           FROM
                           [pmc_Requester] AS R
                           INNER JOIN
                           ES_SOCKS.dbo.mst_Empleados AS M ON R.requester_id = M.Emp_ID";
            try
            {
                sc.OpenConectionTracer();
                sc.LlenarGridUser(this.rgvReq, SQL, "requester", "requester");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during llenarGrid execution: " + ex.Message);
            }
            finally
            {
                sc.CloseConectionTracer();
            }
        }
        private void Mantenimiento_de_solicitante_Load(object sender, EventArgs e)
        {
            
            llenarGrid();

            sc.OpenConectionTracer();
            sc.PermisosBotoneria(this.btnNuevotxtReq,this.btnActualizar, this.btnEliminar, sc.Usuario, sc.AppID, "BtnUsuarios", 'I');
            sc.CloseConectionTracer();
            this.btnNuevotxtReq.Enabled = true;
            this.txtReq.Clear();
            this.txtReq.Enabled = false;
            this.btnGuardartxtReq.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnActualizar.Enabled = false;
            this.chkSol.Checked = false;
            this.chkSol.Enabled = false;
        }
        public string codigoLimpio(string codigoSucio)
        {
            string codigoLimpio = string.Empty;
            for (int i = 0; i < codigoSucio.Length; i++)
            {
                if (Char.IsDigit(codigoSucio[i]))
                    codigoLimpio += codigoSucio[i];
            }
            return codigoLimpio;
        }

        private void btnGuardartxtReq_Click(object sender, EventArgs e)
        {
            if (this.txtReq.TextLength < 17)
            {
                MessageBox.Show("Carné no valido");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtReq.Text))
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }

            string oldValue;
            //si el grid esta vacion vamos a llenar la varible del oldValue con nulos
            if (this.rgvReq.RowCount == 0)
            {
                oldValue = "";
            }
            else
            {
                oldValue = Convert.ToString(this.rgvReq.CurrentRow.Cells[0].Value ?? null);
            }
            String strMensaje;
            try
            {
                sc.OpenConectionTracer();

                SqlParameter[] parametros =
                {
                    new SqlParameter ("@CodigoCompleto",SqlDbType.VarChar){Value= codigoLimpio(this.txtReq.Text)},
                    new SqlParameter ("@userMod",SqlDbType.VarChar){Value=Environment.UserName},
                    new SqlParameter ("@oldCode",SqlDbType.VarChar){Value=oldValue},
                    new SqlParameter ("@accion",SqlDbType.VarChar){Value="I"},
                    new SqlParameter ("@request",SqlDbType.Bit){Value=this.chkSol.Checked}

                };

                strMensaje = sc.InsertDataWithParam("Exec usp_Requester_CRUD @CodigoCompleto,@userMod,@oldCode,@accion,@request", parametros);
                if (strMensaje == "OK")
                {
                    MessageBox.Show("Registro guardado correctamente");
                    sc.CloseConectionTracer();
                    txtReq.Clear();

                    LblNombreCompleto.Text = "";
                    llenarGrid();

                    sc.OpenConectionTracer();
                    sc.PermisosBotoneria(this.btnGuardartxtReq, this.btnActualizar, this.btnEliminar, sc.Usuario, sc.AppID, "BtnUsuarios", 'U');
                    sc.CloseConectionTracer();

                    //vamos a desactivar todos los botones, menos nuevo, si es que tiene permisos....
                    btnGuardartxtReq.Enabled = false;
                    btnEliminar.Enabled = false;
                    txtReq.Enabled = false;
                }
                else if (strMensaje == "REPETIDO")
                {
                    MessageBox.Show("Registro no guardad, El id ya se encuentra en la base de datos");
                    sc.CloseConectionTracer();
                }
                else if (strMensaje == "INACTIVO")
                {
                    MessageBox.Show("Registro no guardado, empleado inactivo.");
                    sc.CloseConectionTracer();
                }
                else

                {
                    MessageBox.Show("Registro no guardado");
                    sc.CloseConectionTracer();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la transacción" + ex);
                sc.CloseConectionTracer();
            }
        }
        public string DevCodigoNumerico(string codigo)
        {
            string nuevoCodigo = "";
            for (int i = 0; i < codigo.Length; i++)
            {
                if (sc.IsNumeric(codigo.Substring(i, 1)))
                {
                    nuevoCodigo = nuevoCodigo + codigo.Substring(i, 1);
                }
            }
            return nuevoCodigo;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtReq.Text))
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }
            if (this.txtReq.TextLength < 13)
            {
                MessageBox.Show("Carné no valido");
                return;
            }
            string oldValue;
            //si el grid esta vacion vamos a llenar la varible del oldValue con nulos
            if (this.rgvReq.RowCount == 0)
            {
                oldValue = "";
            }
            else
            {
                oldValue = Convert.ToString(this.rgvReq.CurrentRow.Cells[0].Value ?? null);
            }
            String strMensaje;
            try
            {
                sc.OpenConectionTracer();

                SqlParameter[] parametros =
                {
                    new SqlParameter ("@CodigoCompleto",SqlDbType.VarChar){Value=this.txtReq.Text},
                    new SqlParameter ("@userMod",SqlDbType.VarChar){Value=Environment.UserName},
                    new SqlParameter ("@oldCode",SqlDbType.VarChar){Value=oldValue},
                    new SqlParameter ("@accion",SqlDbType.VarChar){Value="A"},
                    new SqlParameter ("@request",SqlDbType.Bit){Value=this.chkSol.Checked}

                };
                strMensaje = sc.InsertDataWithParam("Exec usp_Requester_CRUD @CodigoCompleto,@userMod,@oldCode,@accion,@request", parametros);
                if (strMensaje == "OK")
                {
                    MessageBox.Show("Registro actualizado correctamente");
                    sc.CloseConectionTracer();
                    this.txtReq.Clear();

                    llenarGrid();

                    sc.OpenConectionTracer();
                    sc.PermisosBotoneria(this.btnNuevotxtReq, this.btnActualizar, this.btnEliminar, sc.Usuario, sc.AppID, "BtnUsuarios", 'U');
                    sc.CloseConectionTracer();

                    //desactivarylimpiar();
                    //vamos a desactivar todos los botones, menos nuevo, si es que tiene permisos.... 
                    this.btnGuardartxtReq.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnActualizar.Enabled = false;
                    this.txtReq.Enabled = false;
                    this.chkSol.Checked = false;
                    this.chkSol.Enabled = false;
                    this.LblNombreCompleto.Text = "";

                }
                else if (strMensaje == "REPETIDO")
                {
                    MessageBox.Show("Registro no actUalizado, El id ya se encuentra en la base de datos");
                    sc.CloseConectionTracer();
                }
                else if (strMensaje == "INACTIVO")
                {
                    MessageBox.Show("Registro no actualizado, empleado inactivo.");
                    sc.CloseConectionTracer();
                }
                else
                {
                    MessageBox.Show("Registro no actualizado");
                    sc.CloseConectionTracer();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la transacción" + ex);
                sc.CloseConectionTracer();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            llenarGrid();


            sc.OpenConectionTracer();
            sc.PermisosBotoneria(this.btnNuevotxtReq, this.btnActualizar, this.btnEliminar, sc.Usuario, sc.AppID, "BtnUsuarios", 'U');
            sc.CloseConectionTracer();

            this.txtReq.Clear();
            this.txtReq.Enabled = false;
            this.btnGuardartxtReq.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnActualizar.Enabled = false;
            this.txtReq.Enabled = false;
            this.txtReq.Clear();
            this.chkSol.Checked = false;
            this.chkSol.Enabled = false;
            this.LblNombreCompleto.Text = "";
            this.btnNuevotxtReq.Enabled = true;
        }

        private void btnNuevotxtReq_Click(object sender, EventArgs e)
        {
            this.txtReq.Enabled = false;
            this.txtReq.Clear();
            this.btnActualizar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnNuevotxtReq.Enabled = true;
            this.btnGuardartxtReq.Enabled = true;

            this.txtReq.Clear();
            this.txtReq.Enabled = true;
            this.txtReq.Focus();
            this.chkSol.Enabled = true;
            this.LblNombreCompleto.Text = "";
        }

        private void rgvReq_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (this.rgvReq.CurrentRow != null)
            {
                this.txtReq.Text = this.rgvReq.CurrentRow.Cells["CodigoFull"].Value.ToString();
                this.chkSol.Checked = Convert.ToBoolean(this.rgvReq.CurrentRow.Cells["Solicitante"].Value);
            }
            sc.OpenConectionTracer();
            sc.PermisosBotoneria(this.btnNuevotxtReq, this.btnActualizar, this.btnEliminar, sc.Usuario, sc.AppID, "BtnUsuarios", 'U');
            sc.CloseConectionTracer();

            this.txtReq.Enabled = true;
            this.btnNuevotxtReq.Enabled = false;
            this.btnGuardartxtReq.Enabled = false;
            this.chkSol.Enabled = true;
        }

        private void txtReq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtReq.TextLength >= 17)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // Obtenemos la posición de la 'ñ' y el siguiente guion bajo '_'
                    int posInicial = this.txtReq.Text.IndexOf('ñ') + 1; // +1 para movernos después de la 'ñ'
                    int posFinal = this.txtReq.Text.IndexOf('_', posInicial);
                    if (posInicial > 0 && posFinal > posInicial)
                    {
                        // Extraemos la subcadena
                        string subcadena = this.txtReq.Text.Substring(posInicial, posFinal - posInicial);

                        string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                        //vamos a traernos a pantalla el nombre 
                        sc.OpenConectionTracer();
                        LblNombreCompleto.Text = sc.DevValor("SELECT Emp_Nombres + ' ' + Emp_Apellidos AS nombre FROM [ES_SOCKS].[dbo].[mst_Empleados] where  Emp_ID = " + numeros);
                        sc.CloseConectionTracer();
                    }
                }
            }
        }
    }
}
