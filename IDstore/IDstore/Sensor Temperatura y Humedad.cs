using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDstore
{
    public partial class Sensor_Temperatura_y_Humedad : Form
    {
        public Sensor_Temperatura_y_Humedad()
        {
            InitializeComponent();
            chtGrafico.Legends.Clear();
            chtGrafico.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chtGrafico.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }
        int x = 1;
        int Humidity;
        int Temperature;
        int temp;

        private void Sensor_Temperatura_y_Humedad_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Interval = 2000;
            serialPort1.Open();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //read temperature and humidity every 10 seconds
            timer1.Interval = 2000;
            //read information from the serial port
            String dataFromArduino = serialPort1.ReadLine().ToString();
            //separete temperature and humidity and save in array
            String[] dataTempHumid = dataFromArduino.Split(',');
            //get temperature and humidity
            Humidity =      (int)(Math.Round(Convert.ToDecimal(dataTempHumid[0]), 0));
            Temperature =    (int)(Math.Round(Convert.ToDecimal(dataTempHumid[1]), 0));
            //draw temperature in the graphic
            // drawTemperature(Temperature);
           // txtHumidity.Text = Humidity.ToString() + " %";
          //  txtTemperatureCelsius.Text = Temperature.ToString() + " °C";

            StatusStrip control1 = (StatusStrip)this.MdiParent.Controls["statusStrip1"];
            control1.Items["tsslTemperatura"].Text = Temperature.ToString() + " °C";
            StatusStrip control2 = (StatusStrip)this.MdiParent.Controls["statusStrip1"];
            control2.Items["tsslHumedad"].Text = Humidity.ToString() + " %";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //  if (chtGrafico.Series[0].Points.Count > 5)
            // {
            //      chtGrafico.Series[0].Points.RemoveAt(0);
            //     chtGrafico.Update();  
            //}
            //  if (chtGrafico.Series[1].Points.Count > 5)
            //  {
            //      chtGrafico.Series[1].Points.RemoveAt(0);
            //      chtGrafico.Update();
            //  }
            temp = x++;
            chtGrafico.Series[0].Points.AddXY(temp, Humidity);
            chtGrafico.Series[1].Points.AddXY(temp, Temperature); 
        }
    }
}
