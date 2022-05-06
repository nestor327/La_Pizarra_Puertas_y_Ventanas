using La_Pizarra_Puertas_y_Ventanas.Entidades;
using La_Pizarra_Puertas_y_Ventanas.Entrega_de_Pedidos;
using La_Pizarra_Puertas_y_Ventanas.Reutilizables;
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
    public partial class Registrar_Pedido : Form
    {
        private Conexion conex = new Conexion();
        private DataTable cliente = new DataTable();
        private DataTable busqueda = new DataTable();
        private DataTable Pedidos = new DataTable();
        private DataTable prod = new DataTable();

        public Registrar_Pedido()
        {
            InitializeComponent();
        }

        private void Consultar_Clientes_Load(object sender, EventArgs e)
        {
            cliente = conex.ListarEntidades("getClientes");
            dgvClientes.DataSource = cliente;
            prod.Columns.Add(new DataColumn());
            prod = conex.ListarEntidades("GProductos");

            for (int i = 0; i < prod.Rows.Count; i++)
            {
                comboBox1.Items.Add(prod.Rows[i][1]);
            }
            Pedidos.Columns.Add(new DataColumn("Nombre"));
            Pedidos.Columns.Add(new DataColumn("Precio"));
            Pedidos.Columns.Add(new DataColumn("Cantidad"));
            Pedidos.Columns.Add(new DataColumn("Fecha Pedido"));
            Pedidos.Columns.Add(new DataColumn("Fecha Entrega"));
            dataGridView1.DataSource = Pedidos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda.Clear();
            dgvClientes.DataSource = conex.ListarEntidades("getClientes");
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                List<int> indices = new List<int>();
                DataRow dr = cliente.NewRow();
                for (int i = 0; i < cliente.Rows.Count; i++)
                {
                    dr = cliente.Rows[i];
                    if (dr[1].ToString().Contains(textBox1.Text) || dr[2].ToString().Contains(textBox2.Text))
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

                busqueda.Columns[0].ColumnName = "Codigo del Cliente";
                busqueda.Columns[1].ColumnName = "Nombre";
                busqueda.Columns[2].ColumnName = "Apellido";
                busqueda.Columns[3].ColumnName = "Numero Telefonico";
                busqueda.Columns[4].ColumnName = "Sexo";
                busqueda.Columns[5].ColumnName = "Direccion";
                busqueda.Columns[6].ColumnName = "Numero de Pedidos";

                DataRow row = busqueda.NewRow();

                for (int i = 0; i < cliente.Rows.Count; i++)
                {
                    row[0] = cliente.Rows[i][0];
                    row[1] = cliente.Rows[i][1];
                    row[2] = cliente.Rows[i][2];
                    row[3] = cliente.Rows[i][3];
                    row[4] = cliente.Rows[i][4];
                    row[5] = cliente.Rows[i][5];
                    row[6] = cliente.Rows[i][6];

                    busqueda.Rows.Add(row);
                }



                for (int i = cliente.Rows.Count - 1; i >= 0; i--)
                {
                    if (!indices.Contains(i))
                    {
                        busqueda.Rows[i].Delete();
                    }
                }

                dgvClientes.DataSource = busqueda;

            } else
            {
                MessageBox.Show("Debe de rellenar los campos " + cliente.Rows.Count, "Mensaje de Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registrar_Cliente registrar = new Registrar_Cliente();
            registrar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = ((int)conex.ListarEntidades("GetLastPedido").Rows[0][0]+1).ToString();
            textBox4.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString() + " " + dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length==0)
            {
                MessageBox.Show("Ingrese la cantidad del Producto","Mensaje de Advertencia");
                return;
            }
            DataRow row = Pedidos.NewRow();
            row[0] = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            row[1] = prod.Rows[comboBox1.SelectedIndex-1][3];
            row[2] = maskedTextBox1.Text;
            row[3] = DateTime.Now;
            row[4] = dateTimePicker1.Value;
            Pedidos.Rows.Add(row);
            dataGridView1.DataSource = Pedidos;

            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total = total + Double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) * Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            textBox6.Text = total.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                total = total + Double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString())* Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            textBox6.Text = total.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> pedidoU = new List<string>();
            pedidoU.Add(textBox4.Text);
            pedidoU.Add(DateTime.Now.Day.ToString());
            pedidoU.Add(DateTime.Now.Month.ToString());
            pedidoU.Add(DateTime.Now.Year.ToString());
            pedidoU.Add(maskedTextBox2.Text);
            pedidoU.Add(textBox6.Text);
            if ((int.Parse(maskedTextBox2.Text) - int.Parse(textBox6.Text)) < 0)
            {
                pedidoU.Add("Pendiente");
            }
            else
            {
                pedidoU.Add("Cancelado");
            }

            conex.NuevaEntidad("NPedido", pedidoU);

            int pedidoID = int.Parse(conex.ListarEntidades("GetLastPedido").Rows[0][0].ToString());

            List<string> datos = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                datos.Add(pedidoID.ToString());
                datos.Add(comboBox1.Items.IndexOf(dataGridView1.Rows[i].Cells[0].Value.ToString()).ToString());
                datos.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                datos.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                datos.Add(DateTime.Now.Day.ToString());
                datos.Add(DateTime.Now.Month.ToString());
                datos.Add(DateTime.Now.Year.ToString());
                datos.Add(dateTimePicker1.Value.Day.ToString());
                datos.Add(dateTimePicker1.Value.Month.ToString());
                datos.Add(dateTimePicker1.Value.Year.ToString());
                conex.NuevaEntidad("NDPedido",datos);
                datos.Clear();
            }

            MessageBox.Show("El pedido se ingreso correctamente","Mensaje Informativo");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultar_Pedidos_Pendientes consultar = new Consultar_Pedidos_Pendientes();
            consultar.Show();
        }
    }
}





