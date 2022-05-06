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
    public partial class ConsultarCompras : Form
    {
        private Conexion conex = new Conexion();
        public ConsultarCompras()
        {
            InitializeComponent();
        }

        private void ConsultarCompras_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Ordenes_de_Compra");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select * from Ordenes_de_Compra where Id_Inventario=" + maskedTextBox1.Text + " or Id_OrdendeCompra=" + maskedTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarOrdenCompra actualizar = new ActualizarOrdenCompra();
            actualizar.id_ordencompra = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            actualizar.id_Inventario= int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            actualizar.cantidad= int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            actualizar.fecharegistro= DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            actualizar.fecharCompra = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            actualizar.Estado= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            actualizar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActualizarOrdenCompra actualizar = new ActualizarOrdenCompra();
            actualizar.id_ordencompra = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            actualizar.id_Inventario = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            actualizar.cantidad = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            actualizar.fecharegistro = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            actualizar.fecharCompra = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            actualizar.Estado = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            actualizar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Registrar_Compra registrar = new Registrar_Compra();
            registrar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conex.consultaBD("delete from Ordenes_de_Compra where Id_OrdendeCompra="+int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            dataGridView1.DataSource = conex.consultaBD("select * from Ordenes_de_Compra");
        }
    }
}
