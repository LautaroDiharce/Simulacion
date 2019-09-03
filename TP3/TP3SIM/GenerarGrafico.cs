using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var valorMinimo = Valores.Min();
            var valorMaximo = Valores.Max();
            var paso = (valorMaximo - valorMinimo) / cantPasos;            

            for (double i = valorMinimo; i < valorMaximo; i+=paso)
            {
                var valoresEnRango = Valores.Where(x => x >= i && x < (i + paso)).ToList();
                grafico.Series["Serie1"].Points.AddXY(i, valoresEnRango.Count);
            }            
        }
    }
}
