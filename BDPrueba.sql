CREATE DATABASE ProyectoPatronusWeb
USE ProyectoPatronusWeb
drop database ProyectoPatronusWeb 

CREATE TABLE TipoUsuario
(
	idTipoUsuario int primary key identity,
	tipoUsuario varchar(30)
);

CREATE TABLE RegistroUsuario
(
	idUsuario int primary key identity, /*Generdo por la base de datos*/
	correo varchar(30),
	nombreUsuario varchar(30),
	contrasena varchar(30),
	ConfirmarContrasena varchar(30),
	idTipoUsuario int,
	
	FOREIGN KEY (idTipoUsuario) REFERENCES TipoUsuario(idTipoUsuario)
);

UPDATE RegistroUsuario SET nombreUsuario = 'Sin Asignar' where nombreUsuario='-'
UPDATE RegistroUsuario SET correo = 'Sin Asignar' where correo='-'

CREATE TABLE Trabajo
(
	idTrabajo int primary key identity,
	titulo varchar(30),
	descripcion varchar(100),
	idCategoria int,
	fechaInicial varchar(20),
	fechaAsignada varchar(20),
	fechaFinal varchar(20),
	idEstado int,
	idUsuario int,
	
	FOREIGN KEY (idUsuario) REFERENCES RegistroUsuario(idUsuario),
	FOREIGN KEY (idEstado) REFERENCES EstadoTrabajo(idEstado),
	FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
	
);
ALTER TABLE Trabajo ADD costoTrabajo int

CREATE TABLE EstadoTrabajo
(
	idEstado int primary key identity,
	estadoTrabajo varchar(30)
);

CREATE TABLE Categoria
(
	idCategoria int primary key identity,
	categoria varchar(30)
);

--CREATE TABLE perfilUsuario
--{
--	idPerfil int primary key identity,
	
--	FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
	
--}


/*REGISTROS*/
/*------------------TIPOS DE USUARIOS--------------------*/
INSERT INTO TipoUsuario VALUES ('Administrador')
INSERT INTO TipoUsuario VALUES ('Freelancer')
INSERT INTO TipoUsuario VALUES ('Empresa')
INSERT INTO TipoUsuario VALUES ('Sin asignar')

/*------------------ESTADO DE TRABAJOS--------------------*/
INSERT INTO EstadoTrabajo VALUES ('Disponible')
INSERT INTO EstadoTrabajo VALUES ('noDisponible')

/*------------------CATEGORIAS--------------------*/
INSERT INTO Categoria VALUES ('Diseño')
INSERT INTO Categoria VALUES ('Base de datos')
INSERT INTO Categoria VALUES ('Redes')
INSERT INTO Categoria VALUES ('Movil')


/*---------------STORED PROCEDURE---------------*/
/*Usuarios por freelances
Filtro de usuarios para mostrar solamente 
al usuario empresa
*/
CREATE PROCEDURE SP_GETFREELANCERS
(
	@idTipoUsuario INT
)
AS
BEGIN
	SELECT * FROM RegistroUsuario WHERE idTipoUsuario=@idTipoUsuario
END

execute SP_GETFREELANCERS 2

/*Usuarios por freelances
Filtro de usuarios para mostrar solamente 
al usuario freelancer*/

CREATE PROCEDURE SP_GETEMPRESA
(
	@idTipoUsuario INT
)
AS
BEGIN
	SELECT * FROM RegistroUsuario WHERE @idTipoUsuario=3
END




/*Update id trabajo
actualiza el Id del trabajador fantasma :p
*/
CREATE PROCEDURE SP_UpdateFreelancerTrabajo
(
	@idTipoUsuario INT
)
AS
BEGIN
	UPDATE Trabajo SET idUsuario WHERE @idTipoUsuario=4
END



/*Update estado de trabajo
Actualiza el estado en el cual se encuentra el trabajo
disponible o no disponble
*/
CREATE PROCEDURE SP_UpdateFreelancerTrabajo
(
	@idTipoUsuario INT
)
AS
BEGIN
	UPDATE Trabajo SET idUsuario WHERE @idTipoUsuario=4
END

/*----------------VISTA DE TABLAS---------------------*/
SELECT * FROM TipoUsuario
SELECT * FROM Categoria
SELECT * FROM EstadoTrabajo
SELECT * FROM RegistroUsuario
SELECT * FROM Trabajo
SELECT * FROM FREF
SELECT * FROM EMPF



/*TABLAS DEL TERROR :O*/
DROP TABLE FREF
DROP TABLE EMPF
CREATE TABLE FREF
(
	idfref int primary key identity,
	nombreUsuario varchar(30)
);

CREATE TABLE EMPF
(
	idempf int primary key identity,
	nombreUsuario varchar(30),
	numTrabajosPublicados int
);
UPDATE Trabajo SET nombreUsuario = null where nombreUsuario='-'



CREATE TABLE PAISES
(
	idPaises int primary key identity,
	nombrePais varchar(30)
);

INSERT INTO PAISES VALUES ('Baja California')
INSERT INTO PAISES VALUES ('Sonora')
INSERT INTO PAISES VALUES ('Guadalajara')
INSERT INTO PAISES VALUES ('Estado de Mexico')
INSERT INTO PAISES VALUES ('Sinaloa')
INSERT INTO PAISES VALUES ('Monterrey')
INSERT INTO PAISES VALUES ('Durango')
INSERT INTO PAISES VALUES ('San Luis Potosi')
INSERT INTO PAISES VALUES ('Nuevo Leon')
INSERT INTO PAISES VALUES ('Chiapas')


select * from PAISES