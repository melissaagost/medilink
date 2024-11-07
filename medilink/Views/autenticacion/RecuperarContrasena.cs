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
    public partial class RecuperarContrasena : Form
    {

        private CrudVM usuarioVM;
        public RecuperarContrasena()
        {
            InitializeComponent();
        }

        private void BSolicitud_Click(object sender, EventArgs e)
        {
            string credencial = TBEmailNum.Text.Trim();

            if (string.IsNullOrEmpty(credencial))
            {
                MessageBox.Show("Por favor, ingrese un correo o número de teléfono.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CrudVM tempCrudVM = new CrudVM();

            if (tempCrudVM.Validar(credencial))
            {
                MessageBox.Show("Credencial válida. Redirigiendo para restablecer contraseña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevaContrasena nuevaContrasenaForm = new NuevaContrasena(credencial);
                nuevaContrasenaForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("La credencial ingresada no existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }













        private void RecuperarContrasena_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
