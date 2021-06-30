using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proyecto
    {
        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }

    }
}
/*
 * create table Proyecto
(
	CodigoProyecto varchar (5) primary key,
	NombreProyecto varchar (20)
);
 */