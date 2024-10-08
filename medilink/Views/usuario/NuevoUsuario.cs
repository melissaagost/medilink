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
                bool resultado = usuarioVM.CrearUsuario(nuevoUsuario, idEspecialidad ?? -1, idTurno ?? -1);

                if (resultado)
                {
                    MessageBox.Show("Usuario creado exitosamente.");
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);  
            }
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
    }
}
    

