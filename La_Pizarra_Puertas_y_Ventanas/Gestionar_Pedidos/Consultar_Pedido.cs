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
    public partial class Consultar_Pedido : Form
    {
        private Conexion conex = new Conexion();
        public Consultar_Pedido()
        {
            InitializeComponent();
        }

        private void Consultar_Pedido_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Pedidos where Estado='Pendiente'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Detalle_Pedido_Pendiente detalle = new Detalle_Pedido_Pendiente();
            detalle.id_Pedido=int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            detalle.Show();
        }
    }
}
