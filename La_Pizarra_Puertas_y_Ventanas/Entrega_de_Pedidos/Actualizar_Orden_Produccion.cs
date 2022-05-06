using La_Pizarra_Puertas_y_Ventanas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Pizarra_Puertas_y_Ventanas.Entrega_de_Pedidos
{
    public partial class Actualizar_Orden_Produccion : Form
    {
        private Conexion conex = new Conexion(); 
        public int id_Orden_Prod { get; set; }
        public int id_Orden_Prod2 { get; set; }
        public string fecha { get; set; }
        public int cantidad { get; set; }

        public Actualizar_Orden_Produccion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conex.consultaBD("update DetallePedido set Fecha_Entrega = '"+dateTimePicker1.Value.Year+"-"+dateTimePicker1.Value.Month+"-"+dateTimePicker1.Value.Day+"', Cantidad = "+ maskedTextBox1.Text+" where Id_Detalle_Pedido =" +
                "(select Id_Detalle_Pedido from Ordenes_De_Produccion where Id_Orden_De_Produccion = "+id_Orden_Prod+")");
        }

        private void Actualizar_Orden_Produccion_Load(object sender, EventArgs e)
        {
            textBox1.Text = id_Orden_Prod2.ToString();
            dateTimePicker1.Value = DateTime.Parse(fecha);
            maskedTextBox1.Text = cantidad.ToString();
        }
    }
}
