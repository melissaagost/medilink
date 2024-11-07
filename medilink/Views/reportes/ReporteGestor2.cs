using medilink.Models;
using medilink.ViewModels;
using medilink.Views.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace medilink.Views.reportes
{
    public partial class ReporteGestor2 : Form
    {
        private CrudVM usuarioVM;
        public ReporteGestor2(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            this.Load += new EventHandler(ReporteGestor2_Load);

            // Tooltip
            toolTip1.SetToolTip(BGenerar, "Generar Reporte");
            toolTip2.SetToolTip(BExportar, "Exportar Reporte");
            toolTip3.SetToolTip(BLimpiar, "Limpiar Filtros");
            toolTip4.SetToolTip(PBAyuda, "Seleccione el estado de los usuarios que desea ver, luego indique el rol de estos.");
        }

        private void CargarEstados()
        {
            //los estados son exactamente los de la BD, no podemos poner en plural ni mayuscula
            List<string> estados = new List<string> { "si", "no" };
            CBEstado.DataSource = estados;
        }

        private void CargarCombobox()
        {
            try
            {
                List<PerfilM> perfiles = usuarioVM.ListarPerfiles();
                perfiles.Insert(0, new PerfilM { id_perfil = -1, nombre = "Todos" }); 
                CBUsuario.DataSource = perfiles;
                CBUsuario.DisplayMember = "nombre";
                CBUsuario.ValueMember = "id_perfil";
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
        }


        private void ReporteGestor2_Load(object sender, EventArgs e)
        {
                CargarEstados();
                CargarCombobox();
            
        }

        //botones

        private void BExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.bmp|PDF Files|*.pdf|Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    if (saveFileDialog.FileName.EndsWith(".png") || saveFileDialog.FileName.EndsWith(".jpg") || saveFileDialog.FileName.EndsWith(".bmp"))
                    {
                        chartUsuarios.SaveImage(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }

                }
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            CBEstado.SelectedIndex = -1;
            CBUsuario.SelectedIndex = -1;
            chartUsuarios.Series.Clear();
        }

        private void BGenerar_Click(object sender, EventArgs e)
        {
            
            chartUsuarios.Series.Clear();

            string estadoSeleccionado = CBEstado.SelectedItem?.ToString();
            int? perfilSeleccionado = (int)CBUsuario.SelectedValue == -1 ? (int?)null : (int)CBUsuario.SelectedValue;

           
            Series serie = new Series("Usuarios")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            // Obtener los datos filtrados según el estado y el perfil
            List<UsuarioM> usuarios = usuarioVM.ObtenerUsuariosPorEstadoYPerfil(estadoSeleccionado, perfilSeleccionado);

            // Agrupar y agregar los datos al gráfico
            var datosAgrupados = usuarios.GroupBy(u => u.id_perfil)
                                         .Select(g => new { Perfil = g.Key, Cantidad = g.Count() })
                                         .ToList();

            foreach (var item in datosAgrupados)
            {
                string nombrePerfil = ObtenerNombrePerfil(item.Perfil);
                serie.Points.AddXY(nombrePerfil, item.Cantidad);
            }

            // Agregar la serie al chart
            chartUsuarios.Series.Add(serie);
        }
        private string ObtenerNombrePerfil(int idPerfil)
        {
            switch (idPerfil)
            {
                case 1: return "Sistemas";
                case 2: return "Gestor";
                case 3: return "Medico";
                case 4: return "Recepcionista";
                default: return "Desconocido";
            }
        }


    }
}
