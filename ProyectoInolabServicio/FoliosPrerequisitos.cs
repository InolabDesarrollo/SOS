using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class FoliosPrerequisitos : MaterialForm
    {
        public FoliosPrerequisitos()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");


        private void FoliosPrerequisitos_Load(object sender, EventArgs e)
        {
            Todos();
        }

        public void Todos()
        {
            string query;
            query = "select * from V_Prerrequisitos";

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            advancedDataGridView1.DataSource = dt;

            con.Close();

        }
    }
}
