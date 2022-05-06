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

namespace La_Pizarra_Puertas_y_Ventanas.Reutilizables
{
    public partial class Nuevo_Proveedor : Form
    {
        private Conexion conex = new Conexion();
        public int idproveedor { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public Nuevo_Proveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length>0 && textBox1.Text.Length>0 && textBox3.Text.Length>0 && maskedTextBox1.Text.Length>4)
            {
                if (idproveedor==0)
                {
                    conex.consultaBD("insert into Proveedores values ('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "')");
                }
                else
                {
                    conex.consultaBD("update Proveedores set Nombres='"+textBox1.Text+"',Apellidos='"+textBox2.Text+"',Telefono='"+maskedTextBox1.Text+
                        "',Direccion='"+textBox3.Text+"' where Id_Proveedor="+idproveedor);
                }
            }
            else
            {
                MessageBox.Show("Debe de ingresar todos los campos","Mensaje de error");
            }
            
        }

        private void Nuevo_Proveedor_Load(object sender, EventArgs e)
        {
            if (idproveedor==0)
            {
                textBox4.Text = (int.Parse(conex.consultaBD("select top 1 Id_Proveedor from Proveedores order by Id_Proveedor desc").Rows[0][0].ToString()) + 1).ToString();
            }
            else
            {
                label1.Text = "Actualizar Proveedor";
                textBox4.Text = idproveedor.ToString();
                textBox1.Text = nombres;
                textBox2.Text = apellidos;
                maskedTextBox1.Text = telefono;
                textBox3.Text = direccion;
                button1.Text = "Actualizar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
