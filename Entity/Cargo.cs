using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cargo
    {
        public string CodigoCargo { get; set; }
        public string NombreCargo { get; set; }
        public decimal ValorHora { get; set; }
    }
}

/*Create table Cargo
(
	CodigoCargo varchar (5) primary key,
	NombreCargo varchar (20),
	ValorHora numeric
);*/
