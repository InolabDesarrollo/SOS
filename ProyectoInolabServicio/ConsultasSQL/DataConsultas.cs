using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInolabServicio
{
    public class DataConsultas
    {
        public string Conexion;
        public string strSQL;
        SqlConnection Conn;
        SqlCommand Cmd;



        //********************CADENAS DE CONEXION
        string ConBDServer = "Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";
        string ConBDPruebas = "Data Source=INOLABSERVER03;Initial Catalog=BrowserPruebas;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";

        string ConBDProduccionSAP = "Data Source=INOLABSERVER03;Initial Catalog=Inolab;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";
        string ConBDPruebasSAP = "Data Source=INOLABSERVER03;Initial Catalog=Inolab_Test;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";
        //"Data Source=INOLABSERVER03;Initial Catalog=InolabPruebas;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";



        //********************INICIO SESION
        public SqlDataReader getLogin(int tipoBD, string usuario)
        {
            strSQL = "Select * from Usuarios where Activo = 1 and Usuario= '" + usuario + "'";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL Login: " + ex.Message);
            }
        }

        //****************************************************************************************************************
        //*************************************ENVIO CORREO CALENDARIO
        public SqlDataReader SetDatosCorreo(int tipoBD, string Folio)
        {
            strSQL = "Select *from V_FSR where Folio= " + Folio + " and Estatusid = 1";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosCorreo: " + ex.Message);
            }
        }


        //*********************************************************************************************************
        //********************CONSULTAS PARA FOLIOS
     


        public DataTable getBusquedaFSR(int tipoBD, string TipoBus, string Valor, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select * from V_FSR where " + TipoBus + " like '%" + Valor + "%'";
            }
            if(consul == 2)
            {
                strSQL = "select * from V_FSR where " + TipoBus + " like '%" + Valor + "%' and IdAreaServ in (" + area + ")";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL BusquedaFSR: " + ex.Message);                
            }
        }


        public DataTable getFoliosAgrupados(int BD )
        {
            strSQL = "with Grupo AS (Select Equipo, MAX(IdFsr) as IdFrs from V_FSR " +
                    "group by Equipo) " +
                    "select b.Estatus, b.NoLlamada, b.Cliente, Grupo.Equipo from V_FSR b " +
                    "inner join Grupo on Grupo.IdFrs = b.IdFSR " +
                    "where b.Estatusid in (1, 2)";
            try
            {
                return ExecDataSet(strSQL, BD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FoliosAgrupados: " + ex.Message);
            }
        }


        public DataTable getFoliosReporte(int BD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT IdFSR, Folio, Estatus,NoLlamada, TipoLlamada, Cliente, Departamento, Direccion, Localidad, Telefono,  N_Reportado, N_Responsable, Mail, " +
                "TipoContrato, TipoServicio, Ingeniero, mailIng, F_SolicitudServicio, FechaServicio, Equipo, Marca, Modelo, NoSerie, " +
                "IdEquipo_C, Inicio_Servicio, Fin_Servicio, HoraServicio, Asesor1, Correoasesor1, Observaciones, Proximo_Servicio, " +
                "Refaccion, Responsable, Documentador, ArchivoAdjunto, CorreoCliente, TelCliente, EstatusProtocolo, RealizaProtocolo, OC, Funcionando FROM dbo.V_FSR " +
                "where idservicio in (3, 5, 6, 7, 13, 16, 17)";

            }
            if(consul == 2)
            {
                strSQL = "SELECT IdFSR, Folio, Estatus,NoLlamada, TipoLlamada, Cliente, Departamento, Direccion, Localidad, Telefono,  N_Reportado, N_Responsable, Mail, " +
                "TipoContrato, TipoServicio, Ingeniero, mailIng, F_SolicitudServicio, FechaServicio, Equipo, Marca, Modelo, NoSerie, " +
                "IdEquipo_C, Inicio_Servicio, Fin_Servicio, HoraServicio, Asesor1, Correoasesor1, Observaciones, Proximo_Servicio, " +
                "Refaccion, Responsable, Documentador, ArchivoAdjunto, CorreoCliente, TelCliente, EstatusProtocolo, RealizaProtocolo, OC, Funcionando FROM dbo.V_FSR " +
                "where idservicio in (3, 5, 6, 7, 13, 16, 17) and IdAreaServ in (" + area + ")";

            }
            try
            {
                return ExecDataSet(strSQL, BD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FoliosReporte: " + ex.Message);
            }
        }


        public DataTable getFoliosBusqueda(int BD, string TipoBus, string Valor, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select * from V_FSR where " + TipoBus + " like '%" + Valor + "%' order by Folio Desc";
            }
            if(consul == 2)
            {
                strSQL = "select * from V_FSR where " + TipoBus + " like '%" + Valor + "%' and IdAreaServ in (" + area + ") order by Folio Desc";
            }

            try
            {
                return ExecDataSet(strSQL, BD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la cadena SQL FoliosPaginas: " + ex.Message);
            }
        }


        public DataTable getTodosFolios(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select * from V_FSR order by Folio Desc";
            }
            if (consul == 2)
            {
                strSQL = "select * from V_FSR where IdAreaServ in (" + area + ") order by Folio Desc";                
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar la cadena SQL TodosFoliosPag: " + ex.Message);
            }
        }


        public DataTable getFSRFiltroFechas(int BD, string f1, string f2, string tipo, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT * FROM dbo.V_FSR where " + tipo + " between '" + f1 + "' and '" + f2 + "' " +
                "order by " + tipo + " desc";
            }
            if(consul == 2)
            {
                strSQL = "SELECT * FROM dbo.V_FSR where " + tipo + " between '" + f1 + "' and '" + f2 + "' " +
                "and IdAreaServ in (" + area + ") order by " + tipo + " desc";
            }
            try
            {
                return ExecDataSet(strSQL, BD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FiltroFechas: " + ex.Message);
            }
        }


        public DataTable getFiltroFSRHoy(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "Select * from V_FSR where CONVERT(date, FechaServicio) = CONVERT(DATE, GETDATE())";
            }
            if(consul == 2)
            {
                strSQL = "Select * from V_FSR where CONVERT(date, FechaServicio) = CONVERT(DATE, GETDATE()) and IdAreaServ in (" + area + ")";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FiltroFSRHoy: " + ex.Message);
            }
        }


        public DataTable getFSRSemanaAnt(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio " +
                    "BETWEEN CONVERT(DATE, DATEADD(DAY, -7, GETDATE()), 101) AND CONVERT(DATE, DATEADD(DAY, -1, GETDATE()), 101) " +
                    "ORDER BY FechaServicio desc";
            }
            if(consul == 2)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio " +
                    "BETWEEN CONVERT(DATE, DATEADD(DAY, -7, GETDATE()), 101) AND CONVERT(DATE, DATEADD(DAY, -1, GETDATE()), 101) " +
                    "and IdAreaServ in (" + area + ") ORDER BY FechaServicio desc";

            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FiltroSemanaAnt: " + ex.Message);
            }
        }


        public DataTable getFSRMesActual(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT * FROM V_FSR WHERE MONTH(FechaServicio) = MONTH(GETDATE()) AND YEAR(FechaServicio) = YEAR(GETDATE()) " +
                    "ORDER BY FechaServicio desc";
            }
            if(consul == 2)
            {
                strSQL = "SELECT * FROM V_FSR WHERE MONTH(FechaServicio) = MONTH(GETDATE()) AND YEAR(FechaServicio) = YEAR(GETDATE()) " +
                    "AND IdAreaServ in (" + area + ") ORDER BY FechaServicio desc";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recupaerar cadena SQL FSRMesActual: " + ex.Message);
            }
        }


        public DataTable getFSRMesAnterior(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio BETWEEN " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND EOMONTH(GETDATE(), -1 ) ORDER BY FechaServicio desc";
            }
            if(consul == 2)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio BETWEEN " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND EOMONTH(GETDATE(), -1 ) AND IdAreaServ in (" + area + ") ORDER BY FechaServicio desc";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FSRMesAnterior: " + ex.Message);
            }
        }


        public DataTable getFSRMasAntiguos(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio < " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "order by FechaServicio desc";
            }
            if(consul == 2)
            {
                strSQL = "SELECT * FROM V_FSR WHERE FechaServicio < " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND IdAreaServ in (" + area + ") order by FechaServicio desc";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FSRMasAntiguos: " + ex.Message);
            }
        }

        public DataTable getFSRMuestraDatoA(int BD, string Llamada, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select * from V_FSR where NoLlamada = " + Llamada + " and Folio >= 26600 ";
            }
            if(consul == 2)
            {
                strSQL = "select * from V_FSR where NoLlamada = " + Llamada + " and Folio >= 26600 and IdAreaServ in (" + area + ")";
            }

            try
            {
                return ExecDataSet(strSQL, BD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL MuestraDatosA: " + ex.Message);
            }
        }

        public string getComentFolio(int tipoBD, int idActividad)
        {
            strSQL = "select Observaciones from V_FSR where Actividad = " + idActividad;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL Coment Folio: " + ex);
            }
        }


        //***************************************************************************************************************************
        //********************CONSULTAS REGISTROS SAP
        public DataTable getTodasLlamadasSAP(int TipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                       "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                       "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                       "order by FechaInicioactividad ";
            }
            if(consul == 2)
            {
                strSQL = "select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                       "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                       "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP where IdTipoLlamada in (" + area + ") " +
                       "order by FechaInicioactividad ";
            }            

            try
            {
                return ExecDataSet(strSQL, TipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL TodasLlamadasSAP: " + ex.Message);
            }
        }


        public DataTable getLlamadasMes(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                     "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                     "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                     "where DATEPART(MONTH, FechaInicioactividad) = MONTH(Getdate()) AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) " +
                     "order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                     "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                     "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                     "where DATEPART(MONTH, FechaInicioactividad) = MONTH(Getdate()) AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) " +
                     "AND IdTipoLlamada in (" + area + ") " +
                     "order by FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadasMes: " + ex.Message);
            }
        } 


        public DataTable getFiltroLlamadaMesAsignada(int tipoBD, int mes, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP where DATEPART(MONTH, FechaInicioactividad) = " + mes +
                    " AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) and Status_ = 'Asignado' "+
                    "order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP where DATEPART(MONTH, FechaInicioactividad) = " + mes +
                    " AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) and Status_ = 'Asignado' and IdTipoLlamada in (" + area + ") " +
                    "order by FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FiltroLlamadaMesAsignada: " + ex.Message);
            }
        }


        public DataTable getFiltroLlamadaMesSinAsignar(int tipoBD, int mes, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                    "where DATEPART(MONTH, FechaInicioactividad) = " + mes +
                    " AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) and Status_ = 'Sin Asignar' " +
                     "order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                    "where DATEPART(MONTH, FechaInicioactividad) = " + mes +
                    " AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) and Status_ = 'Sin Asignar' and IdTipoLlamada in (" + area + ") " +
                     "order by FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FiltroLlamadaMesSinAsignar: " + ex.Message);
            }
        }


        public DataTable getLlamadaRango(int tipoBD, string FechaI, string FechaF, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                    "where FechaInicioactividad between '" + FechaI + "' and '" + FechaF + "' " +
                    "order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "Select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv from V_LlamadasSAP " +
                    "where FechaInicioactividad between '" + FechaI + "' and '" + FechaF + "' and IdTipoLlamada in (" + area + ") " +
                    "order by FechaInicioactividad";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadaRango: " + ex.Message);
            }
        }


        public DataTable getLlamadasHoy(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                        "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                        "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP where CONVERT(date, FechaInicioactividad, 101) = CONVERT(date, GETDATE(), 101) " +
                        " order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "select Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                        "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                        "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP where CONVERT(date, FechaInicioactividad, 101) = CONVERT(date, GETDATE(), 101) and IdTipoLlamada in (" + area + ") " +
                        " order by FechaInicioactividad";
            }
            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadasHoy: " + ex.Message);
            }
        } 


        public DataTable getLlamadasSemanaAnterior(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                     "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                     "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad BETWEEN DATEADD(DAY, -7, GETDATE()) AND DATEADD(DAY, -1, GETDATE()) " +
                     "order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                     "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                     "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad BETWEEN DATEADD(DAY, -7, GETDATE()) AND DATEADD(DAY, -1, GETDATE()) " +
                     "and IdTipoLlamada in (" + area + ") order by FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadasSemanaAnterior: " + ex.Message);
            }
        }



        public DataTable getLlamadasMesAnterior(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad BETWEEN " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND EOMONTH(GETDATE(), -1 ) " +
                    " ORDER BY FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad BETWEEN " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND EOMONTH(GETDATE(), -1 ) and IdTipoLlamada in (" + area + ") " +
                    " ORDER BY FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar caena SQL LlamadasMesAnterior: " + ex.Message);
            }
        }


        public DataTable getLlamadasMasAntiguas(int tipoBD, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad < " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "ORDER BY FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "SELECT Status_, Ser_confirmar, IDActividad , NoLlamada, FechaCreacion, FechaInicioactividad, FechaIngeniero, FechaCoordinacion, " +
                    "TipoServicio, ClienteFiscal, Equipo, Marca, Modelo, noSerie, OrdenVenta, Asignado, ComentariosLlamada, FolioFSR, Comentarios, IdFSR, IdEquipo, Vig_Contrato, " +
                    "TipoLlamada, FechaActualizaActiv, FechaCreaActiv FROM V_LlamadasSAP WHERE FechaInicioactividad < " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "and IdTipoLlamada in (" + area + ") ORDER BY FechaInicioactividad";
            }            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena AQL LlamadasMasAntiguas: " + ex.Message);
            }
        }


        public DataTable getLlamadaBusqueda(int tipoBD, string TipoBus, string Valor, int consul, string area)
        {
            if(consul == 1)
            {
                strSQL = "select * from V_LlamadasSAP where " + TipoBus + " like '%" + Valor + "%' " +
                        " order by FechaInicioactividad";
            }
            if(consul == 2)
            {
                strSQL = "select * from V_LlamadasSAP where " + TipoBus + " like '%" + Valor + "%' and IdTipoLlamada in (" + area + ") " +
                        " order by FechaInicioactividad";
            }
            if(consul == 3)
            {
                strSQL = "select * from V_LlamadasSAP where TipoLlamada is null and " + TipoBus + " like '%" + Valor + "%'";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadaBusqueda: " + ex.Message);
            }
            
        }

        public DataTable getLlamadasSinArea(int tipoBD)
        {
            strSQL = "select * from V_LlamadasSAP where TipoLlamada is null";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadasSinArea: " + ex.Message);
            }
        }


        public string generaFolio(int tipoBD, string llamada)
        {
            strSQL = "select a.Folio, a.NoLlamada, b.NoLlamada from V_FSR a " +
                    "inner join V_LlamadasSAP b on a.NoLlamada = b.NoLlamada where b.NoLlamada = " + llamada;
            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL GeneraFolio: " + ex.Message);
            }
        }


        


        //*********************** REFACCIONES
        

        //******************************************************************************************************************************************
        //*********************** CONSULTAS FOLIOS DOCUMENTACION
        public DataTable getFoliosDocument(int tipoBD)
        {
            strSQL = "SELECT IdFSR, Folio, Estatus,NoLlamada, Cliente, Departamento, Direccion, Localidad, Telefono,  N_Reportado, N_Responsable, Mail, " +
                       "TipoContrato, TipoServicio, Ingeniero, mailIng, F_SolicitudServicio, FechaServicio, Equipo, Marca, Modelo, NoSerie, " +
                       "IdEquipo_C, Inicio_Servicio, Fin_Servicio, HoraServicio, Asesor1, Correoasesor1, Observaciones, Proximo_Servicio, " +
                       "Refaccion, Responsable, Documentador FROM dbo.V_FSR " +
                       "where idservicio in (2, 3, 4, 5, 6, 7, 8, 13, 15, 16, 17, 18) " +
                       "and not Folio <= 26555 order by Folio desc";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL Foliosdocumentacion: " + ex.Message);
            }
        }


        public DataTable getFoliosMes(int tipoBD, int Mes)
        {
            strSQL = "SELECT IdFSR, Folio, Estatus,NoLlamada, Cliente, Departamento, Direccion, Localidad, Telefono,  N_Reportado, N_Responsable, Mail, " +
                       "TipoContrato, TipoServicio, Ingeniero, mailIng, F_SolicitudServicio, FechaServicio, Equipo, Marca, Modelo, NoSerie, " +
                       "IdEquipo_C, Inicio_Servicio, Fin_Servicio, HoraServicio, Asesor1, Correoasesor1, Observaciones, Proximo_Servicio, " +
                       "Refaccion, Responsable, Documentador FROM dbo.V_FSR " +
                       "where idservicio in (2, 3, 4, 5, 6, 7, 8, 13, 15, 16, 17, 18) and DATEPART(MONTH, Fin_Servicio) = " + Mes +
                       " and DATEPART(YEAR, Fin_Servicio) = YEAR(GETDATE()) " +
                       "and not Folio <= 26599 order by Folio desc";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FoliosMes: " + ex.Message);
            }
        }


        public DataTable getFolioSinDoc(int tipoBD)
        {
            strSQL = "SELECT IdFSR, Folio, Estatus,NoLlamada, Cliente, Departamento, Direccion, Localidad, Telefono,  N_Reportado, N_Responsable, Mail, " +
                       "TipoContrato, TipoServicio, Ingeniero, mailIng, F_SolicitudServicio, FechaServicio, Equipo, Marca, Modelo, NoSerie, " +
                       "IdEquipo_C, Inicio_Servicio, Fin_Servicio, HoraServicio, Asesor1, Correoasesor1, Observaciones, Proximo_Servicio, " +
                       "Refaccion, Responsable, Documentador FROM dbo.V_FSR " +
                       "where idservicio in (2, 3, 4, 5, 6, 7, 8, 13, 15, 16, 17, 18) and IdDocumenta is null " +
                       "and not Folio <= 26599 order by Folio desc";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FolioSinDoc: " + ex.Message);
            }
        }


        public int getExsiteFolioDoc(int tipoBD, string folio)
        {
            strSQL = "select COUNT(FolioFSR) as f from V_Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteFolioDoc: " + ex.Message);
            }
        }


        //*****************ACTUALIZA DOCUMENT
        public int UpdateAsignaDocument(int tipoBD, int idDoc, string folio)
        {
            strSQL = "update FSR set IdDocumenta = " + idDoc + " where Folio = " + folio;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateAsignaDocument: " + ex.Message);
            }
        }


        public int UpdateAsignaResp(int tipoBD, int idResp, string folio)
        {
            strSQL = "update FSR set IdResp = " + idResp + " where Folio = " + folio;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al rescuperar cadena SQL UpdateAsignaResp: " + ex.Message);
            }
        }

        
        public int UpdateDocFolioAcuse(int tipoBD, string tipoAcuse, string rutaAcuse, string tipoFolioA, string FolioAcuse, string folio)
        {
            strSQL = "update Documentacion set " + tipoAcuse + " = '" + rutaAcuse + "', " + tipoFolioA + "= '" + FolioAcuse + "' where FolioFSR = " + folio;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateDocument: " + ex.Message);
            }
        }


        public SqlDataReader Verificafechas(int tipoBD, string folio)
        {
            strSQL = "select F_SinAsignar, F_Realizando, F_Resultado, F_Revision, F_CorrecInterna, F_PendienteF, " +
                    "F_Firmado, F_Liberado, F_CorrecExtern from Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL verificaFechas: " + ex.Message);
            }
        }


        public int UpdateFechasAnteriores(int tipoBD, string tipoFecha, string folio)
        {
            strSQL = "update Documentacion set " + tipoFecha + " = GETDATE() where FolioFSR = " + folio;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateFechasAnteriores: " + ex.Message);
            }
        }


        public int SaveIncidenciaDoc(int tipoBD, string tipoIncidencia, int IdIncidencia, string folio)
        {
            strSQL = "insert into IncidenciaDocument (DescripcionI, IdIncidencia, FolioFSR) values ('" + tipoIncidencia + "', " + IdIncidencia + ", " + folio + ")";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SaveIncidenciaDoc: " + ex.Message);
            }
        }


        public SqlDataReader setDatosFolioDoc(int tipoBD, string folio)
        {
            strSQL = "select * from V_Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosFolioDoc: " + ex.Message);
            }
        }


        public SqlDataReader setIncidenciasDoc(int tipoBD, string folio)
        {
            strSQL = "select * from IncidenciaDocument where FolioFSR = " + folio;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL IncidenciasDoc: " + ex.Message);
            }
        }


        public int UpdateMotCambio(int tipoBD, string motivo, string folioFSR)
        {
            strSQL = "update Documentacion set Motivo_Cambio = '" + motivo + "' where FolioFSR = " + folioFSR;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateMotCambio: " + ex.Message);
            }
        }


        public int UpdateFechaDocument(int tipoBD, string folioFSR)
        {
            strSQL = "update Documentacion set F_SinAsignar = GETDATE() where FolioFSR = " + folioFSR;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateFechaDocument: " + ex.Message);
            }
        }


        //***********************REGISTROS DOCUMENTACION
        public DataTable getRegistrosUsuarioDoc(int tipoBD, string IdUser, int tipoC)
        {
            strSQL = "select FolioFSR, Estatus, Cliente, TipoServicio, Equipo, Marca, Modelo, NoSerie, Inicio_Servicio, Fin_Servicio, " +
                    "Ingeniero, Responsable, Documentador, F_SinAsignar, F_Realizando, F_Resultado, F_Revision, F_CorrecInterna, F_PendienteF, IdEquipo, " +
                    "F_Firmado, F_Liberado, F_CorrecExtern, N_Responsable, CodCliente, fAcuse_guia, ISNULL(Acuse_CE1, 0) AS Acuse_CE1, ISNULL(Acuse_CE2, 0) Acuse_CE2, " +
                    "ISNULL(Acuse_CE3, 0) AS Acuse_CE3, ISNULL(Acuse_CE4, 0) AS Acuse_CE4, ISNULL(Acuse_CE5, 0) AS Acuse_CE5, ISNULL(Acuse_CE6, 0) AS Acuse_CE6, " +
                    "ISNULL(Acuse_CE7, 0) AS Acuse_CE7, ISNULL(Acuse_CE8, 0) AS Acuse_CE8, ISNULL(Acuse_CE9, 0) AS Acuse_CE9, ISNULL(Acuse_CE10, 0) AS Acuse_CE10, " +
                    "ISNULL(FolioA_Inicial, 0) AS FolioA_Inicial, ISNULL(FolioA_CE1, 0) AS FolioA_CE1, ISNULL(FolioA_CE2, 0) AS FolioA_CE2, ISNULL(FolioA_CE3, 0) AS FolioA_CE3, " +
                    "ISNULL(FolioA_CE4, 0) AS FolioA_CE4, ISNULL(FolioA_CE5, 0) AS FolioA_CE5, ISNULL(FolioA_CE6, 0) AS FolioA_CE6, ISNULL(FolioA_CE7, 0) AS FolioA_CE7, " +
                    "ISNULL(FolioA_CE8, 0) AS FolioA_CE8, ISNULL(FolioA_CE9, 0) AS FolioA_CE9, ISNULL(FolioA_CE10, 0) AS FolioA_CE10 " +
                    "from V_Documentacion where IdDocumentador in (" + IdUser + ")";

            if (tipoC == 1)
            {
                strSQL += " and not IdEstatus = 5 order by FolioFSR desc";
            }
            if(tipoC == 2)
            {
                strSQL += " and not IdEstatus = 12 and not IdEstatus = 13 and not IdEstatus = 5 order by FolioFSR desc";
            }
            

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RegistrosUsuarioDoc: " + ex.Message);
            }
        }


        public DataTable getRegistrosDocumentacion(int tipoBD)
        {
            strSQL = "select FolioFSR, Estatus, Cliente, TipoServicio, Equipo, Marca, Modelo, NoSerie, Inicio_Servicio, Fin_Servicio, " +
                    "Ingeniero, Responsable, Documentador, F_SinAsignar, F_Realizando, F_Resultado, F_Revision, F_CorrecInterna, F_PendienteF, IdEquipo, " +
                    "F_Firmado, F_Liberado, F_CorrecExtern, N_Responsable, CodCliente, fAcuse_guia, ISNULL(Acuse_CE1, 0) AS Acuse_CE1, ISNULL(Acuse_CE2, 0) Acuse_CE2, " +
                    "ISNULL(Acuse_CE3, 0) AS Acuse_CE3, ISNULL(Acuse_CE4, 0) AS Acuse_CE4, ISNULL(Acuse_CE5, 0) AS Acuse_CE5, ISNULL(Acuse_CE6, 0) AS Acuse_CE6, " +
                    "ISNULL(Acuse_CE7, 0) AS Acuse_CE7, ISNULL(Acuse_CE8, 0) AS Acuse_CE8, ISNULL(Acuse_CE9, 0) AS Acuse_CE9, ISNULL(Acuse_CE10, 0) AS Acuse_CE10, " +
                    "ISNULL(FolioA_Inicial, 0) AS FolioA_Inicial, ISNULL(FolioA_CE1, 0) AS FolioA_CE1, ISNULL(FolioA_CE2, 0) AS FolioA_CE2, ISNULL(FolioA_CE3, 0) AS FolioA_CE3, " +
                    "ISNULL(FolioA_CE4, 0) AS FolioA_CE4, ISNULL(FolioA_CE5, 0) AS FolioA_CE5, ISNULL(FolioA_CE6, 0) AS FolioA_CE6, ISNULL(FolioA_CE7, 0) AS FolioA_CE7, " +
                    "ISNULL(FolioA_CE8, 0) AS FolioA_CE8, ISNULL(FolioA_CE9, 0) AS FolioA_CE9, ISNULL(FolioA_CE10, 0) AS FolioA_CE10 " +
                    "from V_Documentacion order by FolioFSR desc";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RegistrosDocumentacion: " + ex.Message);
            }
        }


        public DataTable getRegistrosMesD(int tipoBD, int mes)
        {
            strSQL = "select FolioFSR, Estatus, Cliente, TipoServicio, Equipo, Marca, Modelo, NoSerie, Inicio_Servicio, Fin_Servicio, " +
                    "Ingeniero, Responsable, Documentador, F_SinAsignar, F_Realizando, F_Resultado, F_Revision, F_CorrecInterna, F_PendienteF, IdEquipo, " +
                    "F_Firmado, F_Liberado, F_CorrecExtern, N_Responsable, CodCliente, fAcuse_guia, ISNULL(Acuse_CE1, 0) AS Acuse_CE1, ISNULL(Acuse_CE2, 0) Acuse_CE2, " +
                    "ISNULL(Acuse_CE3, 0) AS Acuse_CE3, ISNULL(Acuse_CE4, 0) AS Acuse_CE4, ISNULL(Acuse_CE5, 0) AS Acuse_CE5, ISNULL(Acuse_CE6, 0) AS Acuse_CE6, " +
                    "ISNULL(Acuse_CE7, 0) AS Acuse_CE7, ISNULL(Acuse_CE8, 0) AS Acuse_CE8, ISNULL(Acuse_CE9, 0) AS Acuse_CE9, ISNULL(Acuse_CE10, 0) AS Acuse_CE10, " +
                    "ISNULL(FolioA_Inicial, 0) AS FolioA_Inicial, ISNULL(FolioA_CE1, 0) AS FolioA_CE1, ISNULL(FolioA_CE2, 0) AS FolioA_CE2, ISNULL(FolioA_CE3, 0) AS FolioA_CE3, " +
                    "ISNULL(FolioA_CE4, 0) AS FolioA_CE4, ISNULL(FolioA_CE5, 0) AS FolioA_CE5, ISNULL(FolioA_CE6, 0) AS FolioA_CE6, ISNULL(FolioA_CE7, 0) AS FolioA_CE7, " +
                    "ISNULL(FolioA_CE8, 0) AS FolioA_CE8, ISNULL(FolioA_CE9, 0) AS FolioA_CE9, ISNULL(FolioA_CE10, 0) AS FolioA_CE10 " +
                    "from V_Documentacion where DATEPART(MONTH, Fin_Servicio) =  " + mes +
                    " and DATEPART(YEAR, Fin_Servicio) = YEAR(GETDATE()) order by Fin_Servicio";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RegistrosMesD: " + ex.Message);
            }
        }


        public int getExistenAcuses(int tipoBD, string tipoAcuse, string folio)
        {
            strSQL = "select count(" + tipoAcuse + ") from documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExistenAcuses: " + ex.Message);
            }
        }

               
        public string getRutasAcuses(int tipoBD, string tipoAcuse, string folio)
        {
            strSQL = "select " + tipoAcuse + " from Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RutaAcuse: " + ex.Message);
            }
        }
        
        
        public DataTable getRegistrosRangoDocumentacion(int tipoBD, string fecha1, string fecha2)
        {
            strSQL = "select * from V_Documentacion where Inicio_Servicio between '" + fecha1 + "' and '" + fecha2 + "' order by Inicio_Servicio desc";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RegistrosRango: " + ex.Message + " - " + ex.ToString());
            }
        }
        

        public string getIdFolio(int tipoBD, string FSR)
        {
            strSQL = "select idFSR from V_Documentacion where FolioFSR = " + FSR;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recupoerar cadena SQL getIdFolio: " + ex.Message+ " - " + ex.ToString());
            }
        }

        //***************************DOCUMENTACION
        public SqlDataReader setDatosAsignarDoc(int tipoBD, string FolioD)
        {
            strSQL = "select *from V_FSR where folio=" + FolioD;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosAsignarDoc: " + ex.Message);
            }
        }

        
        public int UpdateFSRDoc(int tipoBD, int Document, int Resp, string folio)
        {
            strSQL = "update FSR set idDocumenta = " + Document + ", IdResp = " + Resp + " where Folio = " + folio;
            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateFSRDoc: " + ex.Message);
            }
        }
        

        //*********************** ACUSES DOCUMENTACION
        public DataTable getClientesAcuse(int tipoBD, string busqueda)
        {
            strSQL = "select distinct CodCliente, Cliente from V_Documentacion " +
                    "where Cliente like '%" + busqueda + "%' --and CodCliente like '%CL%'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ClientesAcuse: " + ex.Message);
            }
        }


        public DataTable getResponsableAcuses(int tipoBD, string cliente)
        {
            strSQL = "select distinct N_Responsable from V_Documentacion where CodCliente = '" + cliente + "'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ResponsableAcuses: " + ex.Message);
            }
        }

        public DataTable getDeptoAcuse(int tipoBD, string cliente)
        {
            strSQL = "select distinct Departamento from V_Documentacion where CodCliente = '" + cliente + "'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DeptoAcuse: " + ex.Message);
            }
        }


        public DataTable getFoliosAcuse(int tipoBD, string idcliente, string cliente)
        {
            //if(tipoC == 1)
            //{
            //    strSQL = "select FolioFSR from V_Documentacion where CodCliente = '" + cliente + "' order by FolioFSR desc";
            //}
            //if(tipoC == 2)
            //{
            //    strSQL = "select FolioFSR from V_Documentacion where CodCliente = '" + cliente + "' " +
            //            "order by FolioFSR desc";
            //}
            //strSQL = "select Folio from V_FSR as F " +
            //        "where exists(select* from V_Documentacion as D where F.Folio = D.FolioFSR and CodCliente = '" + cliente + "') " +
            //        "or F.IdT_Servicio = 4 and Folio >= 29500 order by Folio";
            strSQL = "select * from V_FSR f where Folio >= 29500 and idservicio in (3, 4, 5, 6, 7, 13, 15, 16, 17, 18) " +
                    "and Cliente like '%" + cliente +" %' or exists(select* from V_Documentacion d where d.FolioFSR = f.Folio and CodCliente = '"+ idcliente + "') " +
                    "or Folio = 32625";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FoliosAcuse: " + ex.Message);
            }
        }


        public SqlDataReader setDatosFolioA(int tipoBD, string folio)
        {
            strSQL = "select Folio, TipoServicio, Equipo, NoSerie from V_FSR where Folio = '" + folio + "'";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosFolioA: " + ex.Message);
            }
        } 


        public DataTable getDireccionClienteA(int tipoBD, string cliente)
        {
            strSQL = "select distinct Direccion from V_Documentacion where CodCliente = '" + cliente + "'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DireccionClienteA: " + ex.Message);
            }
        }


        public DataTable getTelefonoAcuse(int tipoBD, string cliente)
        {
            strSQL = "select distinct telefono from V_Documentacion where CodCliente = '" + cliente + "'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL TelefonoAcuse: " + ex.Message);
            }
        }

        public string getFolioAcuse(int tipoBD)
        {
            strSQL = "select max(FolioA) + 1 AS er from AcuseDocumentacion";

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FolioAcuse: " + ex.Message);
            }
        }

        public int updateGuiaAcuse(int tipoBD, string FSR, string guia)
        {
            strSQL = "update AcuseDocumentacion set Guia_Envio = '" + guia + "' where FolioFSR = " + FSR;
            
            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL GuiaAcuse: " + ex.Message);
            }
        }

        public int updateGuiaDocumentacion(int tipoBD, string guia, string FSR)
        {
            strSQL = "update Documentacion set fAcuse_guia = '" + guia + "' where FolioFSR = " + FSR;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL GuiaDocumentacion: " + ex.Message);
            }
        }

        public int UpdateFolioAcuseDoc(int tipoBD, string tipoAcuse, string acuse, string FSR)
        {
            strSQL = "update Documentacion set " + tipoAcuse + " = " + acuse + " where FolioFSR = " + FSR;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateAcuseDoc: " + ex.Message);
            }
        }


        public int getExisteAcuseDigital(int tipoBD, int folio)
        {
            strSQL = "select count(FolioA) as f from AcuseDocumentacion where FolioA = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteAcuseDigital: " + ex.Message);
            }
        }

        public int getTieneFolioA(int tipoBD, int folio, string tipoAcuse)
        {
            strSQL = "select count(" + tipoAcuse + ") from Documentacion where " + tipoAcuse + " = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL TieneFolioA: " + ex.Message);
            }
        }


        public int getExisteFolioInicial(int tipoBD, string folio)
        {
            strSQL = "select count(FolioA_Inicial) as e from Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteFolioInicial: " + ex.Message);
            }
        }

        public DataTable getAcusesDocument(int tipoBD, string FSR, int tipoCon)
        {
            if(tipoCon == 2)
            {
                strSQL = "select * from V_FoliosAcusesDocFirmado where FolioFSR = " + FSR;
            }
            if(tipoCon == 1)
            {
                strSQL = "select * from V_FoliosAcusesDoc where FolioFSR = " + FSR + " and FoliosAcuses >= 13054";
            }           

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL AcusesDocument: " + ex.Message + " " + ex.ToString());
            }
        }
       

        //***********************CORRECCION DE ACUSES
        public SqlDataReader setDatosClienteAcuse(int tipoBD, int acuse)
        {
            strSQL = "select Empresa, Direccion, Atencion, Depto, Observaciones, Telefono from AcuseDocumentacion where FolioA = " + acuse;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQl DatosClienteAcuse: " + ex.Message);
            }
        }


        public SqlDataReader setDatosAcuseFisico(int tipoBD, int folio)
        {
            strSQL = "select CodCliente, Cliente, Direccion, Departamento, N_Responsable, Telefono  from V_Documentacion where FolioFSR = " + folio;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al resuperar cadena SQL DatosAcuseFisico: " + ex.Message);
            }
        }


        public DataTable getDatosFoliosAcuse(int tipoBD, int acuse)
        {
            strSQL = " select A.FolioFSR, V.TipoServicio, V.Equipo, V.NoSerie from AcuseDocumentacion AS A " +
                    "left join V_FSR AS V ON V.Folio = A.FolioFSR where FolioA = " + acuse;

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosFoliosAcuse: " + ex.Message);
            }
        }


        public DataTable getListaAcuses(int tipoBD)
        {
            strSQL = "select FolioFSR, Cliente, TipoServicio, Equipo, NoSerie, AcuseInicial "+
                    "from V_Documentacion as V where " +
                    "exists(select *from AcuseDocumentacion as a where V.FolioFSR = a.FolioFSR) or AcuseInicial is not null " +
                    "and FolioFSR >= 29000 order by FolioFSR desc";
                //"select * from V_AcusesDoc order by FolioA desc";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ListaAcuses: " + ex.Message);
            }
        }


        public int getConteoFoliosAcuse(int tipoBD, string FSR, int tipoC)
        {
            if(tipoC == 1)
            {
                strSQL = "select count(FolioFSR) as c from AcuseDocumentacion where FolioFSR = " + FSR;
            }
            if(tipoC == 2)
            {
                strSQL = "select COUNT(AcuseInicial) + Count(Acuse_CE1) + COUNT(Acuse_CE2) + COUNT(Acuse_CE3) + COUNT(Acuse_CE4) + COUNT(Acuse_CE5) " +
                        "+ COUNT(Acuse_CE6) + COUNT(Acuse_CE7) + COUNT(Acuse_CE8) + COUNT(Acuse_CE9) + COUNT(Acuse_CE10) " +
                        "from V_Documentacion where FolioFSR = " + FSR;
            }            

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ConteoFoliosAcuse: " + ex.Message);
            }
        }


        public int getExistEnAcuseD(int tipoBD, string FSR)
        {
            strSQL = "select count(FolioFSR) from AcuseDocumentacion where FolioFSR = " + FSR;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error a recuperar caden SQL ExisteEnAcuseD: " + ex.Message);
            }
        }


        public int getBuscaUFolioAcuse(int tipoBD, string FSR)
        {
            strSQL = "select Max(FolioA) from AcuseDocumentacion where FolioFSR = " + FSR;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FolioAcuse: " + ex.Message);
            }
        }
        
        //**************************************************************************************************************************************************
        //*********************** CONSULTAS FOLIOS PROTOCOLOS
        public DataTable getFoliosProtocolos(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR  " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where l.IdTiposervicio in (12, 13, 14, 23, 20, 34, 35, 36, 37) " + //20 para calibraciones
                    "order by FechaInicioactividad";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL FoliosProtocolos: " + ex.Message);
            }
        }

        
        public DataTable getProtocolosMes(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where DATEPART(MONTH, FechaInicioactividad) = MONTH(Getdate()) AND DATEPART(Year, FechaInicioactividad) = Year(GETDATE()) " +
                    "and l.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) " +
                    "order by FechaInicioactividad";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocolosInicioMes: " + ex.Message);
            }
        }


        public DataTable getProtocolosHoy(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where CONVERT(date, L.FechaInicioactividad, 101) = CONVERT(date, GETDATE(), 101) " +
                    "and l.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) ";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocolosHoy: " + ex.Message);
            }
        }


        public DataTable getProtocolosSenamaAnt(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where L.FechaInicioactividad between CONVERT(DATE, DATEADD(DAY, -7, GETDATE()), 101) AND CONVERT(DATE, DATEADD(DAY, -1, GETDATE()), 101) " +
                    "and l.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) " +
                    "order by FechaInicioactividad";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocolosSemanaAnt: " + ex.Message);
            }
        }


        public DataTable getProtocolosMesAnterior(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where L.FechaInicioactividad between CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "AND EOMONTH(GETDATE(), -1 ) " +
                    "and l.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) " +
                    "order by FechaInicioactividad";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("error al recuperr cadena SQL ProtocolosMesAnterior: " + ex.Message);
            }
        }


        public DataTable getProtocolosAntiguos(int tipoBD)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where L.FechaInicioactividad < " +
                    "CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) " +
                    "and l.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) " +
                    "order by FechaInicioactividad";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocolosAntiguos: " + ex.Message);
            }
        }


        public DataTable getProtocolosFiltroMes(int tipoBD, int Mes, int tipo)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where DATEPART(MONTH, L.FechaInicioactividad) = " + Mes +
                    " AND DATEPART(Year, L.FechaInicioactividad) = Year(GETDATE()) " +
                    "and L.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) ";

            if(tipo == 1)
            {
                strSQL = strSQL + "and Status_ = 'Asignado' " +
                       "order by FechaInicioactividad";
            }
            if(tipo == 2)
            {
                strSQL = strSQL + "and Status_ = 'Sin Asignar' " +
                       "order by FechaInicioactividad";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocolosFiltroMes: " + ex.Message);
            }
        }


        public DataTable getProtocoloFiltroFechas(int tipoBD, string FechaI, string FechaF)
        {
            strSQL = "select L.Status_, L.Ser_confirmar, L.IDActividad, L.NoLlamada, L.FechaCreacion, L.FechaInicioactividad, L.FechaIngeniero, " +
                    "L.FechaCoordinacion, L.TipoServicio, L.ClienteFiscal, L.Equipo, L.Marca, L.Modelo, L.noSerie, L.OrdenVenta, L.Asignado, " +
                    "L.ComentariosLlamada, L.FolioFSR, L.Comentarios, P.Estatus as EstatusProtocolo, P.RealizaP as RealizaProtocolo, L.Nombre, L.Correo, L.Telefono, L.FolioFSR " +
                    "from V_LlamadasSAP L " +
                    "left join V_Protocolos P on L.IDActividad = P.IdActividad " +
                    "where FechaInicioactividad between '" + FechaI + "' and '" + FechaF + "' " +
                    "and L.IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37) " +
                    "order by FechaInicioactividad";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ProtocoloFiltroFechas: " + ex.Message);
            }
        }


        public string getComentariosLlamada(int idActiv, int tipoBD)
        {
            strSQL = "select ComentariosLlamada from V_LlamadasSAP where IDActividad = " + idActiv;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ComentarioProtocolo: " + ex.Message);
            }
        }


        //****************ACTUALIZA PROTOCOLO
        public DataTable getDatosServicioP(int tipoBD, string NoLlamada)
        {
            strSQL = "select Equipo, IDActividad, TipoServicio, Marca, " +
                   "Modelo, noSerie, FechaSolicitudServicio, Comentarios, FolioFSR, TipoContrato " +
                   "from V_LlamadasSAP where NoLlamada = " + NoLlamada +
                   " and IdTiposervicio in (12, 13, 14, 20, 23, 34, 35, 36, 37)";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosServicioP: " + ex.Message);
            }
        }


        public SqlDataReader setDatosClienteP(int tipoBD, string NoLlamada)
        {
            strSQL = "select * FROM V_LlamadasSAP where NoLlamada = " + NoLlamada;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosClienteP: " + ex.Message);
            }
        }


        public int getExisteProtocolo(int tipoBD, string IdActiv)
        {
            strSQL = "select COUNT(IdActividad) as ac from V_Protocolos where IdActividad = " + IdActiv;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteProtocolo: " + ex.Message);
            }
        }


        public string getUltimoFolioP(int tipoBD)
        {
            strSQL = "select max(FolioProtocolo) + 1 AS er from Protocolos";

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al resuperar cadena SQL UltimoFolioP: " + ex.Message);
            }
        }

        
        public int UpdateProtocolo(int tipoBD, int IdEstatus, int IdRealiza, string tipo_F, string IdActiv)
        {
            strSQL = "update Protocolos set IdEstatus = " + IdEstatus + ", " + tipo_F + " = GETDATE(), IdRealiza = " + IdRealiza + " where IdActividad = " + IdActiv;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateProtocolo: " + ex.Message);
            }
        }


        public int SaveProtocolo(int tipoBD, string tipo_F, string Llamada, string Protocolo, int IdEstatus, int IdRealiza, string IdActiv)
        {
            strSQL = "insert into Protocolos (NoLlamada, FolioProtocolo, IdEstatus, " + tipo_F + ", IdRealiza, IdActividad) values ('" + Llamada + "', " + Protocolo + ", " + IdEstatus + ", GETDATE()," + IdRealiza + ", '" + IdActiv + "')";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SaveProtocolo: " + ex.Message);
            }
        }


        public SqlDataReader getDatosActivP(int tipoBD, string IdActiv)
        {
            strSQL = "select * FROM V_Protocolos where IdActividad = " + IdActiv;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL datosActivP: " + ex.Message);
            }
        }


        //*********PRERREQUISITOS

        public DataTable getPrerrequisitosEnviado(int tipoBD)
        {
            strSQL = "select * from V_Prerrequisitos where Estatus like '%Enviado%'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL PrerrequisitosEnviado: " + ex.Message);
            }
        }


        public string getComentPrerrequisitos(int tipoBD, int numActiv)
        {
            strSQL = "select Comentarios from V_Prerrequisitos where NumActividad = " + numActiv;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ComentPrerrequisitos: " + ex.Message);
            }
        }


        public int savePrerrequisito(int tipoBD, int actividad, string fechaE, string host)
        {
            strSQL = "insert into Prerrequisitos(IdActividad, Estatus, Fecha_Envio, F_Sistema, Host) " +
                    "values(" + actividad + ", 'Enviado', '" + fechaE + "', GETDATE(), '" + host + "')";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL savePrerrequisito: " + ex.Message);
            }
        }


        public int updatePrerrequisitos(int tipoBD, string fehaE, int idActiv, string host)
        {
            strSQL = "update Prerrequisitos set Fecha_Envio = '" + fehaE + "',  F_Sistema = GETDATE(), Host = '" + host + "' where IdActividad = " + idActiv;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al rescuperar cadena SQL UpdateAsignaResp: " + ex.Message);
            }
        }


        public int getExistePrerreq(int tipoBD, int idActiv)
        {
            strSQL = "select count(IdActividad) from Prerrequisitos where IdActividad = " + idActiv;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExistePrerrequisito: " + ex.Message);
            }
        }


        public int saveArchivoPrerrequisito(int tipoBD, int idActividad, string archivo, string host)
        {
            strSQL = "update Prerrequisitos set A_Adjunto = '" + archivo + "', Host = '" + host + "' where IdActividad = " + idActividad;

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL saveArchivoPrerrequisito: " + ex.Message);
            }
        }

        public int getExistePrerreqPDF(int tipoBD, int idActividad)
        {
            strSQL = "select count(IdActividad) from Prerrequisitos where IdActividad = " + idActividad;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL existePrerreqPDF: " + ex.Message);
            }
        }


        public string getRutaPrerreq(int tipoBD, int idActividad)
        {
            strSQL = "select A_Adjunto from Prerrequisitos where IdActividad = " + idActividad;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RutaPrerreq: " + ex.Message);
            }
        }


        public int getExisteFechaPrerreq(int tipoBD, int idActividad)
        {
            strSQL = "select count(Fecha_Envio) from Prerrequisitos where IdActividad = " + idActividad;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteFechaPrerreq: " + ex.Message);
            }
        }



        
        //*********************** CONSULTAS LLAMADAS INTERNAS
        public DataTable getLlamadasInternas(int tipoBD)
        {
            strSQL = "select st.Descripcion as Estatus, a.IdLlamada, a.Consecutivo as NoLlamada, a.Cliente, c.Descripcion as TipoContrato, s.Descripcion as TipoServicio, " +
                    "us.Nombre + ' ' + us.Apellidos as Ingeniero, a.Inicio_Servicio, a.Fin_Servicio, a.Proximo_Servicio, a.Observaciones, a.Cotizacion, a.OC, a.Usuario " +
                    "from Llamada a " +
                    "left outer join Tipo_Contrato c on c.ID = a.IdT_Contrato " +
                    "left outer join Tipo_Servicio s on s.ID = IdT_Servicio " +
                    "left outer join Usuarios us on us.IdUsuario = a.Id_Ingeniero " +
                    "left outer join F_Status st on st.IdStatus = a.IdStatus";
            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL LlamadasInternas: " + ex.Message);
            }
        }


        public SqlDataReader setEquipoLlamada(int tipoBD, int idEquipo)
        {
            strSQL = "select *from equipos where idequipo=" + idEquipo;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al reuperar cadena SQL setEquipoLlamada: " + ex.ToString());
            }
        }



        //*********************************************************************************************************************************************
        //*********************** CONSULTAS DE FSR
        public string getUltimoFolio(int tipoBD)
        {
            strSQL = "select max(Folio) + 1 AS er from FSR";

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UltimoFolio: " + ex.Message);
            }
        }


        public SqlDataReader SetDatosFSR(int tipoBD, string llamada_p)
        {
            strSQL = "select * from V_LlamadasSAP where idactividad = " + llamada_p;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL CargaDatosFSR: " + ex.Message);
            }
        }
                       

        public SqlDataReader getInfoContrato(int tipoBD, string contrato)
        {
            strSQL = "select CONVERT(char(10), C.StartDate, 103) as FechaInicioC, CONVERT(char(10), C.EndDate, 103) as FechaFinC, C.Descriptio as Descripcion," +
                        "C.Remarks2 as DescContrato from OCTR C where ContractID = " + contrato;

            if (tipoBD == 1)
            {
                Conexion = ConBDProduccionSAP;
            }
            if (tipoBD == 2)
            {
                Conexion = ConBDPruebasSAP;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(strSQL, Conn);

            SqlDataReader leer = Cmd.ExecuteReader();

            try
            {
                return leer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL InfoContrato: " + ex.Message);
            }
        }


        public SqlDataReader getValidaNoSerie(int tipoBD, string noSerie)
        {
            strSQL = "select* from Equipos where noserie like '%" + noSerie + "%'";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ValidaNoSerie: " + ex.Message);
            }
        }

        public int SaveEquipo(int tipoBD, string descrip, string noSerie, string marca, string modelo, string idCliente)
        {
            strSQL = "insert into Equipos (Descripcion,noserie,marca,modelo,idcliente) " +
                "values('" + descrip + "','" + noSerie + "','" + marca + "','" + modelo + "','" + idCliente + "')";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SaveEquipo: " + ex.Message);
            }
        }


        public string getBuscaExistFolio(int tipoBD, string fant)
        {
            strSQL = "select count(folio) as c from FSR where folio = " + fant;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL BuscaExistFolio: " + ex.Message);
            }
        }


        public int UpdateFolioSAP(int tipoBD, int folio, string estatus, int numServ)
        {
            strSQL = "update OCLG set Tel ='" + folio + " " + estatus + "' where ClgCode = " + numServ;

            if(tipoBD == 1)
            {
                Conexion = ConBDProduccionSAP;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebasSAP;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(strSQL, Conn);
            Cmd.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena UpdateFolioSAP: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                Conn = null;
                Cmd = null;
            }            
        }
        

        public int GeneraFolioSAP(int TipoBD, int folio, string estatus, int numServ)
        {
            strSQL = "update SCL5 set U_FSR=" + folio + ", U_ESTATUS='" + estatus + "' where clgID=" + numServ;

            if(TipoBD == 1)
            {
                Conexion = ConBDProduccionSAP;
            }
            if(TipoBD == 2)
            {
                Conexion = ConBDPruebasSAP;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(strSQL, Conn);
            Cmd.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL GeneraFolioSAP: " + ex.Message);
            }
        }



        public SqlDataReader getFechasFiltroLlam(int tipoBD, int tipoFecha)
        {
            //MES ANTERIOR
            if(tipoFecha == 1)
            {
                strSQL = "select CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) as primero " +
                        ",EOMONTH(GETDATE(), -1) as ultimo ";                
            }
            //MAS ANTIGUOS
            if(tipoFecha == 2)
            {
                strSQL = "select CONVERT(date, DATEADD(dd, -(DAY(DATEADD(mm, 0, GETDATE())) - 1), DATEADD(mm, -1, GETDATE())), 101) as menor";
            }
            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena FechasFiltros: " + ex.Message);
            }

        }


        //**********ACTUALIZA FSR
        public SqlDataReader setCargaDatosFSR(int tipoBD, string llamada_p)
        {
            strSQL = "select f.*, v.TipoLlamada from FSR f, V_FSR v where v.IdFSR = f.IdFSR and f.IdFSR = " + llamada_p;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al resuperar cadena SQL DatosFSR: " + ex.Message);
            }
        }


        public DataTable getAccionesFSR(int tipoBD, int Folio)
        {
            strSQL = "select idFSRAccion, fechaaccion, HorasAccion, AccionR from FSRAccion where idFolioFSR = " + Folio;

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL AccionesFSR: " + ex.Message);
            }
        }

        public DataTable getRefaccionesFSR(int tipoBD, string Folio)
        {
            strSQL = "select * from Refaccion where idFSR = " + Folio;

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL RefaccionesFSR: " + ex.Message + " - " + ex.ToString());
            }
        }


        public int getBuscaAcciones(int tipoBD, string folio)
        {
            strSQL = "select count(*) from FSRAccion where idFolioFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL Acciones FSR: " + ex.Message + " - " + ex.ToString());
            }
        }


        public int getBuscaRefacciones(int tipoBD, string folio)
        {
            strSQL = "select count(*) from Refaccion where idFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL BuscaRefacciones: " + ex.Message + " - " + ex.ToString());
            }
        }


        public int UpdateInsertAcciones(int tipoBD, int tipoConsul, string fechaA, int hora, string accion, string folio, int usuario, string idAccion)
        {
            if(tipoConsul == 1)
            {
                strSQL = "insert into FSRAccion values('" + fechaA + "', " + hora + ", '" + accion + "', " + folio + ", " + usuario + ", GETDATE())";
            }
            if(tipoConsul == 2)
            {
                strSQL = "update FSRAccion set FechaAccion = '" + fechaA + "', HorasAccion = " + hora + ", AccionR = '" + accion +
                            "', idUsuario = " + usuario + ", FechaSistema = GETDATE() where idFSRAccion = " + idAccion;
            }            

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateInsertAcciones: " + ex.Message + " - " + ex.ToString());
            }
        }


        public int UpdateInsertRefacciones(int tipoBD, int tipoConsul, string numR, int cantidad, string descripcion, string folio, string idRefaccion)
        {
            if(tipoConsul == 1)
            {
                strSQL = "insert into Refaccion values('" + numR + "', " + cantidad + ", '" + descripcion + "', " + folio + ")";
            }
            if(tipoConsul == 2)
            {
                strSQL = "update Refaccion set numRefaccion = '" + numR + "', cantidadRefaccion = " + cantidad + ", descRefaccion = '" + descripcion +
                            "' where idRefaccion = " + idRefaccion;
            }

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL UpdateInsertRefacciones: " + ex.Message + " - " + ex.ToString());
            }
        }


        public int UpdateRefaccionF(int tipoBD, string noParte, int cantidad, string descripcion, int folio)
        {
            strSQL = "insert into Refaccion (numRefaccion, cantidadRefaccion, descRefaccion, idFSR) values ('" + noParte + "', " + cantidad + ", '" + descripcion + "', " + folio + ")";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos UpdateRefaccionF: " + ex.Message);
            }

        }


        public int InsertAccionesF(int tipoBD, string fecha, int hora, string accion, int folio, int user)
        {
            strSQL = "insert into FSRAccion (FechaAccion, HorasAccion, AccionR, idFolioFSR, idUsuario) values ('" + fecha + "', " + hora + ", '" + accion + "', " + folio + ", " + user + ")";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos InsertAccionesF: " + ex.Message);
            }
        }

        public int insetRefacciones(int tipoBD, string noParte, int cant, string descripcion, int folio)
        {
            strSQL = "insert into Refaccion (numRefaccion,cantidadRefaccion,descRefaccion,idFSR) values ('" + noParte + "'," + cant + ",'" + descripcion + "'," + folio + ")";

            try
            {
                return ExecuteNonQuery(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL InsertRefacciones: " + ex.Message);
            }

        }


        //********************* CALENDARIO /MODIFICACION
        public int getEstatusFSR(int tipoBD, string folio)
        {
            strSQL = "select IdStatus from FSR where Folio = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL EstatusFSR: " + ex.Message);
            }
        }

        //*********************************************************************************
        //*********************CONSULTAS DE CORRECTIVO / LLAMADA INTERNA
        public SqlDataReader setDatosCorrectivo(int tipoBD, string folio)
        {
            strSQL = "select * from V_FSR where Folio = " + folio;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosCorrectivo: " + ex.Message);
            }
        }


        public string getConsecutivoLlamada(int tipoBD)
        {
            strSQL = "select max(consecutivo) + 1 AS er from llamada";

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ConsecutivoLlamada: " + ex.Message);
            }
        }


        public SqlDataReader getBuscaCliente(int tipoBD, string cliente)
        {
            strSQL = "select IdCliente as er from Clientes where Empresa like '%" + cliente + "%'";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL BuscaCliente: " + ex.Message);
            }
        }


        public string getBuscaClienteSAP(int tipoBD, string cliente)
        {
            strSQL = "select CardCode as f from OCRD where CardName like '%" + cliente + "%'";

            if (tipoBD == 1)
            {
                Conexion = ConBDProduccionSAP;
            }
            else if (tipoBD == 2)
            {
                Conexion = ConBDPruebasSAP;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(strSQL, Conn);
            string result = Convert.ToString(Cmd.ExecuteScalar());

            try
            {
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL BuscaClienteSAP: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                Conn = null;
                Cmd = null;
            }
        }


        public SqlDataReader setDetalleClienteInter(int tipoBD, int empresa)
        {
            strSQL = "select *from detalle_clientes where idclientes=" + empresa;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL setDetalleClienteInter: " + ex.ToString());
            }
        }

        public SqlDataReader setInfoAsesor(int tipoBD, int idAsesor)
        {
            strSQL = "select *from usuarios where idusuario=" + idAsesor;

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar la cadena SQL setInfoAsesor: " + ex.ToString());
            }
        }

        
        //****************************** CLIENTE
        public DataTable setCliente(int tipoBD, string empresa)
        {
            strSQL = "select *from clientes where empresa LIKE '%" + empresa + "%'";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL setCliente: " + ex.Message);
            }
        }


        //************************************ EQUIPO
        public DataTable setEquipoCliente(int tipoBD, string empresa)
        {
            strSQL = "select *from v_equipos where idcliente='" + empresa + "'  order by equipo";

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL setEquipoCliente: " + ex.Message);
            }
        }

        //*************************************************************************************************************************************************
        //********************* SOLICITUDES INTERNAS DE REFACCIONES -- SEGUIMIENTO
        public int getExisteSeguimiento(int tipoBD, string folio)
        {
            strSQL = "select count(FolioFSR) as er from SeguimientoFSR where FolioFSR = " + folio;

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL getExisteSeguimiento: " + ex.Message);
            }
        }


        public string getObservacionesFSR(int tipoBD, int folio)
        {
            strSQL = "select ObservacionesFSR from V_SeguimientoFolio where Folio = " + folio;

            try
            {
                return ExecuteScalar(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ObservacionesFSR: " + ex.Message);
            }
        }


        public DataTable setSeguimientoFolios(int tipoBD, int consul, int area)
        {
            if(consul == 1)
            {
                strSQL = "select * " +
                        "from V_SeguimientoFolio where idClasificacion = " + area;
            }
            if(consul == 2)
            {
                strSQL = "select * " +
                        "from V_SeguimientoFolio ";
            }

            try
            {
                return ExecDataSet(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SeguimientoFolios: " + ex);
            }
        }


        //NOTIFICACIONES
        public SqlDataReader getDatosNotificacion(int tipoBD, int area)
        {
            strSQL = "select S.FolioFSR, F.Cliente,CONVERT(DATE, S.FechaNotif, 101) AS FechaNotif, S.Comentarios from SeguimientoFSR S " +
                    "LEFT JOIN FSR AS F ON F.Folio = S.FolioFSR " +
                    "where F.idClasificacion = " + area + " and Convert(date, FechaNotif, 101) between CONVERT(DATE, GETDATE(), 101) " +
                    "and CONVERT(DATE, DATEADD(DAY, 2, GETDATE()), 101)";

            try
            {
                return ExecuteReader(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL DatosNotificacion: " + ex);
            }
        }


        public int getExisteNotif(int tipoBD, int area)
        {
            strSQL = "select Count(s.FolioFSR) from SeguimientoFSR s "+
                    "left join FSR f on s.FolioFSR = f.Folio " +
                    "where f.idClasificacion = " + area + " and Convert(date, FechaNotif, 101) between CONVERT(DATE, GETDATE(), 101) " +
                    "and CONVERT(DATE, DATEADD(DAY, 2, GETDATE()), 101)";

            try
            {
                return ExecuteScalarNum(strSQL, tipoBD);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL ExisteNotif: " + ex.Message);
            }
        }



        //**************************************************************************************************************************************************
        //*********************** PROCEDIMIENTOS ALMACENADOS SAVE-UPDATE
        public int SaveFSR(int tipoBD, string codCliente, string cliente, int Contrato, int Problema, int Servicio, string Usuario, int Estatus, int Inge, string FServicio,
                            string folio, int NumServicio, string equipo, string marca, string modelo, string noSerie, string idEquipo, string nResponsable, string nReportado,
                            string Mail, string Depto, string Tel, string Direccion, string Localidad, string fSolServ, string Hora, int idLlamada, string Carpeta, int idAsesor,
                            int idClas, string fallaReportada, string ordenVenta, string protocolo, int diasServ, string hostName)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("Save_FSR_Prueba", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@idcliente", SqlDbType.VarChar);
            sf.Parameters.Add("@cliente", SqlDbType.VarChar);
            sf.Parameters.Add("@idtcontrato", SqlDbType.Int);
            sf.Parameters.Add("@idtproblema", SqlDbType.Int);
            sf.Parameters.Add("@idtservicio", SqlDbType.Int);
            sf.Parameters.Add("@usuario", SqlDbType.VarChar);
            sf.Parameters.Add("@idstatus", SqlDbType.Int);
            sf.Parameters.Add("@iding", SqlDbType.Int);
            sf.Parameters.Add("@fechaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@folio", SqlDbType.VarChar);
            sf.Parameters.Add("@idllamada", SqlDbType.Int);
            sf.Parameters.Add("@equipo", SqlDbType.VarChar);
            sf.Parameters.Add("@marca", SqlDbType.VarChar);
            sf.Parameters.Add("@modelo", SqlDbType.VarChar);
            sf.Parameters.Add("@noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@idequipo_c", SqlDbType.VarChar);

            sf.Parameters.Add("@nrespo", SqlDbType.VarChar);
            sf.Parameters.Add("@nreport", SqlDbType.VarChar);
            sf.Parameters.Add("@mail", SqlDbType.VarChar);
            sf.Parameters.Add("@depto", SqlDbType.VarChar);
            sf.Parameters.Add("@tel", SqlDbType.VarChar);
            sf.Parameters.Add("@direccion", SqlDbType.VarChar);
            sf.Parameters.Add("@localidad", SqlDbType.VarChar);
            sf.Parameters.Add("@fechasolservicio", SqlDbType.DateTime);
            sf.Parameters.Add("@horaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@nollamada", SqlDbType.Int);
            sf.Parameters.Add("@carpeta", SqlDbType.VarChar);
            sf.Parameters.Add("@idasesor", SqlDbType.Int);
            sf.Parameters.Add("@idClas", SqlDbType.Int);
            sf.Parameters.Add("@FallaReportada", SqlDbType.VarChar);
            sf.Parameters.Add("@OC", SqlDbType.VarChar);
            sf.Parameters.Add("@protocolo", SqlDbType.VarChar);
            sf.Parameters.Add("@diasServ", SqlDbType.Int);
            sf.Parameters.Add("@hostName", SqlDbType.Char);

            sf.Parameters["@idcliente"].Value = codCliente;
            sf.Parameters["@cliente"].Value = cliente;
            sf.Parameters["@idtcontrato"].Value = Contrato;
            sf.Parameters["@idtproblema"].Value = Problema;
            sf.Parameters["@idtservicio"].Value = Servicio;
            sf.Parameters["@usuario"].Value = Usuario;
            sf.Parameters["@idstatus"].Value = Estatus;
            sf.Parameters["@iding"].Value = Inge;
            sf.Parameters["@fechaservicio"].Value = FServicio;
            sf.Parameters["@folio"].Value = folio;
            sf.Parameters["@idllamada"].Value = NumServicio;
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noSerie;
            sf.Parameters["@idequipo_c"].Value = idEquipo;

            sf.Parameters["@nrespo"].Value = nResponsable;
            sf.Parameters["@nreport"].Value = nReportado;
            sf.Parameters["@mail"].Value = Mail;
            sf.Parameters["@depto"].Value = Depto;
            sf.Parameters["@tel"].Value = Tel;
            sf.Parameters["@direccion"].Value = Direccion;
            sf.Parameters["@localidad"].Value = Localidad;
            sf.Parameters["@fechasolservicio"].Value = fSolServ;
            sf.Parameters["@horaservicio"].Value = Hora;
            sf.Parameters["@nollamada"].Value = idLlamada;
            sf.Parameters["@carpeta"].Value = Carpeta;
            sf.Parameters["@idasesor"].Value = idAsesor;
            sf.Parameters["@idClas"].Value = idClas;
            sf.Parameters["@FallaReportada"].Value = fallaReportada;
            sf.Parameters["@OC"].Value = ordenVenta;
            sf.Parameters["@protocolo"].Value = protocolo;
            sf.Parameters["@diasServ"].Value = diasServ;
            sf.Parameters["@hostName"].Value = hostName;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error al guardar datos SaveFSR: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int saveFSRIngenieros(int tipoBD, string idcliente, string cliente, int IdTContrato, int idTProblema, int idTServicio, string usuario, int idEstatus, int idIng, string fechaserv,
             string equipo, string marca, string modelo, string noSerie, string idequipoC, string nrespo, string nreport, string mail, string folio, int idLlamada, string depto, string tel,
             string direccion, string localidad, string fechaSolServ, string horaServ, int noLlamada, string carpeta, int idAsesor, int idClass, string FallaReportada, int idIng2, int idIng3, string OC,
             string protocolo, int diasServ, string hostName)
        {
            if (tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if (tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("SaveFSR_IngAcompaña", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@idcliente", SqlDbType.VarChar);
            sf.Parameters.Add("@cliente", SqlDbType.VarChar);
            sf.Parameters.Add("@idtcontrato", SqlDbType.Int);
            sf.Parameters.Add("@idtproblema", SqlDbType.Int);
            sf.Parameters.Add("@idtservicio", SqlDbType.Int);
            sf.Parameters.Add("@usuario", SqlDbType.VarChar);
            sf.Parameters.Add("@idstatus", SqlDbType.Int);
            sf.Parameters.Add("@iding", SqlDbType.Int);
            sf.Parameters.Add("@fechaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@folio", SqlDbType.VarChar);
            sf.Parameters.Add("@idllamada", SqlDbType.Int);
            sf.Parameters.Add("@equipo", SqlDbType.VarChar);
            sf.Parameters.Add("@marca", SqlDbType.VarChar);
            sf.Parameters.Add("@modelo", SqlDbType.VarChar);
            sf.Parameters.Add("@noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@idequipo_c", SqlDbType.VarChar);

            sf.Parameters.Add("@nrespo", SqlDbType.VarChar);
            sf.Parameters.Add("@nreport", SqlDbType.VarChar);
            sf.Parameters.Add("@mail", SqlDbType.VarChar);
            sf.Parameters.Add("@depto", SqlDbType.VarChar);
            sf.Parameters.Add("@tel", SqlDbType.VarChar);
            sf.Parameters.Add("@direccion", SqlDbType.VarChar);
            sf.Parameters.Add("@localidad", SqlDbType.VarChar);
            sf.Parameters.Add("@fechasolservicio", SqlDbType.DateTime);
            sf.Parameters.Add("@horaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@nollamada", SqlDbType.Int);
            sf.Parameters.Add("@carpeta", SqlDbType.VarChar);
            sf.Parameters.Add("@idasesor", SqlDbType.Int);
            sf.Parameters.Add("@idClas", SqlDbType.Int);
            sf.Parameters.Add("@FallaReportada", SqlDbType.VarChar);
            sf.Parameters.Add("@IdIng2", SqlDbType.Int);
            sf.Parameters.Add("@IdIng3", SqlDbType.Int);
            sf.Parameters.Add("@OC", SqlDbType.VarChar);
            sf.Parameters.Add("@protocolo", SqlDbType.VarChar);
            sf.Parameters.Add("@diasServ", SqlDbType.Int);
            sf.Parameters.Add("@hostName", SqlDbType.Char);

            sf.Parameters["@idcliente"].Value = idcliente;
            sf.Parameters["@cliente"].Value = cliente;
            sf.Parameters["@idtcontrato"].Value = IdTContrato;
            sf.Parameters["@idtproblema"].Value = idTProblema;
            sf.Parameters["@idtservicio"].Value = idTServicio;
            sf.Parameters["@usuario"].Value = usuario;
            sf.Parameters["@idstatus"].Value = idEstatus;
            sf.Parameters["@iding"].Value = idIng;
            sf.Parameters["@fechaservicio"].Value = fechaserv;
            sf.Parameters["@folio"].Value = folio;
            sf.Parameters["@idllamada"].Value = idLlamada;
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noSerie;
            sf.Parameters["@idequipo_c"].Value = idequipoC;

            sf.Parameters["@nrespo"].Value = nrespo;
            sf.Parameters["@nreport"].Value = nreport;
            sf.Parameters["@mail"].Value = mail;
            sf.Parameters["@depto"].Value = depto;
            sf.Parameters["@tel"].Value = tel;
            sf.Parameters["@direccion"].Value = direccion;
            sf.Parameters["@localidad"].Value = localidad;
            sf.Parameters["@fechasolservicio"].Value = fechaSolServ;
            sf.Parameters["@horaservicio"].Value = horaServ;
            sf.Parameters["@nollamada"].Value = noLlamada;
            sf.Parameters["@carpeta"].Value = carpeta;
            sf.Parameters["@idasesor"].Value = idAsesor;
            sf.Parameters["@idClas"].Value = idClass;
            sf.Parameters["@FallaReportada"].Value = FallaReportada;
            sf.Parameters["@IdIng2"].Value = idIng2;
            sf.Parameters["@IdIng3"].Value = idIng3;
            sf.Parameters["@OC"].Value = OC;
            sf.Parameters["@protocolo"].Value = protocolo;
            sf.Parameters["@diasServ"].Value = diasServ;
            sf.Parameters["@hostName"].Value = hostName;

            sf.ExecuteNonQuery();


            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error al guardar datos saveFSRIngenieros: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }
        

        public int PDFSaveFSR(int tipoBD, string idcliente, string cliente, int IdTContrato, int idTProblema, int idTServicio, string usuario, int idEstatus, int idIng, string fechaserv, string folio,
              int idLlamada, string equipo, string marca, string modelo, string noSerie, string idequipoC, string nrespo, string nreport, string mail, string depto, string tel, string direccion,
             string localidad, string fechaSolServ, string horaServ, int noLlamada, string carpeta, int idAsesor, int idClass, string FileFSR, string FallaReportada, string OC, string protocolo, string hostName)

        {
            if (tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if (tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("Save_PDF_FSR", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@idcliente", SqlDbType.VarChar);
            sf.Parameters.Add("@cliente", SqlDbType.VarChar);
            sf.Parameters.Add("@idtcontrato", SqlDbType.Int);
            sf.Parameters.Add("@idtproblema", SqlDbType.Int);
            sf.Parameters.Add("@idtservicio", SqlDbType.Int);
            sf.Parameters.Add("@usuario", SqlDbType.VarChar);
            sf.Parameters.Add("@idstatus", SqlDbType.Int);
            sf.Parameters.Add("@iding", SqlDbType.Int);
            sf.Parameters.Add("@fechaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@folio", SqlDbType.VarChar);
            sf.Parameters.Add("@idllamada", SqlDbType.Int);
            sf.Parameters.Add("@equipo", SqlDbType.VarChar);
            sf.Parameters.Add("@marca", SqlDbType.VarChar);
            sf.Parameters.Add("@modelo", SqlDbType.VarChar);
            sf.Parameters.Add("@noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@idequipo_c", SqlDbType.VarChar);

            sf.Parameters.Add("@nrespo", SqlDbType.VarChar);
            sf.Parameters.Add("@nreport", SqlDbType.VarChar);
            sf.Parameters.Add("@mail", SqlDbType.VarChar);
            sf.Parameters.Add("@depto", SqlDbType.VarChar);
            sf.Parameters.Add("@tel", SqlDbType.VarChar);
            sf.Parameters.Add("@direccion", SqlDbType.VarChar);
            sf.Parameters.Add("@localidad", SqlDbType.VarChar);
            sf.Parameters.Add("@fechasolservicio", SqlDbType.DateTime);
            sf.Parameters.Add("@horaservicio", SqlDbType.VarChar);
            sf.Parameters.Add("@nollamada", SqlDbType.Int);
            sf.Parameters.Add("@carpeta", SqlDbType.VarChar);
            sf.Parameters.Add("@idasesor", SqlDbType.Int);
            sf.Parameters.Add("@idClas", SqlDbType.Int);
            sf.Parameters.Add("@FileFSR", SqlDbType.VarChar);
            sf.Parameters.Add("@FallaReportada", SqlDbType.VarChar);
            sf.Parameters.Add("@OC", SqlDbType.VarChar);
            sf.Parameters.Add("@protocolo", SqlDbType.VarChar);
            sf.Parameters.Add("@hostName", SqlDbType.VarChar);

            sf.Parameters["@idcliente"].Value = idcliente;
            sf.Parameters["@cliente"].Value = cliente;
            sf.Parameters["@idtcontrato"].Value = IdTContrato;
            sf.Parameters["@idtproblema"].Value = idTProblema;
            sf.Parameters["@idtservicio"].Value = idTServicio;
            sf.Parameters["@usuario"].Value = usuario;
            sf.Parameters["@idstatus"].Value = idEstatus;
            sf.Parameters["@iding"].Value = idIng;
            sf.Parameters["@fechaservicio"].Value = fechaserv;
            sf.Parameters["@folio"].Value = folio;
            sf.Parameters["@idllamada"].Value = idLlamada;
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noSerie;
            sf.Parameters["@idequipo_c"].Value = idequipoC;

            sf.Parameters["@nrespo"].Value = nrespo;
            sf.Parameters["@nreport"].Value = nreport;
            sf.Parameters["@mail"].Value = mail;
            sf.Parameters["@depto"].Value = depto;
            sf.Parameters["@tel"].Value = tel;
            sf.Parameters["@direccion"].Value = direccion;
            sf.Parameters["@localidad"].Value = localidad;
            sf.Parameters["@fechasolservicio"].Value = fechaSolServ;
            sf.Parameters["@horaservicio"].Value = horaServ;
            sf.Parameters["@nollamada"].Value = noLlamada;
            sf.Parameters["@carpeta"].Value = carpeta;
            sf.Parameters["@idasesor"].Value = idAsesor;
            sf.Parameters["@idClas"].Value = idClass;
            sf.Parameters["@FileFSR"].Value = FileFSR;
            sf.Parameters["@FallaReportada"].Value = FallaReportada;
            sf.Parameters["@OC"].Value = OC;
            sf.Parameters["@protocolo"].Value = protocolo;
            sf.Parameters["@hostName"].Value = hostName;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error al guardar los datos PDFSaveFSR: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }

        public int SaveDetalleFSR(int tipoBD, string folio, string idCliente, string nRespo, string nReport, string mail, string depto, string tel, string direccion, string localidad)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand df = new SqlCommand("SaveDetalleFSR", Conn);
            df.CommandType = CommandType.StoredProcedure;

            df.Parameters.Add("@folio", SqlDbType.VarChar);
            df.Parameters.Add("@idcliente", SqlDbType.VarChar);
            df.Parameters.Add("@nrespo", SqlDbType.VarChar);
            df.Parameters.Add("@nreport", SqlDbType.VarChar);
            df.Parameters.Add("@mail", SqlDbType.VarChar);
            df.Parameters.Add("@depto", SqlDbType.VarChar);
            df.Parameters.Add("@tel", SqlDbType.VarChar);
            df.Parameters.Add("@direccion", SqlDbType.VarChar);
            df.Parameters.Add("@localidad", SqlDbType.VarChar);

            df.Parameters["@folio"].Value = folio;
            df.Parameters["@idcliente"].Value = idCliente;
            df.Parameters["@nrespo"].Value = nRespo;
            df.Parameters["@nreport"].Value = nReport;
            df.Parameters["@mail"].Value = mail;
            df.Parameters["@depto"].Value = depto;
            df.Parameters["@tel"].Value = tel;
            df.Parameters["@direccion"].Value = direccion;
            df.Parameters["@localidad"].Value = localidad;

            df.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error al guardar datos SaveDetalleFSR: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int UpdateFechaActividad(int tipoBD, DateTime fechai, DateTime fechaf, int noServicio)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand df = new SqlCommand("Up_Fec_Serv", Conn);
            df.CommandType = CommandType.StoredProcedure;

            df.Parameters.Add("@fechai", SqlDbType.DateTime);
            df.Parameters.Add("@fechaf", SqlDbType.DateTime);
            df.Parameters.Add("@idactividad", SqlDbType.Int);

            df.Parameters["@fechai"].Value = fechai;
            df.Parameters["@fechaf"].Value = fechaf;
            df.Parameters["@idactividad"].Value = noServicio;
            df.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error al guardar los datos UpdateFechaActividad: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SendCorreoIngResponsable(int tipoBD)
        {
            if (tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if (tipoBD == 2)
            {
                Conexion = null;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand de = new SqlCommand("SendMail", Conn);
            de.CommandType = CommandType.StoredProcedure;
            de.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SendCorreoIngResponsable: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SendCorreoIngAc1(int tipoBD)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = null;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand ia = new SqlCommand("SendMailAcompaña1", Conn);
            ia.CommandType = CommandType.StoredProcedure;
            ia.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SendCorreoIngAc1: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SendCorreoIngAc2(int tipoBD)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = null;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand c = new SqlCommand("SendMailAcompaña2", Conn);
            c.CommandType = CommandType.StoredProcedure;
            c.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SendCorreoIngAc2: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SendCorreoAsesor(int tipoBD)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = null;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand a = new SqlCommand("SendMailAsesor_S", Conn);
            a.CommandType = CommandType.StoredProcedure;
            a.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SendCorreoAsesor: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SendMailAsesor(int tipoBD)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebasSAP;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand c = new SqlCommand("SendMailAsesor", Conn);
            c.CommandType = CommandType.StoredProcedure;
            c.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar cadena SQL SendMailAsesor: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }

        public int SaveDocumentacion(int tipoBD, string folio, int Idestatus, string cliente, string equipo, string marca, string modelo, string noSerie, string FechaServ,
                int IdIngeniero, int TipoServ, int Resp, int Document, string asesor, string otro, string usuario, string comentarios)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sd = new SqlCommand("Save_Documentacion", Conn);
            sd.CommandType = CommandType.StoredProcedure;

            sd.Parameters.Add("@FolioFSR", SqlDbType.VarChar);
            sd.Parameters.Add("@IdEstatus", SqlDbType.Int);
            sd.Parameters.Add("@cliente", SqlDbType.VarChar);
            sd.Parameters.Add("@equipo", SqlDbType.VarChar);
            sd.Parameters.Add("@marca", SqlDbType.VarChar);
            sd.Parameters.Add("@modelo", SqlDbType.VarChar);
            sd.Parameters.Add("@noSerie", SqlDbType.VarChar);
            sd.Parameters.Add("@FechaServicio", SqlDbType.VarChar);
            sd.Parameters.Add("@idIngeniero", SqlDbType.Int);
            sd.Parameters.Add("@idT_Servicio", SqlDbType.Int);
            sd.Parameters.Add("@idResponsable", SqlDbType.Int);
            sd.Parameters.Add("@idDocumentador", SqlDbType.Int);
            sd.Parameters.Add("@asesor", SqlDbType.VarChar);
            sd.Parameters.Add("@OtraIncidencia", SqlDbType.VarChar);
            sd.Parameters.Add("@usuario", SqlDbType.VarChar);
            sd.Parameters.Add("@comentarios", SqlDbType.VarChar);

            sd.Parameters["@FolioFSR"].Value = folio;
            sd.Parameters["@IdEstatus"].Value = Idestatus;
            sd.Parameters["@cliente"].Value = cliente;
            sd.Parameters["@equipo"].Value = equipo;
            sd.Parameters["@marca"].Value = marca;
            sd.Parameters["@modelo"].Value = modelo;
            sd.Parameters["@noSerie"].Value = noSerie;
            sd.Parameters["@FechaServicio"].Value =FechaServ;
            sd.Parameters["@idIngeniero"].Value = IdIngeniero;
            sd.Parameters["@idT_Servicio"].Value = TipoServ;
            sd.Parameters["@idResponsable"].Value = Resp;
            sd.Parameters["@idDocumentador"].Value = Document;
            sd.Parameters["@asesor"].Value = asesor;
            sd.Parameters["@OtraIncidencia"].Value = otro;
            sd.Parameters["@usuario"].Value = usuario;
            sd.Parameters["@comentarios"].Value = comentarios;

            sd.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los datos SaveDocumentacion: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int UpdateFSRFisico(int tipoBD, int Folio, string rutaFSR, int estatus, string InicioServ, string FinServ, string FechaServ, string fallaReport,
                                    string fallaEncontrada, string noSerie, string idEquipo, string observaciones)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("Update_FSR_Fisico", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@FolioFSR", SqlDbType.Int);
            sf.Parameters.Add("@rutaFSR", SqlDbType.VarChar);
            sf.Parameters.Add("@IdEstatus", SqlDbType.Int);
            sf.Parameters.Add("@InicioServicio", SqlDbType.VarChar);
            sf.Parameters.Add("@FinServicio", SqlDbType.VarChar);
            sf.Parameters.Add("@FechaServicio", SqlDbType.VarChar);
            sf.Parameters.Add("@FallaReport", SqlDbType.VarChar);
            sf.Parameters.Add("@FallaEncontrada", SqlDbType.VarChar);
            sf.Parameters.Add("@Noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@IdEquipo", SqlDbType.VarChar);
            sf.Parameters.Add("@Observaciones", SqlDbType.VarChar);

            sf.Parameters["@FolioFSR"].Value = Folio;
            sf.Parameters["@rutaFSR"].Value = rutaFSR;
            sf.Parameters["@IdEstatus"].Value = estatus;
            sf.Parameters["@InicioServicio"].Value = InicioServ;
            sf.Parameters["@FinServicio"].Value = FinServ;
            sf.Parameters["@FechaServicio"].Value = FechaServ;
            sf.Parameters["@FallaReport"].Value = fallaReport;
            sf.Parameters["@FallaEncontrada"].Value = fallaEncontrada;
            sf.Parameters["@Noserie"].Value = noSerie;
            sf.Parameters["@IdEquipo"].Value = idEquipo;
            sf.Parameters["@Observaciones"].Value = observaciones;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos UpdateFSRFisico: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int saveLlamadaInterna(int tipoBD, int llamada, int idCliente, string cliente, int idIng, int idContrato, int idProblema, int IdFolio, string usuario,
                                        int idEstatus, string observaciones, string cotizacion, string oc, string hostName)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sl = new SqlCommand("SaveLlamada", Conn);
            sl.CommandType = CommandType.StoredProcedure;

            sl.Parameters.Add("@consecutivo", SqlDbType.Int);
            sl.Parameters.Add("@idcliente", SqlDbType.Int);
            sl.Parameters.Add("@cliente", SqlDbType.VarChar);
            sl.Parameters.Add("@iding", SqlDbType.Int);
            sl.Parameters.Add("@idtcontrato", SqlDbType.Int);
            sl.Parameters.Add("@idtproblema", SqlDbType.Int);
            sl.Parameters.Add("@idfolios", SqlDbType.Int);
            sl.Parameters.Add("@user", SqlDbType.VarChar);
            sl.Parameters.Add("@idstatus", SqlDbType.Int);
            sl.Parameters.Add("@observaciones", SqlDbType.VarChar);
            sl.Parameters.Add("@coti", SqlDbType.NVarChar);
            sl.Parameters.Add("@oc", SqlDbType.NVarChar);
            sl.Parameters.Add("@hostName", SqlDbType.VarChar);

            sl.Parameters["@consecutivo"].Value = llamada;
            sl.Parameters["@idcliente"].Value = idCliente;
            sl.Parameters["@cliente"].Value = cliente;
            sl.Parameters["@iding"].Value = idIng;
            sl.Parameters["@idtcontrato"].Value = idContrato;
            sl.Parameters["@idtproblema"].Value = idProblema;
            sl.Parameters["@idfolios"].Value = IdFolio;
            sl.Parameters["@user"].Value = usuario;
            sl.Parameters["@idstatus"].Value = idEstatus;
            sl.Parameters["@observaciones"].Value = observaciones;
            sl.Parameters["@coti"].Value = cotizacion;
            sl.Parameters["@oc"].Value = oc;
            sl.Parameters["@hostName"].Value = hostName;

            sl.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar datos saveLlamadaInterna: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int saveDetalleEquipo(int tipoBD, string llamada, int IdEquipo)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand de = new SqlCommand("SaveDetEquipo", Conn);
            de.CommandType = CommandType.StoredProcedure;

            de.Parameters.Add("@folio", SqlDbType.VarChar);
            de.Parameters.Add("@idequipo", SqlDbType.Int);

            de.Parameters["@folio"].Value = llamada;
            de.Parameters["@idequipo"].Value = IdEquipo;

            de.ExecuteNonQuery();
            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos SaveDetalleEquipo: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int saveFolioLlamadaInterna(int tipoBD, string idCliente, string Cliente, int idTContrato, int idTProblema, int idTServicio, string usuario, int idEstatus, int idIng, string fechaServicio, int Folio, int idLlamada, string equipo, string marca, string modelo,
                    string noSerie, string idEquipo_C, string nRespo, string nReport, string mail, string depto, string tel, string direccion, string localidad, string coti, string oc, string coment, string hora, int idAsesor, int noLlamada, int diasServ, string hostName)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("Save_FSR_1", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@idcliente", SqlDbType.VarChar);
            sf.Parameters.Add("@cliente", SqlDbType.VarChar);
            sf.Parameters.Add("@idtcontrato", SqlDbType.Int);
            sf.Parameters.Add("@idtproblema", SqlDbType.Int);
            sf.Parameters.Add("@idtservicio", SqlDbType.Int);
            sf.Parameters.Add("@usuario", SqlDbType.VarChar);
            sf.Parameters.Add("@idstatus", SqlDbType.Int);
            sf.Parameters.Add("@iding", SqlDbType.Int);
            sf.Parameters.Add("@fechaservicio", SqlDbType.Date);
            sf.Parameters.Add("@folio", SqlDbType.Int);
            sf.Parameters.Add("@idllamada", SqlDbType.Int);
            sf.Parameters.Add("@equipo", SqlDbType.VarChar);
            sf.Parameters.Add("@marca", SqlDbType.VarChar);
            sf.Parameters.Add("@modelo", SqlDbType.VarChar);
            sf.Parameters.Add("@noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@idequipo_C", SqlDbType.VarChar);
            sf.Parameters.Add("@nrespo", SqlDbType.VarChar);
            sf.Parameters.Add("@nreport", SqlDbType.VarChar);
            sf.Parameters.Add("@mail", SqlDbType.VarChar);
            sf.Parameters.Add("@depto", SqlDbType.VarChar);
            sf.Parameters.Add("@tel", SqlDbType.VarChar);
            sf.Parameters.Add("@direccion", SqlDbType.VarChar);
            sf.Parameters.Add("@localidad", SqlDbType.VarChar);
            sf.Parameters.Add("@coti", SqlDbType.VarChar);
            sf.Parameters.Add("@oc", SqlDbType.VarChar);
            sf.Parameters.Add("@coment", SqlDbType.VarChar);
            sf.Parameters.Add("@hora", SqlDbType.VarChar);
            sf.Parameters.Add("@idasesor", SqlDbType.Int);
            sf.Parameters.Add("@nollamada", SqlDbType.Int);
            sf.Parameters.Add("@diasServ", SqlDbType.Int);
            sf.Parameters.Add("@hostName", SqlDbType.VarChar);

            sf.Parameters["@idcliente"].Value = idCliente;
            sf.Parameters["@cliente"].Value = Cliente;
            sf.Parameters["@idtcontrato"].Value = idTContrato;
            sf.Parameters["@idtproblema"].Value = idTProblema;
            sf.Parameters["@idtservicio"].Value = idTServicio;
            sf.Parameters["@usuario"].Value = usuario;
            sf.Parameters["@idstatus"].Value = idEstatus;
            sf.Parameters["@iding"].Value = idIng;
            sf.Parameters["@fechaservicio"].Value = fechaServicio;
            sf.Parameters["@folio"].Value = Folio;
            sf.Parameters["@idllamada"].Value = idLlamada;
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noSerie;
            sf.Parameters["@idequipo_C"].Value = idEquipo_C;
            sf.Parameters["@nrespo"].Value = nRespo;
            sf.Parameters["@nreport"].Value = nReport;
            sf.Parameters["@mail"].Value = mail;
            sf.Parameters["@depto"].Value = depto;
            sf.Parameters["@tel"].Value = tel;
            sf.Parameters["@direccion"].Value = direccion;
            sf.Parameters["@localidad"].Value = localidad;
            sf.Parameters["@coti"].Value = coti;
            sf.Parameters["@oc"].Value = oc;
            sf.Parameters["@coment"].Value = coment;
            sf.Parameters["@hora"].Value = hora;
            sf.Parameters["@idasesor"].Value = idAsesor;
            sf.Parameters["@nollamada"].Value = noLlamada;
            sf.Parameters["@diasServ"].Value = diasServ;
            sf.Parameters["@hostName"].Value = hostName;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al aguardar los datos SaveFolioLlamadaInterna: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }
       

        public int saveDetalleCliente(int tipoBD, string folio, int idCliente, string tel, string direccion, string localidad, string nRespon, string nReport, string mail, string depto)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand dc = new SqlCommand("SaveDetCliente", Conn);
            dc.CommandType = CommandType.StoredProcedure;

            dc.Parameters.Add("@folio", SqlDbType.VarChar);
            dc.Parameters.Add("@idcliente", SqlDbType.Int);
            dc.Parameters.Add("@tel", SqlDbType.VarChar);
            dc.Parameters.Add("@direccion", SqlDbType.VarChar);
            dc.Parameters.Add("@localidad", SqlDbType.VarChar);
            dc.Parameters.Add("@nrespon", SqlDbType.VarChar);
            dc.Parameters.Add("@nreport", SqlDbType.VarChar);
            dc.Parameters.Add("@mail", SqlDbType.VarChar);
            dc.Parameters.Add("@depto", SqlDbType.VarChar);

            dc.Parameters["@folio"].Value = folio;
            dc.Parameters["@idcliente"].Value = idCliente;
            dc.Parameters["@tel"].Value = tel;
            dc.Parameters["@direccion"].Value = direccion;
            dc.Parameters["@localidad"].Value = localidad;
            dc.Parameters["@nrespon"].Value = nRespon;
            dc.Parameters["@nreport"].Value = nReport;
            dc.Parameters["@mail"].Value = mail;
            dc.Parameters["@depto"].Value = depto;

            dc.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos SaveDetalleCliente: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int UpdateDetalleCliente(int tipoBD, int idCliente, string tel, string direccion, string localidad, string nRespon, string nReport, string mail, string depto)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand c = new SqlCommand("UpdateDetCliente", Conn);
            c.CommandType = CommandType.StoredProcedure;

            c.Parameters.Add("@idcliente", SqlDbType.Int);
            c.Parameters.Add("@tel", SqlDbType.VarChar);
            c.Parameters.Add("@direccion", SqlDbType.VarChar);
            c.Parameters.Add("@localidad", SqlDbType.VarChar);
            c.Parameters.Add("@nrespon", SqlDbType.VarChar);
            c.Parameters.Add("@nreport", SqlDbType.VarChar);
            c.Parameters.Add("@mail", SqlDbType.VarChar);
            c.Parameters.Add("@depto", SqlDbType.VarChar);

            c.Parameters["@idcliente"].Value = idCliente;
            c.Parameters["@tel"].Value = tel;
            c.Parameters["@direccion"].Value = direccion;
            c.Parameters["@localidad"].Value = localidad;
            c.Parameters["@nrespon"].Value = nRespon;
            c.Parameters["@nreport"].Value = nReport;
            c.Parameters["@mail"].Value = mail;
            c.Parameters["@depto"].Value = depto;

            c.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos UpdateDetalleCliente: " + ex.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }



        public int SaveSeguimientoFolio(int tipoBD, string Folio, string FechaNotif, string Comentarios, int IdIng, int IdUser, string host)
        {
            if (tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand ss = new SqlCommand("Save_SeguimientoFolio", Conn);
            ss.CommandType = CommandType.StoredProcedure;

            ss.Parameters.Add("@FSR", SqlDbType.Int);
            ss.Parameters.Add("@FechaNotif", SqlDbType.DateTime);
            ss.Parameters.Add("@Comentarios", SqlDbType.VarChar);
            ss.Parameters.Add("@IdIng", SqlDbType.Int);
            ss.Parameters.Add("@IdUser", SqlDbType.Int);
            ss.Parameters.Add("@hostName", SqlDbType.VarChar);

            ss.Parameters["@FSR"].Value = Folio;
            ss.Parameters["@FechaNotif"].Value = FechaNotif;
            ss.Parameters["@Comentarios"].Value = Comentarios;
            ss.Parameters["@IdIng"].Value = IdIng;
            ss.Parameters["@IdUser"].Value = IdUser;
            ss.Parameters["@hostName"].Value = host;

            ss.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los Datos SaveSeguimientoFolio: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int UpdateSeguimientoFolio(int tipoBD, string Folio, int IdIng, string host, string comentarios, string fechaN)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("Update_SeguimientoF", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@FSR", SqlDbType.Int);
            sf.Parameters.Add("@IdIng", SqlDbType.Int);
            sf.Parameters.Add("@host", SqlDbType.VarChar);
            sf.Parameters.Add("@Comentarios", SqlDbType.VarChar);
            sf.Parameters.Add("@fecha_notif", SqlDbType.DateTime);

            sf.Parameters["@FSR"].Value = Folio;
            sf.Parameters["@IdIng"].Value = IdIng;
            sf.Parameters["@host"].Value = host;
            sf.Parameters["@Comentarios"].Value = comentarios;
            sf.Parameters["@fecha_notif"].Value = fechaN;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al actualizar los datos SeguimientoFolio: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int SaveAcuse(int tipoBD, int FolioA, string FolioFSR, string Empresa, string Direccion, string Atencion, string Depto, string FechaA, string Observaciones,
                                int idUsuario, string host, string telefono, string guiaEnvio)
        {
            if (tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if (tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sa = new SqlCommand("SaveAcuse", Conn);
            sa.CommandType = CommandType.StoredProcedure;

            sa.Parameters.Add("@FolioA", SqlDbType.Int);
            sa.Parameters.Add("@FolioFSR", SqlDbType.VarChar);
            sa.Parameters.Add("@Empresa", SqlDbType.VarChar);
            sa.Parameters.Add("@Direccion", SqlDbType.VarChar);
            sa.Parameters.Add("@Atencion", SqlDbType.VarChar);
            sa.Parameters.Add("@Depto", SqlDbType.VarChar);
            sa.Parameters.Add("@FechaA", SqlDbType.Date);
            sa.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            sa.Parameters.Add("@idUsuario", SqlDbType.Int);
            sa.Parameters.Add("@Host", SqlDbType.VarChar);
            sa.Parameters.Add("@Telefono", SqlDbType.VarChar);
            sa.Parameters.Add("@GuiaEnvio", SqlDbType.VarChar);

            sa.Parameters["@FolioA"].Value = FolioA;
            sa.Parameters["@FolioFSR"].Value = FolioFSR;
            sa.Parameters["@Empresa"].Value = Empresa;
            sa.Parameters["@Direccion"].Value = Direccion;
            sa.Parameters["@Atencion"].Value = Atencion;
            sa.Parameters["@Depto"].Value = Depto;
            sa.Parameters["@FechaA"].Value = FechaA;
            sa.Parameters["@Observaciones"].Value = Observaciones;
            sa.Parameters["@idUsuario"].Value = idUsuario;
            sa.Parameters["@Host"].Value = host;
            sa.Parameters["@Telefono"].Value = telefono;
            sa.Parameters["@GuiaEnvio"].Value = guiaEnvio;

            sa.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al guardar los datos SaveAcuse: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }



        public int UpdateDocumentacion(int tipoBD, int Idestatus, int IdResp, int IdDocument, string tipo_f, string usuario, string Comentarios, string OtraIn, string folio)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand ud = new SqlCommand("Update_Documentacion", Conn);
            ud.CommandType = CommandType.StoredProcedure;

            ud.Parameters.Add("@Folio", SqlDbType.Int);
            ud.Parameters.Add("@Idestatus", SqlDbType.Int);
            ud.Parameters.Add("@IdResponsable", SqlDbType.Int);
            ud.Parameters.Add("@IdDocumentador", SqlDbType.Int);
            ud.Parameters.Add("@TipoFecha", SqlDbType.VarChar);
            ud.Parameters.Add("@Usuario", SqlDbType.VarChar);
            ud.Parameters.Add("@Comentarios", SqlDbType.VarChar);
            ud.Parameters.Add("@OtraI", SqlDbType.VarChar);

            ud.Parameters["@Folio"].Value = folio;
            ud.Parameters["@Idestatus"].Value = Idestatus;
            ud.Parameters["@IdResponsable"].Value = IdResp;
            ud.Parameters["@IdDocumentador"].Value = IdDocument;
            ud.Parameters["@TipoFecha"].Value = tipo_f;
            ud.Parameters["@Usuario"].Value = usuario;
            ud.Parameters["@Comentarios"].Value = Comentarios;
            ud.Parameters["@OtraI"].Value = OtraIn;

            ud.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Actualizar los datos UpdateDocumentacion: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }
        }


        public int UpdateCalendarioReasigna(int tipoBD, string fechaServicio, int ing, int Folio, string hostName, string motivo)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand sf = new SqlCommand("ActualizaFechaServicio", Conn);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Clear();

            sf.Parameters.Add("@fservicio", SqlDbType.Date);
            sf.Parameters.Add("@ing", SqlDbType.Int);
            sf.Parameters.Add("@folio", SqlDbType.Int);
            sf.Parameters.Add("@hostName", SqlDbType.Char);
            sf.Parameters.Add("@reasigna", SqlDbType.VarChar);

            sf.Parameters["@fservicio"].Value = fechaServicio;
            sf.Parameters["@ing"].Value = ing;
            sf.Parameters["@folio"].Value = Folio;
            sf.Parameters["@hostName"].Value = hostName;
            sf.Parameters["@reasigna"].Value = motivo;

            sf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Actualizar los datos UpdateCalendarioReasigna: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

                Conn = null;
            }

        }


        public int UpdateInfoFSR(int tipoBD, string folio, string cliente, string direccion, string localidad, string responsable, string reportado, string depto, string telefono, string mail,
                                string equipo, string marca, string modelo, string noSerie, string idEquipo, string webInicio, string webFin, string fallaEn, int tipoServicio, int tipoProblema, 
                                int tipoContrato,string observaciones, string host, string funciona)
        {
            if(tipoBD == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoBD == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            SqlCommand uf = new SqlCommand("UpdateFSR", Conn);
            uf.CommandType = CommandType.StoredProcedure;

            uf.Parameters.Add("@FolioFSR", SqlDbType.VarChar);
            uf.Parameters.Add("@Cliente", SqlDbType.VarChar);
            uf.Parameters.Add("@Direccion", SqlDbType.VarChar);
            uf.Parameters.Add("@Localidad", SqlDbType.VarChar);
            uf.Parameters.Add("@Responsable", SqlDbType.VarChar);
            uf.Parameters.Add("@Reportado", SqlDbType.VarChar);
            uf.Parameters.Add("@Depto", SqlDbType.VarChar);
            uf.Parameters.Add("@Telefono", SqlDbType.VarChar);
            uf.Parameters.Add("@Mail", SqlDbType.VarChar);
            uf.Parameters.Add("@Equipo", SqlDbType.VarChar);
            uf.Parameters.Add("@Marca", SqlDbType.VarChar);
            uf.Parameters.Add("@Modelo", SqlDbType.VarChar);
            uf.Parameters.Add("@NoSerie", SqlDbType.VarChar);
            uf.Parameters.Add("@IdEquipo", SqlDbType.VarChar);
            uf.Parameters.Add("@WebInicio", SqlDbType.DateTime);
            uf.Parameters.Add("@WebFin", SqlDbType.DateTime);
            uf.Parameters.Add("@FallaEncontrada", SqlDbType.VarChar);
            uf.Parameters.Add("@TipoServicio", SqlDbType.Int);
            uf.Parameters.Add("@TipoProblema", SqlDbType.Int);
            uf.Parameters.Add("@TipoContrato", SqlDbType.Int);
            uf.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            uf.Parameters.Add("@host", SqlDbType.VarChar);
            uf.Parameters.Add("@Funciona", SqlDbType.VarChar);

            uf.Parameters["@FolioFSR"].Value = folio;
            uf.Parameters["@Cliente"].Value = cliente;
            uf.Parameters["@Direccion"].Value = direccion;
            uf.Parameters["@Localidad"].Value = localidad;
            uf.Parameters["@Responsable"].Value = responsable;
            uf.Parameters["@Reportado"].Value = reportado;
            uf.Parameters["@Depto"].Value = depto;
            uf.Parameters["@Telefono"].Value = telefono;
            uf.Parameters["@Mail"].Value = mail;
            uf.Parameters["@Equipo"].Value = equipo;
            uf.Parameters["@Marca"].Value = marca;
            uf.Parameters["@Modelo"].Value = modelo;
            uf.Parameters["@NoSerie"].Value = noSerie;
            uf.Parameters["@IdEquipo"].Value = idEquipo;
            uf.Parameters["@WebInicio"].Value = webInicio;
            uf.Parameters["@WebFin"].Value = webFin;
            uf.Parameters["@FallaEncontrada"].Value = fallaEn;
            uf.Parameters["@TipoServicio"].Value = tipoServicio;
            uf.Parameters["@TipoProblema"].Value = tipoProblema;
            uf.Parameters["@TipoContrato"].Value = tipoContrato;
            uf.Parameters["@Observaciones"].Value = observaciones;
            uf.Parameters["@host"].Value = host;
            uf.Parameters["@Funciona"].Value = funciona;

            uf.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Actualizar los Datos: " + ex.Message + " - " + ex.ToString());
            }
        }


        //public int SaveDetalleEquipo(int tipoBD, string llamada, int equipo)
        //{
        //    if(tipoBD == 1)
        //    {
        //        Conexion = ConBDServer;
        //    }
        //    if(tipoBD == 2)
        //    {
        //        Conexion = ConBDPruebasSAP;
        //    }

        //    Conn = new SqlConnection(Conexion);
        //    Conn.Open();

        //    SqlCommand de = new SqlCommand("SaveDetEquipo", Conn);
        //    de.CommandType = CommandType.StoredProcedure;

        //    de.Parameters.Add("@folio", SqlDbType.VarChar);
        //    de.Parameters.Add("@idequipo", SqlDbType.Int);

        //    de.Parameters["@folio"].Value = llamada;
        //    de.Parameters["@idequipo"].Value = equipo;

        //    de.ExecuteNonQuery();

        //    try
        //    {
        //        return 1;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception("Error al recuperar la cadena SQL SaveDetalleEquipo: " + ex.ToString());
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //        Conn.Dispose();

        //        Conn = null;
        //    }
        //}



        //EJECUTA CONSULTAS
        //*************************************************************************************************************************************************
        //***********************EJECUTA CONSULTAS GET / MUESTRA DE DATOS GRID
        public DataTable ExecDataSet(string QueryString, int tipoConn)
        {
            if (tipoConn == 1)
            {
                Conexion = ConBDServer;
            }
            else if (tipoConn == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = Conn.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = QueryString;
            Cmd.CommandTimeout = 2000;
            Cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            da.Fill(dt);
            //dgvDatos.DataSource = dt;
            try
            {
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar ExecDataSet: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                strSQL = null;
                Conn = null;
                Cmd = null;
            }
        }
                     
        
        //*********************** EJECUTA CONSULTAS UN SOLO DATO
        public string ExecuteScalar(string QueryString, int tipoConn)
        {
            if (tipoConn == 1)
            {
                Conexion = ConBDServer;
            }
            else if (tipoConn == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(QueryString, Conn);
            string result = Convert.ToString(Cmd.ExecuteScalar());

            try
            {
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar ExecuteScalar: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                Conn = null;
                Cmd = null;
            }
        }


        public int ExecuteScalarNum(string QueryString, int tipoConn)
        {
            if (tipoConn == 1)
            {
                Conexion = ConBDServer;
            }
            else if (tipoConn == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(QueryString, Conn);
            int result = Convert.ToInt32(Cmd.ExecuteScalar());

            try
            {
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar ExecuteScalarNum: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                Conn = null;
                Cmd = null;
            }
        }



        //*********************** EJECUTA READER
        string result;
        string nulo = " ";
        int bandera = 0;
        public SqlDataReader ExecuteReader(string QuieryString, int tipoConn)
        {
            if(tipoConn == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoConn == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(QuieryString, Conn);

            SqlDataReader leer = Cmd.ExecuteReader();            

            try
            {                
                return leer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar ExecuteReader: " + ex.Message);
            }
        }


        //*********************** EJECUTA INSERT - UPDATE
        public int ExecuteNonQuery(string QueryString, int tipoConn)
        {
            if(tipoConn == 1)
            {
                Conexion = ConBDServer;
            }
            if(tipoConn == 2)
            {
                Conexion = ConBDPruebas;
            }

            Conn = new SqlConnection(Conexion);
            Conn.Open();

            Cmd = new SqlCommand(QueryString, Conn);
            Cmd.ExecuteNonQuery();

            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("Error recuperar ExecuteNonQuery: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                Conn = null;
                Cmd = null;
            }
        }
    }
}
