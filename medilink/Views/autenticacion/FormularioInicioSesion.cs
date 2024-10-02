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


namespace medilink.Views.autenticacion
{
    public partial class FormularioInicioSesion : Form
    {
        public FormularioInicioSesion()
        {
            InitializeComponent();
            InitializeCustomComponents(); // Inicializa los componentes personalizados
        }

        private void InitializeCustomComponents()
        {
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Text = "Iniciar Sesión";

            // Establecer el color de fondo
            //this.BackColor = System.Drawing.Color.FromArgb(64, 112, 83); // Color #407053
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Views\assets\imagenes\formulario_inicio.png");
            this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Eliminar la barra de título (incluyendo los botones de minimizar, maximizar y cerrar)
            this.FormBorderStyle = FormBorderStyle.None;

            // Contenedor rectangular con bordes redondeados
            RoundedPanel container = new RoundedPanel
            {
                BackColor = System.Drawing.Color.FromArgb(255, 253, 240),
                Width = 320,
                Height = 338,
                Location = new System.Drawing.Point((this.ClientSize.Width - 320) / 2, (this.ClientSize.Height - 338) / 2),
                Padding = new Padding(2)
            };

            this.Controls.Add(container);

            // Crear el FlowLayoutPanel
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0),
                Margin = new Padding(0)

            };

            // Título
            Label titleLabel = new Label
            {
                Text = "Iniciar Sesión",
                Font = new System.Drawing.Font("Georgia", 25, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(64, 112, 83),
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Margin = new Padding(0, 0, 0, 20);
            flowLayoutPanel.Controls.Add(titleLabel);


            // TextBox para el Usuario
            Label userLabel = new Label { Text = "Usuario", ForeColor = System.Drawing.Color.Gray };
            TextBox usernameTextBox = new TextBox { Width = 250, Margin = new Padding(0, 0, 0, 15) };
            flowLayoutPanel.Controls.Add(userLabel);
            flowLayoutPanel.Controls.Add(usernameTextBox);

            // TextBox para la Contraseña
            Label passwordLabel = new Label { Text = "Contraseña", ForeColor = System.Drawing.Color.Gray };
            TextBox passwordTextBox = new TextBox { Width = 250, Margin = new Padding(0, 0, 0, 15), UseSystemPasswordChar = true };
            flowLayoutPanel.Controls.Add(passwordLabel);
            flowLayoutPanel.Controls.Add(passwordTextBox);

            // Botón de Ingresar
            Button loginButton = new Button
            {
                Text = "Ingresar",
                Width = 250,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(64, 112, 83),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 5)
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
                Margin = new Padding(0, 10, 0, 0)
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

        private void Ingresar(string username, string password)
        {
            // Aquí puedes manejar la lógica de inicio de sesión
            MessageBox.Show($"Iniciando sesión con usuario: {username}");
        }
    }
}