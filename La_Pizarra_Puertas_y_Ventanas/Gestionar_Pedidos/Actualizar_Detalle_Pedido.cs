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
    public partial class Actualizar_Detalle_Pedido : Form
    {
        public int Id_Detalle_Pedido { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        private DataTable prod = new DataTable();
        private Conexion conex = new Conexion();
        public Actualizar_Detalle_Pedido()
        {
            InitializeComponent();
        }

        private void Actualizar_Detalle_Pedido_Load(object sender, EventArgs e)
        {
            textBox1.Text = Id_Detalle_Pedido.ToString();
            prod = conex.ListarEntidades("GProductos");

            for (int i = 0; i < prod.Rows.Count; i++)
            {
                comboBox1.Items.Add(prod.Rows[i][1]);
            }
            comboBox1.SelectedItem = comboBox1.Items[Id_Producto - 1];
            maskedTextBox1.Text = Cantidad.ToString();
            maskedTextBox2.Text = Precio.ToString();
            dateTimePicker1.Value = new DateTime(Fecha_Entrega.Year,Fecha_Entrega.Month,Fecha_Entrega.Day);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            List<string> datos = new List<string>();
            List<string> datos2 = new List<string>();
            datos2.Add(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            datos.Add(textBox1.Text);
            datos.Add(conex.BuscarEntidad("BuscarIdProducto",datos2).Rows[0][0].ToString());
            datos.Add(maskedTextBox1.Text);
            datos.Add(maskedTextBox2.Text);
            datos.Add(dateTimePicker1.Value.Year.ToString()+"-"+ dateTimePicker1.Value.Month.ToString()+"-"+ dateTimePicker1.Value.Day.ToString());

            conex.ModificarEdintidad("UpdateDetalle", datos);


        }
    }
}
