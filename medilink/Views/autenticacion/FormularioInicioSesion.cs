using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO; // Necesario para Path.Combine
using medilink.Views.assets;
using medilink.BD;
using MySql.Data.MySqlClient;
using medilink.Models;
using medilink.Auth;
using System.Configuration;



namespace medilink.Views.autenticacion
{
    public partial class FormularioInicioSesion : Form
    {

        public static UsuarioM UsuarioActual { get; set; }
        private ConexionBD conexionBD;
        public FormularioInicioSesion()
        {
            InitializeComponent();
            InitializeCustomComponents();
            conexionBD = new ConexionBD();


        }

        private void InitializeCustomComponents()
        {
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Text = "Iniciar Sesión";

            // Establecer el color de fondo
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Views\assets\imagenes\formulario_inicio.png");
            this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

           
            this.StartPosition = FormStartPosition.CenterScreen;

            // Eliminar la barra de título (incluyendo los botones de minimizar, maximizar y cerrar)
            this.FormBorderStyle = FormBorderStyle.None;

            // Contenedor rectangular con bordes redondeados
            RoundedPanel container = new RoundedPanel
            {
                BackColor = System.Drawing.Color.FromArgb(255, 253, 240),
                Width = 330,
                Height = 338,
                Location = new System.Drawing.Point((this.ClientSize.Width - 320) / 2, (this.ClientSize.Height - 338) / 2),
                Padding = new Padding(7)
            };

            this.Controls.Add(container);

            // Crear el FlowLayoutPanel y centrar su contenido
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5),
                Margin = new Padding(5),
                Anchor = AnchorStyles.None // Esto centrará el contenido dentro del contenedor
            };

            // Título
            Label titleLabel = new Label
            {
                Text = "Iniciar Sesión",
                Font = new System.Drawing.Font("Georgia", 25, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(64, 112, 83),
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 0, 0, 20)
            };
            flowLayoutPanel.Controls.Add(titleLabel);


            // TextBox para el Usuario
            Label userLabel = new Label { Text = "Usuario", ForeColor = System.Drawing.Color.Gray, Anchor = AnchorStyles.None };
            TextBox usernameTextBox = new TextBox { Width = 250, Margin = new Padding(0, 0, 0, 15), Anchor = AnchorStyles.None };
            flowLayoutPanel.Controls.Add(userLabel);
            flowLayoutPanel.Controls.Add(usernameTextBox);

            // TextBox para la Contraseña
            Label passwordLabel = new Label { Text = "Contraseña", ForeColor = System.Drawing.Color.Gray , Anchor = AnchorStyles.None };
            TextBox passwordTextBox = new TextBox { Width = 250, Margin = new Padding(0, 0, 0, 15), UseSystemPasswordChar = true , Anchor = AnchorStyles.None };
            flowLayoutPanel.Controls.Add(passwordLabel);
            flowLayoutPanel.Controls.Add(passwordTextBox);
            passwordTextBox.KeyDown += new KeyEventHandler(passwordTextBox_KeyDown);


             void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Ingresar(usernameTextBox.Text, passwordTextBox.Text);  
                    e.SuppressKeyPress = true; 
                }
            }


            // Botón de Ingresar
            Button loginButton = new Button
            {
                Text = "Ingresar",
                Width = 250,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(64, 112, 83),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 5),
                Anchor = AnchorStyles.None

            };
            loginButton.Click += (sender, e) => Ingresar(usernameTextBox.Text, passwordTextBox.Text);
            flowLayoutPanel.Controls.Add(loginButton);


            // Botón de Olvidaste tu contraseña?
            Button forgotPasswordButton = new Button
            {
                Text = "Olvidaste tu contraseña?",
                Width = 250,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(64, 112, 83),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 0),
                Anchor = AnchorStyles.None
            };

            // Agregar el evento Click al botón
            forgotPasswordButton.Click += (sender, e) =>
            {
                RecuperarContrasena recuperarContrasenaForm = new RecuperarContrasena();
                recuperarContrasenaForm.Show(); // Muestra el formulario de RecuperarContraseña
            };

            // Aquí puedes agregar un evento para manejar la recuperación de contraseña
            flowLayoutPanel.Controls.Add(forgotPasswordButton);

            // Agregar el FlowLayoutPanel al RoundedPanel
            container.Controls.Add(flowLayoutPanel);

            // Botones de Minimizar y Cerrar
            Button minimizeButton = new Button
            {
                Text = "-",
                Font = new System.Drawing.Font("Verdana", 20, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.FromArgb(64, 112, 83),
                Size = new System.Drawing.Size(30, 30),
                Location = new System.Drawing.Point(1210, 10)
            };
            minimizeButton.Click += (sender, e) => this.WindowState = FormWindowState.Minimized;
            this.Controls.Add(minimizeButton);

            Button closeButton = new Button
            {
                Text = "X",
                Font = new System.Drawing.Font("Verdana", 16, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.FromArgb(64, 112, 83),
                Size = new System.Drawing.Size(30, 30),
                Location = new System.Drawing.Point(1250, 10)
            };
            closeButton.Click += (sender, e) => this.Close();
            this.Controls.Add(closeButton);
        }
        private void Ingresar(string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Los campos de usuario y contraseña no pueden estar vacíos ni contener espacios.");
                return;
            }

            var mode = ConfigurationManager.AppSettings["AuthMode"] ?? "LDAP";

            // ====== MODO LDAP (requerido por el TP) ======
            if (mode.Equals("LDAP", StringComparison.OrdinalIgnoreCase))
            {
                //try
                //{
                    var ldap = new medilink.Auth.LdapAuthService();

                    // 1) Autenticar contra AD
                    if (!ldap.ValidateUser(usuario, contraseña))
                    {
                        MessageBox.Show("Usuario o contraseña inválidos (AD).");
                        return;
                    }

                    // 2) Resolver rol por pertenencia a grupos AD
                    var rol = ldap.GetUserRole(usuario, contraseña);
                    if (rol == null)
                    {
                        MessageBox.Show("El usuario no tiene un grupo de la app en AD.");
                        return;
                    }

                    // 3) Sombra (opcional) para tu UI actual: crear UsuarioM mínimo
                    //    Mapea rol → id_perfil (1: Sistemas, 2: Gestor, 3: Médico, 4: Recepcionista)
                    int idPerfil = MapRolToPerfilId(rol);
                    if (idPerfil == 0)
                    {
                        MessageBox.Show("Rol no reconocido.");
                        return;
                    }

                    var usuarioEncontrado = new UsuarioM
                    {
                        usuario = usuario,
                        id_perfil = idPerfil,
                        status = "si"
                    };

                    FormularioInicioSesion.UsuarioActual = usuarioEncontrado;

                    // 4) Abrir menú según perfil (tu Menu ya acepta UsuarioM)
                    var menuForm = new Menu(usuarioEncontrado);
                    menuForm.ConfigurarMenuPorPerfil(usuarioEncontrado.id_perfil);
                    menuForm.Show();

                    this.Close();
                    return;
            }

            // ====== MODO LOCAL (fallback: tu lógica actual con MySQL) ======
            try
            {
                using (var conexionBD = new ConexionBD())
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        string query = "SELECT * FROM usuario WHERE usuario = @usuario LIMIT 1";
                        using (MySqlCommand comando = new MySqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@usuario", usuario);

                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    var usuarioEncontrado = UsuarioM.UserFromTableRow(reader);

                                    if (usuarioEncontrado.status.ToLower() == "no")
                                    {
                                        MessageBox.Show("Tu cuenta se encuentra dada de baja. Por favor, comunicate con Atención al Cliente.");
                                        return;
                                    }

                                    if (usuarioEncontrado.contraseña == contraseña)
                                    {
                                        FormularioInicioSesion.UsuarioActual = usuarioEncontrado;

                                        var menuForm = new Menu(usuarioEncontrado);
                                        menuForm.ConfigurarMenuPorPerfil(usuarioEncontrado.id_perfil);
                                        menuForm.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Contraseña incorrecta.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Usuario incorrecto.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo establecer conexión con la base de datos.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión (local): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado (local): " + ex.Message);
            }
        }

        private int MapRolToPerfilId(string rol)
        {
            switch (rol)
            {
                case "Sistemas": return 1;
                case "Gestor": return 2;
                case "Medico": return 3;
                case "Recepcionista": return 4;
                default: return 0;
            }
        }


    }
}