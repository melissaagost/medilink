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
        private Panel panelVistas; 
        private UsuarioM usuarioLogueado; 
        private CrudVM usuarioVM;
        private EditarPerfil editarPerfilForm; 

        public Perfil(Panel panelVistasDelMenu, UsuarioM usuario)
        {
            InitializeComponent();
            this.panelVistas = panelVistasDelMenu;
            this.usuarioLogueado = usuario;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            CargarDatosUsuario(); 
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
            
            LabelNombre.Text = $"{usuarioLogueado.nombre} {usuarioLogueado.apellido}";
            LabelCorreo.Text = usuarioLogueado.correo;
            LabelDireccion.Text = usuarioLogueado.direccion;
            LabelTelefono.Text = usuarioLogueado.telefono;
            LabelUsuario.Text = usuarioLogueado.usuario;
            LabelPerfil.Text = usuarioLogueado.id_perfil.ToString();

        }

        // Método que se ejecuta cuando se dispara el evento PerfilActualizado
        private void OnPerfilActualizado(object sender, EventArgs e)
        {
            usuarioLogueado = usuarioVM.ObtenerUsuarioPorId(usuarioLogueado.id_usuario); 
            CargarDatosUsuario(); 
        }

        // Nueva función para recargar los datos del perfil al volver a la vista perfil
        private void RecargarDatosUsuario()
        {
            usuarioLogueado = usuarioVM.ObtenerUsuarioPorId(usuarioLogueado.id_usuario);
            CargarDatosUsuario();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            RecargarDatosUsuario(); 
        }
    }

}