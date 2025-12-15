using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
namespace Rmc.Consultas
{
    public partial class frmListSobrantes : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana = new SemanasTableAdapter();
        ListadoSobrantesTableAdapter TaSemana = new ListadoSobrantesTableAdapter();
        public frmListSobrantes()
        {
            InitializeComponent();
            ((GridTableElement)this.GridViewSobrantes.TableElement).AlternatingRowColor = Color.WhiteSmoke;
        }
        #endregion

        #region EVENTOS
        private void frmListSobrantes_Load(object sender, EventArgs e)
        {
            try
            {
                //GridViewExportar.SendToBack();
                anio.Fill(ds.Anios);
                cbxAnio.DataSource = ds.Tables["Anios"];


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                semana.Fill(ds.Semanas, cbxAnio.Text.Trim());
                CbxSemana.DataSource = (DataTable)ds.Tables["Semanas"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxSemana_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                try
                {
                
                    TaSemana.Fill(ds.ListadoSobrantes, CbxSemana.Text.Trim());
                    var datos = (DataTable)ds.Tables["ListadoSobrantes"];
                    GridViewSobrantes.DataSource = datos;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show (ex.Message );
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
   
#endregion
    }
}
