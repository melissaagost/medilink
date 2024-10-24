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

namespace medilink.Views.usuario
{
    public partial class NuevoUsuario : Form
    {
        private UsuarioM usuarioLogueado;  
        private CrudVM usuarioVM;  

        public NuevoUsuario(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            CargarComboboxes();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //por accidente
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //por accidente

        }

        private void label6_Click(object sender, EventArgs e)
        {
            //por accidente

        }

        private void labelNuevoUsuario_Click(object sender, EventArgs e)
        {
            //por accidente

        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            //ignorar

        }

        private void CargarComboboxes()
        {
            try
            {
                comboBoxProvincia.DataSource = usuarioVM.ListarProvincias();
                comboBoxProvincia.DisplayMember = "nombre";
                comboBoxProvincia.ValueMember = "id_provincia";


                comboBoxCiudad.DataSource = usuarioVM.ListarCiudades();
                comboBoxCiudad.DisplayMember = "nombre";
                comboBoxCiudad.ValueMember = "id_ciudad";


                comboBoxPerfil.DataSource = usuarioVM.ListarPerfiles();
                comboBoxPerfil.DisplayMember = "nombre";
                comboBoxPerfil.ValueMember = "id_perfil";


                comboBoxEspecialidad.DataSource = usuarioVM.ObtenerEspecialidades();
                comboBoxEspecialidad.DisplayMember = "nombre";
                comboBoxEspecialidad.ValueMember = "id_especialidad";

                comboBoxTurno.DataSource = usuarioVM.ObtenerTurnos();
                comboBoxTurno.DisplayMember = "nombre";
                comboBoxTurno.ValueMember = "id_turno";

            } 
            catch (Exception ex){
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxUsuario.Text) ||
                string.IsNullOrWhiteSpace(textBoxContraseña.Text) ||
                string.IsNullOrWhiteSpace(textBoxCorreo.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                string.IsNullOrWhiteSpace(textBoxDomicilio.Text) ||
                comboBoxProvincia.SelectedItem == null ||
                comboBoxCiudad.SelectedItem == null ||
                comboBoxPerfil.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validar el formato del DNI (debe ser numérico y tener 7 u 8 dígitos)
            if (!int.TryParse(textBoxDNI.Text, out int dni) ||
                (textBoxDNI.Text.Length != 7 && textBoxDNI.Text.Length != 8))
            {
                MessageBox.Show("El DNI debe ser un número válido de 7 u 8 dígitos.");
                return;
            }

            // Validar el nombre (debe ser solo letras)
            if (!IsValidName(textBoxNombre.Text))
            {
                MessageBox.Show("El nombre debe contener solo letras.");
                return;
            }

            // Validar el apellido (debe ser solo letras)
            if (!IsValidName(textBoxApellido.Text))
            {
                MessageBox.Show("El apellido debe contener solo letras.");
                return;
            }

            // Validar el formato del correo
            if (!IsValidEmail(textBoxCorreo.Text))
            {
                MessageBox.Show("El correo electrónico no es válido.");
                return;
            }

            // Validar el formato del teléfono (debe ser numérico, entre 10 y 15 dígitos)
            if (!long.TryParse(textBoxTelefono.Text, out long telefono) ||
                textBoxTelefono.Text.Length < 10 || textBoxTelefono.Text.Length > 15)
            {
                MessageBox.Show("El número de teléfono debe ser numérico y contener entre 10 y 15 dígitos.");
                return;
            }

            // Validar que la fecha de nacimiento no sea posterior a la fecha actual
            if (dateTimePicker1.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser el día de hoy ni una fecha futura.");
                return;
            }

            // Validar que el usuario sea mayor de edad (por ejemplo, 18 años)
            int edadMinima = 18;
            DateTime fechaActual = DateTime.Now;
            DateTime fechaNacimiento = dateTimePicker1.Value;

            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Restar un año si la fecha de nacimiento aún no ha ocurrido este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            if (edad < edadMinima)
            {
                MessageBox.Show($"El usuario debe tener al menos {edadMinima} años para poder registrarse.");
                return;
            }


            // Validar que el usuario no contenga espacios
            if (textBoxUsuario.Text.Contains(" "))
            {
                MessageBox.Show("El usuario no debe contener espacios.");
                return;
            }

            // Validar que la contraseña no contenga espacios
            if (textBoxContraseña.Text.Contains(" "))
            {
                MessageBox.Show("La contraseña no debe contener espacios.");
                return;
            }


            // Crear el objeto UsuarioM
            UsuarioM nuevoUsuario = new UsuarioM()
            {
                dni = int.Parse(textBoxDNI.Text),
                nombre = textBoxNombre.Text,
                apellido = textBoxApellido.Text,
                telefono = textBoxTelefono.Text,
                usuario = textBoxUsuario.Text,
                contraseña = textBoxContraseña.Text,
                correo = textBoxCorreo.Text,
                direccion = textBoxDomicilio.Text,
                id_provincia = (int)comboBoxProvincia.SelectedValue,
                id_ciudad = (int)comboBoxCiudad.SelectedValue,
                id_perfil = (int)comboBoxPerfil.SelectedValue,
                fecha_nacimiento = dateTimePicker1.Value
            };

            try
            {
                int? idEspecialidad = null;
                int? idTurno = null;

                if (nuevoUsuario.id_perfil == 3)
                {
                    idEspecialidad = (int?)comboBoxEspecialidad.SelectedValue;
                    idTurno = (int?)comboBoxTurno.SelectedValue;
                }

                // Si no es médico, pasar valores nulos
                string mensajeError;
                bool resultado = usuarioVM.CrearUsuario(nuevoUsuario, idEspecialidad ?? -1, idTurno ?? -1, out mensajeError);

                if (resultado)
                {
                    MessageBox.Show("Usuario creado exitosamente.");
                }
                else
                {
                    MessageBox.Show(mensajeError); 
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
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //viejo, ignorar
        }

        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //viejo, ignorar
        }

        private void comboBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilM idPerfilSeleccionado = comboBoxPerfil.SelectedItem as PerfilM;

            if (idPerfilSeleccionado.id_perfil == 3)
            {
                // Habilitar los comboboxes de especialidad y turno si es médico
                comboBoxEspecialidad.Enabled = true;
                comboBoxTurno.Enabled = true;
            }
            else
            {
                // Deshabilitar los comboboxes si no es médico
                comboBoxEspecialidad.Enabled = false;
                comboBoxTurno.Enabled = false;
            }

        }


        private void comboBoxPerfil_SelectedValueChanged(object sender, EventArgs e)
        {
           //ignorar
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
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
    }
}
    

