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

namespace medilink.Views.reportes
{
    public partial class ReporteGestor : Form
    {
        private CrudVM usuarioVM;

        public ReporteGestor(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            this.Load += new EventHandler(ReporteGestor_Load);

            // Tooltip
            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
        }

        private void ReporteGestor_Load(object sender, EventArgs e)
        {
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
            chartCitas.Series.Clear();
        }

        private void BGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DTPInicio.Value.Date;
            DateTime fechaFin = DTPFin.Value.Date;

            List<CitaRG> citasPorMedico = usuarioVM.ListarCitasGestor(fechaInicio, fechaFin);

            chartCitas.Series.Clear();

            var serie = new Series("Citas por Médico")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var cita in citasPorMedico)
            {
                serie.Points.AddXY("Médico " + cita.id_medico, cita.total_citas);
            }

            chartCitas.Series.Add(serie);
        }
    } 
}







