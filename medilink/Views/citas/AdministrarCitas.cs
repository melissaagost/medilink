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
    public partial class AdministrarCitas : Form
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM; 
        public AdministrarCitas(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.Load += new EventHandler(AdministrarCitas_Load);

            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
        }

        private void AdministrarCitas_Load(object sender, EventArgs e)
        {
            int idUsuarioLogueado = usuarioLogueado.id_usuario;
            CargarCitas(idUsuarioLogueado); 
            CargarCitasCanceladas(idUsuarioLogueado);
            CargarCitasCompletadas(idUsuarioLogueado);
            CargarPacientes();

        }

        private void CargarCitas(int idUsuarioLogueado) {
            try {
                List<CitaM> citas = usuarioVM.ListarCitas(idUsuarioLogueado);
                List<CitaM> citasActivas = citas
                   .Where(u => u.status != null && u.status.Trim().Equals("activa", StringComparison.OrdinalIgnoreCase))
                   .ToList();

                dataGridViewProgramadas.AutoGenerateColumns = false;
                dataGridViewProgramadas.DataSource = citasActivas;
                dataGridViewProgramadas.Columns.Clear();


                dataGridViewProgramadas.Columns.Add("paciente_nombre", "Nombre del Paciente");
                dataGridViewProgramadas.Columns["paciente_nombre"].DataPropertyName = "paciente_nombre";

                dataGridViewProgramadas.Columns.Add("medico_nombre", "Profesional a cargo");
                dataGridViewProgramadas.Columns["medico_nombre"].DataPropertyName = "medico_nombre";

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
            catch (Exception ex) { MessageBox.Show("Error al cargar las citas: " + ex.Message); }
        }

        private void dataGridViewProgramadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewProgramadas.Columns["btnCancelar"].Index && e.RowIndex >= 0)
            {
                int id_cita = Convert.ToInt32(dataGridViewProgramadas.Rows[e.RowIndex].Cells["id_cita"].Value);

                DialogResult confirmResult = MessageBox.Show("¿Está seguro que desea cancelar la cita?",
                              "Confirmación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes) 
                {
                    bool resultado = usuarioVM.CancelarCita(id_cita);

                    if (resultado)
                    {
                        MessageBox.Show("Cita cancelada exitosamente.");
                        int idUsuarioLogueado = usuarioLogueado.id_usuario;
                        CargarCitasCanceladas(idUsuarioLogueado);
                        CargarCitas(idUsuarioLogueado);
                    }
                    else
                    {
                        MessageBox.Show("Error al cancelar cita.");
                    }
                }
                else { MessageBox.Show("La operación fue cancelada."); }
               
            }
        }

        //citas canceladas
        private void CargarCitasCanceladas(int idUsuarioLogueado)
        {
            try
            {
                List<CitaM> citas = usuarioVM.ListarCitas(idUsuarioLogueado);
                List<CitaM> citasCanceladas = citas
                .Where(u => u.status != null && u.status.Trim().Equals("cancelada", StringComparison.OrdinalIgnoreCase))
                .ToList();

                dataGridViewInactivos.AutoGenerateColumns = false;
                dataGridViewInactivos.DataSource = citasCanceladas;
                dataGridViewInactivos.Columns.Clear();


                dataGridViewInactivos.Columns.Add("paciente_nombre", "Nombre del Paciente");
                dataGridViewInactivos.Columns["paciente_nombre"].DataPropertyName = "paciente_nombre";

                dataGridViewInactivos.Columns.Add("medico_nombre", "Profesional a cargo");
                dataGridViewInactivos.Columns["medico_nombre"].DataPropertyName = "medico_nombre";

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "fecha"
                });

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "motivo",
                    HeaderText = "Motivo",
                    DataPropertyName = "motivo"
                });

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "status",
                    HeaderText = "Status",
                    DataPropertyName = "status"
                });

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_paciente",
                    DataPropertyName = "id_paciente",
                    Visible = false
                });

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_medico",
                    DataPropertyName = "id_medico",
                    Visible = false
                });

                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_cita",
                    HeaderText = "ID Cita",
                    DataPropertyName = "id_cita",
                    Visible = false
                });

                DataGridViewButtonColumn btnReprogramar = new DataGridViewButtonColumn();
                btnReprogramar.HeaderText = "Acción";
                btnReprogramar.Text = "Reprogramar";
                btnReprogramar.Name = "btnReprogramar";
                btnReprogramar.UseColumnTextForButtonValue = true;
                dataGridViewInactivos.Columns.Add(btnReprogramar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message);
            }
        }


        private void dataGridViewInactivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInactivos.Columns["btnReprogramar"].Index && e.RowIndex >= 0)
            {
                int id_cita = Convert.ToInt32(dataGridViewInactivos.Rows[e.RowIndex].Cells["id_cita"].Value);
                string motivo = dataGridViewInactivos.Rows[e.RowIndex].Cells["motivo"].Value.ToString();
                int id_paciente = Convert.ToInt32(dataGridViewInactivos.Rows[e.RowIndex].Cells["id_paciente"].Value);
                int id_profesional = Convert.ToInt32(dataGridViewInactivos.Rows[e.RowIndex].Cells["id_medico"].Value);

                // Abrir el formulario de reprogramar cita y pasarle los datos de la cita actual
                // Si tienes el objeto usuarioLogueado en tu vista de origen
                var reprogramarForm = new ReprogramarCita(id_cita, motivo, id_paciente, id_profesional, usuarioLogueado);
                reprogramarForm.Show();


            }
        }

        //completadas (solo ver)
        private void CargarCitasCompletadas(int idUsuarioLogueado)
        {
            try
            {
                List<CitaM> citas = usuarioVM.ListarCitas(idUsuarioLogueado);
                List<CitaM> citasCompletadas = citas
                .Where(u => u.status != null && u.status.Trim().Equals("completada", StringComparison.OrdinalIgnoreCase))
                .ToList();

                dataGridViewCompletadas.AutoGenerateColumns = false;
                dataGridViewCompletadas.DataSource = citasCompletadas;
                dataGridViewCompletadas.Columns.Clear();


                dataGridViewCompletadas.Columns.Add("paciente_nombre", "Nombre del Paciente");
                dataGridViewCompletadas.Columns["paciente_nombre"].DataPropertyName = "paciente_nombre";

                dataGridViewCompletadas.Columns.Add("medico_nombre", "Profesional a cargo");
                dataGridViewCompletadas.Columns["medico_nombre"].DataPropertyName = "medico_nombre";

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "fecha"
                });

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "motivo",
                    HeaderText = "Motivo",
                    DataPropertyName = "motivo"
                });

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "status",
                    HeaderText = "Status",
                    DataPropertyName = "status"
                });

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_paciente",
                    DataPropertyName = "id_paciente",
                    Visible = false
                });

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_medico",
                    DataPropertyName = "id_medico",
                    Visible = false
                });

                dataGridViewCompletadas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_cita",
                    HeaderText = "ID Cita",
                    DataPropertyName = "id_cita",
                    Visible = false
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message);
            }
        }

        //pacientes
        private void CargarPacientes()
        {
            try
            {
                List<PacienteM> pacientes = usuarioVM.ListarPacientes();

                dataGridViewPacientes.AutoGenerateColumns = false;
                dataGridViewPacientes.DataSource = pacientes;
                dataGridViewPacientes.Columns.Clear();


                dataGridViewPacientes.Columns.Add("dni", "DNI");
                dataGridViewPacientes.Columns["dni"].DataPropertyName = "dni";

                dataGridViewPacientes.Columns.Add("nombre", "Nombre");
                dataGridViewPacientes.Columns["nombre"].DataPropertyName = "nombre";

                dataGridViewPacientes.Columns.Add("apellido", "Apellido");
                dataGridViewPacientes.Columns["apellido"].DataPropertyName = "apellido";

                dataGridViewPacientes.Columns.Add("telefono", "Teléfono");
                dataGridViewPacientes.Columns["telefono"].DataPropertyName = "telefono";


                dataGridViewPacientes.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_paciente",
                    HeaderText = "ID Paciente",
                    DataPropertyName = "id_paciente",
                    Visible = false
                });


                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn();
                btnBaja.HeaderText = "Acción";
                btnBaja.Text = "Editar Paciente";
                btnBaja.Name = "btnEditar";
                btnBaja.UseColumnTextForButtonValue = true;
                dataGridViewPacientes.Columns.Add(btnBaja);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    } 
}
