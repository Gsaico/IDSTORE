namespace IDstore
{
    partial class Sensor_Temperatura_y_Humedad
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chtGrafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGrafico
            // 
            chartArea1.Name = "ChartArea1";
            this.chtGrafico.ChartAreas.Add(chartArea1);
            this.chtGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.chtGrafico.Legends.Add(legend1);
            this.chtGrafico.Location = new System.Drawing.Point(0, 0);
            this.chtGrafico.Name = "chtGrafico";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chtGrafico.Series.Add(series1);
            this.chtGrafico.Series.Add(series2);
            this.chtGrafico.Size = new System.Drawing.Size(1237, 900);
            this.chtGrafico.TabIndex = 0;
            this.chtGrafico.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Temperatura y Humedad";
            this.chtGrafico.Titles.Add(title1);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Sensor_Temperatura_y_Humedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 900);
            this.Controls.Add(this.chtGrafico);
            this.Name = "Sensor_Temperatura_y_Humedad";
            this.Text = "Sensor_Temperatura_y_Humedad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sensor_Temperatura_y_Humedad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtGrafico;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}