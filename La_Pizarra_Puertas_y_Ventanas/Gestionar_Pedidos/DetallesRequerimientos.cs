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
    public partial class DetallesRequerimientos : Form
    {
        public int id_req { get; set; }
        private Conexion conex = new Conexion();
        public DetallesRequerimientos()
        {
            InitializeComponent();
        }

        private void DetallesRequerimientos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select *, (select top 1 Nombre from EstadoRequerimientos where Id_Requerimiento = "+id_req+") as Estado" +
                " from Detalle_Requerimientos where Id_Requerimiento = "+id_req);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conex.consultaBD("update EstadoRequerimientos set Nombre='Completada' where Id_Requerimiento="+id_req);
            dataGridView1.DataSource = conex.consultaBD("select *, (select top 1 Nombre from EstadoRequerimientos where Id_Requerimiento = "+id_req+") as Estado" +
            " from Detalle_Requerimientos where Id_Requerimiento = " + id_req);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conex.consultaBD("delete Detalle_Requerimientos where Id_Detalle_Requerimiento="+dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            dataGridView1.DataSource = conex.consultaBD("select *, (select top 1 Nombre from EstadoRequerimientos where Id_Requerimiento = " + id_req + ") as Estado" +
                " from Detalle_Requerimientos where Id_Requerimiento = " + id_req);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nuevo_Requerimiento nuevo = new Nuevo_Requerimiento();
            nuevo.id_Requerimiento = id_req;
            nuevo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.consultaBD("select *, (select top 1 Nombre from EstadoRequerimientos where Id_Requerimiento = " + id_req + ") as Estado" +
                " from Detalle_Requerimientos where Id_Requerimiento = " + id_req);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nuevo_Requerimiento nuevo = new Nuevo_Requerimiento();
            nuevo.id_Requerimiento = 0;
            nuevo.id_DetalleReq = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            nuevo.cantidad= int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            nuevo.id_Inventario= int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            nuevo.Show();
        }
    }
}
