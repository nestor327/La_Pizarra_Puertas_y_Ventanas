using La_Pizarra_Puertas_y_Ventanas.Entidades;
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
    public partial class Consultar_Cliente : Form
    {
        private Conexion conex = new Conexion();
        public Consultar_Cliente()
        {
            InitializeComponent();
        }

        private void Consultar_Cliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Cliente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrar_Cliente registrar = new Registrar_Cliente();
            registrar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
                return;
            else
            dataGridView1.DataSource = conex.consultaBD("select * from Cliente where Nombre like '%"+textBox1.Text+
                "%' or Apellido like '%" + textBox1.Text + "%' or Direccion like '%" + textBox1.Text + "%'");
        }
    }
}
