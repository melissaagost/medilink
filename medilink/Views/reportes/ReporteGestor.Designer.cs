﻿namespace medilink.Views.reportes
{
    partial class ReporteGestor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGestor));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelNuevoUsuario = new System.Windows.Forms.Label();
            this.PBAyuda = new System.Windows.Forms.PictureBox();
            this.labeLDNI = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartCitas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BGenerar = new System.Windows.Forms.Button();
            this.BExportar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.DTPInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPFin = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.CBMedico = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.lblResumen2 = new System.Windows.Forms.Label();
            this.lblResumen3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBAyuda)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNuevoUsuario
            // 
            this.labelNuevoUsuario.AutoSize = true;
            this.labelNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.labelNuevoUsuario.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNuevoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.labelNuevoUsuario.Location = new System.Drawing.Point(186, 33);
            this.labelNuevoUsuario.Name = "labelNuevoUsuario";
            this.labelNuevoUsuario.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelNuevoUsuario.Size = new System.Drawing.Size(505, 41);
            this.labelNuevoUsuario.TabIndex = 4;
            this.labelNuevoUsuario.Text = "Analice las citas del Centro Médico";
            // 
            // PBAyuda
            // 
            this.PBAyuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBAyuda.BackgroundImage")));
            this.PBAyuda.Location = new System.Drawing.Point(838, 12);
            this.PBAyuda.Name = "PBAyuda";
            this.PBAyuda.Size = new System.Drawing.Size(66, 62);
            this.PBAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PBAyuda.TabIndex = 16;
            this.PBAyuda.TabStop = false;
            // 
            // labeLDNI
            // 
            this.labeLDNI.AutoSize = true;
            this.labeLDNI.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLDNI.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labeLDNI.Location = new System.Drawing.Point(149, 100);
            this.labeLDNI.Name = "labeLDNI";
            this.labeLDNI.Size = new System.Drawing.Size(45, 13);
            this.labeLDNI.TabIndex = 17;
            this.labeLDNI.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(149, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fecha de Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(384, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha de fin";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.chartCitas);
            this.panel1.Location = new System.Drawing.Point(152, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 327);
            this.panel1.TabIndex = 20;
            // 
            // chartCitas
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCitas.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartCitas.Legends.Add(legend3);
            this.chartCitas.Location = new System.Drawing.Point(14, 14);
            this.chartCitas.Name = "chartCitas";
            this.chartCitas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series";
            this.chartCitas.Series.Add(series3);
            this.chartCitas.Size = new System.Drawing.Size(525, 301);
            this.chartCitas.TabIndex = 0;
            // 
            // BGenerar
            // 
            this.BGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BGenerar.BackgroundImage")));
            this.BGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BGenerar.Location = new System.Drawing.Point(722, 216);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(70, 74);
            this.BGenerar.TabIndex = 21;
            this.BGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BGenerar.UseVisualStyleBackColor = false;
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click_1);
            // 
            // BExportar
            // 
            this.BExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.BExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BExportar.BackgroundImage")));
            this.BExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BExportar.Location = new System.Drawing.Point(722, 296);
            this.BExportar.Name = "BExportar";
            this.BExportar.Size = new System.Drawing.Size(70, 74);
            this.BExportar.TabIndex = 22;
            this.BExportar.UseVisualStyleBackColor = false;
            this.BExportar.Click += new System.EventHandler(this.BExportar_Click_1);
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BLimpiar.BackgroundImage")));
            this.BLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BLimpiar.Location = new System.Drawing.Point(722, 376);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(72, 74);
            this.BLimpiar.TabIndex = 23;
            this.BLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click_1);
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(152, 116);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(121, 21);
            this.CBEstado.TabIndex = 24;
            // 
            // DTPInicio
            // 
            this.DTPInicio.Location = new System.Drawing.Point(152, 171);
            this.DTPInicio.Name = "DTPInicio";
            this.DTPInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPInicio.TabIndex = 25;
            // 
            // DTPFin
            // 
            this.DTPFin.Location = new System.Drawing.Point(387, 171);
            this.DTPFin.Name = "DTPFin";
            this.DTPFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFin.TabIndex = 26;
            // 
            // CBMedico
            // 
            this.CBMedico.FormattingEnabled = true;
            this.CBMedico.Location = new System.Drawing.Point(309, 116);
            this.CBMedico.Name = "CBMedico";
            this.CBMedico.Size = new System.Drawing.Size(121, 21);
            this.CBMedico.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(306, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Médico";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Italic);
            this.lblResumen.Location = new System.Drawing.Point(148, 589);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 17);
            this.lblResumen.TabIndex = 30;
            // 
            // lblResumen2
            // 
            this.lblResumen2.AutoSize = true;
            this.lblResumen2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen2.Location = new System.Drawing.Point(288, 589);
            this.lblResumen2.Name = "lblResumen2";
            this.lblResumen2.Size = new System.Drawing.Size(0, 18);
            this.lblResumen2.TabIndex = 31;
            // 
            // lblResumen3
            // 
            this.lblResumen3.AutoSize = true;
            this.lblResumen3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Italic);
            this.lblResumen3.Location = new System.Drawing.Point(543, 589);
            this.lblResumen3.Name = "lblResumen3";
            this.lblResumen3.Size = new System.Drawing.Size(0, 17);
            this.lblResumen3.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(288, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Mujeres y Hombres Atendidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 560);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Citas por mes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(543, 560);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Total de citas del médico";
            // 
            // ReporteGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(916, 646);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResumen3);
            this.Controls.Add(this.lblResumen2);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.CBMedico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DTPFin);
            this.Controls.Add(this.DTPInicio);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.BExportar);
            this.Controls.Add(this.BGenerar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labeLDNI);
            this.Controls.Add(this.PBAyuda);
            this.Controls.Add(this.labelNuevoUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReporteGestor";
            this.Text = "ReporteGestor";
            this.Load += new System.EventHandler(this.ReporteGestor_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.PBAyuda)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNuevoUsuario;
        private System.Windows.Forms.PictureBox PBAyuda;
        private System.Windows.Forms.Label labeLDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitas;
        private System.Windows.Forms.Button BGenerar;
        private System.Windows.Forms.Button BExportar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.DateTimePicker DTPInicio;
        private System.Windows.Forms.DateTimePicker DTPFin;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ComboBox CBMedico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblResumen2;
        private System.Windows.Forms.Label lblResumen3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}