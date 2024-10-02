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
    public partial class PaginaInicioForm : Form
    {
        public PaginaInicioForm()
        {
            InitializeComponent();
            InitializeCustomComponents(); // Inicializa los componentes personalizados
        }

        private void InitializeCustomComponents()
        {
            this.Size = new System.Drawing.Size(1300, 650);

            // Fondo de imagen
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Views\assets\imagenes\inicio.png");
            this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Eliminar la barra de título (incluyendo los botones de minimizar, maximizar y cerrar)
            this.FormBorderStyle = FormBorderStyle.None;

            // Crear TextBlock como Label en Windows Forms
            Label titleLabel = new Label
            {
                Text = "Tu salud, nuestra\nprioridad",
                Font = new System.Drawing.Font("Georgia", 55, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                AutoSize = true,
                Location = new System.Drawing.Point(580, 42),
                BackColor = System.Drawing.Color.Transparent, // Hacer el fondo transparente
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(titleLabel);

            // Subtítulo
            Label subtitleLabel = new Label
            {
                Text = "La solución integral para la gestión de salud y profesionales.",
                Font = new System.Drawing.Font("Verdana", 18),
                ForeColor = System.Drawing.Color.White,
                AutoSize = true,
                Location = new System.Drawing.Point(527, 223),
                BackColor = System.Drawing.Color.Transparent // Hacer el fondo transparente

            };
            this.Controls.Add(subtitleLabel);

            // Otros textos descriptivos
            Label easySchedulingLabel = new Label
            {
                Text = "Agendar un turno nunca fue tan fácil.",
                Font = new System.Drawing.Font("Verdana", 20, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(34, 77, 51),
                AutoSize = true,
                Location = new System.Drawing.Point(675, 410),
                BackColor = System.Drawing.Color.Transparent // Hacer el fondo transparente

            };
            this.Controls.Add(easySchedulingLabel);

            Label realTimeAvailabilityLabel = new Label
            {
                Text = "Con solo unos pocos clics, selecciona la especialidad y el\nprofesional que necesitas. La disponibilidad se actualiza en\ntiempo real, elegí el horario que más te convenga.",
                Font = new System.Drawing.Font("Verdana", 14),
                ForeColor = System.Drawing.Color.FromArgb(34, 77, 51),
                AutoSize = true,
                Location = new System.Drawing.Point(679, 445),
                BackColor = System.Drawing.Color.Transparent // Hacer el fondo transparente

            };
            this.Controls.Add(realTimeAvailabilityLabel);

            Label organizedInfoLabel = new Label
            {
                Text = "Toda tu información, organizada de manera intuitiva.",
                Font = new System.Drawing.Font("Verdana", 20, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(34, 77, 51),
                AutoSize = true,
                Location = new System.Drawing.Point(340, 532),
                BackColor = System.Drawing.Color.Transparent // Hacer el fondo transparente

            };
            this.Controls.Add(organizedInfoLabel);

            Label infoAccessLabel = new Label
            {
                Text = "Accede rápidamente a tus citas, historial médico y recordatorios\ndesde un panel de control diseñado para facilitar la navegación.\nEncuentra lo que necesitas sin complicaciones.",
                Font = new System.Drawing.Font("Verdana", 14),
                ForeColor = System.Drawing.Color.FromArgb(34, 77, 51),
                AutoSize = true,
                Location = new System.Drawing.Point(344, 565),
                BackColor = System.Drawing.Color.Transparent // Hacer el fondo transparente

            };
            this.Controls.Add(infoAccessLabel);

            // Botón de Iniciar Sesión
            Button loginButton = new Button
            {
                Text = "INICIAR SESION",
                Font = new System.Drawing.Font("Verdana", 15, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.FromArgb(64, 112, 83),
                Size = new System.Drawing.Size(280, 69),
                Location = new System.Drawing.Point(785, 284)
            };
            loginButton.Click += (sender, e) => {
                FormularioInicioSesion inicioSesionForm = new FormularioInicioSesion();
                inicioSesionForm.Show();
                this.Hide(); // Oculta la página actual
            };
            this.Controls.Add(loginButton);

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

        private void PaginaInicioForm_Load(object sender, EventArgs e)
        {

        }
    }
}