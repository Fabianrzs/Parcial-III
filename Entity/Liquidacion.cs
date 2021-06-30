using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {
        public string CodigoProyecto { get; set; }
		public string CodigoCargo { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
        public decimal HorasTrabajadas { get; set; }
		public decimal ValoraPagar { get; set; }


	}

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
