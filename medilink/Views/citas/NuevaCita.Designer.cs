namespace medilink.Views.citas
{
    partial class NuevaCita
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
            this.labelNuevoUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBuscarPaciente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxMotivo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSelecMedico = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCita = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancelarAgenda = new System.Windows.Forms.Button();
            this.buttonAgendar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNuevoUsuario
            // 
            this.labelNuevoUsuario.AutoSize = true;
            this.labelNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.labelNuevoUsuario.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNuevoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.labelNuevoUsuario.Location = new System.Drawing.Point(331, 53);
            this.labelNuevoUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNuevoUsuario.Name = "labelNuevoUsuario";
            this.labelNuevoUsuario.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelNuevoUsuario.Size = new System.Drawing.Size(499, 51);
            this.labelNuevoUsuario.TabIndex = 1;
            this.labelNuevoUsuario.Text = "Programar una Nueva Cita";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(216, 197);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar paciente por DNI";
            // 
            // comboBoxBuscarPaciente
            // 
            this.comboBoxBuscarPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBuscarPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxBuscarPaciente.FormattingEnabled = true;
            this.comboBoxBuscarPaciente.Location = new System.Drawing.Point(220, 233);
            this.comboBoxBuscarPaciente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBuscarPaciente.Name = "comboBoxBuscarPaciente";
            this.comboBoxBuscarPaciente.Size = new System.Drawing.Size(309, 24);
            this.comboBoxBuscarPaciente.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label2.Location = new System.Drawing.Point(216, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Motivo de la consulta";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBoxMotivo
            // 
            this.richTextBoxMotivo.Location = new System.Drawing.Point(220, 364);
            this.richTextBoxMotivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxMotivo.Name = "richTextBoxMotivo";
            this.richTextBoxMotivo.Size = new System.Drawing.Size(309, 91);
            this.richTextBoxMotivo.TabIndex = 6;
            this.richTextBoxMotivo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label3.Location = new System.Drawing.Point(635, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione profesional a cargo";
            // 
            // comboBoxSelecMedico
            // 
            this.comboBoxSelecMedico.FormattingEnabled = true;
            this.comboBoxSelecMedico.Location = new System.Drawing.Point(639, 233);
            this.comboBoxSelecMedico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSelecMedico.Name = "comboBoxSelecMedico";
            this.comboBoxSelecMedico.Size = new System.Drawing.Size(309, 24);
            this.comboBoxSelecMedico.TabIndex = 8;
            // 
            // dateTimePickerCita
            // 
            this.dateTimePickerCita.Location = new System.Drawing.Point(639, 361);
            this.dateTimePickerCita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerCita.Name = "dateTimePickerCita";
            this.dateTimePickerCita.Size = new System.Drawing.Size(309, 22);
            this.dateTimePickerCita.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.label4.Location = new System.Drawing.Point(635, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Seleccione fecha y hora de la consulta";
            // 
            // buttonCancelarAgenda
            // 
            this.buttonCancelarAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.buttonCancelarAgenda.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarAgenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.buttonCancelarAgenda.Location = new System.Drawing.Point(600, 540);
            this.buttonCancelarAgenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancelarAgenda.Name = "buttonCancelarAgenda";
            this.buttonCancelarAgenda.Size = new System.Drawing.Size(211, 65);
            this.buttonCancelarAgenda.TabIndex = 27;
            this.buttonCancelarAgenda.Text = "Cancelar";
            this.buttonCancelarAgenda.UseVisualStyleBackColor = false;
            // 
            // buttonAgendar
            // 
            this.buttonAgendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.buttonAgendar.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.buttonAgendar.Location = new System.Drawing.Point(381, 540);
            this.buttonAgendar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAgendar.Name = "buttonAgendar";
            this.buttonAgendar.Size = new System.Drawing.Size(211, 65);
            this.buttonAgendar.TabIndex = 26;
            this.buttonAgendar.Text = "Agendar";
            this.buttonAgendar.UseVisualStyleBackColor = false;
            this.buttonAgendar.Click += new System.EventHandler(this.buttonAgendar_Click);
            // 
            // NuevaCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1219, 704);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NuevaCita";
            this.Text = "NuevaCita";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNuevoUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBuscarPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxMotivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSelecMedico;
        private System.Windows.Forms.DateTimePicker dateTimePickerCita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancelarAgenda;
        private System.Windows.Forms.Button buttonAgendar;
    }
}