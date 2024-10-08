namespace medilink.Views.usuario
{
    partial class AdminGestor
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
            this.tabControlGestor = new System.Windows.Forms.TabControl();
            this.tabPageMedicos = new System.Windows.Forms.TabPage();
            this.dataGridViewMedicos = new System.Windows.Forms.DataGridView();
            this.CDNIMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellidoMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuarioMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStatusMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccionesMedicos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageRecepcionistas = new System.Windows.Forms.TabPage();
            this.dataGridViewRecepcionistas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusRecep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControlGestor.SuspendLayout();
            this.tabPageMedicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicos)).BeginInit();
            this.tabPageRecepcionistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepcionistas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(306, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestione sus Empleados";
            // 
            // tabControlGestor
            // 
            this.tabControlGestor.Controls.Add(this.tabPageMedicos);
            this.tabControlGestor.Controls.Add(this.tabPageRecepcionistas);
            this.tabControlGestor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlGestor.Location = new System.Drawing.Point(12, 50);
            this.tabControlGestor.Name = "tabControlGestor";
            this.tabControlGestor.SelectedIndex = 0;
            this.tabControlGestor.Size = new System.Drawing.Size(890, 505);
            this.tabControlGestor.TabIndex = 2;
            // 
            // tabPageMedicos
            // 
            this.tabPageMedicos.Controls.Add(this.dataGridViewMedicos);
            this.tabPageMedicos.Location = new System.Drawing.Point(4, 22);
            this.tabPageMedicos.Name = "tabPageMedicos";
            this.tabPageMedicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMedicos.Size = new System.Drawing.Size(882, 479);
            this.tabPageMedicos.TabIndex = 0;
            this.tabPageMedicos.Text = "Médicos";
            this.tabPageMedicos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMedicos
            // 
            this.dataGridViewMedicos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDNIMedico,
            this.CNombreMedico,
            this.CApellidoMedico,
            this.CUsuarioMedico,
            this.CStatusMedico,
            this.CAccionesMedicos});
            this.dataGridViewMedicos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMedicos.Name = "dataGridViewMedicos";
            this.dataGridViewMedicos.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewMedicos.TabIndex = 0;
            // 
            // CDNIMedico
            // 
            this.CDNIMedico.HeaderText = "DNI";
            this.CDNIMedico.Name = "CDNIMedico";
            this.CDNIMedico.ReadOnly = true;
            this.CDNIMedico.Width = 145;
            // 
            // CNombreMedico
            // 
            this.CNombreMedico.HeaderText = "Nombre";
            this.CNombreMedico.Name = "CNombreMedico";
            this.CNombreMedico.ReadOnly = true;
            this.CNombreMedico.Width = 145;
            // 
            // CApellidoMedico
            // 
            this.CApellidoMedico.HeaderText = "Apellido";
            this.CApellidoMedico.Name = "CApellidoMedico";
            this.CApellidoMedico.ReadOnly = true;
            this.CApellidoMedico.Width = 145;
            // 
            // CUsuarioMedico
            // 
            this.CUsuarioMedico.HeaderText = "Usuario";
            this.CUsuarioMedico.Name = "CUsuarioMedico";
            this.CUsuarioMedico.ReadOnly = true;
            this.CUsuarioMedico.Width = 145;
            // 
            // CStatusMedico
            // 
            this.CStatusMedico.HeaderText = "Dado de Baja";
            this.CStatusMedico.Name = "CStatusMedico";
            this.CStatusMedico.ReadOnly = true;
            this.CStatusMedico.Width = 126;
            // 
            // CAccionesMedicos
            // 
            this.CAccionesMedicos.HeaderText = "Acción";
            this.CAccionesMedicos.Name = "CAccionesMedicos";
            this.CAccionesMedicos.Text = "Dar de Baja";
            this.CAccionesMedicos.ToolTipText = "Desactive un usuario";
            this.CAccionesMedicos.UseColumnTextForButtonValue = true;
            this.CAccionesMedicos.Width = 126;
            // 
            // tabPageRecepcionistas
            // 
            this.tabPageRecepcionistas.Controls.Add(this.dataGridViewRecepcionistas);
            this.tabPageRecepcionistas.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecepcionistas.Name = "tabPageRecepcionistas";
            this.tabPageRecepcionistas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecepcionistas.Size = new System.Drawing.Size(882, 479);
            this.tabPageRecepcionistas.TabIndex = 1;
            this.tabPageRecepcionistas.Text = "Recepcionistas";
            this.tabPageRecepcionistas.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRecepcionistas
            // 
            this.dataGridViewRecepcionistas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewRecepcionistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecepcionistas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.StatusRecep,
            this.CAccion});
            this.dataGridViewRecepcionistas.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRecepcionistas.Name = "dataGridViewRecepcionistas";
            this.dataGridViewRecepcionistas.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewRecepcionistas.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 145;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 145;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 145;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 145;
            // 
            // StatusRecep
            // 
            this.StatusRecep.HeaderText = "Dado de baja";
            this.StatusRecep.Name = "StatusRecep";
            this.StatusRecep.ReadOnly = true;
            this.StatusRecep.Width = 126;
            // 
            // CAccion
            // 
            this.CAccion.HeaderText = "Acción";
            this.CAccion.Name = "CAccion";
            this.CAccion.Text = "Dar de Alta";
            this.CAccion.UseColumnTextForButtonValue = true;
            this.CAccion.Width = 126;
            // 
            // AdminGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 572);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlGestor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminGestor";
            this.Text = "AdminGestor";
            this.Load += new System.EventHandler(this.AdminGestor_Load);
            this.tabControlGestor.ResumeLayout(false);
            this.tabPageMedicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicos)).EndInit();
            this.tabPageRecepcionistas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepcionistas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlGestor;
        private System.Windows.Forms.TabPage tabPageMedicos;
        private System.Windows.Forms.DataGridView dataGridViewMedicos;
        private System.Windows.Forms.TabPage tabPageRecepcionistas;
        private System.Windows.Forms.DataGridView dataGridViewRecepcionistas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusRecep;
        private System.Windows.Forms.DataGridViewButtonColumn CAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDNIMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellidoMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuarioMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStatusMedico;
        private System.Windows.Forms.DataGridViewButtonColumn CAccionesMedicos;
    }
}