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

namespace medilink.Views.citas
{
    public partial class NuevaCita : Form
    {
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;

        public NuevaCita(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
