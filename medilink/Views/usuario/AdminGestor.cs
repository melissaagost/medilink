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

namespace medilink.Views.usuario
{
    public partial class AdminGestor : Form
    {
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public AdminGestor(UsuarioM usuarioLogueado) 
        {
            InitializeComponent();
            this.Load += new EventHandler(AdminGestor_Load);
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
        }

        private void AdminGestor_Load(object sender, EventArgs e)
        {
            CargarMedicos();
            CargarRecepcionistas();
            CargarPacientes();

        }

        //medicos
        private void CargarMedicos()
        {
            try {
                List<MedicoM> medicos = usuarioVM.ListarMedicos();

                dataGridViewMedicos.AutoGenerateColumns = false;
                dataGridViewMedicos.DataSource = medicos;
                dataGridViewMedicos.Columns.Clear();

                dataGridViewMedicos.Columns.Add("nombre", "Nombre");
                dataGridViewMedicos.Columns["nombre"].DataPropertyName = "nombre";

                dataGridViewMedicos.Columns.Add("apellido", "Apellido");
                dataGridViewMedicos.Columns["apellido"].DataPropertyName = "apellido";

                dataGridViewMedicos.Columns.Add("telefono", "Teléfono");
                dataGridViewMedicos.Columns["telefono"].DataPropertyName = "telefono";

                //dataGridViewMedicos.Columns.Add("status", "Status");
                //dataGridViewMedicos.Columns["status"].DataPropertyName = "status";

                dataGridViewMedicos.Columns.Add("especialidad_nombre", "Especialidad");
                dataGridViewMedicos.Columns["especialidad_nombre"].DataPropertyName = "especialidad_nombre";

                dataGridViewMedicos.Columns.Add("turno_nombre", "Turno");
                dataGridViewMedicos.Columns["turno_nombre"].DataPropertyName = "turno_nombre";

                dataGridViewMedicos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_usuario",
                    HeaderText = "ID Usuario",
                    DataPropertyName = "id_usuario",
                    Visible = false
                });

                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn();
                btnBaja.HeaderText = "Acción";
                btnBaja.Text = "Dar de Baja";
                btnBaja.Name = "btnDarDeBaja";
                btnBaja.UseColumnTextForButtonValue = true;
                dataGridViewMedicos.Columns.Add(btnBaja);

                DataGridViewButtonColumn btnAlta = new DataGridViewButtonColumn();
                btnAlta.HeaderText = "Acción";
                btnAlta.Text = "Dar de Alta";
                btnAlta.Name = "btnDarDeAlta";
                btnAlta.UseColumnTextForButtonValue = true;
                dataGridViewMedicos.Columns.Add(btnAlta);

            }
            
            catch (Exception ex) {
                MessageBox.Show("Error al cargar médicos: " + ex.Message);
            }
        }


        private void dataGridViewMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMedicos.Columns["btnDarDeBaja"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewMedicos.Rows[e.RowIndex].Cells["id_usuario"].Value);

                bool resultado = usuarioVM.DarDeBajaUsuario(id_usuario); 

                if (resultado)
                {
                    MessageBox.Show("Médico dado de baja exitosamente.");
                    dataGridViewMedicos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    MessageBox.Show("Error al dar de baja al médico.");
                }
            }

            if (e.ColumnIndex == dataGridViewMedicos.Columns["btnDarDeAlta"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewMedicos.Rows[e.RowIndex].Cells["id_usuario"].Value);

                bool resultado = usuarioVM.DarDeAltaUsuario(id_usuario); 

                if (resultado)
                {
                    MessageBox.Show("Médico dado de alta exitosamente.");
                    dataGridViewMedicos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Error al dar de alta al médico.");
                }
            }
        }

        //recepcionistas
        private void CargarRecepcionistas()
        {
            try {
                List<UsuarioM> recepcionistas = usuarioVM.ListarUsuarios();
                List<UsuarioM> usuariosRecep = recepcionistas.Where(u => u.id_perfil == 4).ToList();

                dataGridViewRecepcionistas.AutoGenerateColumns = false;
                dataGridViewRecepcionistas.DataSource = usuariosRecep;
                dataGridViewRecepcionistas.Columns.Clear();


                dataGridViewRecepcionistas.Columns.Add("dni", "DNI");
                dataGridViewRecepcionistas.Columns["dni"].DataPropertyName = "dni";

                dataGridViewRecepcionistas.Columns.Add("nombre", "Nombre");
                dataGridViewRecepcionistas.Columns["nombre"].DataPropertyName = "nombre";

                dataGridViewRecepcionistas.Columns.Add("apellido", "Apellido");
                dataGridViewRecepcionistas.Columns["apellido"].DataPropertyName = "apellido";

                dataGridViewRecepcionistas.Columns.Add("usuario", "Usuario");
                dataGridViewRecepcionistas.Columns["usuario"].DataPropertyName = "usuario";


                dataGridViewRecepcionistas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_usuario",
                    HeaderText = "ID Usuario",
                    DataPropertyName = "id_usuario",
                    Visible = false
                });


                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn();
                btnBaja.HeaderText = "Acción";
                btnBaja.Text = "Dar de Baja";
                btnBaja.Name = "btnDarDeBaja";
                btnBaja.UseColumnTextForButtonValue = true;
                dataGridViewRecepcionistas.Columns.Add(btnBaja);


                DataGridViewButtonColumn btnAlta = new DataGridViewButtonColumn();
                btnAlta.HeaderText = "Acción";
                btnAlta.Text = "Dar de Alta";
                btnAlta.Name = "btnDarDeAlta";
                btnAlta.UseColumnTextForButtonValue = true;
                dataGridViewRecepcionistas.Columns.Add(btnAlta);

            }
            catch (Exception ex) {  MessageBox.Show(ex.Message); }
        }

        private void dataGridViewRecepcionistas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRecepcionistas.Columns["btnDarDeBaja"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewRecepcionistas.Rows[e.RowIndex].Cells["id_usuario"].Value);

                bool resultado = usuarioVM.DarDeBajaUsuario(id_usuario);

                if (resultado)
                {
                    MessageBox.Show("Recepcionista dado de baja exitosamente.");
                    dataGridViewRecepcionistas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    MessageBox.Show("Error al dar de baja al recepcionista.");
                }
            }

            if (e.ColumnIndex == dataGridViewRecepcionistas.Columns["btnDarDeAlta"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewRecepcionistas.Rows[e.RowIndex].Cells["id_usuario"].Value);

                bool resultado = usuarioVM.DarDeAltaUsuario(id_usuario);

                if (resultado)
                {
                    MessageBox.Show("Recepcionista dado de alta exitosamente.");
                    dataGridViewRecepcionistas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Error al dar de alta al recepcionista.");
                }
            }

        }

        //pacientes
        private void CargarPacientes()
        {
            try {
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
                btnBaja.Text = "Dar de Baja";
                btnBaja.Name = "btnDarDeBaja";
                btnBaja.UseColumnTextForButtonValue = true;
                dataGridViewPacientes.Columns.Add(btnBaja);


                DataGridViewButtonColumn btnAlta = new DataGridViewButtonColumn();
                btnAlta.HeaderText = "Acción";
                btnAlta.Text = "Dar de Alta";
                btnAlta.Name = "btnDarDeAlta";
                btnAlta.UseColumnTextForButtonValue = true;
                dataGridViewPacientes.Columns.Add(btnAlta);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridViewPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPacientes.Columns["btnDarDeBaja"].Index && e.RowIndex >= 0)
            {
                int id_paciente = Convert.ToInt32(dataGridViewPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                bool resultado = usuarioVM.DarDeBajaPaciente(id_paciente);

                if (resultado)
                {
                    MessageBox.Show("Paciente dado de baja exitosamente.");
                    dataGridViewPacientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    MessageBox.Show("Error al dar de baja al paciente.");
                }
            }

            if (e.ColumnIndex == dataGridViewPacientes.Columns["btnDarDeAlta"].Index && e.RowIndex >= 0)
            {
                int id_paciente = Convert.ToInt32(dataGridViewPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                bool resultado = usuarioVM.DarDeAltaPaciente(id_paciente);

                if (resultado)
                {
                    MessageBox.Show("Paciente dado de alta exitosamente.");
                    dataGridViewPacientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Error al dar de alta al paciente.");
                }
            }
        }
    }
}
