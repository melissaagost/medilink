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
using MySql.Data.MySqlClient;


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
            this.Load += new EventHandler(ReporteMedico_Load); 

            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
            toolTip4.SetToolTip(PBAyuda, "Seleccione el estado de las citas que desea ver, luego indique el rango de fechas.");

        }

        //cargamos cb
        private void CargarEstados()
        {
            //los estados son exactamente los de la BD, no podemos poner en plural ni mayuscula
            List<string> estados = new List<string> { "Todas", "cancelada", "completada", "activa" };
            CBEstado.DataSource = estados;
        }

        private void ReporteMedico_Load(object sender, EventArgs e)
        {
            CargarEstados(); 
        }

        //botones
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            CBEstado.SelectedIndex = -1;
            DTPInicio.Value = DateTime.Now;
            DTPFin.Value = DateTime.Now;
            lblResumen.Text = "";
            lblResumen2.Text = "";
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

        private int BuscarMedico(int idUsuario) //obtiene medico logueado para mostrar citas
        {

            using (var conexionBD = new ConexionBD())  
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        string query = "SELECT * FROM medico WHERE id_usuario = @usuario";
                        using (MySqlCommand comando = new MySqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@usuario", idUsuario);

                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();

                                    return Convert.ToInt32(reader["id_medico"]);
                                }
                            }

                        }
                    }
                }

            }
            return 0;
        } 





        private void BGenerar_Click(object sender, EventArgs e)
        {
            // Obtener el id del médico logueado

            int idMedico = BuscarMedico(usuarioLogueado.id_usuario);


            //filtros
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

            List<CitaM> citas = usuarioVM.ListarCitasFiltradas(idMedico, estadoSeleccionado, fechaInicio, fechaFin);

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

            //citas por estado

            var citasPorEstado = citas.GroupBy(c => c.status)
                                       .Select(g => new { Estado = g.Key, Cantidad = g.Count() });


            foreach (var grupo in citasPorEstado)
            {
                serie.Points.AddXY(grupo.Estado, grupo.Cantidad);
            }

            chartCitas.Series.Add(serie);

            //citas por genro

            var citasPorGenero = citas.GroupBy(c => c.Paciente.genero).Select(g => new { Genero = g.Key, Cantidad = g.Count() });

            lblResumen2.Text = "";

            foreach (var grupo in citasPorGenero)
            {
                string leyenda;

                if (grupo.Genero == "M")
                {
                    leyenda = "Hombres atendidos";
                }
                else if (grupo.Genero == "F")
                {
                    leyenda = "Mujeres atendidas";
                }
                else
                {
                    leyenda = "Otros atendidos"; // valores no esperados
                }

                lblResumen2.Text += $"{leyenda} : {grupo.Cantidad} \n";
            }

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





        //por accidente
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartCitas_Click(object sender, EventArgs e)
        {

        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
 