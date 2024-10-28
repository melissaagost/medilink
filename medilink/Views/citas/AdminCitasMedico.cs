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
            CargarCitasActivas(idUsuarioLogueado);
            CargarCitasCanceladas(idUsuarioLogueado);
            CargarCitasCompletadas(idUsuarioLogueado);

        }


        private void CargarCitasActivas(int idUsuarioLogueado)
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

                    DataGridViewButtonColumn btnCompletar = new DataGridViewButtonColumn();
                    btnCompletar.HeaderText = "Acción";
                    btnCompletar.Text = "Marcar como completada";
                    btnCompletar.Name = "btnCompletar";
                    btnCompletar.UseColumnTextForButtonValue = true;
                    dataGridViewProgramadas.Columns.Add(btnCompletar);
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
                        CargarCitasActivas(idUsuarioLogueado);
                    }
                    else
                    {
                        MessageBox.Show("Error al cancelar cita.");
                    }
                }
                else { MessageBox.Show("La operación fue cancelada."); }
               
            }
            else
            {
                if (e.ColumnIndex == dataGridViewProgramadas.Columns["btnCompletar"].Index && e.RowIndex >= 0)
                {
                    int id_cita = Convert.ToInt32(dataGridViewProgramadas.Rows[e.RowIndex].Cells["id_cita"].Value);

                    DialogResult confirmResult = MessageBox.Show("¿Está seguro que desea marcar la cita como completada?",
                                  "Confirmación",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        bool resultado = usuarioVM.CompletarCita(id_cita);

                        if (resultado)
                        {
                            MessageBox.Show("Cita completada exitosamente.");
                            int idUsuarioLogueado = usuarioLogueado.id_usuario;
                            CargarCitasCanceladas(idUsuarioLogueado);
                            CargarCitasActivas(idUsuarioLogueado);
                            CargarCitasCompletadas(idUsuarioLogueado);
                        }
                        else
                        {
                            MessageBox.Show("Error al completar cita.");
                        }
                    }
                    else { MessageBox.Show("La operación fue cancelada."); }

                }
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

                dataGridViewCanceladas.AutoGenerateColumns = false;
                dataGridViewCanceladas.DataSource = citasCanceladas;
                dataGridViewCanceladas.Columns.Clear();


                dataGridViewCanceladas.Columns.Add("paciente_nombre", "Nombre del Paciente");
                dataGridViewCanceladas.Columns["paciente_nombre"].DataPropertyName = "paciente_nombre";

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "fecha"
                });

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "motivo",
                    HeaderText = "Motivo",
                    DataPropertyName = "motivo" 
                });

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "status",
                    HeaderText = "Status",
                    DataPropertyName = "status"
                });

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_paciente",
                    DataPropertyName = "id_paciente",
                    Visible = false
                });

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_medico",
                    DataPropertyName = "id_medico",
                    Visible = false
                });

                dataGridViewCanceladas.Columns.Add(new DataGridViewTextBoxColumn()
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
                dataGridViewCanceladas.Columns.Add(btnReprogramar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message);
            }
        }

        private void dataGridViewCanceladas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCanceladas.Columns["btnReprogramar"].Index && e.RowIndex >= 0)
            {
                int id_cita = Convert.ToInt32(dataGridViewCanceladas.Rows[e.RowIndex].Cells["id_cita"].Value);
                string motivo = dataGridViewCanceladas.Rows[e.RowIndex].Cells["motivo"].Value.ToString();
                int id_paciente = Convert.ToInt32(dataGridViewCanceladas.Rows[e.RowIndex].Cells["id_paciente"].Value);
                int id_profesional = Convert.ToInt32(dataGridViewCanceladas.Rows[e.RowIndex].Cells["id_medico"].Value);

         
                var reprogramarForm = new ReprogramarCita(id_cita, motivo, id_paciente, id_profesional, usuarioLogueado);

                
                if (reprogramarForm.ShowDialog() == DialogResult.OK)
                { 
                    CargarCitasActivas(usuarioLogueado.id_usuario); // Refresca 
                    CargarCitasCanceladas(usuarioLogueado.id_usuario);
                }



            } 
        }


        //citas completadas
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
    }
}

