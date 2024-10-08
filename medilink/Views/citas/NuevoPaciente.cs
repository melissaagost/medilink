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
    public partial class NuevoPaciente : Form
    { 
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public NuevoPaciente(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            CargarComboboxes();
        }

        private void NuevoPaciente_Load(object sender, EventArgs e)
        {
            //por accidente
        }

        private void CargarComboboxes()
        {
            try
            {
                comboBoxProvinciaPaciente.DataSource = usuarioVM.ListarProvincias();
                comboBoxProvinciaPaciente.DisplayMember = "nombre";
                comboBoxProvinciaPaciente.ValueMember = "id_provincia";


                comboBoxCiudadPaciente.DataSource = usuarioVM.ListarCiudades();
                comboBoxCiudadPaciente.DisplayMember = "nombre";
                comboBoxCiudadPaciente.ValueMember = "id_ciudad";

                comboBoxObraSocial.DataSource = usuarioVM.ObtenerObrasSociales();
                comboBoxObraSocial.DisplayMember = "nombre";
                comboBoxObraSocial.ValueMember = "id_obra_social";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
        }

        private void buttonCancelarPaciente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAñadirPaciente_Click(object sender, EventArgs e)
        {
            PacienteM nuevoPaciente = new PacienteM() {

                dni = int.Parse(textBoxDNIPaciente.Text),
                nombre = textBoxNombrePaciente.Text,
                apellido = textBoxApellidoPaciente.Text,
                fecha_nacimiento = dateTimePickerPaciente.Value,
                correo = textBoxCorreoPaciente.Text,
                telefono = textBoxTelefonoPaciente.Text,
                direccion = textBoxDireccionPaciente.Text,
                edad = int.Parse(textBoxEdadPaciente.Text),
                id_obra_social = (int)comboBoxObraSocial.SelectedValue,
                id_ciudad = (int)comboBoxCiudadPaciente.SelectedValue,
                id_provincia = (int)comboBoxProvinciaPaciente.SelectedValue
            };

            try
            {
                bool resultado = usuarioVM.RegistrarPaciente(nuevoPaciente);

                if (resultado)
                {
                    MessageBox.Show("Paciente agendado exitosamente.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
