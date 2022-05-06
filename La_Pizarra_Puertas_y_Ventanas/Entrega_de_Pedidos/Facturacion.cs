using La_Pizarra_Puertas_y_Ventanas.Entidades;
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

namespace La_Pizarra_Puertas_y_Ventanas.Entrega_de_Pedidos
{
    public partial class Facturacion : Form
    {
        private Conexion conex = new Conexion();
        public int id_Pedido { get; set; }
        public string nombreCliente { get; set; }
        public string fechaPedido { get; set; }
        public DataTable detalles = new DataTable();
        public int Abonado { get; set; }
        public int Pendiente { get; set; }
        public int total { get; set; }
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            datos.Add(id_Pedido.ToString());
            label2.Text = "Ciente: "+nombreCliente;
            label4.Text = "Fecha del Pedido: " + fechaPedido.Substring(0,10);
            label5.Text ="Fecha_Actual: "+ DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            detalles = conex.BuscarEntidad("DetallesDePedido",datos);
            dataGridView1.DataSource = detalles;
            label7.Text = "Abonado: " + Abonado.ToString();
            label8.Text = "Pendinte " + Pendiente.ToString();
            label10.Text = "Total: " + total.ToString();
            label3.Text = "Pedido: " + id_Pedido;
        }

        private void maskedTextBox1_MaskChanged(object sender, EventArgs e)
        {
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            label8.Text = "Pendiente: " + (total - Abonado - int.Parse(maskedTextBox1.Text));
            label7.Text = "Abonado: " + (Abonado+ int.Parse(maskedTextBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();            
                datos.Clear();
                datos.Add(id_Pedido.ToString());
                datos.Add(maskedTextBox1.Text);
                datos.Add("Pendiente");
            
            conex.ModificarEdintidad("UpdateDetallePedido", datos);
            List<string> datosp = new List<string>();
            datosp.Add(id_Pedido.ToString());
            dataGridView1.DataSource = conex.BuscarEntidad("DetallesDePedido", datosp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            if ((total - Abonado - int.Parse(maskedTextBox1.Text)) <= 0)
            {
                datos.Clear();
                datos.Add(id_Pedido.ToString());
                datos.Add(total.ToString());
                datos.Add("Cancelado");
                conex.consultaBD("update Pedidos set Total="+ total.ToString() + ", Estado='Cancelado' where Id_Pedido="+id_Pedido.ToString());
            }
            else
            {
                MessageBox.Show("No puede facturar si no ha Cancelado","Mensaje de Error");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            datos.Add(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            dataGridView1.DataSource=conex.BuscarEntidad("EliminarDetalle",datos);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizar_Detalle_Pedido actualizar = new Actualizar_Detalle_Pedido();
            actualizar.Id_Detalle_Pedido = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            actualizar.Id_Producto= int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString());
            actualizar.Cantidad = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString());
            actualizar.Precio = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString());
            actualizar.Fecha_Entrega = DateTime.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[6].Value.ToString());
            actualizar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Registrar_Nuevo_Detalle registrar_Nuevo = new Registrar_Nuevo_Detalle();
            registrar_Nuevo.nombreCliente = nombreCliente;
            registrar_Nuevo.idPedido = id_Pedido;        
            registrar_Nuevo.Show();

        }
    }
}
