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
    public partial class Consultar_Pedidos_Pendientes : Form
    {
        private Conexion conex = new Conexion();
        private DataTable pedidos = new DataTable();
        private DataTable busqueda = new DataTable();
        public Consultar_Pedidos_Pendientes()
        {
            InitializeComponent();
        }

        private void Registrar_Factura_Load(object sender, EventArgs e)
        {
            pedidos=conex.ListarEntidades("PedidosPedientes");
            dataGridView1.DataSource = pedidos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            busqueda.Clear();
            dataGridView1.DataSource = conex.ListarEntidades("PedidosPedientes");
            if (textBox1.Text.Length > 0)
            {
                List<int> indices = new List<int>();
                DataRow dr = pedidos.NewRow();
                for (int i = 0; i < pedidos.Rows.Count; i++)
                {
                    dr = pedidos.Rows[i];
                    if (dr[1].ToString().Contains(textBox1.Text))
                    {
                        indices.Add(i);
                    }
                }

                if (busqueda.Columns.Count == 0)
                {
                    DataColumn col;
                    for (int i = 0; i < 7; i++)
                    {
                        col = new DataColumn();
                        busqueda.Columns.Add(col);
                    }
                }

                busqueda.Columns[0].ColumnName = "Codigo del Pedido";
                busqueda.Columns[1].ColumnName = "Nombre del Cliente";
                busqueda.Columns[2].ColumnName = "Fecha del Pedido";
                busqueda.Columns[3].ColumnName = "Abonado";
                busqueda.Columns[4].ColumnName = "Total";
                busqueda.Columns[5].ColumnName = "Deuda";
                busqueda.Columns[6].ColumnName = "Estado";

                DataRow row;

                for (int i = 0; i < pedidos.Rows.Count; i++)
                {
                    row = busqueda.NewRow();
                    row[0] = pedidos.Rows[i][0];
                    row[1] = pedidos.Rows[i][1];
                    row[2] = pedidos.Rows[i][2];
                    row[3] = pedidos.Rows[i][3];
                    row[4] = pedidos.Rows[i][4];
                    row[5] = pedidos.Rows[i][5];
                    row[6] = pedidos.Rows[i][6];

                    busqueda.Rows.Add(row);
                }



                for (int i = pedidos.Rows.Count - 1; i >= 0; i--)
                {
                    if (!indices.Contains(i))
                    {
                        busqueda.Rows[i].Delete();
                    }
                }

                dataGridView1.DataSource = busqueda;

            }
            else
            {
                MessageBox.Show("Debe de rellenar los campos " + pedidos.Rows.Count, "Mensaje de Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.ListarEntidades("PedidosNoCancelados");
            pedidos.Clear();
            pedidos= conex.ListarEntidades("PedidosNoCancelados");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Facturacion facturar = new Facturacion();
            facturar.nombreCliente = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
            facturar.fechaPedido = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
            facturar.id_Pedido = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            facturar.Abonado= int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString());
            facturar.Pendiente= int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value.ToString());
            facturar.total = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString());
            facturar.Show();
        }
    }
}
