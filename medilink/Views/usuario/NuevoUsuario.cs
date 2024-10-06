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
            //por accidente

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
                id_provincia = int.Parse(comboBoxProvincia.SelectedItem.ToString()),
                id_ciudad = int.Parse(comboBoxCiudad.SelectedItem.ToString()),
                id_perfil = int.Parse(comboBoxPerfil.SelectedItem.ToString()),
                fecha_nacimiento = dateTimePicker1.Value
            };

           
            try
            {
                bool resultado = usuarioVM.CrearUsuario(nuevoUsuario);  // Llamar al ViewModel
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

