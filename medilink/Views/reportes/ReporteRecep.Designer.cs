﻿namespace medilink.Views.reportes
{
    partial class ReporteRecep
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteRecep));
            this.labelNuevoUsuario = new System.Windows.Forms.Label();
            this.labeLDNI = new System.Windows.Forms.Label();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPFin = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartCitas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BGenerar = new System.Windows.Forms.Button();
            this.BExportar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.PBAyuda = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.lblResumen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBAyuda)).BeginInit();
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
            this.labelNuevoUsuario.Padding = new System.Windows.Forms.Padding(5);
            this.labelNuevoUsuario.Size = new System.Drawing.Size(505, 41);
            this.labelNuevoUsuario.TabIndex = 3;
            this.labelNuevoUsuario.Text = "Analice las citas del Centro Médico";
            this.labelNuevoUsuario.Click += new System.EventHandler(this.labelNuevoUsuario_Click);
            // 
            // labeLDNI
            // 
            this.labeLDNI.AutoSize = true;
            this.labeLDNI.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLDNI.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labeLDNI.Location = new System.Drawing.Point(149, 100);
            this.labeLDNI.Name = "labeLDNI";
            this.labeLDNI.Size = new System.Drawing.Size(45, 13);
            this.labeLDNI.TabIndex = 4;
            this.labeLDNI.Text = "Estado";
            this.labeLDNI.Click += new System.EventHandler(this.labeLDNI_Click);
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(152, 116);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(121, 21);
            this.CBEstado.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(149, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
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
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha de fin";
            // 
            // DTPInicio
            // 
            this.DTPInicio.Location = new System.Drawing.Point(152, 171);
            this.DTPInicio.Name = "DTPInicio";
            this.DTPInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPInicio.TabIndex = 8;
            // 
            // DTPFin
            // 
            this.DTPFin.Location = new System.Drawing.Point(387, 171);
            this.DTPFin.Name = "DTPFin";
            this.DTPFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFin.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.chartCitas);
            this.panel1.Location = new System.Drawing.Point(152, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 327);
            this.panel1.TabIndex = 10;
            // 
            // chartCitas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCitas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCitas.Legends.Add(legend1);
            this.chartCitas.Location = new System.Drawing.Point(14, 14);
            this.chartCitas.Name = "chartCitas";
            this.chartCitas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series";
            this.chartCitas.Series.Add(series1);
            this.chartCitas.Size = new System.Drawing.Size(525, 301);
            this.chartCitas.TabIndex = 0;
            this.chartCitas.Text = "chart1";
            // 
            // BGenerar
            // 
            this.BGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BGenerar.BackgroundImage")));
            this.BGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BGenerar.Location = new System.Drawing.Point(722, 216);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(70, 74);
            this.BGenerar.TabIndex = 12;
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
            this.BExportar.TabIndex = 13;
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
            this.BLimpiar.TabIndex = 14;
            this.BLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click_1);
            // 
            // PBAyuda
            // 
            this.PBAyuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBAyuda.BackgroundImage")));
            this.PBAyuda.Location = new System.Drawing.Point(852, 12);
            this.PBAyuda.Name = "PBAyuda";
            this.PBAyuda.Size = new System.Drawing.Size(66, 62);
            this.PBAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PBAyuda.TabIndex = 15;
            this.PBAyuda.TabStop = false;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(149, 563);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(10, 13);
            this.lblResumen.TabIndex = 16;
            this.lblResumen.Text = " ";
            // 
            // ReporteRecep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(916, 598);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.PBAyuda);
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.BExportar);
            this.Controls.Add(this.BGenerar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DTPFin);
            this.Controls.Add(this.DTPInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.labeLDNI);
            this.Controls.Add(this.labelNuevoUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReporteRecep";
            this.Text = "ReporteRecep";
            this.Load += new System.EventHandler(this.ReporteRecep_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBAyuda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNuevoUsuario;
        private System.Windows.Forms.Label labeLDNI;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPInicio;
        private System.Windows.Forms.DateTimePicker DTPFin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitas;
        private System.Windows.Forms.Button BGenerar;
        private System.Windows.Forms.Button BExportar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.PictureBox PBAyuda;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblResumen;
    }
}