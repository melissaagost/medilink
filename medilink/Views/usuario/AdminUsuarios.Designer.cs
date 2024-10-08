namespace medilink.Views.usuario
{
    partial class AdminUsuarios
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
            this.tabControlUsuarios = new System.Windows.Forms.TabControl();
            this.tabPageActivos = new System.Windows.Forms.TabPage();
            this.dataGridViewActivos = new System.Windows.Forms.DataGridView();
            this.CDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageInactivos = new System.Windows.Forms.TabPage();
            this.dataGridViewInactivos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlUsuarios.SuspendLayout();
            this.tabPageActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivos)).BeginInit();
            this.tabPageInactivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlUsuarios
            // 
            this.tabControlUsuarios.Controls.Add(this.tabPageActivos);
            this.tabControlUsuarios.Controls.Add(this.tabPageInactivos);
            this.tabControlUsuarios.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlUsuarios.Location = new System.Drawing.Point(12, 55);
            this.tabControlUsuarios.Name = "tabControlUsuarios";
            this.tabControlUsuarios.SelectedIndex = 0;
            this.tabControlUsuarios.Size = new System.Drawing.Size(890, 505);
            this.tabControlUsuarios.TabIndex = 0;
            // 
            // tabPageActivos
            // 
            this.tabPageActivos.Controls.Add(this.dataGridViewActivos);
            this.tabPageActivos.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivos.Name = "tabPageActivos";
            this.tabPageActivos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivos.Size = new System.Drawing.Size(882, 479);
            this.tabPageActivos.TabIndex = 0;
            this.tabPageActivos.Text = "Activos";
            this.tabPageActivos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewActivos
            // 
            this.dataGridViewActivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDNI,
            this.CNombre,
            this.CApellido,
            this.CUsuario,
            this.CPerfil,
            this.CAcciones});
            this.dataGridViewActivos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewActivos.Name = "dataGridViewActivos";
            this.dataGridViewActivos.Size = new System.Drawing.Size(876, 473);
            this.dataGridViewActivos.TabIndex = 0;
            this.dataGridViewActivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActivos_CellContentClick);
            // 
            // CDNI
            // 
            this.CDNI.HeaderText = "DNI";
            this.CDNI.Name = "CDNI";
            this.CDNI.ReadOnly = true;
            this.CDNI.Width = 145;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            this.CNombre.ReadOnly = true;
            this.CNombre.Width = 145;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.Name = "CApellido";
            this.CApellido.ReadOnly = true;
            this.CApellido.Width = 145;
            // 
            // CUsuario
            // 
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            this.CUsuario.Width = 145;
            // 
            // CPerfil
            // 
            this.CPerfil.HeaderText = "Perfil";
            this.CPerfil.Name = "CPerfil";
            this.CPerfil.ReadOnly = true;
            this.CPerfil.Width = 126;
            // 
            // CAcciones
            // 
            this.CAcciones.HeaderText = "Acción";
            this.CAcciones.Name = "CAcciones";
            this.CAcciones.Text = "Dar de Baja";
            this.CAcciones.ToolTipText = "Desactive un usuario";
            this.CAcciones.UseColumnTextForButtonValue = true;
            this.CAcciones.Width = 126;
            // 
            // tabPageInactivos
            // 
            this.tabPageInactivos.Controls.Add(this.dataGridViewInactivos);
            this.tabPageInactivos.Location = new System.Drawing.Point(4, 22);
            this.tabPageInactivos.Name = "tabPageInactivos";
            this.tabPageInactivos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInactivos.Size = new System.Drawing.Size(882, 479);
            this.tabPageInactivos.TabIndex = 1;
            this.tabPageInactivos.Text = "Inactivos";
            this.tabPageInactivos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInactivos
            // 
            this.dataGridViewInactivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.dataGridViewInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInactivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.CAccion});
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
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Perfil";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 126;
            // 
            // CAccion
            // 
            this.CAccion.HeaderText = "Acción";
            this.CAccion.Name = "CAccion";
            this.CAccion.Text = "Dar de Alta";
            this.CAccion.UseColumnTextForButtonValue = true;
            this.CAccion.Width = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(306, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestione los Usuarios";
            // 
            // AdminUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 572);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminUsuarios";
            this.Text = "AdminUsuarios";
            this.Load += new System.EventHandler(this.AdminUsuarios_Load);
            this.tabControlUsuarios.ResumeLayout(false);
            this.tabPageActivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivos)).EndInit();
            this.tabPageInactivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInactivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlUsuarios;
        private System.Windows.Forms.TabPage tabPageActivos;
        private System.Windows.Forms.TabPage tabPageInactivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewInactivos;
        private System.Windows.Forms.DataGridView dataGridViewActivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPerfil;
        private System.Windows.Forms.DataGridViewButtonColumn CAcciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn CAccion;
    }
}