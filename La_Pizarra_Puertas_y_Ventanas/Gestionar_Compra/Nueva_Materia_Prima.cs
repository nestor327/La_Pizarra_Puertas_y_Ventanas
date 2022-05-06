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
    public partial class Nueva_Materia_Prima : Form
    {
        private Conexion conex = new Conexion();
        public int idac { get; set; }
        public int idInventario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int id_Proveedor { get; set; }
        public Nueva_Materia_Prima()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length>0 && textBox3.Text.Length>0 && maskedTextBox1.Text.Length>0)
            {
                if (idac==1)
                {
                    conex.consultaBD("update Inventarios set Nombre='"+textBox2.Text+"',Descripcion_Uso='"+textBox3.Text+
                        "',Cantidad_Disponible="+maskedTextBox1.Text+" where Id_Inventario="+idInventario);
                }
                else
                {
                    conex.consultaBD("insert into Inventarios values (" + (comboBox1.SelectedIndex + 1) + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + maskedTextBox1.Text + ")");
                }                
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos","Mensaje de error");
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Nueva_Materia_Prima_Load(object sender, EventArgs e)
        {
            if (idac==1)
            {
                label1.Text = "Actualizar Materia Prima";
                button1.Text = "Actualizar";
                textBox1.Text = idInventario.ToString();
                DataTable prov = new DataTable();
                prov = conex.consultaBD("select Nombres from Proveedores");

                for (int i = 0; i < prov.Rows.Count; i++)
                {
                    comboBox1.Items.Add(prov.Rows[i][0].ToString());
                }
                textBox2.Text = nombre;
                textBox3.Text = descripcion;
                maskedTextBox1.Text = cantidad.ToString();
            }
            else
            {
                textBox1.Text = (int.Parse(conex.consultaBD("select top 1 Id_Inventario from Inventarios order by Id_Inventario desc").Rows[0][0].ToString()) + 1).ToString();
                DataTable prov = new DataTable();
                prov = conex.consultaBD("select Nombres from Proveedores");

                for (int i = 0; i < prov.Rows.Count; i++)
                {
                    comboBox1.Items.Add(prov.Rows[i][0].ToString());
                }
            }            
        }
    }
}
