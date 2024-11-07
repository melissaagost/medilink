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

        private CrudVM usuarioVM;

        public ReporteRecep(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            this.Load += new EventHandler(ReporteRecep_Load);

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

        private void ReporteRecep_Load(object sender, EventArgs e)
        {
            CargarEstados();
        }

        // Botones
        private void BGenerar_Click_1(object sender, EventArgs e)
        {
            // Filtros
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todas";
            DateTime fechaInicio = DTPInicio.Value.Date;
            DateTime fechaFin = DTPFin.Value.Date;

            if (DTPFin.Value.Date < DTPInicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DTPFin.Value.Date == DTPInicio.Value.Date)
            {
                MessageBox.Show("La fecha de inicio y fin no pueden ser iguales.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<CitaM> citas = usuarioVM.ListarCitasRecep(estadoSeleccionado, fechaInicio, fechaFin);

            if (citas == null || citas.Count == 0)
            {
                MessageBox.Show("No se encontraron citas en el rango de fechas seleccionado.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            chartCitas.Series.Clear();

            var serie = new Series("Citas")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };

            foreach (var cita in citas)
            {
                serie.Points.AddXY(cita.fecha.ToShortDateString(), 1);
            }

            chartCitas.Series.Add(serie);
        }

        private void BExportar_Click_1(object sender, EventArgs e)
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

        private void BLimpiar_Click_1(object sender, EventArgs e)
        {
            CBEstado.SelectedIndex = -1;
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
            chartCitas.Series.Clear();
        }
















        private void labeLDNI_Click(object sender, EventArgs e)
        {

        }

        private void labelNuevoUsuario_Click(object sender, EventArgs e)
        {

        }

    }
}
