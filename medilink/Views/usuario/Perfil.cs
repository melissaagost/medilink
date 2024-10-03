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

        public Perfil(Panel panelVistasDelMenu)
        {
            InitializeComponent();
            this.panelVistas = panelVistasDelMenu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new EditarPerfil();
            nuevaVistaForm.TopLevel = false;
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None;
            nuevaVistaForm.Dock = DockStyle.Fill;
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }
    }
}
