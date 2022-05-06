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
    public partial class Devoluciones : Form
    {
        private Conexion conex = new Conexion();
        public Devoluciones()
        {
            InitializeComponent();
        }

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = conex.consultaBD("select * from DetallePedido");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            dataGridView1.DataSource = conex.consultaBD("select * from Devoluciones");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = conex.consultaBD("select Nombre+' '+Apellido from Cliente where Id_Cliente=(select Id_Cliente from Pedidos where Id_Pedido=(select Id_Pedido from DetallePedido where Id_Detalle_Pedido="+comboBox1.SelectedItem.ToString()+"))").Rows[0][0].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0)
            {
                conex.consultaBD("insert into Devoluciones values (" + (comboBox1.SelectedItem) + ",(select Cliente from Pedidos where Id_Pedido=(select Id_Pedido from DetallePedido where Id_Detalle_Pedido="+comboBox1.SelectedItem+")),'" + textBox5.Text + "'," +
                "'" + dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "')");
                dataGridView1.DataSource = conex.consultaBD("select * from Devoluciones");
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Mensaje de error");
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conex.consultaBD("delete from Devoluciones where Id_Devolucion ="+dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
