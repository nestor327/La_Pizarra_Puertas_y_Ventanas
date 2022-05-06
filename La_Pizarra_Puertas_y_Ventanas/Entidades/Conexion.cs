using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Pizarra_Puertas_y_Ventanas.Entidades
{
    public class Conexion
    {
            public SqlConnection conect = new SqlConnection();
            public Conexion()
            {
                try
                {
                    conect = new SqlConnection("Server=localhost; Database=Pizarra_Puertas_y_Ventanas; integrated security=true");
                    conect.Open();
                }
                catch
                {

                }
            }
            public int IdentificarUsuario(string user)
            {
                SqlConnection k = conect;
                SqlCommand prueba = new SqlCommand("sp_getrole", k);
                prueba.CommandType = CommandType.StoredProcedure;
                prueba.Parameters.AddWithValue("@username", user);
                prueba.Parameters.Add("@role", SqlDbType.Int).Direction = ParameterDirection.Output;
                k.Open();
                int t = prueba.ExecuteNonQuery();
                int y = 4;
                if (prueba.Parameters["@role"].Value.ToString().Equals(""))
                {
                }
                else
                {
                    y = Convert.ToInt32(prueba.Parameters["@role"].Value);
                }
                k.Close();
                return y;
            }
            public DataTable ListarEntidades(string procedure)
            {
                DataTable entidades = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "execute "+procedure;
                cmd.Connection = conect;

                SqlDataAdapter adacter = new SqlDataAdapter(cmd);
                adacter.Fill(entidades);
                conect.Close();
                return entidades;
            }
            public void NuevaEntidad(string procedure, List<string> datos)
            {
                SqlCommand cmd = new SqlCommand();
            SqlParameter[] parametre;
            if (procedure.Equals("NPedido"))
            {
                parametre = new SqlParameter[datos.Count-2];
            }else if (procedure.Equals("NDPedido"))
            {
                parametre = new SqlParameter[datos.Count - 4];
            }
            else
            {
                parametre = new SqlParameter[datos.Count];
            }
                

            switch (procedure)
            {
                case "NCliente":
                    parametre[0] = new SqlParameter("@Nombre", SqlDbType.NVarChar);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@Apellido", SqlDbType.NVarChar);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@Sexo", SqlDbType.Char);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@Telefono", SqlDbType.Char);
                    parametre[3].Value = datos[3];
                    parametre[4] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
                    parametre[4].Value = datos[4];
                    parametre[5] = new SqlParameter("@Numero_de_Pedidos", SqlDbType.Int);
                    parametre[5].Value = datos[5];
                    break;
                case "NPedido":
                    parametre[0] = new SqlParameter("@Cliente", SqlDbType.Int);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@Fecha_Pedido", SqlDbType.DateTime);
                    parametre[1].Value = datos[1] + "-" + datos[2] + "-"+datos[3];
                    parametre[2] = new SqlParameter("@Abonado", SqlDbType.Float);
                    parametre[2].Value = datos[4];
                    parametre[3] = new SqlParameter("@Saldo", SqlDbType.Float);
                    parametre[3].Value = datos[5];
                    parametre[4] = new SqlParameter("@Estado", SqlDbType.NVarChar);
                    parametre[4].Value = datos[6];
                    break;
                case "NDPedido":

                    parametre[0] = new SqlParameter("@Id_Pedido", SqlDbType.Int);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@Id_Producto", SqlDbType.Int);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@Cantidad", SqlDbType.Int);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@Precio", SqlDbType.Float);
                    parametre[3].Value = datos[3];
                    parametre[4] = new SqlParameter("@Fecha_Pedido", SqlDbType.DateTime);
                    parametre[4].Value = datos[4]+"-"+datos[5]+"-"+datos[6];
                    parametre[5] = new SqlParameter("@Fecha_Entrega", SqlDbType.DateTime);
                    parametre[5].Value = datos[7] + "-" + datos[8] + "-" + datos[9];
                    break;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Connection = conect;
                cmd.Parameters.AddRange(parametre);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            
            public void ModificarEdintidad(string procedure, List<string> datos)
            {
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] parameter = new SqlParameter[datos.Count];
                switch (procedure)
                {
                    case "UpdateDetallePedido":
                    parameter[0] = new SqlParameter("@Id_Pedido", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@Abonado", SqlDbType.Float);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@Estado", SqlDbType.VarChar);
                    parameter[2].Value = datos[2];
                        break;
                case "UpdateDetalle":
                    parameter[0] = new SqlParameter("@Id_Detalle_Pedido", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@Id_Producto", SqlDbType.Int);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@Cantidad", SqlDbType.Int);
                    parameter[2].Value = datos[2];
                    parameter[3] = new SqlParameter("@Precio", SqlDbType.Float);
                    parameter[3].Value = datos[3];
                    parameter[4] = new SqlParameter("@Fecha_Entrega", SqlDbType.DateTime);
                    parameter[4].Value = datos[4];
                    break;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Connection = conect;
                cmd.Parameters.AddRange(parameter);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            public DataTable consultaBD(string consulta)
            {
            DataTable entidades = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cmd.Connection = conect;

            SqlDataAdapter adacter = new SqlDataAdapter(cmd);
            adacter.Fill(entidades);
            conect.Close();
            return entidades;

            }
            public DataTable BuscarEntidad(string procedure, List<string> datos)
            {
                DataTable entidades = new DataTable();
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] parameter = new SqlParameter[datos.Count];
                switch (procedure)
                {
                    case "DetallesDePedido":
                        parameter[0] = new SqlParameter("@Id_Pedido", SqlDbType.Int);
                        parameter[0].Value = datos[0];
                        break;
                case "EliminarDetalle":
                        parameter[0] = new SqlParameter("@Id_Detalle", SqlDbType.Int);
                        parameter[0].Value = datos[0];
                    break;
                case "BuscarIdProducto":
                        parameter[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        parameter[0].Value = datos[0];
                    break;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Connection = conect;
                cmd.Parameters.AddRange(parameter);
                SqlDataAdapter adacter = new SqlDataAdapter(cmd);
                adacter.Fill(entidades);
                conect.Close();
                return entidades;
            }
            public DataTable Vistas(string vista)
            {
                DataTable entidades = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from " + vista;
                cmd.Connection = conect;

                SqlDataAdapter adacter = new SqlDataAdapter(cmd);
                adacter.Fill(entidades);
                conect.Close();
                return entidades;
            }
        }

    }
