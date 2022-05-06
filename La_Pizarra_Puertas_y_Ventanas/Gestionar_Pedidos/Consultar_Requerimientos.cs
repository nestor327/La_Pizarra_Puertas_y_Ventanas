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
    public partial class Consultar_Requerimientos : Form
    {
        private Conexion conex = new Conexion();
        public Consultar_Requerimientos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetallesRequerimientos detalles = new DetallesRequerimientos();
            detalles.id_req = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            detalles.Show();
        }

        private void Consultar_Requerimientos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Requerimientos");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Requerimientos where Id_Orden_Produccion="+textBox1.Text);
        }
    }
}
