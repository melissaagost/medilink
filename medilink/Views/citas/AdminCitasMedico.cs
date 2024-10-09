using medilink.Models;
using medilink.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.Views.citas
{
    public partial class AdminCitasMedico : Form
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public AdminCitasMedico(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.Load += new EventHandler(AdminCitasMedico_Load);

            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
        }

        private void AdminCitasMedico_Load(object sender, EventArgs e)
        {
            int idUsuarioLogueado = usuarioLogueado.id_usuario; // Asegúrate de que obtienes el ID correcto.
            CargarCitas(idUsuarioLogueado);

        }


        private void CargarCitas(int idUsuarioLogueado)
            {
                try
                {
                    List<CitaM> citas = usuarioVM.ListarCitas(idUsuarioLogueado);
                    List<CitaM> citasActivas = citas
                    .Where(u => u.status != null && u.status.Trim().Equals("activa", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                    dataGridViewProgramadas.AutoGenerateColumns = false;
                    dataGridViewProgramadas.DataSource = citasActivas;
                    dataGridViewProgramadas.Columns.Clear();


                dataGridViewProgramadas.Columns.Add("paciente_nombre", "Nombre del Paciente");
                dataGridViewProgramadas.Columns["paciente_nombre"].DataPropertyName = "paciente_nombre";

                dataGridViewProgramadas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "fecha",
                        HeaderText = "Fecha",
                        DataPropertyName = "fecha"
                    });

                    dataGridViewProgramadas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "motivo",
                        HeaderText = "Motivo",
                        DataPropertyName = "motivo"
                    });

                    dataGridViewProgramadas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "status",
                        HeaderText = "Status",
                        DataPropertyName = "status"
                    });

                    dataGridViewProgramadas.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "id_cita",
                        HeaderText = "ID Cita",
                        DataPropertyName = "id_cita",
                        Visible = false
                    });

                    DataGridViewButtonColumn btnCancelar = new DataGridViewButtonColumn();
                    btnCancelar.HeaderText = "Acción";
                    btnCancelar.Text = "Cancelar";
                    btnCancelar.Name = "btnCancelar";
                    btnCancelar.UseColumnTextForButtonValue = true;
                    dataGridViewProgramadas.Columns.Add(btnCancelar);
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las citas: " + ex.Message);
                }
            }

        private void dataGridViewProgramadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewProgramadas.Columns["btnCancelar"].Index && e.RowIndex >= 0)
            {
                int id_cita = Convert.ToInt32(dataGridViewProgramadas.Rows[e.RowIndex].Cells["id_cita"].Value);

                bool resultado = usuarioVM.CancelarCita(id_cita);

                if (resultado)
                {
                    MessageBox.Show("Cita cancelada exitosamente.");
                    dataGridViewProgramadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    MessageBox.Show("Error al cancelar cita.");
                }
            }
        }
    }
    }

