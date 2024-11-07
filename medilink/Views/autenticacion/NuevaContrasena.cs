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

namespace medilink.Views.autenticacion
{
    public partial class NuevaContrasena : Form
    {
        private CrudVM usuarioVM;

        private string credencial;
        public NuevaContrasena(string credencial)
        {
            InitializeComponent();
            this.credencial = credencial;
            usuarioVM = new CrudVM();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BReestablecer_Click(object sender, EventArgs e)
        {
            
            string nuevaContrasena = TBPass.Text.Trim();

            if (string.IsNullOrEmpty(nuevaContrasena))
            {
                MessageBox.Show("Por favor, ingrese una nueva contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuarioVM.Cambiar(credencial, nuevaContrasena))
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("La nueva contraseña no puede ser la misma que la actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






























        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TBPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
