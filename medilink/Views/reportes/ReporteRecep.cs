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

namespace medilink.Views.reportes
{
    public partial class ReporteRecep : Form
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public ReporteRecep(UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
        }
    }
}
