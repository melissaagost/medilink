using medilink.Models;
using medilink.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.Views.usuario
{
    public partial class Perfil : Form
    {
        private Panel panelVistas; // Define una variable para almacenar la referencia al panel
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        private EditarPerfil editarPerfilForm; // Agregar una referencia a la vista de edición

        public Perfil(Panel panelVistasDelMenu, UsuarioM usuario)
        {
            InitializeComponent();
            this.panelVistas = panelVistasDelMenu;
            this.usuarioLogueado = usuario;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            CargarDatosUsuario();  // Cargar los datos del usuario al inicializar la vista
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                panelVistas.Controls.Clear();

                // Inicializar el formulario de edición de perfil
                editarPerfilForm = new EditarPerfil(usuarioLogueado);

                // Suscribirse al evento de perfil actualizado
                editarPerfilForm.PerfilActualizado += OnPerfilActualizado;

                editarPerfilForm.TopLevel = false;
                editarPerfilForm.FormBorderStyle = FormBorderStyle.None;
                editarPerfilForm.Dock = DockStyle.Fill;
                panelVistas.Controls.Add(editarPerfilForm);
                editarPerfilForm.Show();
            }
            else
            {
                MessageBox.Show("El usuario no está inicializado correctamente.");
            }
        }

        // Método para cargar los datos del usuario en los Labels y PictureBox
        private void CargarDatosUsuario()
        {
            // Asignar los valores a los Labels
            LabelNombre.Text = $"{usuarioLogueado.nombre} {usuarioLogueado.apellido}";
            LabelCorreo.Text = usuarioLogueado.correo;
            LabelDireccion.Text = usuarioLogueado.direccion;
            LabelTelefono.Text = usuarioLogueado.telefono;
            LabelUsuario.Text = usuarioLogueado.usuario;
            LabelPerfil.Text = usuarioLogueado.id_perfil.ToString();

            // Mostrar la foto de perfil, si existe
            if (usuarioLogueado.foto != null && usuarioLogueado.foto.Length > 0)
            {
                using (var ms = new MemoryStream(usuarioLogueado.foto))
                {
                    pictureBoxPFP.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxPFP.Image = null; // O asignar una imagen por defecto si no hay foto
            }
        }

        // Método que se ejecuta cuando se dispara el evento PerfilActualizado
        private void OnPerfilActualizado(object sender, EventArgs e)
        {
            // Recargar los datos del usuario desde la base de datos después de la edición
            usuarioLogueado = usuarioVM.ObtenerUsuarioPorId(usuarioLogueado.id_usuario);  // Asegúrate de que esta consulta esté funcionando correctamente
            CargarDatosUsuario(); // Recargar los datos del usuario en la vista
        }

        // Nueva función para recargar los datos del perfil al volver a la vista perfil
        private void RecargarDatosUsuario()
        {
            // Recargar los datos del usuario desde la base de datos cada vez que se abre la vista de perfil
            usuarioLogueado = usuarioVM.ObtenerUsuarioPorId(usuarioLogueado.id_usuario);
            CargarDatosUsuario();
        }

        // Cuando el formulario de perfil gana el foco (es activado), recargamos los datos
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            RecargarDatosUsuario();  // Recargar los datos cuando el formulario de perfil se activa
        }
    }

}