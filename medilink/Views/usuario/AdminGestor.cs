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
        }

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

                dataGridViewMedicos.Columns.Add("status", "Status");
                dataGridViewMedicos.Columns["status"].DataPropertyName = "status";

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
        { }

    }
}
