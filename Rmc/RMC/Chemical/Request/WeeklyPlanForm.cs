using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Chemical.Request
{
    public partial class WeeklyPlanForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        string sql1;
        string sql;
        bool flagEstado = false;
        public WeeklyPlanForm()
        {
            InitializeComponent();
            GridViewPlan.Rows.AddNew();
        }

        #endregion

        #region METODOS
        private bool ValidarData()
        {
            try
            {
                if (GridViewPlan.RowCount > 0)
                {
                    DataTable dt = new DataTable();
                    DataTable dtErrores = new DataTable();

                    string sqlDelete = "";
                    dt.Columns.Add("pla_semana", typeof(string));
                    dt.Columns.Add("pla_item", typeof(string));
                    dt.Columns.Add("pla_UOM", typeof(string));

                    for (int r = 0; r < this.GridViewPlan.RowCount; r++)
                    {

                        dt.Rows.Add(CbxSemana.Text.Trim(), GridViewPlan.Rows[r].Cells["pla_item"].Value.ToString().Trim(), GridViewPlan.Rows[r].Cells["pla_UOM"].Value.ToString().Trim());

                    }
                    sc.OpenConection();

                    sqlDelete = "DELETE FROM Wainari_stg_plan";
                    sc.EjecutarQuery(sqlDelete);

                    sc.InsertSqlBulkCopy(dt, "Wainari_stg_plan");

                    sql1 = " SELECT * FROM (SELECT stg.pla_semana,stg.pla_item,UPPER(stg.pla_UOM) as pla_UOM ,'ENTRAN' AS ESTADO, 3 AS ORDEN FROM Wainari_stg_plan stg left join" +
                           " ES_SOCKS..wai_Plan pl on stg.pla_semana=pl.pla_semana and stg.pla_item =pl.pla_item" +
                           " WHERE pl.pla_usuario is null" +
                           " UNION  ALL" +
                           " SELECT pl.pla_semana,pl.pla_item,pl.pla_UOM,'SALEN' AS ESTADO ,2 AS ORDEN FROM Wainari_stg_plan stg right join" +
                           " ES_SOCKS..wai_Plan pl on stg.pla_semana=pl.pla_semana and stg.pla_item =pl.pla_item" +
                           " WHERE stg.pla_UOM is null" +
                           " UNION  ALL" +
                           " SELECT sol_semana,sol_item,sol_UOM,'ERROR' AS ESTADO, 1 AS ORDEN FROM Wainari_stg_plan stg right join" +
                           " ES_SOCKS..wai_Solicitudes pl on stg.pla_semana=pl.sol_semana and stg.pla_item =pl.sol_item" +
                           " WHERE stg.pla_UOM is null) DATOS" +
                           " WHERE  DATOS.pla_semana='" + CbxSemana.Text.Trim() + "'" +
                           " ORDER BY ORDEN ASC";

                    dtErrores = sc.DevDataTable2(sql1);

                    sc.CloseConection();
                    GridViewPlan.DataSource = dtErrores;

                    foreach (DataRow row in dtErrores.Rows)
                    {
                        if (row["ESTADO"].ToString().Equals("ERROR"))
                        {
                            flagEstado = true;

                            break;
                        }
                        else
                        {
                            flagEstado = false;
                        }
                    }
                }

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                flagEstado = true;
                MessageBox.Show("Existen valores duplicados" + sqlEx.Message);
            }
            catch (Exception ex)
            {
                flagEstado = true;
                MessageBox.Show(ex.Message);
            }
            return flagEstado;
        }
        #endregion

        #region EVENTOS
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewPlan.DataSource = null;
                this.GridViewPlan.Rows.Clear();
                GridViewPlan.Rows.AddNew();
                CbxSemana.Items[0].Value.ToString();
                CbxSemana.BackColor = Color.White;
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                labelgw.Visible = false;
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
                BtnGuardar.Enabled = false;
                if (CbxSemana.Text.Trim() == "" || CbxSemana.Text.Trim() == "0000-00")
                {
                    CbxSemana.BackColor = Color.MistyRose;
                }
                else if (GridViewPlan.Rows[0].Cells["pla_item"].Value == null || GridViewPlan.Rows[0].Cells["pla_UOM"].Value == null)
                {
                    BtnGuardar.Enabled = true;
                    labelgw.Visible = true;
                }
                else
                {
                    if (ValidarData() == true)
                    {
                        LblError.Visible = true;

                    }
                    else
                    {
                        sql = "EXEC usp_Wainari_subida_plan";
                        sc.OpenConection();

                        sc.EjecutarQuery(sql);
                        sc.CloseConection();
                        GridViewPlan.DataSource = null;
                        this.GridViewPlan.Rows.Clear();
                        GridViewPlan.Rows.AddNew();
                        CbxSemana.Text = "0000-00";
                        BtnGuardar.Enabled = true;
                        MessageBox.Show("\n Proceso Realizado \n con Exito \n", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {

                RadMessageBox.Show("\n" + ex.Message);
            }
        }

        private void GridViewPlan_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Index == -1)
            {
                return;
            }
            else
            {
                try
                {
                    if (GridViewPlan.RowCount > 1)
                    {
                        if (e.RowElement.RowInfo.Cells["ESTADO"].Value != null)
                        {
                            if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("ERROR"))
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.Red;
                            }
                            else if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("SALEN"))
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.Gold;
                            }
                            else if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("ENTRAN"))
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FrmPedidoPlan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tracerDataSet.WeekPlan' table. You can move, or remove it, as needed.
            try
            {
                // Llenar el DataSet con los datos de la tabla WeekPlan
                this.weekPlanTableAdapter1.Fill(this.tracerDataSet1.WeekPlan);

                // Asignar el DataSource del ComboBox
                CbxSemana.DataSource = tracerDataSet1.WeekPlan;
                CbxSemana.DisplayMember = "WeekID"; // la columna que quieres mostrar
                CbxSemana.ValueMember = "WeekID";   // el valor del ComboBox (puede ser la misma columna)
                CbxSemana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxSemana_Click(object sender, EventArgs e)
        {
            CbxSemana.BackColor = Color.White;
        }
        #endregion
    }
}
