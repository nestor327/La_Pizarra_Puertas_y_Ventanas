using La_Pizarra_Puertas_y_Ventanas.Entrega_de_Pedidos;
using La_Pizarra_Puertas_y_Ventanas.Gestionar_Compra;
using La_Pizarra_Puertas_y_Ventanas.Gestionar_Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Pizarra_Puertas_y_Ventanas
{
    public partial class Form1 : Form
    {
        private Registrar_Pedido consu = new Registrar_Pedido();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultar_Cliente consultar = new Consultar_Cliente();
            consultar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Consultar_Pedido consultar = new Consultar_Pedido();
            consultar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            Produccion produccion = new Produccion();

            produccion.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConsultarCompras consul = new ConsultarCompras();
            consul.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Consultar_Proveedores consultar = new Consultar_Proveedores();
            consultar.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Devoluciones devoluciones = new Devoluciones();

            devoluciones.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Produccion produccion = new Produccion();
            produccion.Show();
        }
    }
}
