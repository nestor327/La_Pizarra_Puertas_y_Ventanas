using La_Pizarra_Puertas_y_Ventanas.Entidades;
using La_Pizarra_Puertas_y_Ventanas.Entrega_de_Pedidos;
using La_Pizarra_Puertas_y_Ventanas.Gestionar_Compra;
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
    public partial class Produccion : Form
    {
        private Conexion conex = new Conexion();

        public Produccion()
        {
            InitializeComponent();
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select Id_Orden_De_Produccion,(select Nombre+' '+Apellido from Cliente where" +
                " Id_Cliente=Ordenes_De_Produccion.Id_Cliente) as [Nombre del Cliente], Id_Detalle_Pedido, Fecha_Entrega, Cantidad_Productos from Ordenes_De_Produccion where Fecha_Entrega > GETDATE()");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select Id_Orden_De_Produccion, " +
                "(select Nombre + ' ' + Apellido from Cliente where Id_Cliente = Ordenes_De_Produccion.Id_Cliente)," +
                "Id_Detalle_Pedido,Fecha_Entrega,Cantidad_Productos from Ordenes_De_Produccion where Fecha_Entrega > GETDATE() " +
                "and  (select Nombre + ' ' + Apellido from Cliente where Id_Cliente = Ordenes_De_Produccion.Id_Cliente) like '%" + textBox1.Text + "%'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Informacion_de_Orden informacion = new Informacion_de_Orden();
            informacion.id_Orden_de_Produccion = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            informacion.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conex.consultaBD("delete Ordenes_De_Produccion where Id_Orden_De_Produccion=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            dataGridView1.DataSource = conex.consultaBD("select Id_Orden_De_Produccion,(select Nombre+' '+Apellido from Cliente where" +
                         " Id_Cliente=Ordenes_De_Produccion.Id_Cliente) as [Nombre del Cliente], Id_Detalle_Pedido, Fecha_Entrega, Cantidad_Productos from Ordenes_De_Produccion where Fecha_Entrega > GETDATE()");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Actualizar_Orden_Produccion actualizar = new Actualizar_Orden_Produccion();
            actualizar.id_Orden_Prod = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            actualizar.id_Orden_Prod2 = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            actualizar.fecha = (dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            actualizar.cantidad = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            actualizar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Detalle_Pedido_Pendiente detalle = new Detalle_Pedido_Pendiente();
            detalle.id_Pedido = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString());
            detalle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= conex.consultaBD("select Id_Orden_De_Produccion,(select Nombre+' '+Apellido from Cliente where" +
                         " Id_Cliente=Ordenes_De_Produccion.Id_Cliente) as [Nombre del Cliente], Id_Detalle_Pedido, Fecha_Entrega, Cantidad_Productos from Ordenes_De_Produccion where Fecha_Entrega > GETDATE()");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Requerimientos requerimientos = new Requerimientos();
            requerimientos.id_Orden = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            requerimientos.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Consultar_Requerimientos consultar = new Consultar_Requerimientos();
            consultar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Consultar_Inventario consultar = new Consultar_Inventario();

            consultar.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Registrar_Compra registrar = new Registrar_Compra();

            registrar.Show();
        }
    }
}
