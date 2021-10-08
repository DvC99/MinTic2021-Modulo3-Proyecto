USE MinTic2021;

CREATE TABLE Administrador (
    Id int PRIMARY KEY IDENTITY (1, 1),
	Cedula varChar unique not null,
    Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Edad int not null,
	Genero varchar(50) not null,
	Telefono varChar(50) not null,
	Cargo varChar(50) not null
);

CREATE TABLE Familiar (
	Id int PRIMARY KEY IDENTITY (1, 1),
	Cedula varChar unique not null,
    Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Edad int not null,
	Genero varchar(50) not null,
	Telefono varChar(50) not null,
	Parentesco varChar(50) not null
);

CREATE TABLE Paciente (
    Id int PRIMARY KEY IDENTITY (1, 1),
	Cedula varChar unique not null,
	Id_administrador int NOT NULL,
	Id_familiar int NOT NULL,	
    Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Edad int not null,
	Genero varchar(50) not null,
	Telefono varChar(50) not null

	CONSTRAINT FK_Paciente_Administrador
	FOREIGN KEY (Id_administrador) REFERENCES Administrador(Id)
		ON UPDATE CASCADE
		ON DELETE CASCADE,
	CONSTRAINT FK_Paciente_Familiar
	FOREIGN KEY (Id_familiar) REFERENCES Familiar(Id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);



CREATE TABLE Medico (
	Id int PRIMARY KEY IDENTITY (1, 1),
	Cedula varChar unique not null,
	Id_administrador int NOT NULL,	
    Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Edad int not null,
	Genero varchar(50) not null,
	Telefono varChar(50) not null,
	Especialidad varChar(50) not null

	CONSTRAINT FK_Medico_Administrador
	FOREIGN KEY (Id_administrador) REFERENCES Administrador(Id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);

CREATE TABLE Enfermera (
    Id int PRIMARY KEY IDENTITY (1, 1),
	Cedula varChar unique not null,
	Id_administrador int NOT NULL,	
    Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Edad int not null,
	Genero varchar(50) not null,
	Telefono varChar(50) not null,
	Especialidad varChar(50) not null

	CONSTRAINT FK_Enfermera_Administrador
	FOREIGN KEY (Id_administrador) REFERENCES Administrador(Id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);

CREATE TABLE HistoriaClinica (
	Id int PRIMARY KEY IDENTITY (1, 1),
    Id_paciente int NOT NULL,
    Id_medico int not null,
    Id_enfermera int not null,
	Oximetria varchar(50) not null,
	FrecuenciaRespitario varchar(50) not null,
    FrecuenciaCardiaca varchar(50) not null,
    Temperatura varchar(50) not null,
    PrecionArterial varchar(50) not null,
    Glicemia varchar(50) not null,
	Fechavisita datetime NOT NULL,
    Comentarios text NOT NULL

	CONSTRAINT FK_HistoriaClinica_Paciente
	FOREIGN KEY (Id_paciente) REFERENCES Paciente(Id),

	CONSTRAINT FK_HistoriaClinica_Medico
	FOREIGN KEY (Id_medico) REFERENCES Medico(Id),

	CONSTRAINT FK_HistoriaClinica_Enfermera
	FOREIGN KEY (Id_enfermera) REFERENCES Enfermera(Id)
);

CREATE TABLE Asignacion (
    Id_paciente int NOT NULL,
    Id_medico int NOT NULL,
    Id_enfermera int NOT NULL,
	Id_historiaClinica int not null,
    fechainicio datetime NOT NULL,
    fechafinal datetime NOT NULL

	CONSTRAINT FK_Asignacion_Paciente
	FOREIGN KEY (Id_paciente) REFERENCES Paciente(Id),

	CONSTRAINT FK_Asignacion_Medico
	FOREIGN KEY (Id_medico) REFERENCES Medico(Id),

	CONSTRAINT FK_Asignacion_Enfermera
	FOREIGN KEY (Id_enfermera) REFERENCES Enfermera(Id),

	CONSTRAINT FK_Asignacion_HistoriaClinica
	FOREIGN KEY (Id_historiaClinica) REFERENCES HistoriaClinica(Id)
);
