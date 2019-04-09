--script creacion de tablas 
create table Sexo(
id_sexo int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table FormacionProfecional(
id_formacionProfecional int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Especialidad(
id_especialidad int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Nacionalidad(
id_nacionalidad int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Autoidetificacion(
id_autoidetificacion int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table CodigoMPS(
id_codigoMPS int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)

create table Profecional(
id_Profecional int  identity (1,1) Not null primary key,
nombres  varchar (100),
apellidos varchar (100),
fechaNacimiento date,  
ci varchar (10) unique,
contrasenia varchar (50),
FirmaSello varchar (50),
id_sexo int,
id_formacionProfecional int, 
id_especialidad int,
id_nacionalidad int, 
id_autoidetificacion int, 
id_codigoMPS int,
foto varchar (200),
 foreign key(id_sexo) references Sexo(id_sexo), 
foreign key(id_formacionProfecional) references FormacionProfecional(id_formacionProfecional),
 foreign key(id_especialidad) references Especialidad(id_especialidad),
 foreign key(id_nacionalidad) references Nacionalidad(id_nacionalidad),
 foreign key(id_autoidetificacion) references Autoidetificacion(id_autoidetificacion),
 foreign key(id_codigoMPS) references CodigoMPS(id_codigoMPS),
)

create table LugarAtencion(
id_lugarAtencion int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table TipoEstable	(
id_tipoEstable int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table InstitucionSistema(
id_institucionSistema int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)

create table Grupo(	
idGrupo	 int  identity (1,1) Not null primary key,
nombreUnidad	varchar (50),
id_lugarAtencion	int,
id_tipoEstable	int,
id_institucionSistema int,
id_Profecional int,
estado int default (1),
foreign key(id_Profecional) references Profecional(id_Profecional),
foreign key(id_lugarAtencion) references LugarAtencion(id_lugarAtencion),
foreign key(id_tipoEstable) references TipoEstable(id_tipoEstable),
foreign key(id_institucionSistema) references InstitucionSistema(id_institucionSistema),
)

create table AfiliadoPaciente(
id_AfiliadoPaciente int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)

create table GrupoPrioritario(
id_GrupoPrioritario int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Provincia (
id_Provincia  int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Canton(
id_Canton int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
create table Parroquia(
id_Parroquia int  identity (1,1) Not null primary key,
codigo int ,
descrpcion nvarchar(50)
)
 
create table Paciente
(
id_Paciente int  identity (1,1) Not null primary key,
nombres varchar (100),
Apellidos varchar (100),
cedula varchar(10)  not null unique,
id_sexo int,
fechaNacimiento date,
cedulaRepresentante varchar(10),
id_nacionalidad int,
id_autoidetificacion int,
id_AfiliadoPaciente int,
id_GrupoPrioritario int,
semanaGestacion int,
id_Provincia int,
id_Canton int ,
id_Parroquia int ,
Resinto varchar(200),
TipoSangre varchar(20),
Telefono varchar (50),
foto varchar(200),
fechaRejistro datetime default GETDATE(),
estado int default(1),
foreign key(id_sexo) references Sexo(id_sexo), 
 foreign key(id_nacionalidad) references Nacionalidad(id_nacionalidad),
 foreign key(id_autoidetificacion) references Autoidetificacion(id_autoidetificacion),
foreign key(id_AfiliadoPaciente) references AfiliadoPaciente(id_AfiliadoPaciente),
foreign key(id_GrupoPrioritario) references GrupoPrioritario(id_GrupoPrioritario),
foreign key(id_Provincia) references Provincia(id_Provincia),
foreign key(id_Canton) references Canton(id_Canton),
foreign key(id_Parroquia) references Parroquia(id_Parroquia)
)

create table AsignacionGrupo(
idGrupo int ,
id_Paciente int ,
creador bit default 0,
estado int default 1,
fechaAsignacion datetime default GETDATE(),
primary key (idGrupo,id_Paciente),
foreign key(idGrupo) references Grupo(idGrupo),
foreign key (id_Paciente) references Paciente (id_Paciente)
)


create table Plantograma
(
idPlantograma int identity (1,1) not null primary key,
imgIzq varchar (200),
imgDer  varchar (200),
imgIzqAnlss  varchar (200),
imgDerAnlss  varchar (200),
x  float ,
xD  float ,
y float ,
yD float ,
mF float ,
mFD float ,
aI float ,
aID float ,
tA float ,
tAD float ,
LongPieY float ,
LongPieYD float ,
LongPieX float ,
LongPieXD float ,
resultado float ,
resultadoD float ,
diagnostica  varchar (50),
diagnosticaD  varchar (50),
estado int default 1,
fechaCreacion datetime default Getdate(),
id_Paciente int,
 foreign key (id_Paciente) references Paciente (id_Paciente),
)

-- funcion
create Function fN_ver_si_esta_en_grupo(@idGrupo int,@id_Pacienteint int)
RETURNS Int
AS
BEGIN
  Declare @id int
  Declare @idReturn int
  Set @id=  (select ag.id_Paciente from Grupo as g Inner join AsignacionGrupo as ag on g.idGrupo=ag.idGrupo where g.idGrupo=@idGrupo   and ag.id_Paciente=@id_Pacienteint)
if(@id>0)
  BEGIN
   Set @idReturn=@id
  end
else
  Begin
    Set @idReturn=0
  end
Return @idReturn
END


select *from Paciente as p where  not p.id_Paciente=dbo.fN_ver_si_esta_en_grupo(3,p.id_Paciente)
---------------------


