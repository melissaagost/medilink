namespace medilink.Views.citas
{
    partial class AdministrarCitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlCitasRecep = new System.Windows.Forms.TabControl();
            this.tabPageActivas = new System.Windows.Forms.TabPage();
            this.dataGridViewProgramadas = new System.Windows.Forms.DataGridView();
            this.CDNIPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombrePaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMedicoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccionesPaciente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageCanceladas = new System.Windows.Forms.TabPage();
            this.dataGridViewInactivos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMedicoPcancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccionCita = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCompletadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewPacientes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.comboBoxBuscarPaciente = new System.Windows.Forms.ComboBox();
            this.comboBoxBuscarMedico = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlCitasRecep.SuspendLayout();
            this.tabPageActivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramadas)).BeginInit();
            this.tabPageCanceladas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInactivos)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletadas)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(275, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestione Citas y Pacientes";
            // 
            // tabControlCitasRecep
            // 
            this.tabControlCitasRecep.Controls.Add(this.tabPageActivas);
            this.tabControlCitasRecep.Controls.Add(this.tabPageCanceladas);
            this.tabControlCitasRecep.Controls.Add(this.tabPage1);
            this.tabControlCitasRecep.Controls.Add(this.tabPage2);
            this.tabControlCitasRecep.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCitasRecep.Location = new System.Drawing.Point(20, 69);
            this.tabControlCitasRecep.Name = "tabControlCitasRecep";
            this.tabControlCitasRecep.SelectedIndex = 0;
            this.tabControlCitasRecep.Size = new System.Drawing.Size(890, 505);
            this.tabControlCitasRecep.TabIndex = 2;
            // 
            // tabPageActivas
            // 
            this.tabPageActivas.Controls.Add(this.dataGridViewProgramadas);
            this.tabPageActivas.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivas.Name = "tabPageActivas";
            this.tabPageActivas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivas.Size = new System.Drawing.Size(882, 479);
            this.tabPageActivas.TabIndex = 0;
            this.tabPageActivas.Text = "Activas";
            this.tabPageActivas.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProgramadas
            // 
            this.dataGridViewProgramadas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewProgramadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProgramadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDNIPaciente,
            this.CNombrePaciente,
            this.CMedicoPaciente,
            this.CFechaHora,
            this.CAccionesPaciente});
            this.dataGridViewProgramadas.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewProgramadas.Name = "dataGridViewProgramadas";
            this.dataGridViewProgramadas.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewProgramadas.TabIndex = 0;
            this.dataGridViewProgramadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProgramadas_CellContentClick);
            // 
            // CDNIPaciente
            // 
            this.CDNIPaciente.HeaderText = "DNI";
            this.CDNIPaciente.Name = "CDNIPaciente";
            this.CDNIPaciente.ReadOnly = true;
            this.CDNIPaciente.Width = 167;
            // 
            // CNombrePaciente
            // 
            this.CNombrePaciente.HeaderText = "Nombre";
            this.CNombrePaciente.Name = "CNombrePaciente";
            this.CNombrePaciente.ReadOnly = true;
            this.CNombrePaciente.Width = 167;
            // 
            // CMedicoPaciente
            // 
            this.CMedicoPaciente.HeaderText = "Médico";
            this.CMedicoPaciente.Name = "CMedicoPaciente";
            this.CMedicoPaciente.ReadOnly = true;
            this.CMedicoPaciente.Width = 167;
            // 
            // CFechaHora
            // 
            this.CFechaHora.HeaderText = "Fecha - Hora";
            this.CFechaHora.Name = "CFechaHora";
            this.CFechaHora.ReadOnly = true;
            this.CFechaHora.Width = 167;
            // 
            // CAccionesPaciente
            // 
            this.CAccionesPaciente.HeaderText = "Acción";
            this.CAccionesPaciente.Name = "CAccionesPaciente";
            this.CAccionesPaciente.Text = "Dar de Baja";
            this.CAccionesPaciente.ToolTipText = "Desactive un usuario";
            this.CAccionesPaciente.UseColumnTextForButtonValue = true;
            this.CAccionesPaciente.Width = 167;
            // 
            // tabPageCanceladas
            // 
            this.tabPageCanceladas.Controls.Add(this.dataGridViewInactivos);
            this.tabPageCanceladas.Location = new System.Drawing.Point(4, 22);
            this.tabPageCanceladas.Name = "tabPageCanceladas";
            this.tabPageCanceladas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCanceladas.Size = new System.Drawing.Size(882, 479);
            this.tabPageCanceladas.TabIndex = 1;
            this.tabPageCanceladas.Text = "Canceladas";
            this.tabPageCanceladas.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInactivos
            // 
            this.dataGridViewInactivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInactivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CMedicoPcancelado,
            this.CFecha,
            this.CAccionCita});
            this.dataGridViewInactivos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInactivos.Name = "dataGridViewInactivos";
            this.dataGridViewInactivos.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewInactivos.TabIndex = 0;
            this.dataGridViewInactivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInactivos_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 167;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 167;
            // 
            // CMedicoPcancelado
            // 
            this.CMedicoPcancelado.HeaderText = "Médico";
            this.CMedicoPcancelado.Name = "CMedicoPcancelado";
            this.CMedicoPcancelado.ReadOnly = true;
            this.CMedicoPcancelado.Width = 167;
            // 
            // CFecha
            // 
            this.CFecha.HeaderText = "Fecha - Hora";
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            this.CFecha.Width = 167;
            // 
            // CAccionCita
            // 
            this.CAccionCita.HeaderText = "Acción";
            this.CAccionCita.Name = "CAccionCita";
            this.CAccionCita.Text = "Dar de Alta";
            this.CAccionCita.UseColumnTextForButtonValue = true;
            this.CAccionCita.Width = 167;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewCompletadas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(882, 479);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Completadas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCompletadas
            // 
            this.dataGridViewCompletadas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewCompletadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompletadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewButtonColumn1});
            this.dataGridViewCompletadas.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCompletadas.Name = "dataGridViewCompletadas";
            this.dataGridViewCompletadas.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewCompletadas.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 167;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 167;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Médico";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 167;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Fecha - Hora";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 167;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Acción";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Dar de Alta";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 167;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewPacientes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(882, 479);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Pacientes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPacientes
            // 
            this.dataGridViewPacientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewButtonColumn2});
            this.dataGridViewPacientes.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPacientes.Name = "dataGridViewPacientes";
            this.dataGridViewPacientes.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewPacientes.TabIndex = 2;
            this.dataGridViewPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPacientes_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 145;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 145;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 145;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 145;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Dado de baja";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 126;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Acción";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Dar de Alta";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 126;
            // 
            // comboBoxBuscarPaciente
            // 
            this.comboBoxBuscarPaciente.FormattingEnabled = true;
            this.comboBoxBuscarPaciente.Location = new System.Drawing.Point(440, 602);
            this.comboBoxBuscarPaciente.Name = "comboBoxBuscarPaciente";
            this.comboBoxBuscarPaciente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscarPaciente.TabIndex = 35;
            // 
            // comboBoxBuscarMedico
            // 
            this.comboBoxBuscarMedico.FormattingEnabled = true;
            this.comboBoxBuscarMedico.Location = new System.Drawing.Point(149, 602);
            this.comboBoxBuscarMedico.Name = "comboBoxBuscarMedico";
            this.comboBoxBuscarMedico.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscarMedico.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(24, 605);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Buscar por médico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(308, 605);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Buscar por paciente:";
            // 
            // BBuscar
            // 
            this.BBuscar.Location = new System.Drawing.Point(611, 600);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(75, 23);
            this.BBuscar.TabIndex = 37;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(692, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Limpiar Filtros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdministrarCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(930, 670);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBuscarPaciente);
            this.Controls.Add(this.comboBoxBuscarMedico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlCitasRecep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministrarCitas";
            this.Text = "AdministrarCitas";
            this.Load += new System.EventHandler(this.AdministrarCitas_Load);
            this.tabControlCitasRecep.ResumeLayout(false);
            this.tabPageActivas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramadas)).EndInit();
            this.tabPageCanceladas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInactivos)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletadas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlCitasRecep;
        private System.Windows.Forms.TabPage tabPageActivas;
        private System.Windows.Forms.DataGridView dataGridViewProgramadas;
        private System.Windows.Forms.TabPage tabPageCanceladas;
        private System.Windows.Forms.DataGridView dataGridViewInactivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDNIPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombrePaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMedicoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaHora;
        private System.Windows.Forms.DataGridViewButtonColumn CAccionesPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMedicoPcancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewButtonColumn CAccionCita;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewCompletadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.ComboBox comboBoxBuscarPaciente;
        private System.Windows.Forms.ComboBox comboBoxBuscarMedico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button button1;
    }
}