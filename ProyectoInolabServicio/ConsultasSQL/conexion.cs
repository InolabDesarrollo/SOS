using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoInolabServicio
{
    class conexion
    {
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        private SqlCommandBuilder cmd;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommand comando = new SqlCommand();
        //DataTable dt;

        public void conectar()
        {
            try
            {
                con.Open();
                // MessageBox.Show("Conectado a la Base de Datos", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a la Base de Datos");
            }
            finally
            {
                con.Close();
            }
        }
        public void consulta(string sql, string tabla)
        {
            //string q = "Select * from V_FSR";

            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmd = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }
        public bool insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            if (i > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool actualizar(string tabla, string campos, string condicion)
        {
            con.Open();
            string actualizar = "update " + tabla + " set " + campos + "  where " + condicion;
            comando = new SqlCommand(actualizar, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool buscar(string tabla, string condicion)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string buscar = "select* from " + tabla + " where IdVendedor = ";
            comando = new SqlCommand(buscar, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}