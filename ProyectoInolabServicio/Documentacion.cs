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
    public partial class Documentacion : MaterialForm
    {
        public Documentacion(string Folio, int BD)
        {
            InitializeComponent();
            FolioD = Folio;
            tipoBD = BD;
        }

        //***************VARIABLES
        string FolioD, fServicio;
        int Idestatus, v_dvg, IdComboResp, Resp, IdComboDoc, Document;
        int tipoBD;
        int IdResp, IdDocument, cmbDocum;


        //*****************INSTANCIA DE CLASE DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        //*****************CONEXION BD
        //SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Incidencias' Puede moverla o quitarla según sea necesario.
            this.incidenciasTableAdapter.Fill(this.browserDataSet.Incidencias);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet.Tipo_Servicio);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet.Usuarios);

            CargaCombos();

            IdResp = 0;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();

            cmbIngeniero.SelectedItem = null;
            cmbTServicio.SelectedItem = null;
            //cmbIncidencia.Text = null;

            CargarDatos();         
        }


        //*******************CARGA LOS DATOS DEL FOLIO SELECCIONADO A ASIGNAR
        public void CargarDatos()
        {           
            SqlDataReader leer;
            leer = objConsultasBD.setDatosAsignarDoc(tipoBD, FolioD);
            if (leer.Read())
            {
                lblFolio.Text = Convert.ToString(leer["Folio"]);
                lblEstatus.Text = Convert.ToString(leer["Estatus"]);
                txtCliente.Text = Convert.ToString(leer["Cliente"]);
                txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                cmbIngeniero.SelectedValue = Convert.ToInt32(leer["IdIngeniero"]);
                cmbTServicio.SelectedValue = Convert.ToInt32(leer["idServicio"]);
                dtpfechaServicio.Text = Convert.ToString(leer["FechaServicio"]);
                txtMarca.Text = Convert.ToString(leer["Marca"]);
                txtModelo.Text = Convert.ToString(leer["Modelo"]);
                txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                txtAsesor.Text = Convert.ToString(leer["Asesor1"]);

                //comprobamos si es dato nulo en Responsable
                if (leer.IsDBNull(45))
                {
                    cmbResponsable.Text = null;
                }
                else
                {
                    IdResp = Convert.ToInt32(leer["IdResp"]);
                    cmbResponsable.SelectedValue = IdResp;
                }
                //asignamos index a combo con id de usuario documentador
                if (leer.IsDBNull(47))
                {
                    cmbDocumenta.SelectedText = null;
                }
                else
                {
                    IdDocument = Convert.ToInt32(leer["IdDocumenta"]);
                    cmbDocumenta.SelectedValue = IdDocument;
                }
            }
            //con.Close();
            cmbEstatus.SelectedValue = 14;
        }


        //********************GUARDA LOS DATOS A DOCUMENTACION Y REALIZA UPDATE A FSR PARA DOCUMENTADOR Y RESPONSBLE
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDocumenta.Text))
            {
                MessageBox.Show("No se ha asignado un Responsable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbResponsable.Text))
            {
                MessageBox.Show("No se ha asignado Documentador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }         
            SaveDocument();
            SaveIncidencia();
            UpFSR();           

            btnGuardar.Visible = false;
            Limpiar();

            this.Close();
        }


        //****************ASIGNA ID DE DOCUMENTADOR DEPENDIENDO DE LA SELECCION
        private void cmDocumenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document = Convert.ToInt32(cmbDocumenta.SelectedValue);
        }


        //*******************ASIGNA ID DE RESPONSABLE DEPENDIENDO A LA SELECCION
        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resp = Convert.ToInt32(cmbResponsable.SelectedValue);
        }


        //*******************AGREGA LA INCIDENCIA EN LA SELECCION
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            int Id;
            v_dvg = 1;
            dataGridView1.Rows.Add(cmbIncidencia.SelectedValue, cmbIncidencia.Text);
            Id = cmbIncidencia.SelectedIndex;

            if (Id == 14)
            {
                txtOtro.Visible = true;
                lblOtro.Visible = true;
            }
        }


        //******************ASIGNA ID DE ESTATUS DEPENDIENDO DE LA ELECCION
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idestatus = Convert.ToInt32(cmbEstatus.SelectedValue);
        }


        //**********************LLAMA LA CONSULTA PARA GUARDAR LOS DATOS EN TABLA DOCUMENTACION
        public void SaveDocument()
        {
            int result;
            try
            {
                result = objConsultasBD.SaveDocumentacion(tipoBD, lblFolio.Text, Idestatus, txtCliente.Text, txtEquipo.Text, txtMarca.Text, txtModelo.Text, txtNoSerie.Text, dtpfechaServicio.Text,
                        Convert.ToInt32(cmbIngeniero.SelectedValue), Convert.ToInt32(cmbTServicio.SelectedValue), Resp, Document, txtAsesor.Text, txtOtro.Text, TestSpire.Usr.User, txtComentarios.Text);
                if(result == 1)
                {
                    MessageBox.Show("Se ha guardado el folio " + lblFolio.Text + " para documentación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //***************************gUARDA LAS INCIDENCIAS AGREGADAS AL GRID
        public void SaveIncidencia()
        {
            int result;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows != null && dataGridView1.Rows.Count != 0)
                {
                    try
                    {
                        result = objConsultasBD.SaveIncidenciaDoc(tipoBD, dataGridView1.Rows[i].Cells["txtDgvTipoIncidencia"].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells["txtDgvIdIncidencia"].Value), lblFolio.Text);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }


        //******************GUARDA EL ID DE DOCUMENTADOR Y RESPONSABLE EN EL FOLIO TABLA FSR
        public void UpFSR()
        {
            int r;

            try
            {
                r = objConsultasBD.UpdateFSRDoc(tipoBD, Document, Resp, lblFolio.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**************LIMPIA CONTROLES
        public void Limpiar()
        {
            txtAsesor.Text = null;
            txtCliente.Text = null;
            txtEquipo.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            txtNoSerie.Text = null;
            txtOtro.Text = null;
            txtComentarios.Text = "";
            dtpfechaServicio.Text = "";
            cmbDocumenta.Text = null;
            cmbIncidencia.Text = null;
            cmbResponsable.Text = null;
            cmbTServicio.Text = null;
            cmbIngeniero.Text = null;
        }


        public void CargaCombos()
        {
            cmbEstatus.DisplayMember = "Text";
            cmbEstatus.ValueMember = "Value";

            var items = new[]
            {
                new{ Text = "Sin Asignar", Value = 14 },
                 new { Text = "Resultados Completos", Value = 7 },
                new { Text = "Resultados Incompletos", Value  = 18},
                new { Text = "Sin Resultados", Value = 19},
                new { Text = "Realizando", Value = 6 },               
                new { Text = "Revision", Value = 8 },
                new { Text = "Correccion Interna", Value = 9 },
                new { Text = "Pendiente de Firma", Value = 10 },
                new { Text = "Firmado", Value = 11 },
                new { Text = "Liberado", Value = 12 },
                new { Text = "Correcciones Externas", Value = 13 },
                new { Text = "Cancelado", Value = 5 }
            };
            cmbEstatus.DataSource = items;

            cmbDocumenta.DisplayMember = "Text";
            cmbDocumenta.ValueMember = "Value";

            var itemsD = new[]
            {
                new { Text = "Alejandra Gutierrez", Value = 36 },
                new { Text = "Alicia Ruiz", Value = 107 },
                new { Text = "Alizbeth Segura", Value = 22 },
                new { Text = "Andrea Miranda", Value = 132 },
                new { Text = "Brenda Pacheco", Value = 128 },
                new { Text = "Carmen Patiño", Value = 33},
                new { Text = "Cesar Leal", Value = 75 },
                new { Text = "Cinthia Martinez", Value = 85 },
                new { Text = "Cinthia Torres", Value = 62 },
                new { Text = "Cynthia Lopez", Value = 76},
                new { Text = "Edgar Aguilar", Value = 37 },
                new { Text = "Fernanda Rodriguez", Value = 45},
                new { Text = "Iskra Cruz", Value = 40},
                new { Text = "Jessica Nieto", Value = 108},
                new { Text = "Josue Gomez", Value = 129 },
                new { Text = "Judith Tamayo", Value = 104},
                new { Text = "Lorena Reyes", Value = 35 },
                new { Text = "Marco Galicia", Value = 130},
                new { Text = "Monica Pichardo", Value = 72 },
                new { Text = "Patricia Rodriguez", Value = 101},
                new { Text = "Regina Siordia", Value = 137 },
                //new { Text = "Rosario Martinez", Value = 34},
            };
            cmbDocumenta.DataSource = itemsD;

            cmbResponsable.DisplayMember = "Text";
            cmbResponsable.ValueMember = "Value";

            var itemsR = new[]
            {
                new { Text = "Alizbeth Segura", Value = 22 },
                new { Text = "Iskra Cruz", Value = 40 },
                new { Text = "Lorena Reyes", Value = 35 }
            };
            cmbResponsable.DataSource = itemsR;
        }
    }
}
