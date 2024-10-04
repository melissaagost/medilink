using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using medilink.Views.usuario;
using medilink.Views.citas;
//using medilink.Views.reportes;
using medilink.Views.autenticacion;
using medilink.Models;
using MySqlX.XDevAPI;


namespace medilink.Views.autenticacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BPerfil = new System.Windows.Forms.Button();
            this.Bcerrar = new System.Windows.Forms.Button();
            this.BReportesGestor = new System.Windows.Forms.Button();
            this.BAdminGestor = new System.Windows.Forms.Button();
            this.BReporteMedico = new System.Windows.Forms.Button();
            this.BAdminMedico = new System.Windows.Forms.Button();
            this.BAdminRecep = new System.Windows.Forms.Button();
            this.BReportes = new System.Windows.Forms.Button();
            this.BNuevoPaciente = new System.Windows.Forms.Button();
            this.BNuevaCita = new System.Windows.Forms.Button();
            this.BBackup = new System.Windows.Forms.Button();
            this.BAdminUsuarios = new System.Windows.Forms.Button();
            this.BNuevoUsuario = new System.Windows.Forms.Button();
            this.panelVistas = new System.Windows.Forms.Panel();
            this.BCambiarPerfil = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.panelMenu.Controls.Add(this.BCambiarPerfil);
            this.panelMenu.Controls.Add(this.BPerfil);
            this.panelMenu.Controls.Add(this.Bcerrar);
            this.panelMenu.Controls.Add(this.BReportesGestor);
            this.panelMenu.Controls.Add(this.BAdminGestor);
            this.panelMenu.Controls.Add(this.BReporteMedico);
            this.panelMenu.Controls.Add(this.BAdminMedico);
            this.panelMenu.Controls.Add(this.BAdminRecep);
            this.panelMenu.Controls.Add(this.BReportes);
            this.panelMenu.Controls.Add(this.BNuevoPaciente);
            this.panelMenu.Controls.Add(this.BNuevaCita);
            this.panelMenu.Controls.Add(this.BBackup);
            this.panelMenu.Controls.Add(this.BAdminUsuarios);
            this.panelMenu.Controls.Add(this.BNuevoUsuario);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(241, 722);
            this.panelMenu.TabIndex = 0;
            // 
            // BPerfil
            // 
            this.BPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.BPerfil.FlatAppearance.BorderSize = 0;
            this.BPerfil.Image = ((System.Drawing.Image)(resources.GetObject("BPerfil.Image")));
            this.BPerfil.Location = new System.Drawing.Point(70, 663);
            this.BPerfil.Name = "BPerfil";
            this.BPerfil.Size = new System.Drawing.Size(61, 56);
            this.BPerfil.TabIndex = 12;
            this.BPerfil.UseVisualStyleBackColor = false;
            this.BPerfil.Click += new System.EventHandler(this.BPerfil_Click);
            // 
            // Bcerrar
            // 
            this.Bcerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.Bcerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.Bcerrar.FlatAppearance.BorderSize = 0;
            this.Bcerrar.Image = ((System.Drawing.Image)(resources.GetObject("Bcerrar.Image")));
            this.Bcerrar.Location = new System.Drawing.Point(3, 663);
            this.Bcerrar.Name = "Bcerrar";
            this.Bcerrar.Size = new System.Drawing.Size(61, 56);
            this.Bcerrar.TabIndex = 11;
            this.Bcerrar.UseVisualStyleBackColor = false;
            this.Bcerrar.Click += new System.EventHandler(this.Bcerrar_Click);
            // 
            // BReportesGestor
            // 
            this.BReportesGestor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BReportesGestor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BReportesGestor.FlatAppearance.BorderSize = 3;
            this.BReportesGestor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BReportesGestor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BReportesGestor.Image = ((System.Drawing.Image)(resources.GetObject("BReportesGestor.Image")));
            this.BReportesGestor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BReportesGestor.Location = new System.Drawing.Point(12, 612);
            this.BReportesGestor.Name = "BReportesGestor";
            this.BReportesGestor.Size = new System.Drawing.Size(211, 54);
            this.BReportesGestor.TabIndex = 10;
            this.BReportesGestor.Text = "          Reportes";
            this.BReportesGestor.UseVisualStyleBackColor = false;
            this.BReportesGestor.Click += new System.EventHandler(this.BReportesGestor_Click);
            // 
            // BAdminGestor
            // 
            this.BAdminGestor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BAdminGestor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BAdminGestor.FlatAppearance.BorderSize = 3;
            this.BAdminGestor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BAdminGestor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BAdminGestor.Image = ((System.Drawing.Image)(resources.GetObject("BAdminGestor.Image")));
            this.BAdminGestor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAdminGestor.Location = new System.Drawing.Point(12, 552);
            this.BAdminGestor.Name = "BAdminGestor";
            this.BAdminGestor.Size = new System.Drawing.Size(211, 54);
            this.BAdminGestor.TabIndex = 9;
            this.BAdminGestor.Text = "          Administrar";
            this.BAdminGestor.UseVisualStyleBackColor = false;
            this.BAdminGestor.Click += new System.EventHandler(this.BAdminGestor_Click);
            // 
            // BReporteMedico
            // 
            this.BReporteMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BReporteMedico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BReporteMedico.FlatAppearance.BorderSize = 3;
            this.BReporteMedico.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BReporteMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BReporteMedico.Image = ((System.Drawing.Image)(resources.GetObject("BReporteMedico.Image")));
            this.BReporteMedico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BReporteMedico.Location = new System.Drawing.Point(12, 492);
            this.BReporteMedico.Name = "BReporteMedico";
            this.BReporteMedico.Size = new System.Drawing.Size(211, 54);
            this.BReporteMedico.TabIndex = 8;
            this.BReporteMedico.Text = "          Reportes";
            this.BReporteMedico.UseVisualStyleBackColor = false;
            this.BReporteMedico.Click += new System.EventHandler(this.BReporteMedico_Click);
            // 
            // BAdminMedico
            // 
            this.BAdminMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BAdminMedico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BAdminMedico.FlatAppearance.BorderSize = 3;
            this.BAdminMedico.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BAdminMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BAdminMedico.Image = ((System.Drawing.Image)(resources.GetObject("BAdminMedico.Image")));
            this.BAdminMedico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAdminMedico.Location = new System.Drawing.Point(12, 432);
            this.BAdminMedico.Name = "BAdminMedico";
            this.BAdminMedico.Size = new System.Drawing.Size(211, 54);
            this.BAdminMedico.TabIndex = 7;
            this.BAdminMedico.Text = "          Administrar";
            this.BAdminMedico.UseVisualStyleBackColor = false;
            this.BAdminMedico.Click += new System.EventHandler(this.BAdminMedico_Click);
            // 
            // BAdminRecep
            // 
            this.BAdminRecep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BAdminRecep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BAdminRecep.FlatAppearance.BorderSize = 3;
            this.BAdminRecep.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BAdminRecep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BAdminRecep.Image = ((System.Drawing.Image)(resources.GetObject("BAdminRecep.Image")));
            this.BAdminRecep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAdminRecep.Location = new System.Drawing.Point(12, 372);
            this.BAdminRecep.Name = "BAdminRecep";
            this.BAdminRecep.Size = new System.Drawing.Size(211, 54);
            this.BAdminRecep.TabIndex = 6;
            this.BAdminRecep.Text = "          Administrar";
            this.BAdminRecep.UseVisualStyleBackColor = false;
            this.BAdminRecep.Click += new System.EventHandler(this.BAdminRecep_Click);
            // 
            // BReportes
            // 
            this.BReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BReportes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BReportes.FlatAppearance.BorderSize = 3;
            this.BReportes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BReportes.Image = ((System.Drawing.Image)(resources.GetObject("BReportes.Image")));
            this.BReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BReportes.Location = new System.Drawing.Point(12, 312);
            this.BReportes.Name = "BReportes";
            this.BReportes.Size = new System.Drawing.Size(211, 54);
            this.BReportes.TabIndex = 5;
            this.BReportes.Text = "          Reportes";
            this.BReportes.UseVisualStyleBackColor = false;
            this.BReportes.Click += new System.EventHandler(this.BReportes_Click);
            // 
            // BNuevoPaciente
            // 
            this.BNuevoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BNuevoPaciente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BNuevoPaciente.FlatAppearance.BorderSize = 3;
            this.BNuevoPaciente.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BNuevoPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BNuevoPaciente.Image = ((System.Drawing.Image)(resources.GetObject("BNuevoPaciente.Image")));
            this.BNuevoPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevoPaciente.Location = new System.Drawing.Point(12, 252);
            this.BNuevoPaciente.Name = "BNuevoPaciente";
            this.BNuevoPaciente.Size = new System.Drawing.Size(211, 54);
            this.BNuevoPaciente.TabIndex = 4;
            this.BNuevoPaciente.Text = "          Nuevo Paciente";
            this.BNuevoPaciente.UseVisualStyleBackColor = false;
            this.BNuevoPaciente.Click += new System.EventHandler(this.BNuevoPaciente_Click);
            // 
            // BNuevaCita
            // 
            this.BNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BNuevaCita.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BNuevaCita.FlatAppearance.BorderSize = 3;
            this.BNuevaCita.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BNuevaCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BNuevaCita.Image = ((System.Drawing.Image)(resources.GetObject("BNuevaCita.Image")));
            this.BNuevaCita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevaCita.Location = new System.Drawing.Point(12, 192);
            this.BNuevaCita.Name = "BNuevaCita";
            this.BNuevaCita.Size = new System.Drawing.Size(211, 54);
            this.BNuevaCita.TabIndex = 3;
            this.BNuevaCita.Text = "          Nueva Cita";
            this.BNuevaCita.UseVisualStyleBackColor = false;
            this.BNuevaCita.Click += new System.EventHandler(this.BNuevaCita_Click);
            // 
            // BBackup
            // 
            this.BBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BBackup.FlatAppearance.BorderSize = 3;
            this.BBackup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BBackup.Image = ((System.Drawing.Image)(resources.GetObject("BBackup.Image")));
            this.BBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBackup.Location = new System.Drawing.Point(12, 132);
            this.BBackup.Name = "BBackup";
            this.BBackup.Size = new System.Drawing.Size(211, 54);
            this.BBackup.TabIndex = 2;
            this.BBackup.Text = "        Backup";
            this.BBackup.UseVisualStyleBackColor = false;
            this.BBackup.Click += new System.EventHandler(this.BBackup_Click);
            // 
            // BAdminUsuarios
            // 
            this.BAdminUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BAdminUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BAdminUsuarios.FlatAppearance.BorderSize = 3;
            this.BAdminUsuarios.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BAdminUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BAdminUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("BAdminUsuarios.Image")));
            this.BAdminUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAdminUsuarios.Location = new System.Drawing.Point(12, 72);
            this.BAdminUsuarios.Name = "BAdminUsuarios";
            this.BAdminUsuarios.Size = new System.Drawing.Size(211, 54);
            this.BAdminUsuarios.TabIndex = 1;
            this.BAdminUsuarios.Text = "          Administrar";
            this.BAdminUsuarios.UseVisualStyleBackColor = false;
            this.BAdminUsuarios.Click += new System.EventHandler(this.BAdminUsuarios_Click);
            // 
            // BNuevoUsuario
            // 
            this.BNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(244)))), ((int)(((byte)(223)))));
            this.BNuevoUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BNuevoUsuario.FlatAppearance.BorderSize = 3;
            this.BNuevoUsuario.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BNuevoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BNuevoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("BNuevoUsuario.Image")));
            this.BNuevoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevoUsuario.Location = new System.Drawing.Point(12, 12);
            this.BNuevoUsuario.Name = "BNuevoUsuario";
            this.BNuevoUsuario.Size = new System.Drawing.Size(211, 54);
            this.BNuevoUsuario.TabIndex = 0;
            this.BNuevoUsuario.Text = "          Nuevo Usuario";
            this.BNuevoUsuario.UseVisualStyleBackColor = false;
            this.BNuevoUsuario.Click += new System.EventHandler(this.BNuevoUsuario_Click);
            // 
            // panelVistas
            // 
            this.panelVistas.Location = new System.Drawing.Point(256, 12);
            this.panelVistas.Name = "panelVistas";
            this.panelVistas.Size = new System.Drawing.Size(916, 697);
            this.panelVistas.TabIndex = 1;
            // 
            // BCambiarPerfil
            // 
            this.BCambiarPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.BCambiarPerfil.FlatAppearance.BorderSize = 0;
            this.BCambiarPerfil.Image = ((System.Drawing.Image)(resources.GetObject("BCambiarPerfil.Image")));
            this.BCambiarPerfil.Location = new System.Drawing.Point(137, 663);
            this.BCambiarPerfil.Name = "BCambiarPerfil";
            this.BCambiarPerfil.Size = new System.Drawing.Size(61, 56);
            this.BCambiarPerfil.TabIndex = 13;
            this.BCambiarPerfil.UseVisualStyleBackColor = false;
            this.BCambiarPerfil.Click += new System.EventHandler(this.BCambiarPerfil_Click);
            // 
            // Menu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.ClientSize = new System.Drawing.Size(1184, 721);
            this.ControlBox = false;
            this.Controls.Add(this.panelVistas);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //BOTONES SISTEMAS
        private void BNuevoUsuario_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new NuevoUsuario();
            nuevaVistaForm.TopLevel = false; // Evita que sea una ventana separada
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; // Sin bordes ni títulos
            nuevaVistaForm.Dock = DockStyle.Fill; // Hace que llene el panel
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BAdminUsuarios_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new AdminUsuarios();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None;
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BBackup_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new Backup();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None;
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        //BOTONES RECEPCIONISTA
        private void BNuevaCita_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new NuevaCita();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BNuevoPaciente_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new NuevoPaciente();
            nuevaVistaForm.TopLevel = false;
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BAdminRecep_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new AdministrarCitas();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BReportes_Click(object sender, EventArgs e)
        {

        }

        //BOTONES MÉDICO
        private void BAdminMedico_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new AdminCitasMedico();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BReporteMedico_Click(object sender, EventArgs e)
        {

        }

        //BOTONES GESTOR
        private void BAdminGestor_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new AdminGestor();
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        private void BReportesGestor_Click(object sender, EventArgs e)
        {

        }

        //BOTONES CERRAR Y VER PERFIL
        private void Bcerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void BPerfil_Click(object sender, EventArgs e)
        {
            panelVistas.Controls.Clear();
            Form nuevaVistaForm = new Perfil(panelVistas);
            nuevaVistaForm.TopLevel = false; 
            nuevaVistaForm.FormBorderStyle = FormBorderStyle.None; 
            nuevaVistaForm.Dock = DockStyle.Fill; 
            panelVistas.Controls.Add(nuevaVistaForm);
            nuevaVistaForm.Show();
        }

        //FILTRAMOS BOTONES SEGUN ROL
        internal void ConfigurarMenuPorPerfil(int id_perfil)
        {
            
            BNuevoUsuario.Visible = false; //sistemas
            BBackup.Visible = false;
            BAdminUsuarios.Visible = false;
            BAdminGestor.Visible = false; //gestor
            BReportesGestor.Visible = false;
            BAdminMedico.Visible = false;  //medico 
            BReporteMedico.Visible = false;
            BNuevaCita.Visible = false;  //recep
            BNuevoPaciente.Visible = false;
            BReportes.Visible = false;  
            BAdminRecep.Visible = false;



            switch (id_perfil)
            {
                case 1: 
                    BNuevoUsuario.Visible = true; 
                    BBackup.Visible = true;
                    BAdminUsuarios.Visible = true;
                    break;
                case 2: 
                    BAdminGestor.Visible = true; 
                    BReportesGestor.Visible = true;
                    break;
                case 3: 
                    BAdminMedico.Visible = true;
                    BReporteMedico.Visible = true;
                    break;
                case 4: 
                    BNuevaCita.Visible = true;
                    BNuevoPaciente.Visible = true;
                    BReportes.Visible = true;
                    BAdminRecep.Visible = true;
                    break;
                default:
                    MessageBox.Show("Perfil no reconocido");
                    break;
            }
        }

        private void BCambiarPerfil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cambiar de perfil?", "Cambiar de perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormularioInicioSesion.UsuarioActual = null;
                FormularioInicioSesion formLogin = new FormularioInicioSesion();
                formLogin.Show();
                this.Close();
            }
        }
    }
}
