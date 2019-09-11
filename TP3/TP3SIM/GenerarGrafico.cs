using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP3SIM
{
    public partial class GenerarGrafico : Form
    {
        List<double> Valores;
        int cantPasos;
        public GenerarGrafico(List<double> _valores)
        {
            InitializeComponent();
            Valores = _valores;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Limpiar();
            if (!int.TryParse(txtCantPasos.Text, out cantPasos))
            {
                MessageBox.Show("Debe cargar la cantidad de pasos para poder graficar los valores", "Advertencia");
                return;
            }
            else if (cantPasos > Valores.Count)
            {
                MessageBox.Show("La cantidad de pasos no puede ser mayor a la cantidad de valores", "Advertencia");
                return;
            }

            CalcularGrafico();
        }

        private void CalcularGrafico()
        {


                List<double> ejeX = new List<double>();

                List<int> ejey = new List<int>();
                var valorMinimo = Valores.Min();
                var valorMaximo = Valores.Max();
                var paso = (valorMaximo - valorMinimo) / cantPasos;


                for (double i = valorMinimo; i < valorMaximo; i += paso)
                {

                    var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                    ejey.Add(valoresEnRango.Count);
                    ejeX.Add(i);


                }
                var chart = grafico.ChartAreas[0];
                chart.AxisX.IntervalType = DateTimeIntervalType.Number;
                chart.AxisX.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.IsEndLabelVisible = true;
                chart.AxisX.Minimum = ejeX.Min() - paso;
                chart.AxisX.Maximum = ejeX.Max() + paso;
                chart.AxisY.Minimum = 0;
                chart.AxisY.Maximum = ejey.Max() + 2;
                chart.AxisX.Interval = Math.Round(paso, 3);
                chart.AxisY.Interval = 1;
                grafico.Series["Numeros"].ChartType = SeriesChartType.Column;

                for (int i = 0; i < ejeX.Count; i++)
                {
                    grafico.Series["Numeros"].Points.AddXY(Math.Round(ejeX[i] + (paso / 2), 3), ejey[i]);
                }
            
            /* var valorMinimo = Valores.Min();
             var valorMaximo = Valores.Max();
             var paso = (valorMaximo - valorMinimo) / cantPasos;            

             for (double i = valorMinimo; i < valorMaximo; i+=paso)
             {
                 var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                 grafico.Series["Serie1"].Points.AddXY(i, valoresEnRango.Count);
             }            */
        }
        private void Limpiar()
        {
            foreach (var series in grafico.Series)
            {
                series.Points.Clear();
            }
            return;

        }

    }
}
