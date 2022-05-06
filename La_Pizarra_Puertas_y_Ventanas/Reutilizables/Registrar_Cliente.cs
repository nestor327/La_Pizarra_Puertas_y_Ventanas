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
    public partial class Registrar_Cliente : Form
    {
        private Conexion conexion = new Conexion();
        public Registrar_Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> clientes = new List<string>();
            if (textBox1.Text.Length > 0 && textBox2.Text.Length>0 && comboBox1.SelectedIndex>0 && maskedTextBox1.Text.Length>5 && textBox6.Text.Length>0)
            {
                clientes.Add(textBox1.Text);
                clientes.Add(textBox2.Text);
                if (comboBox1.SelectedIndex==1)
                {
                    clientes.Add("Masculino");
                }
                else if(comboBox1.SelectedIndex == 2)
                {
                    clientes.Add("Femenino");
                }
                else
                {
                    clientes.Add("Otro");
                }
                clientes.Add(maskedTextBox1.Text);
                clientes.Add(textBox6.Text);
                clientes.Add(textBox3.Text);
                conexion.NuevaEntidad("NCliente",clientes);
                Close();
            }

        }

        private void Registrar_Cliente_Load(object sender, EventArgs e)
        {
            DataTable dt = conexion.ListarEntidades("getClientes");
            int codigo = (int)(dt.Rows[dt.Rows.Count-1][0])+1;
            textBox5.Text = codigo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
