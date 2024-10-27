namespace medilink.Views.citas
{
    partial class AdminCitasMedico
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
            this.tabControlCitasMedico = new System.Windows.Forms.TabControl();
            this.tabPageActivas = new System.Windows.Forms.TabPage();
            this.dataGridViewProgramadas = new System.Windows.Forms.DataGridView();
            this.CDNIPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombrePaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellidoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccionesPaciente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageCanceladas = new System.Windows.Forms.TabPage();
            this.dataGridViewCanceladas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccionCita = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCompletadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControlCitasMedico.SuspendLayout();
            this.tabPageActivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramadas)).BeginInit();
            this.tabPageCanceladas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanceladas)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(306, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gestione sus Citas";
            // 
            // tabControlCitasMedico
            // 
            this.tabControlCitasMedico.Controls.Add(this.tabPageActivas);
            this.tabControlCitasMedico.Controls.Add(this.tabPageCanceladas);
            this.tabControlCitasMedico.Controls.Add(this.tabPage1);
            this.tabControlCitasMedico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCitasMedico.Location = new System.Drawing.Point(12, 50);
            this.tabControlCitasMedico.Name = "tabControlCitasMedico";
            this.tabControlCitasMedico.SelectedIndex = 0;
            this.tabControlCitasMedico.Size = new System.Drawing.Size(890, 505);
            this.tabControlCitasMedico.TabIndex = 4;
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
            this.CApellidoPaciente,
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
            // CApellidoPaciente
            // 
            this.CApellidoPaciente.HeaderText = "Apellido";
            this.CApellidoPaciente.Name = "CApellidoPaciente";
            this.CApellidoPaciente.ReadOnly = true;
            this.CApellidoPaciente.Width = 167;
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
            this.tabPageCanceladas.Controls.Add(this.dataGridViewCanceladas);
            this.tabPageCanceladas.Location = new System.Drawing.Point(4, 22);
            this.tabPageCanceladas.Name = "tabPageCanceladas";
            this.tabPageCanceladas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCanceladas.Size = new System.Drawing.Size(882, 479);
            this.tabPageCanceladas.TabIndex = 1;
            this.tabPageCanceladas.Text = "Canceladas";
            this.tabPageCanceladas.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCanceladas
            // 
            this.dataGridViewCanceladas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewCanceladas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCanceladas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.CFecha,
            this.CAccionCita});
            this.dataGridViewCanceladas.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCanceladas.Name = "dataGridViewCanceladas";
            this.dataGridViewCanceladas.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewCanceladas.TabIndex = 0;
            this.dataGridViewCanceladas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCanceladas_CellContentClick);
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 167;
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
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewButtonColumn1});
            this.dataGridViewCompletadas.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCompletadas.Name = "dataGridViewCompletadas";
            this.dataGridViewCompletadas.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewCompletadas.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 167;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 167;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 167;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha - Hora";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 167;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Acción";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Dar de Alta";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 167;
            // 
            // AdminCitasMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 572);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlCitasMedico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminCitasMedico";
            this.Text = "AdminCitasMedico";
            this.Load += new System.EventHandler(this.AdminCitasMedico_Load);
            this.tabControlCitasMedico.ResumeLayout(false);
            this.tabPageActivas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramadas)).EndInit();
            this.tabPageCanceladas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanceladas)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlCitasMedico;
        private System.Windows.Forms.TabPage tabPageActivas;
        private System.Windows.Forms.DataGridView dataGridViewProgramadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDNIPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombrePaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellidoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaHora;
        private System.Windows.Forms.DataGridViewButtonColumn CAccionesPaciente;
        private System.Windows.Forms.TabPage tabPageCanceladas;
        private System.Windows.Forms.DataGridView dataGridViewCanceladas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewButtonColumn CAccionCita;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewCompletadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}