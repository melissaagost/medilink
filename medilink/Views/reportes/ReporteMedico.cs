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
        }

        private void CargarReporteCitas(int idMedico)
        {
            // Llama a la función del ViewModel para obtener los datos
            List<ReporteCitas> datos = usuarioVM.ListarCitasCanceladasYReprogramadas(idMedico);

            // Limpia series anteriores del chart
            chartCitas.Series.Clear();

            // Crea una nueva serie para el gráfico
            var serie = new Series("Citas")
            {
                ChartType = SeriesChartType.Pie, // Puedes usar SeriesChartType.Bar para un gráfico de barras
                IsValueShownAsLabel = true // Muestra las etiquetas con valores
            };

            // Añade los puntos a la serie
            foreach (var dato in datos)
            {
                serie.Points.AddXY(dato.Tipo, dato.Cantidad);
            }

            // Añade la serie al chart
            chartCitas.Series.Add(serie);
        }

        // Llama a esta función cuando se cargue el formulario de reporte
        private void ReporteCitasMedico_Load(object sender, EventArgs e)
        {
            int idMedico = usuarioLogueado.id_usuario; // Suponiendo que tienes el id del médico logueado
            CargarReporteCitas(idMedico);
        }

    }
}
 