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
using medilink.Views;

namespace medilink.Views.usuario
{
    public partial class EditarPerfil : Form
    {
        private UsuarioM usuarioOriginal;
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public EditarPerfil(UsuarioM usuario)
        {

            InitializeComponent();
            this.usuarioLogueado = usuario;
            this.usuarioOriginal = usuario;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);


            // Cargar los datos del usuario en los campos
            textBoxCorreo.Text = usuarioLogueado.correo;
            textBoxEditUsuario.Text = usuarioLogueado.usuario;
            textBoxEditDomicilio.Text = usuarioLogueado.direccion;
            textBoxEditTelefono.Text = usuarioLogueado.telefono;
            textBoxEditContraseña.Text = usuarioLogueado.contraseña;

            // Mostrar la foto si existe
            if (usuarioLogueado.foto != null)
            {
                pictureBoxEditPFP.Image = Image.FromStream(new MemoryStream(usuarioLogueado.foto));
            }
        }

        private void BEditarPFP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxEditPFP.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBoxEditPFP.Tag = openFileDialog.FileName; // Almacena la ruta de la nueva imagen temporalmente
                }
            }
        }

        private void buttonEliminarPFP_Click(object sender, EventArgs e)
        {
            pictureBoxEditPFP.Image = null;
            pictureBoxEditPFP.Tag = null;
        }


        public delegate void PerfilActualizadoEventHandler(object sender, EventArgs e);
        public event PerfilActualizadoEventHandler PerfilActualizado;
        private void buttonGuardarCambios_Click(object sender, EventArgs e)
        {
            
            byte[] foto = null;
            if (pictureBoxEditPFP.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxEditPFP.Image.Save(ms, pictureBoxEditPFP.Image.RawFormat);
                    foto = ms.ToArray();
                }
            }

            // Crea un nuevo objeto UsuarioM con los datos editados
            UsuarioM usuarioEditado = new UsuarioM
            {
                id_usuario = usuarioOriginal.id_usuario,
                usuario = textBoxEditUsuario.Text,
                foto = foto, 
                direccion = textBoxEditDomicilio.Text,
                telefono = textBoxEditTelefono.Text,
                correo = textBoxCorreo.Text,
                contraseña = textBoxEditContraseña.Text
            };

            
            bool resultado = usuarioVM.EditarPerfil(usuarioEditado, usuarioLogueado.id_usuario);

            if (resultado)
            {
                PerfilActualizado?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Perfil actualizado exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el perfil.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
