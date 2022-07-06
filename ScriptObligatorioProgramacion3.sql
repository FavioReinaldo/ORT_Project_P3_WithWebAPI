-- ********************* Borrar base si existe y crear nueva *********************

USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='ObligaotrioProgramacion3')
	DROP DATABASE ObligaotrioProgramacion3
GO

CREATE DATABASE ObligaotrioProgramacion3;
GO

USE ObligaotrioProgramacion3;
GO


-- ********************* Creacion de tablas *********************

--Tabla Usuario
CREATE TABLE Usuario (
	mail VARCHAR(200) NOT NULL,
	password VARCHAR(200) NOT NULL		
);
GO

Alter Table Usuario
	Add Constraint Usuario_PK
	Primary Key (mail);
GO

--Tabla Tipo
Create table dbo.Tipo(
			Nombre varchar(50) not null unique,
			Descripcion varchar(200));
GO

Alter Table dbo.Tipo
	Add Constraint Tipo_PK
	Primary Key (Nombre);
GO

--Tabla Planta
CREATE TABLE Planta (
	NombreTipo VARCHAR(50) NOT NULL,
	NombreCientifico VARCHAR(200) NOT NULL,
	NombresVulgares VARCHAR(200),
	Descripcion VARCHAR(200),
	Ambiente VARCHAR(200),
	AlturaMaxima INT,
	FotoPlanta VARCHAR(200)		
);
GO

Alter Table Planta
	Add Constraint Planta_PK
	Primary Key (NombreCientifico);
GO

Alter table Planta
	Add Constraint Planta_FK
	Foreign Key (NombreTipo) References
	dbo.Tipo (Nombre);
GO

--Tabla FichaCuidados
CREATE TABLE FichaCuidados (	
	NombreCientifico VARCHAR(200) NOT NULL,
	FrecuenciaRiego VARCHAR(200),
	Illuminacion VARCHAR(200),
	Temperatura INT 	
);
GO

Alter Table FichaCuidados
	Add Constraint FichaCuidados_PK
	Primary Key (NombreCientifico);
GO

Alter table FichaCuidados
	Add Constraint FichaCuidados_FK
	Foreign Key (NombreCientifico) References
	Planta (NombreCientifico);
GO

-- ********************* Inserts de Datos *********************



-- Usuario 

INSERT INTO Usuario (mail, password)
	VALUES 	

		('Usuario1@mail.com', 'Usuario1'),
		('Usuario2@mail.com', 'Usuario2'),
		('Usuario3@mail.com', 'Usuario3');
		
insert into dbo.Tipo values

			('Hierba','Es una planta que no presenta órganos decididamente leñosos. Los tallos de las hierbas son verdes y generalmente mueren al acabar la buena estación, siendo luego reemplazados por otros nuevos.'),
			('Mata','La mata es un subarbusto o arbusto enano que se distingue del arbusto por la disposición de las ramas a ras del suelo, y por tener menor altura (no suelen superar los 20 cm).'),
			('Arbusto','Llamamos arbusto a una planta leñosa que, a diferencia del árbol, no se eleva sobre un solo tronco o fuste, sino que se ramifica desde la misma base.'),
			('Arbol','Los árboles son plantas con tallo leñoso que se ramifica a cierta altura del suelo. '),
			('Gimnosperma ','Son plantas que sí tienen verdadera raíz, tallo, hojas, flores y fruto. Estas se reproducen por semillas que se encuentran en el interior del fruto.'),
			('Angiosperma','Tienen verdadera raíz, tallo, hojas y flores, pero no cuentan con fruto. Sus flores producen semillas, pero estas no se encuentran encerradas.'),
			('Perenne','Viven durante varias temporadas ya que cuentan con recursos para vivir con mayor facilidad y durante periodos de tiempo más largos que el resto.'),
			('Bianuale','Tienen un periodo de crecimiento que ocupa dos temporadas completas.'),
			('Anuale','Tienen un periodo de vida que tan sólo ocupa una temporada.');
			
			
INSERT INTO Planta (NombreTipo, NombreCientifico, NombresVulgares, Descripcion, Ambiente, AlturaMaxima, FotoPlanta)
	VALUES 	

		('Arbusto', 'Chamaedorea Elegans', 'Palmera de salon', 'Esta es una descripcion de la planta', 'Interior', 95, 'Chamaedorea_Elegans_001.jpg'),
		('Hierba','Thymus', 'Tomillo', 'Esta es una descripcion de la planta', 'Exterior', 43, 'Thymus_001.jpg'),
		('Arbol', 'Quercus Robur', 'Roble', 'Esta es una descripcion de la planta', 'Exterior' , 1500, 'Quercus_Robur_001.jpg'),
		('Gimnosperma', 'Pinus', 'Pino', 'Esta es una descripcion de la planta', 'Exterior' , 900, 'Pinus_001.jpg'),
		('Perenne', 'Vinca Major','Hierba doncella','Esta es una descripcion de la planta', 'Exterior' , 70, 'Vinca_Major_001.jpg'),
		('Arbol', 'Prunus Cerasus','Cereso','Esta es una descripcion de la planta', 'Exterior' , 850, 'Prunus_Cerasus_001.jpg'),
		('Hierba','Sanseviera','Espada de San Jorge','Esta es una descripcion de la planta', 'Mixta' , 120, 'Sanseviera_001.jpg'),
		('Arbol','Eucalyptus','Eucalipto','Esta es una descripcion de la planta', 'Exterior' , 1200, 'Eucalyptus_001.jpg'),
		('Hierba','Mentha','Menta','Esta es una descripcion de la planta', 'Mixta' , 1200, 'Mentha_001.jpg'),
		('Hierba','Succulentus','Suculenta','Esta es una descripcion de la planta', 'Interior' , 20, 'Succulentus_001.jpg');
		

INSERT INTO FichaCuidados(NombreCientifico, FrecuenciaRiego, Illuminacion, Temperatura )
	
	VALUES 	
		('Chamaedorea Elegans', '1 semana', 'indirecta', 20),
		('Thymus',  '2 dias', 'indirecta', 25),
		('Quercus Robur',  '3 dias', 'indirecta', 15),
		('Pinus',  '2 semanas', 'indirecta', 17),
		('Vinca Major',  '1 semana', 'indirecta', 22),
		('Prunus Cerasus',  '2 semanas', 'indirecta', 20),
		('Sanseviera',  '4 dias', 'indirecta', 18),
		('Eucalyptus',  '1 dia', 'indirecta', 20),
		('Mentha',  '5 dias', 'indirecta', 18),
		('Succulentus',  '1 dia', 'indirecta', 17);	
		
		
select * from Usuario

select * from dbo.Tipo

select * from Planta

select * from FichaCuidados