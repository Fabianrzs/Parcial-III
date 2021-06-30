using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacioService
    {
        readonly LiquidacionRepository repository;
        readonly ConnectionManager connection;

        public LiquidacioService(string connectionString)
        {
            connection = new ConnectionManager(connectionString);
            repository = new LiquidacionRepository(connection);
        }


        public bool RegistrarCorrectos(Liquidacion liquidacion, string seleccion)
        {
            try
            {
                connection.Open();




                return false;
            }
            catch (Exception e) { return false; }
            finally { connection.Close(); }

            
        }




        //---------------------Carga de archivo Para validar --------------------
        
        public ConsultaResponseLiquidacion ConsularLiquidacion(string ruta)
        {
            try
            {
                connection.Open();
                return new ConsultaResponseLiquidacion(repository.ConsultarLiquidacion(ruta));

            }
            catch (Exception e) { return new ConsultaResponseLiquidacion(e.Message); }
            finally { connection.Close(); }
        }

        public class ConsultaResponseLiquidacion
        {
            public List<Liquidacion> Liquidacions { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }


            public ConsultaResponseLiquidacion(List<Liquidacion> liquidacions)
            {
                Liquidacions = liquidacions;
                Error = false;
            }

            public ConsultaResponseLiquidacion(string message)
            {
                Message = message;
                Error = true;
            }
        }












        //------------------------Cargar Datos de la base en combo-------------
        public CargaResponseProyecto CargarProyecto()
        {
            try
            {
                connection.Open();
                return new CargaResponseProyecto(repository.ConsultarServicio());
            }
            catch (Exception e) { return new CargaResponseProyecto(e.ToString()); }
            finally { connection.Close(); }
        }

        public class CargaResponseProyecto
        {
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public List<Proyecto> Proyectos { get; set; }

            public CargaResponseProyecto(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }

            public CargaResponseProyecto(List<Proyecto> proyectos)
            {
                Proyectos = proyectos;
                Error = false;
            }
        }



    }
}
