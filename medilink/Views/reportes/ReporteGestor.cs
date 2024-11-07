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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace medilink.Views.reportes
{
    public partial class ReporteGestor : Form  
    {
        
        private CrudVM usuarioVM;

        public ReporteGestor(UsuarioM usuarioLogueado)  
        {
            InitializeComponent();
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            this.Load += new EventHandler(ReporteGestor_Load_1);

            // Tooltip
            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
            toolTip4.SetToolTip(PBAyuda, "Seleccione el estado de las citas que desea ver, luego indique el rango de fechas.");
        }

        private void CargarEstados()
        {
            //los estados son exactamente los de la BD, no podemos poner en plural ni mayuscula
            List<string> estados = new List<string> { "Todas", "cancelada", "completada", "activa" };
            CBEstado.DataSource = estados;
        }

        private void CargarComboboxes()
        {
            try
            {

                CBMedico.DataSource = usuarioVM.ObtenerMedicos();
                CBMedico.DisplayMember = "nombre";
                CBMedico.ValueMember = "id_medico";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
        }

        private void ReporteGestor_Load_1(object sender, EventArgs e)
        {
            CargarEstados();
            CargarComboboxes();
        }



        private void BGenerar_Click_1(object sender, EventArgs e)
        {
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todas";
            DateTime fechaInicio = DTPInicio.Value.Date;
            DateTime fechaFin = DTPFin.Value.Date;
            int? idMedico = CBMedico.SelectedValue as int?;

            List<CitaM> citas = usuarioVM.ListarCitasGestor(estadoSeleccionado, fechaInicio, fechaFin, idMedico);

            foreach (var cita in citas)
            {
                cita.Paciente = usuarioVM.ObtenerPacientePorId(cita.id_paciente);
            }


            chartCitas.Series.Clear();

            var serie = new Series("Citas")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };

            var citasPorEstado = citas.GroupBy(c => c.status)
                                       .Select(g => new { Estado = g.Key, Cantidad = g.Count() });

            foreach (var grupo in citasPorEstado)
            {
                serie.Points.AddXY(grupo.Estado, grupo.Cantidad);
            }

            chartCitas.Series.Add(serie);

            if (estadoSeleccionado == "Todas")
            {
                lblResumen.Text = ObtenerResumenCitasPorMes(citas);
            }


        }

        private string ObtenerResumenCitasPorMes(List<CitaM> citas)
        {
            var citasPorMes = citas.GroupBy(c => c.fecha.Month)
                                   .Select(g => $"Mes {g.Key}: {g.Count()} citas").ToList();
            return string.Join("\n", citasPorMes);
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
            CBMedico.SelectedIndex = -1;
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
            chartCitas.Series.Clear();
        }

        private void LPMujeres_Click(object sender, EventArgs e)
        {

        }
    } 
}
 






