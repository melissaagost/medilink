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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace medilink.Views.reportes
{
    public partial class ReporteRecep : Form
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;

        public ReporteRecep(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            this.Load += new EventHandler(ReporteRecepcionista_Load);

            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
            toolTip4.SetToolTip(PBAyuda, "Seleccione el estado de las citas que desea ver, luego indique el rango de fechas.");
        }

        // Cargamos cb
        private void CargarEstados()
        {
            // Los estados son exactamente los de la BD, no podemos poner en plural ni mayuscula
            List<string> estados = new List<string> { "Todas", "cancelada", "completada", "activa" };
            CBEstado.DataSource = estados;
        }

        private void ReporteRecepcionista_Load(object sender, EventArgs e)
        {
            CargarEstados();
        }

        // Botones
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
            // Filtros
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todas";
            DateTime fechaInicio = DTPInicio.Value.Date;
            DateTime fechaFin = DTPFin.Value.Date;

            List<CitaM> citas = usuarioVM.ListarCitasRecep(estadoSeleccionado, fechaInicio, fechaFin);

            chartCitas.Series.Clear();

            var serie = new Series("Citas")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var cita in citas)
            {
                // Usar la fecha como X y algún valor o categoría como Y (ejemplo: 1 para citas canceladas, 2 para completadas, etc.)
                serie.Points.AddXY(cita.fecha.ToShortDateString(), 1);
            }

            chartCitas.Series.Add(serie);
        }

        private void labeLDNI_Click(object sender, EventArgs e)
        {

        }

        private void labelNuevoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
