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
    public partial class Nuevo_Requerimiento : Form
    {
        private Conexion conex = new Conexion();
        public int id_Requerimiento { get; set; }
        public int id_DetalleReq { get; set; }
        public int id_Inventario { get; set; }
        public int cantidad { get; set; }
        public Nuevo_Requerimiento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0)
            {
                if (id_Requerimiento==0)
                {
                conex.consultaBD("update Detalle_Requerimientos set Id_Inventario="+ (comboBox1.SelectedIndex + 1) + ",Cantidad="+maskedTextBox1.Text+" where Id_Detalle_Requerimiento="+id_DetalleReq);
                }
                else
                {                
                    conex.consultaBD("insert into Detalle_Requerimientos values(" + id_Requerimiento + "," + (comboBox1.SelectedIndex + 1) + ", " + maskedTextBox1.Text + ") " +
                        "insert into EstadoRequerimientos values(" + id_Requerimiento + ", 'Pendiente')");                
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos", "Mensaje de Error");
            }
        }

        private void Nuevo_Requerimiento_Load(object sender, EventArgs e)
        {
            textBox1.Text = id_Requerimiento.ToString();
            DataTable dt = conex.consultaBD("select Nombre from Inventarios");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            if (id_Requerimiento==0)
            {
                label1.Text = "Actualizar detalle Requerimiento";
                comboBox1.SelectedIndex=id_Inventario-1;
                maskedTextBox1.Text = cantidad.ToString();
                button1.Text = "Actualizar";
                textBox1.Text = id_DetalleReq.ToString();
                label4.Text = "Detalle Requerimiento";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
