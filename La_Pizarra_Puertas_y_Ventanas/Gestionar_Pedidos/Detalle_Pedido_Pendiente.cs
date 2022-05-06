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
    public partial class Detalle_Pedido_Pendiente : Form
    {
        public int id_Pedido { get; set; }
        private Conexion conex = new Conexion();
        public Detalle_Pedido_Pendiente()
        {
            InitializeComponent();
        }

        private void Detalle_Pedido_Pendiente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from DetallePedido where Id_Pedido="+id_Pedido);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = conex.consultaBD("select (select Nombre+' '+Apellido from Cliente where Id_Cliente=Pedidos.Cliente)" +
                " from Pedidos where Id_Pedido=" + (dataGridView1.SelectedRows[0].Cells[1].Value.ToString())).Rows[0][0].ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conex.consultaBD("insert into Ordenes_De_Produccion values ("+ conex.consultaBD("select (select Id_Cliente from Cliente where Id_Cliente=Pedidos.Cliente)" +
                " from Pedidos where Id_Pedido=" + (dataGridView1.SelectedRows[0].Cells[1].Value.ToString())).Rows[0][0].ToString() +
                ","+ dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + ",'"+DateTime.Parse(textBox3.Text).Year+"-"+ DateTime.Parse(textBox3.Text).Month+"-"+ DateTime.Parse(textBox3.Text).Day + "',"+int.Parse(textBox2.Text)+")");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
