Create table Cargo
(
	CodigoCargo varchar (5) primary key,
	NombreCargo varchar (20),
	ValorHora numeric
);

Create table Liquidacion
(
	CodigoProyecto varchar(5),
	CodigoCargo varchar (5),
	Identificacion varchar(12), 
	Nombre varchar (50),
	HorasTrabajadas numeric,
	ValoraPagar numeric
);

create table Proyecto
(
	CodigoProyecto varchar (5) primary key,
	NombreProyecto varchar (20)
);

Select * From Proyecto

Insert into Proyecto (CodigoProyecto, NombreProyecto) values ('P001','Las Flores');
Insert into Proyecto (CodigoProyecto, NombreProyecto) values ('P002','Los Rosales');
Insert into Proyecto (CodigoProyecto, NombreProyecto) values ('P003','Los Trigos');

insert into Cargo (CodigoCargo, NombreCargo, ValorHora) values ('C001','Obrero ',10000);
insert into Cargo (CodigoCargo, NombreCargo, ValorHora) values ('C002','Secretaría ',20000);
insert into Cargo (CodigoCargo, NombreCargo, ValorHora) values ('C003','Oficios Varios ',15000);
insert into Cargo (CodigoCargo, NombreCargo, ValorHora) values ('C004','Arquitecto ',30000);


 
  
 

