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
    public partial class Registrar_Nuevo_Detalle : Form
    {
        public int codigoDelPedido { get; set; }
        private Conexion conex = new Conexion();
        private DataTable Pedidos = new DataTable();
        public DataTable produ = new DataTable();        
        public int idPedido { get; set; }
        public string nombreCliente { get; set; }
        private int ultimoRe = 0;
        public Registrar_Nuevo_Detalle()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                if (int.Parse(conex.consultaBD("select top 1 Id_Detalle_Pedido from DetallePedido order by Id_Detalle_Pedido desc").Rows[0][0].ToString())<int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                {
                    conex.consultaBD("insert into DetallePedido values (" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," +
                        dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString() + "," +
                        dataGridView1.Rows[i].Cells[4].Value.ToString() + ",'" + DateTime.Now.Year.ToString() + "-" +
                        DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() +
                        "','" + DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()).Year+"-"+
                        DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()).Month +"-"+ 
                        DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()).Day + "')");
                }
            }
        }

        private void Registrar_Nuevo_Detalle_Load(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            datos.Add(idPedido.ToString());
            produ = conex.ListarEntidades("GProductos");
            Pedidos = conex.BuscarEntidad("DetallesDePedido",datos);
            textBox3.Text = idPedido.ToString();
            textBox5.Text = nombreCliente;
            DataTable data = conex.ListarEntidades("GProductos");
            for (int i=0;i< data.Rows.Count;i++)
            {
                comboBox1.Items.Add(data.Rows[i][1].ToString());
            }
            dataGridView1.DataSource = Pedidos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la cantidad del Producto", "Mensaje de Advertencia");
                return;
            }
            DataRow row = Pedidos.NewRow();
            row[0] = int.Parse(conex.ListarEntidades("obtenerIdDetalle").Rows[0][0].ToString()) + 1;
            row[1] = idPedido.ToString();
            row[2] = (comboBox1.SelectedIndex).ToString();
            row[3] = maskedTextBox1.Text;
            row[4] = conex.consultaBD("select Precio from ProductosyServicios where Id_Producto=" + (comboBox1.SelectedIndex).ToString()).Rows[0][0].ToString();
            row[5] = DateTime.Now;
            row[6] = dateTimePicker1.Value;
            Pedidos.Rows.Add(row);
            dataGridView1.DataSource = Pedidos;


            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total = total + Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            textBox6.Text = total.ToString();
        }
    }
}
