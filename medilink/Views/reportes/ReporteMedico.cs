using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using medilink.Models;
using medilink.ViewModels;
using medilink.Views;
using medilink.BD;
using static medilink.BD.Crud;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace medilink.Views.reportes
{
    public partial class ReporteMedico : Form
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;

        public ReporteMedico(UsuarioM usuarioLogueado)
        {
            InitializeComponent(); 
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
            toolTip4.SetToolTip(PBAyuda, "Seleccione el estado de las citas que desea ver, luego indique el rango de fechas.");

        }

        //cargamos cb
        private void ReporteMedico_Load(object sender, EventArgs e)
        {
            CBEstado.Items.Add("Todas");
            CBEstado.Items.Add("Activas");
            CBEstado.Items.Add("Canceladas");
            CBEstado.SelectedIndex = 0; 
        }

        //botones
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            CBEstado.SelectedIndex = -1;
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
            chartCitas.Series.Clear();
        }

        private void BExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.bmp|PDF Files|*.pdf|Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    if (saveFileDialog.FileName.EndsWith(".png") || saveFileDialog.FileName.EndsWith(".jpg") || saveFileDialog.FileName.EndsWith(".bmp"))
                    {
                        chartCitas.SaveImage(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    
                }
            }
        }

        private void BGenerar_Click(object sender, EventArgs e)
        {
            string estado = CBEstado.SelectedItem?.ToString();
            if (estado == "Todas") estado = "";


            DateTime fechaInicio = DTPInicio.Value;
            DateTime fechaFin = DTPFin.Value;

            if (usuarioLogueado.id_medico.HasValue)
            {
                var citas = usuarioVM.ListarCitasPorEstadoYFecha(usuarioLogueado.id_medico.Value, estado, fechaInicio, fechaFin);

                // Configurar el Chart
                chartCitas.Series.Clear();
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Citas");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

                foreach (var cita in citas)
                {
                    series.Points.AddXY(cita.Tipo, cita.Cantidad);
                }

                chartCitas.Series.Add(series);
            }
            else
            {
                MessageBox.Show("No se encontró un médico asociado a este usuario.");
            }
        }







        //por accidente
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartCitas_Click(object sender, EventArgs e)
        {

        }

    }
}
 