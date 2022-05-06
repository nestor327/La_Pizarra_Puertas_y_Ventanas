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
    public partial class Consultar_Inventario : Form
    {
        private Conexion conex = new Conexion();
        public Consultar_Inventario()
        {
            InitializeComponent();
        }

        private void Consultar_Inventario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Inventarios");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nueva_Materia_Prima nueva_Materia = new Nueva_Materia_Prima();
            nueva_Materia.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nueva_Materia_Prima nueva_Materia = new Nueva_Materia_Prima();
            nueva_Materia.idac = 1;
            nueva_Materia.idInventario = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            nueva_Materia.id_Proveedor = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            nueva_Materia.nombre = (dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            nueva_Materia.descripcion = (dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            nueva_Materia.cantidad = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            nueva_Materia.Show();
        }
    }
}
