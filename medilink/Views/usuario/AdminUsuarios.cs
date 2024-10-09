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

namespace medilink.Views.usuario
{ 
    public partial class AdminUsuarios : Form 
    {

        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        public AdminUsuarios( UsuarioM usuarioLogueado) 
        {
            InitializeComponent();
            this.Load += new EventHandler(AdminUsuarios_Load);
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);

        }

        private void CargarUsuariosActivos()
        {
            try
            {
                List<UsuarioM> todosLosUsuarios = usuarioVM.ListarUsuarios();

               
                List<UsuarioM> usuariosActivos = todosLosUsuarios
                    .Where(u => u.status != null && u.status.Trim().Equals("si", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                dataGridViewActivos.AutoGenerateColumns = false;

                dataGridViewActivos.DataSource = usuariosActivos;

                dataGridViewActivos.Columns.Clear(); 

                dataGridViewActivos.Columns.Add("dni", "DNI");
                dataGridViewActivos.Columns["dni"].DataPropertyName = "dni";

                dataGridViewActivos.Columns.Add("nombre", "Nombre");
                dataGridViewActivos.Columns["nombre"].DataPropertyName = "nombre";

                dataGridViewActivos.Columns.Add("apellido", "Apellido");
                dataGridViewActivos.Columns["apellido"].DataPropertyName = "apellido";

                dataGridViewActivos.Columns.Add("usuario", "Usuario");
                dataGridViewActivos.Columns["usuario"].DataPropertyName = "usuario";

                dataGridViewActivos.Columns.Add("id_perfil", "Perfil");
                dataGridViewActivos.Columns["id_perfil"].DataPropertyName = "id_perfil";

                
                DataGridViewButtonColumn btnBaja = new DataGridViewButtonColumn();
                btnBaja.HeaderText = "Acción";
                btnBaja.Text = "Dar de Baja";
                btnBaja.Name = "btnDarDeBaja";
                btnBaja.UseColumnTextForButtonValue = true;
                dataGridViewActivos.Columns.Add(btnBaja);

                dataGridViewActivos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_usuario",
                    HeaderText = "ID Usuario",
                    DataPropertyName = "id_usuario",  
                    Visible = false 
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }


        private void AdminUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuariosActivos();
            CargarUsuariosInactivos();
        }

        private void dataGridViewActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dataGridViewActivos.Columns["btnDarDeBaja"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewActivos.Rows[e.RowIndex].Cells["id_usuario"].Value);

                
                bool resultado = usuarioVM.DarDeBajaUsuario(id_usuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario dado de baja exitosamente.");
                    CargarUsuariosActivos(); // Refresca la grilla después de dar de baja
                    CargarUsuariosInactivos();
                }
                else
                {
                    MessageBox.Show("Error al dar de baja al usuario.");
                }
            }
        }

        //lo mismo pero para el grid de inactivos
        private void CargarUsuariosInactivos()
        {
            try
            {
                List<UsuarioM> todosLosUsuarios = usuarioVM.ListarUsuarios();
                List<UsuarioM> usuariosInactivos = todosLosUsuarios
                    .Where(u => u.status != null && u.status.Trim().Equals("no", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                dataGridViewInactivos.AutoGenerateColumns = false;

                dataGridViewInactivos.DataSource = usuariosInactivos;

                
                dataGridViewInactivos.Columns.Clear();

                
                dataGridViewInactivos.Columns.Add("dni", "DNI");
                dataGridViewInactivos.Columns["dni"].DataPropertyName = "dni";

                dataGridViewInactivos.Columns.Add("nombre", "Nombre");
                dataGridViewInactivos.Columns["nombre"].DataPropertyName = "nombre";

                dataGridViewInactivos.Columns.Add("apellido", "Apellido");
                dataGridViewInactivos.Columns["apellido"].DataPropertyName = "apellido";

                dataGridViewInactivos.Columns.Add("usuario", "Usuario");
                dataGridViewInactivos.Columns["usuario"].DataPropertyName = "usuario";

                dataGridViewInactivos.Columns.Add("id_perfil", "Perfil");
                dataGridViewInactivos.Columns["id_perfil"].DataPropertyName = "id_perfil";

                
                DataGridViewButtonColumn btnAlta = new DataGridViewButtonColumn();
                btnAlta.HeaderText = "Acción";
                btnAlta.Text = "Dar de Alta";
                btnAlta.Name = "btnDarDeAlta";
                btnAlta.UseColumnTextForButtonValue = true;
                dataGridViewInactivos.Columns.Add(btnAlta);

                // Agregar columna oculta con el ID del usuario
                dataGridViewInactivos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "id_usuarioI",
                    HeaderText = "ID UsuarioI",
                    DataPropertyName = "id_usuario",
                    Visible = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void dataGridViewInactivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewInactivos.Columns["btnDarDeAlta"].Index && e.RowIndex >= 0)
            {
                int id_usuario = Convert.ToInt32(dataGridViewInactivos.Rows[e.RowIndex].Cells["id_usuarioI"].Value);


                bool resultado = usuarioVM.DarDeAltaUsuario(id_usuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario dado de alta exitosamente.");
                    CargarUsuariosActivos();
                    CargarUsuariosInactivos(); // Refresca la grilla después de dar de baja
                }
                else
                {
                    MessageBox.Show("Error al dar de alta al usuario.");
                }
            }
        }

    }
}
