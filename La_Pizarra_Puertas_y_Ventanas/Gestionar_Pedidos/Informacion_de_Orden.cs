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

namespace La_Pizarra_Puertas_y_Ventanas.Gestionar_Pedidos
{
    public partial class Informacion_de_Orden : Form
    {
        public int id_Orden_de_Produccion { get; set; }
        public string Estado { get; set; }
        private Conexion conex = new Conexion();
        public Informacion_de_Orden()
        {
            InitializeComponent();
        }

        private void Informacion_de_Orden_Load(object sender, EventArgs e)
        {
            textBox7.Text = conex.consultaBD("select Id_Pedido from Pedidos " +
                "where Id_Pedido = (select Id_Pedido from DetallePedido where Id_Detalle_Pedido = " +
                "(select Id_Detalle_Pedido from Ordenes_De_Produccion where Id_Orden_De_Produccion = 2))").Rows[0][0].ToString();
            textBox1.Text = conex.consultaBD("select(select Nombre + ' ' + Apellido from Cliente where Id_Cliente = Ordenes_De_Produccion.Id_Cliente)" +
                " from Ordenes_De_Produccion where Id_Orden_De_Produccion = " + id_Orden_de_Produccion).Rows[0][0].ToString();
            textBox2.Text = conex.consultaBD("select Nombre_Producto from ProductosyServicios where Id_Producto = " +
                "(select Id_Producto from DetallePedido where Id_Detalle_Pedido =  (select Id_Detalle_Pedido from Ordenes_De_Produccion " +
                "where Id_Orden_De_Produccion = " + id_Orden_de_Produccion + "))").Rows[0][0].ToString();
            textBox3.Text = conex.consultaBD("select Descripcion from ProductosyServicios where Id_Producto = " +
                "(select Id_Producto from DetallePedido where Id_Detalle_Pedido =  (select Id_Detalle_Pedido from Ordenes_De_Produccion " +
                "where Id_Orden_De_Produccion = " + id_Orden_de_Produccion + "))").Rows[0][0].ToString();
            textBox9.Text = conex.consultaBD("select Estado from Pedidos where Id_Pedido = (select Id_Pedido from DetallePedido where Id_Detalle_Pedido =" +
                "  (select Id_Detalle_Pedido from Ordenes_De_Produccion where Id_Orden_De_Produccion = " + id_Orden_de_Produccion + "))").Rows[0][0].ToString();
            textBox4.Text = conex.consultaBD("select Cantidad_Productos from Ordenes_De_Produccion where Id_Orden_De_Produccion=" + id_Orden_de_Produccion).Rows[0][0].ToString();
            textBox8.Text = conex.consultaBD("select Precio from DetallePedido where Id_Detalle_Pedido=" +
                "(select Id_Detalle_Pedido from Ordenes_De_Produccion where Id_Orden_De_Produccion="+id_Orden_de_Produccion+")").Rows[0][0].ToString();
            textBox5.Text = conex.consultaBD("select Fecha_Entrega from Ordenes_De_Produccion where Id_Orden_De_Produccion="+id_Orden_de_Produccion).Rows[0][0].ToString();
            textBox6.Text = conex.consultaBD("select Fecha_Pedido from DetallePedido where Id_Detalle_Pedido=(select Id_Detalle_Pedido from Ordenes_De_Produccion where Id_Orden_De_Produccion=" +
                id_Orden_de_Produccion + ")").Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
