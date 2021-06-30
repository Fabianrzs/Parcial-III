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

                Cargo cargo = repository.ValCodigoCargo(liquidacion.CodigoCargo);
                Proyecto proyecto = repository.ValCodigoProyecto(liquidacion.CodigoProyecto);

                if (proyecto != null)
                {
                    if (proyecto.NombreProyecto.Equals(seleccion)) 
                    {
                        if (cargo != null)
                        {
                            if ((cargo.ValorHora * liquidacion.HorasTrabajadas) == liquidacion.ValoraPagar)
                            {
                                repository.GuardarLiquidacion(liquidacion); return true;
                            }
                            else
                            {
                                liquidacion.ValoraPagar = cargo.ValorHora * liquidacion.HorasTrabajadas;
                            }
                            repository.GuardarLiquidacion(liquidacion); return false;
                        }
                        else
                        {
                            cargo = repository.ValCodigoPago(liquidacion.ValoraPagar / liquidacion.HorasTrabajadas);

                            if (cargo != null)
                            {
                                liquidacion.CodigoCargo = cargo.CodigoCargo;
                                repository.GuardarLiquidacion(liquidacion); return false;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception e) { return false; }
            finally { connection.Close(); }  
        }


        public ConsultaResponseLiquidacionestabla ConsularLiquidacion()
        {
            try
            {
                connection.Open();
                return new ConsultaResponseLiquidacionestabla(repository.ConsultarLiquidacioness());

            }
            catch (Exception e) { return new ConsultaResponseLiquidacionestabla(e.Message); }
            finally { connection.Close(); }
        }

        public class ConsultaResponseLiquidacionestabla
        {
            public List<Liquidacion> Liquidaciones { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }


            public ConsultaResponseLiquidacionestabla(List<Liquidacion> liquidacion)
            {
                Liquidaciones = liquidacion;
                Error = false;
            }

            public ConsultaResponseLiquidacionestabla(string message)
            {
                Message = message;
                Error = true;
            }
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
                return new CargaResponseProyecto(repository.ConsultarProyectos());
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
