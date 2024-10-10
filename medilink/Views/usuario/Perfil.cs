using medilink.Models;
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
    public partial class Perfil : Form
    {
        private Panel panelVistas; // Define una variable para almacenar la referencia al panel

        private UsuarioM usuarioLogueado;
        public Perfil(Panel panelVistasDelMenu, UsuarioM usuario)
        {
            InitializeComponent();
            this.panelVistas = panelVistasDelMenu;
            this.usuarioLogueado = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado != null)
            {
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
    }
}
