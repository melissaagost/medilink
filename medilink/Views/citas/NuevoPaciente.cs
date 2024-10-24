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
            DialogResult resultado = MessageBox.Show(
               "¿Estás seguro de que deseas cancelar los cambios?",
               "Confirmar cancelación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void buttonAñadirPaciente_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombrePaciente.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellidoPaciente.Text) ||
                string.IsNullOrWhiteSpace(textBoxCorreoPaciente.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefonoPaciente.Text) ||
                string.IsNullOrWhiteSpace(textBoxDireccionPaciente.Text) ||
                string.IsNullOrWhiteSpace(textBoxEdadPaciente.Text) ||
                comboBoxObraSocial.SelectedItem == null ||
                comboBoxCiudadPaciente.SelectedItem == null ||
                comboBoxProvinciaPaciente.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validar el formato del DNI (debe ser numérico y tener 7 u 8 dígitos)
            if (!int.TryParse(textBoxDNIPaciente.Text, out int dni) ||
                (textBoxDNIPaciente.Text.Length != 7 && textBoxDNIPaciente.Text.Length != 8))
            {
                MessageBox.Show("El DNI debe ser un número válido de 7 u 8 dígitos.");
                return;
            }

            // Validar el nombre (debe ser solo letras)
            if (!IsValidName(textBoxNombrePaciente.Text))
            {
                MessageBox.Show("El nombre debe contener solo letras.");
                return;
            }

            // Validar el apellido (debe ser solo letras)
            if (!IsValidName(textBoxApellidoPaciente.Text))
            {
                MessageBox.Show("El apellido debe contener solo letras.");
                return;
            }

            // Validar el formato de la edad (debe ser numérico entre 0 y 100)
            if (!int.TryParse(textBoxEdadPaciente.Text, out int edad) || edad < 0 || edad > 100)
            {
                MessageBox.Show("La edad debe ser un número entre 0 y 100.");
                return;
            }

            // Validar el formato del correo
            if (!IsValidEmail(textBoxCorreoPaciente.Text))
            {
                MessageBox.Show("El correo electrónico no es válido.");
                return;
            }

            // Validar el formato del teléfono (debe ser numérico, entre 10 y 15 dígitos)
            if (!long.TryParse(textBoxTelefonoPaciente.Text, out long telefono) ||
                textBoxTelefonoPaciente.Text.Length < 10 || textBoxTelefonoPaciente.Text.Length > 15)
            {
                MessageBox.Show("El número de teléfono debe ser numérico y contener entre 10 y 15 dígitos.");
                return;
            }

            // Validar que la fecha de nacimiento no sea posterior a la fecha actual
            if (dateTimePickerPaciente.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser posterior a la fecha actual.");
                return;
            }

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
                else
                {
                    MessageBox.Show("No se pudo agendar el paciente. Intente nuevamente.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Método para validar formato de correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailAddr = new System.Net.Mail.MailAddress(email);
                return emailAddr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Método para validar que el nombre contenga solo letras
        private bool IsValidName(string name)
        {
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)); // Permite letras y espacios
        }
    }
}
