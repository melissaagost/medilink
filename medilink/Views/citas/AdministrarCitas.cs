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
            dataGridViewPacientes.CellFormatting += dataGridViewPacientes_CellFormatting;
             
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
            CargarComboboxes();

        }

        private void CargarComboboxes()
        {
            try
            {
                comboBoxBuscarPaciente.DataSource = usuarioVM.ObtenerPacientes();
                comboBoxBuscarPaciente.DisplayMember = "dni";
                comboBoxBuscarPaciente.ValueMember = "id_paciente";


                comboBoxBuscarMedico.DataSource = usuarioVM.ObtenerMedicos();
                comboBoxBuscarMedico.DisplayMember = "nombre";
                comboBoxBuscarMedico.ValueMember = "id_medico";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
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

                
                var reprogramarForm = new ReprogramarCita(id_cita, motivo, id_paciente, id_profesional, usuarioLogueado);
                if (reprogramarForm.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas(usuarioLogueado.id_usuario); // Refresca 
                    CargarCitasCanceladas(usuarioLogueado.id_usuario);
                }



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
        //no esta funcionando el color
        private void dataGridViewPacientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewPacientes.Columns[e.ColumnIndex].Name == "status")
            {
                
                if (e.Value != null && e.Value.ToString().ToLower() == "no")
                {
                    dataGridViewPacientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

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


                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acción";
                btnEditar.Text = "Editar Paciente";
                btnEditar.Name = "btnEditar";
                btnEditar.UseColumnTextForButtonValue = true;
                dataGridViewPacientes.Columns.Add(btnEditar);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridViewPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPacientes.Columns["btnEditar"].Index && e.RowIndex >= 0)
            {
                int id_paciente = Convert.ToInt32(dataGridViewPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                // Llamar a la función que obtiene la información del paciente
                PacienteM paciente = usuarioVM.ObtenerPacientePorId(id_paciente);

                if (paciente != null)
                {
                    var editarPaciente = new EditarPaciente(paciente, usuarioLogueado);

                    // Si se cierra el formulario, refrescar la tabla
                    if (editarPaciente.ShowDialog() == DialogResult.OK)
                    {
                        CargarPacientes(); // Refresca el DataGridView después de editar el paciente
                    }
                }
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            int? idMedico = comboBoxBuscarMedico.SelectedValue as int? == -1 ? (int?)null : comboBoxBuscarMedico.SelectedValue as int?;
            int? idPaciente = comboBoxBuscarPaciente.SelectedValue as int? == -1 ? (int?)null : comboBoxBuscarPaciente.SelectedValue as int?;

            // Usar usuarioLogueado.id_usuario en lugar de idUsuarioLogueado
            List<CitaM> citasFiltradas = usuarioVM.ListarCitas(usuarioLogueado.id_usuario, idMedico, idPaciente);
            dataGridViewProgramadas.DataSource = citasFiltradas;
            dataGridViewInactivos.DataSource = citasFiltradas;
            dataGridViewCompletadas.DataSource= citasFiltradas;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reiniciar los filtros de búsqueda
            comboBoxBuscarMedico.SelectedIndex = -1;
            comboBoxBuscarPaciente.SelectedIndex = -1;

            // Obtener todas las citas una sola vez
            List<CitaM> todasLasCitas = usuarioVM.ListarCitas(usuarioLogueado.id_usuario);

            // Filtrar las citas por estado
            List<CitaM> citasActivas = todasLasCitas
                .Where(u => u.status != null && u.status.Trim().Equals("activa", StringComparison.OrdinalIgnoreCase))
                .ToList();

            List<CitaM> citasCanceladas = todasLasCitas
                .Where(u => u.status != null && u.status.Trim().Equals("cancelada", StringComparison.OrdinalIgnoreCase))
                .ToList();

            List<CitaM> citasCompletadas = todasLasCitas
                .Where(u => u.status != null && u.status.Trim().Equals("completada", StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Asignar cada lista filtrada a su respectivo DataGridView
            dataGridViewProgramadas.DataSource = citasActivas;
            dataGridViewInactivos.DataSource = citasCanceladas;
            dataGridViewCompletadas.DataSource = citasCompletadas;
        }



    }
}
