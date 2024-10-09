namespace medilink.Views.citas
{
    partial class ReprogramarCita
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
            this.buttonCancelarAgenda = new System.Windows.Forms.Button();
            this.buttonAgendar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerCita = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSelecMedico = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxMotivo = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBuscarPaciente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNuevoUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancelarAgenda
            // 
            this.buttonCancelarAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.buttonCancelarAgenda.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarAgenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.buttonCancelarAgenda.Location = new System.Drawing.Point(449, 456);
            this.buttonCancelarAgenda.Name = "buttonCancelarAgenda";
            this.buttonCancelarAgenda.Size = new System.Drawing.Size(189, 53);
            this.buttonCancelarAgenda.TabIndex = 38;
            this.buttonCancelarAgenda.Text = "Cancelar";
            this.buttonCancelarAgenda.UseVisualStyleBackColor = false;
            // 
            // buttonAgendar
            // 
            this.buttonAgendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.buttonAgendar.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.buttonAgendar.Location = new System.Drawing.Point(254, 456);
            this.buttonAgendar.Name = "buttonAgendar";
            this.buttonAgendar.Size = new System.Drawing.Size(189, 53);
            this.buttonAgendar.TabIndex = 37;
            this.buttonAgendar.Text = "Reprogramar";
            this.buttonAgendar.UseVisualStyleBackColor = false;
            this.buttonAgendar.Click += new System.EventHandler(this.buttonAgendar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label4.Location = new System.Drawing.Point(482, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Seleccione fecha y hora de la consulta";
            // 
            // dateTimePickerCita
            // 
            this.dateTimePickerCita.Location = new System.Drawing.Point(485, 312);
            this.dateTimePickerCita.Name = "dateTimePickerCita";
            this.dateTimePickerCita.Size = new System.Drawing.Size(233, 20);
            this.dateTimePickerCita.TabIndex = 35;
            // 
            // comboBoxSelecMedico
            // 
            this.comboBoxSelecMedico.FormattingEnabled = true;
            this.comboBoxSelecMedico.Location = new System.Drawing.Point(485, 208);
            this.comboBoxSelecMedico.Name = "comboBoxSelecMedico";
            this.comboBoxSelecMedico.Size = new System.Drawing.Size(233, 21);
            this.comboBoxSelecMedico.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label3.Location = new System.Drawing.Point(482, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Seleccione profesional a cargo";
            // 
            // richTextBoxMotivo
            // 
            this.richTextBoxMotivo.Location = new System.Drawing.Point(171, 315);
            this.richTextBoxMotivo.Name = "richTextBoxMotivo";
            this.richTextBoxMotivo.Size = new System.Drawing.Size(233, 75);
            this.richTextBoxMotivo.TabIndex = 32;
            this.richTextBoxMotivo.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label2.Location = new System.Drawing.Point(168, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Motivo de la consulta";
            // 
            // comboBoxBuscarPaciente
            // 
            this.comboBoxBuscarPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBuscarPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxBuscarPaciente.FormattingEnabled = true;
            this.comboBoxBuscarPaciente.Location = new System.Drawing.Point(171, 208);
            this.comboBoxBuscarPaciente.Name = "comboBoxBuscarPaciente";
            this.comboBoxBuscarPaciente.Size = new System.Drawing.Size(233, 21);
            this.comboBoxBuscarPaciente.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(168, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Buscar paciente por DNI";
            // 
            // labelNuevoUsuario
            // 
            this.labelNuevoUsuario.AutoSize = true;
            this.labelNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.labelNuevoUsuario.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNuevoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.labelNuevoUsuario.Location = new System.Drawing.Point(315, 57);
            this.labelNuevoUsuario.Name = "labelNuevoUsuario";
            this.labelNuevoUsuario.Padding = new System.Windows.Forms.Padding(5);
            this.labelNuevoUsuario.Size = new System.Drawing.Size(276, 41);
            this.labelNuevoUsuario.TabIndex = 28;
            this.labelNuevoUsuario.Text = "Reprogramar Cita";
            // 
            // ReprogramarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 572);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancelarAgenda);
            this.Controls.Add(this.buttonAgendar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerCita);
            this.Controls.Add(this.comboBoxSelecMedico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxMotivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBuscarPaciente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNuevoUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReprogramarCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReprogramarCita";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelarAgenda;
        private System.Windows.Forms.Button buttonAgendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerCita;
        private System.Windows.Forms.ComboBox comboBoxSelecMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBuscarPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNuevoUsuario;
    }
}