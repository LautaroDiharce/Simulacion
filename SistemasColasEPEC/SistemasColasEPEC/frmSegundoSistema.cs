﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemasColasEPEC.Clases;

namespace SistemasColasEPEC
{
    public partial class frmSegundoSistema : Form
    {
        int simulaciones;
        Simulador simulador;
        IServiciable servidorRecepcion;
        IServiciable ServidorDar1;
        IServiciable ServidorDar2;
        IServiciable servidorBalanza;
        IColeable colaLlegada;
        IColeable ColaBalanza;
        IColeable colaDarsena;
        double promedioClienteEnSistema;
        List<Tester> testers;
        double tiempoEspera;
        public frmSegundoSistema()
        {
            InitializeComponent();
            simulador = new Simulador();
            testers = new List<Tester>();
            txtSimulaciones.Text = "30";
            txtSimulaciones.Enabled = false;
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            int parseo;
            bool aceptacion = int.TryParse(txtSimulaciones.Text, out parseo);
            if (!aceptacion)
            {
                MessageBox.Show("Ingrese una cantidad de simulaciones valida", "Mistake");
            }
            else
            {
                btnSimular.Enabled = false;
                txtCamionesNoAtendidos.Enabled = false;
                txtCamionesPromedioXDia.Enabled = false;
                txtPromedioEnSistema.Enabled = false;
                txtCantidadSimulaciones.Enabled = false;
                txtSimulaciones.Enabled = false;
                List<IServiciable> servidors = new List<IServiciable>();
                List<IServiciable> serviciables2 = new List<IServiciable>();
                CalculoUniforme calculoUniformeLlegada = new CalculoUniforme(7, 5);
                CalculoUniforme calculoUniformeEmpleado = new CalculoUniforme(7, 3);
                CalculoUniforme calculoUniformaBalanza = new CalculoUniforme(7, 5);
                CalculoUniforme calculoUniformeDarsena1 = new CalculoUniforme(20, 15);
                CalculoUniforme calculoUniformeDarsena2 = new CalculoUniforme(20, 15);
                CalculoNormal calculoNormalCalibrado = new CalculoNormal(10, 1.2);
                colaLlegada = new Cola(calculoUniformeLlegada, "Llegada Camiones", "1 Cola Camiones", 1);

                servidorRecepcion = new Servidor(colaLlegada, calculoUniformeEmpleado, "0 FAT Atencion", "Encargado Atencion", false, true);
                servidors.Add(servidorRecepcion);


                ColaBalanza = new SistemasColasEPEC.Clases.Buffer("Cola Balanza", servidors, 2);

                servidorBalanza = new Servidor(ColaBalanza, calculoUniformaBalanza, "3 FAT Balanza", "Balanza", false, true);
                serviciables2.Add(servidorRecepcion);
                serviciables2.Add(servidorBalanza);
                colaDarsena = new Clases.Buffer("Cola Darsenas", serviciables2, 3);
                //ServidorDar2 = new Servidor(colaDarsena, calculoUniformeDarsena1, "2 FatDarsena1", "Darsena2", true, false);
                //ServidorDar1 = new Servidor(colaDarsena, calculoUniformeDarsena1, "1 FatDarsena1", "Darsena1", true, false);


                ServidorDar1 = new ServidorInterrupcion(colaDarsena, calculoNormalCalibrado, calculoUniformeDarsena1, "2 FatDarsena2", "Darsena2", "FI Darsena2", 15, true, false);
                ServidorDar2 = new ServidorInterrupcion(colaDarsena, calculoNormalCalibrado, calculoUniformeDarsena2, "1 FatDarsena1", "Darsena1", "FI Darsena1", 15, true, false);
                List<int> servidorServicios = new List<int>();
                List<double> servidorProbabilidades = new List<double>();
                // algunos servidores son la entrada para colas y deben elegir una de las colas mediante una probabilidad, el numero permite hacer referencia a alguna cola
                servidorServicios.Add(2);
                servidorServicios.Add(3);
                servidorProbabilidades.Add(0.65);
                servidorProbabilidades.Add(0.35);
                List<int> servidor3Servicios = new List<int>();
                List<double> servidor3Probabilidades = new List<double>();
                servidor3Servicios.Add(3);
                servidor3Probabilidades.Add(1);
                //multiplexor se encarga de elegir alguna cola
                simulador.agregarEventoMultiplexor(servidorRecepcion, servidorServicios, servidorProbabilidades);
                simulador.agregarEventoMultiplexor(servidorBalanza, servidor3Servicios, servidor3Probabilidades);
                simulador.agregarServidor(ServidorDar1);
                simulador.agregarServidor(ServidorDar2);
                simulador.agregarCola(colaLlegada);

                simulador.agregarCola(colaDarsena);
                simulador.agregarCola(ColaBalanza);




                tiempoEspera = 0;
                // algun numero entero para probar los metodos de la clase simulador
                simulaciones = parseo;
                //se simula
                simulador.simularMes(simulaciones, 1080, 720);
                //se devuelven los vectores estados
                testers = simulador.darTesters();
                int filas = testers.Count;
                int celdas = testers[0].darValores().Count;
                string fila = "";
                for (int i = 0; i < filas; i++)
                {

                    for (int j = 0; j < celdas; j++)
                    {
                        fila += "_" + testers[i].darValores()[j];
                    }
                    dgvSimulaciones.Rows.Add(fila);
                    fila = "";
                }
                promedioClienteEnSistema = simulador.promedioEnSistema();
                tiempoEspera = simulador.darTiempoEspera();
                txtCamionesPromedioXDia.Text = promedioClienteEnSistema.ToString();
                txtCamionesNoAtendidos.Text = simulador.darTotalCamines().ToString();
                txtCantidadSimulaciones.Text = simulador.darSimulaciones().ToString();
                txtPromedioCamionesXdia.Text = simulador.darPromediodeCamionesXdia().ToString();
            }
        }

        private void limpiarLista()
        {
            dgvSimulaciones.Rows.Clear();
            testers = new List<Tester>();
            simulador.Clear();
            txtCantidadSimulaciones.Clear();
            txtCamionesPromedioXDia.Clear();
            txtCamionesNoAtendidos.Clear();
            txtPromedioEnSistema.Clear();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            testers.Clear();
            limpiarLista();
            btnSimular.Enabled = true;


        }


    }
}
