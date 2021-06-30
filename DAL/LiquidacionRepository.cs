using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LiquidacionRepository
    {
        private SqlConnection _connection;

        public LiquidacionRepository(ConnectionManager connection)
        {
            _connection = connection._connection;
        }

        public Proyecto ValCodigoProyecto(string CodigoProyecto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@CodigoProyecto", SqlDbType.VarChar).Value = CodigoProyecto;
                command.CommandText = "Select * From Proyecto where CodigoProyecto = @CodigoProyecto";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        return MapToProyecto(dataReader);
                    }
                }
            }
            return null;
        }


        public Cargo ValCodigoCargo(string CodCargo)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@CodCargo", SqlDbType.VarChar).Value = CodCargo;
                command.CommandText = "Select * From Cargo where CodigoCargo = @CodCargo";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        return MapToCargo(dataReader);
                    }
                }
            }
            return null;
        }

        private Cargo MapToCargo(SqlDataReader dataReader)
        {
            Cargo Cargo = null;

            if (!dataReader.HasRows) return Cargo;

            Cargo = new Cargo()
            {
                CodigoCargo = (string)dataReader["CodigoCargo"],
                NombreCargo = (string)dataReader["NombreCargo"],
                ValorHora = (decimal)dataReader["ValorHora"]

            };
            return Cargo;
        }

    //-------------Consulta Proyecto----------------

    public List<Proyecto> ConsultarProyectos()
        {
            List<Proyecto> Proyectos = new List<Proyecto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * From Proyecto";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Proyecto proyecto = MapToProyecto(dataReader);
                        Proyectos.Add(proyecto);
                    }
                }
            }
            return Proyectos;
        }

        private Proyecto MapToProyecto(SqlDataReader dataReader)
        {
            Proyecto proyecto = null;

            if (!dataReader.HasRows) return proyecto;

            proyecto = new Proyecto()
            {
                CodigoProyecto = (string)dataReader["CodigoProyecto"],
                NombreProyecto = (string)dataReader["NombreProyecto"]
            };
            return proyecto;
        }


        //------------------------------------------------------------------------------

        public int GuardarLiquidacion(Liquidacion liquidacion)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Liquidacion (CodigoProyecto,CodigoCargo,Identificacion,Nombre,HorasTrabajadas,ValoraPagar) " +
                    "values (@CodigoProyecto, @CodigoCargo, @Identificacion, @Nombre, @HorasTrabajadas, @ValoraPagar)";

                command.Parameters.Add("@CodigoProyecto", SqlDbType.VarChar).Value = liquidacion.CodigoProyecto ;
                command.Parameters.Add("@CodigoCargo", SqlDbType.VarChar).Value = liquidacion.CodigoCargo;
                command.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = liquidacion.Identificacion;
                command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = liquidacion.Nombre;
                command.Parameters.Add("@HorasTrabajadas", SqlDbType.Decimal).Value = liquidacion.HorasTrabajadas;
                command.Parameters.Add("@ValoraPagar", SqlDbType.Decimal).Value = liquidacion.ValoraPagar;

                return command.ExecuteNonQuery();

            }
        }

        public List<Liquidacion> ConsultarLaboratorio()
        {
            List<Liquidacion> List = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * From Liquidacion";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = MapToLiquidacion(dataReader);
                        List.Add(liquidacion);
                    }
                }
            }
            return List;
        }
        private Liquidacion MapToLiquidacion(SqlDataReader dataReader)
        {
            Liquidacion liquidacion = null;

            if (!dataReader.HasRows) return liquidacion;

            liquidacion = new Liquidacion()
            {
                CodigoProyecto = (string)dataReader["CodigoProyecto"],
                CodigoCargo = (string)dataReader["CodigoCargo"],
                Identificacion = (string)dataReader["Identificacion"],
                Nombre = (string)dataReader["Nombre"],
                HorasTrabajadas = (decimal)dataReader["HorasTrabajadas"],
                ValoraPagar = (decimal)dataReader["ValoraPagar"]

            };

            return liquidacion;
        }

        /*Create table Liquidacion
(
	CodigoProyecto varchar(5),
	CodigoCargo varchar (5),
	Identificacion varchar(12), 
	Nombre varchar (50),
	HorasTrabajadas numeric,
	ValoraPagar numeric
);*/

        //-------------Archivo-------------
        public List<Liquidacion> ConsultarLiquidacion(string ruta)
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();

            FileStream file = new FileStream(ruta, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string linea = "";

            while ((linea = reader.ReadLine()) != null)
            {
                Liquidacion liquidacion = MapearServicio(linea);
                liquidaciones.Add(liquidacion);
            }
            file.Close();
            reader.Close();

            return liquidaciones;
        }

        private Liquidacion MapearServicio(string linea)
        {
            string[] datosEstudiante = linea.Split(';');

            Liquidacion liquidacion = new Liquidacion()
            {
                CodigoCargo = datosEstudiante[1],
                CodigoProyecto = datosEstudiante[0],
                Identificacion = datosEstudiante[2],
                Nombre = datosEstudiante[3],
                HorasTrabajadas=Convert.ToDecimal(datosEstudiante[4]),
                ValoraPagar = Convert.ToDecimal(datosEstudiante[5])
            };
            return liquidacion;
        }




    }
}
