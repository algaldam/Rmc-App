using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Rmc.Clases;
using System.Linq;
using Rmc.Clases.dsPMCTableAdapters;

namespace Rmc.Subidas
{
    public partial class frmMtnSemanas : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        bool flag = false;
        dsPMC ds = new dsPMC();
        List<pmc_Semanas> DataSemana = new List<pmc_Semanas>();
        pmc_SemanasTableAdapter TA_SEM = new pmc_SemanasTableAdapter();
        DataTable DATOS = new DataTable();
        public frmMtnSemanas()
        {
            InitializeComponent();
            Lbl_ID.SendToBack();
            BtnEliminar.RootElement.ToolTipText = "Presione F6 para Eliminar";
            BtnGuardar.RootElement.ToolTipText = "Presione F4 para Guardar";
            BtnNuevo.RootElement.ToolTipText = "Presione F1 para Crear registro";
            BtnCancelar.RootElement.ToolTipText = "Presione End para Cancelar";
        }
        #endregion


        #region DATOS
        private void CargarDatos()
        {
            try
            {
                TA_SEM.Fill(ds.pmc_Semanas);
                DATOS = (DataTable)ds.Tables["pmc_Semanas"];
                
               
                GridViewSemanas.DataSource = DATOS ;
                Unbinding();
                Binding();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void Unbinding()
        {
            try
            {
                TxtAnio.DataBindings.Clear();
                TxtSemana.DataBindings.Clear();
                Lbl_ID.DataBindings.Clear();
                ChkEstado.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void Binding()
        {
            try
            {
                TxtAnio.DataBindings.Add("Text", DATOS, "ANIO",false, DataSourceUpdateMode.Never);
                TxtSemana.DataBindings.Add("Text", DATOS, "SEMANA", false, DataSourceUpdateMode.Never);
                ChkEstado.DataBindings.Add("IsChecked", DATOS, "sem_estado", false, DataSourceUpdateMode.Never);
                Lbl_ID.DataBindings.Add("Text", DATOS, "sem_ID", false, DataSourceUpdateMode.Never);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region EVENTOS
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.F6)
                {
                    BtnGuardar.Focus();
                    BtnEliminar.PerformClick();

                }
                else if (keyData == Keys.F4)
                {
                    BtnGuardar.PerformClick();
                }
                else if (keyData == Keys.F1)
                {
                    BtnNuevo.PerformClick();
                }
                else if (keyData == Keys.End)
                {
                    BtnCancelar.PerformClick();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                TxtSemana.Text = "00";
                TxtAnio.Text = "0000";
                TxtAnio.Enabled = true;
                TxtSemana.Enabled = true;
                ChkEstado.Enabled = false;
                ChkEstado.Checked = true;
                TxtAnio.Focus();
                flag = true;
                BtnEliminar.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAnio.Text.Trim() == "0000" || TxtAnio.Text.Trim() == "")
                {
                    TxtAnio.BackColor = Color.MistyRose;
                }
                else if (TxtSemana.Text.Trim() == "00" || TxtSemana.Text.Trim() == "")
                {

                    TxtSemana.BackColor = Color.MistyRose;
                }
                else
                {
                    if (flag == true)
                    {
                        using (dcPmcDataContext db = new dcPmcDataContext())
                        {
                            pmc_Semanas semana = new pmc_Semanas
                            {
                                sem_ID = TxtAnio.Text.Trim() + "-" + TxtSemana.Text.Trim(),
                                sem_estado = true,
                                sem_usuario_crea = Environment.UserName,
                                sem_FH_crea = DateTime.Now
                            };
                            db.pmc_Semanas.InsertOnSubmit(semana);
                            db.SubmitChanges();
                        }
                        flag = false;
                        CargarDatos();
                    }
                    else
                    {
                        using (dcPmcDataContext dba = new dcPmcDataContext())
                        {
                            var registro = (from x in dba.pmc_Semanas
                                            where x.sem_ID == Lbl_ID.Text.Trim()
                                            select x).FirstOrDefault();

                            registro.sem_estado = ChkEstado.IsChecked;
                            dba.SubmitChanges();
                        }
                        int fila = GridViewSemanas.Rows.IndexOf(this.GridViewSemanas.CurrentRow);
                        CargarDatos();

                        GridViewSemanas.Rows[fila].IsSelected = true;
                        GridViewSemanas.Rows[fila].IsCurrent = true;

                    }
                   
                    BtnEliminar.Enabled = true;
                    ChkEstado.Enabled = true;
                    POP_ALERT.CaptionText = "Exito";
                    POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                    POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                    POP_ALERT.ThemeName = "Windows8";
                    POP_ALERT.ContentText = "Proceso Correcto...";
                    POP_ALERT.Show();
                } 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmMtnSemanas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TxtAnio.BackColor = Color.White;
                 if (e.KeyChar == (char)13)
                    {
                       TxtSemana.Focus ();
                    }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿ Realmente desea Eliminar Semana?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (dcPmcDataContext dbe = new dcPmcDataContext())
                    {
                        var registro = (from x in dbe.pmc_Semanas
                                        where x.sem_ID == Lbl_ID.Text.Trim()
                                        select x).FirstOrDefault();

                        dbe.pmc_Semanas.DeleteOnSubmit(registro );
                        dbe.SubmitChanges();
                    }

                    CargarDatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtSemana.BackColor = Color.White;
        }

        private void GridViewSemanas_Click(object sender, EventArgs e)
        {
            TxtSemana.BackColor = Color.White;
            TxtAnio.BackColor = Color.White;
            BtnEliminar.Enabled = true;
            ChkEstado.Enabled = true;
            TxtAnio.Enabled = false;
            TxtSemana.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                 int fila = GridViewSemanas.Rows.IndexOf(this.GridViewSemanas.CurrentRow);
                    CargarDatos();

                    GridViewSemanas.Rows[fila].IsSelected = true;
                    GridViewSemanas.Rows[fila].IsCurrent = true;
                    BtnEliminar.Enabled = true;
                    TxtAnio.Enabled = false;
                    TxtSemana.Enabled = false;
                    ChkEstado.Enabled = true;
            }
            catch (Exception ex)
            {
                
                MessageBox .Show (ex.Message );
            }
        }

        #endregion

    }
}
