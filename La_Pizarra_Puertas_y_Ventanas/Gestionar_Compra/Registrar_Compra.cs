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

namespace La_Pizarra_Puertas_y_Ventanas.Gestionar_Compra
{
    public partial class Registrar_Compra : Form
    {
        private Conexion conex = new Conexion();

        public Registrar_Compra()
        {
            InitializeComponent();
        }

        private void Registrar_Compra_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Ordenes_de_Compra");
            DataTable inventario = new DataTable();
            inventario = conex.consultaBD("select * from Inventarios");
            for (int i=0;i<inventario.Rows.Count;i++)
            {
                comboBox1.Items.Add(inventario.Rows[i][2].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length>0)
            {
                conex.consultaBD("insert into Ordenes_de_Compra values (" + (comboBox1.SelectedIndex + 1) + "," + maskedTextBox1.Text + ",'" + dateTimePicker1.Value.Year.ToString() + "-" +
                    dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString() + "','" + dateTimePicker2.Value.Year.ToString() + "-" +
                    dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString() + "','Pendiente')");
            }
            else
            {
                MessageBox.Show("Ingrese los datos","Mensaje de Error");
            }
            dataGridView1.DataSource= conex.consultaBD("select * from Ordenes_de_Compra");
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
