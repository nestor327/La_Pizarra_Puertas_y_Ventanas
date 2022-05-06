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

namespace La_Pizarra_Puertas_y_Ventanas.Gestionar_Compra
{
    public partial class Consultar_Proveedores : Form
    {
        private Conexion conex = new Conexion();
        public Consultar_Proveedores()
        {
            InitializeComponent();
        }

        private void Consultar_Proveedores_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= conex.consultaBD("select * from Proveedores");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= conex.consultaBD("select * from Proveedores where Nombres like '%"+textBox1.Text+"%' or Apellidos like '%"+ textBox1.Text + "%' or Direccion like '%"+ textBox1.Text + "%' ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Nuevo_Proveedor nuevo = new Nuevo_Proveedor();
            nuevo.idproveedor = 0;
            nuevo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nuevo_Proveedor nuevo = new Nuevo_Proveedor();
            nuevo.idproveedor = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            nuevo.nombres = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            nuevo.apellidos = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            nuevo.telefono = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            nuevo.direccion = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            nuevo.Show();
        }
    }
}
