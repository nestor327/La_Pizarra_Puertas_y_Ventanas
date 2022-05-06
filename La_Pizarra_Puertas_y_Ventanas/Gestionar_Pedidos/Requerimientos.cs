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
    public partial class Requerimientos : Form
    {
        private Conexion conex = new Conexion();
        public DataTable reque = new DataTable();
        
        public int id_Orden { get; set; }
        public Requerimientos()
        {
            InitializeComponent();
        }

        private void Requerimientos_Load(object sender, EventArgs e)
        {
            textBox1.Text = id_Orden.ToString();
            DataTable combo = conex.consultaBD("select Nombre from Inventarios");
            for (int i=0;i<combo.Rows.Count;i++)
            {
                comboBox1.Items.Add(combo.Rows[i][0].ToString());
            }
            reque.Columns.Add(new DataColumn("Materia Prima"));
            reque.Columns.Add(new DataColumn("Cantidad"));
            dataGridView1.DataSource = reque;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length>0 && int.Parse(maskedTextBox1.Text)<=
                int.Parse(conex.consultaBD("select top 1 Cantidad_Disponible from Inventarios where Nombre='"+comboBox1.SelectedItem.ToString()+"'").Rows[0][0].ToString()))
            {
                DataRow dr = reque.NewRow();
                dr[0] = comboBox1.SelectedItem.ToString();
                dr[1] = maskedTextBox1.Text;
                reque.Rows.Add(dr);
            }
            else
            {
                MessageBox.Show("Introdusca la cantidad de la materia prima menor a la Existente","Mensaje de Error");
            }
            dataGridView1.DataSource = reque;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Parse((conex.consultaBD("select Fecha_Entrega from Ordenes_De_Produccion where Id_Orden_De_Produccion=" + id_Orden)).Rows[0][0].ToString());

            conex.consultaBD("insert into Requerimientos values(" + id_Orden + ",'" + time.Year + "-" + time.Month + "-" + time.Day + "')");
            int id_Requer = int.Parse(conex.consultaBD("select top 1 Id_Requerimiento from Requerimientos order by Id_Requerimiento desc").Rows[0][0].ToString());
            conex.consultaBD("insert into EstadoRequerimientos values("+id_Requer+", '"+"Pendiente"+"')");
            for (int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                conex.consultaBD("insert into Detalle_Requerimientos values ("+id_Requer+","+
                    (int.Parse(comboBox1.Items.IndexOf(dataGridView1.Rows[i].Cells[0].Value.ToString()).ToString())+1)+","+maskedTextBox1.Text+")");

                
            }
            MessageBox.Show("Requerimientos Guardados","Mensaje Informativo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
