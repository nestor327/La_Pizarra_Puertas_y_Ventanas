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
    public partial class ActualizarOrdenCompra : Form
    {
        private Conexion conex = new Conexion();
        public int id_ordencompra { get; set; }
        public int id_Inventario { get; set; }
        public int cantidad { get; set; }
        public DateTime fecharegistro { get; set; }
        public DateTime fecharCompra { get; set; }
        public string Estado { get; set; }
        public ActualizarOrdenCompra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length>0)
            {
                conex.consultaBD("update Ordenes_de_Compra set Id_Inventario="+(comboBox1.SelectedIndex+1)+",Cantidad="+maskedTextBox1.Text+"," +
                    "Fecha_Registro='"+dateTimePicker1.Value.Year.ToString()+"-"+ dateTimePicker1.Value.Month.ToString() + "-"+ dateTimePicker1.Value.Day.ToString()+
                    "',Fecha_Compra='"+ dateTimePicker2.Value.Year.ToString() + "-" + dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString()+
                    "',Estado='"+comboBox2.SelectedItem.ToString()+"' where Id_OrdendeCompra="+id_ordencompra);
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos");
            }
        }
        
        private void ActualizarOrdenCompra_Load(object sender, EventArgs e)
        {
            DataTable inve = new DataTable();
            inve = conex.consultaBD("select * from Inventarios");
            for (int i=0;i<inve.Rows.Count;i++)
            {
                comboBox1.Items.Add(inve.Rows[i][2].ToString());
            }
            textBox1.Text = id_ordencompra.ToString();
            comboBox1.SelectedIndex = id_Inventario;
            maskedTextBox1.Text = cantidad.ToString();
            dateTimePicker1.Value = fecharegistro;
            dateTimePicker2.Value = fecharCompra;
            if (Estado.Equals("Completado"))
            {
                comboBox2.SelectedIndex = 1;
            }
            else
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
