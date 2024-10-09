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
            this.tabControlCitasRecep.SuspendLayout();
            this.tabPageActivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramadas)).BeginInit();
            this.tabPageCanceladas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(314, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestione las Citas";
            // 
            // tabControlCitasRecep
            // 
            this.tabControlCitasRecep.Controls.Add(this.tabPageActivas);
            this.tabControlCitasRecep.Controls.Add(this.tabPageCanceladas);
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
            // AdministrarCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(930, 611);
            this.ControlBox = false;
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
    }
}