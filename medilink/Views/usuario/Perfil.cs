using medilink.Models;
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
        public Perfil(Panel panelVistasDelMenu, UsuarioM usuario)
        {
            InitializeComponent();
            this.panelVistas = panelVistasDelMenu;
            this.usuarioLogueado = usuario;
            CargarDatosUsuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
                panelVistas.Controls.Clear();
                Form nuevaVistaForm = new EditarPerfil(usuarioLogueado);
                nuevaVistaForm.TopLevel = false;
                nuevaVistaForm.FormBorderStyle = FormBorderStyle.None;
                nuevaVistaForm.Dock = DockStyle.Fill;
                panelVistas.Controls.Add(nuevaVistaForm);
                nuevaVistaForm.Show();
            }
            else
            {
                MessageBox.Show("El usuario no está inicializado correctamente.");
            }


        }

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
                pictureBoxPFP.Image = null; 
            }
        }
    }
}