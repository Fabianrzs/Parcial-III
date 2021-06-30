using Entity;
using System;
using System.Collections.Generic;
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
        //-------------Consulta Proyecto----------------

        public List<Proyecto> ConsultarServicio()
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
                CodigoCargo = datosEstudiante[0],
                CodigoProyecto = datosEstudiante[1],
                Identificacion = datosEstudiante[2],
                Nombre = datosEstudiante[3],
                HorasTrabajadas=Convert.ToDecimal(datosEstudiante[4]),
                ValoraPagar = Convert.ToDecimal(datosEstudiante[5])
            };
            return liquidacion;
        }




    }
}
