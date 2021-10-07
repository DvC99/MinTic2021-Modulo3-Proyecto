USE MinTic2021;

CREATE TABLE administrador (
    id integer IDENTITY (1, 1),
    id_paciente integer NOT NULL,
    id_asignacion integer NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE paciente (
    id integer IDENTITY (1, 1),
    cedula varchar UNIQUE NOT NULL,
    pasaporte varchar UNIQUE NOT NULL,
    id_asignacion integer NOT NULL,
    id_historiaclinica integer NOT NULL,
    id_administrador integer NOT NULL,
    nombre1 char NOT NULL,
    nombre2 char NOT NULL,
    apellido1 char NOT NULL,
    apellido2 char NOT NULL,
    edad integer NOT NULL,
    eps varchar NOT NULL,
    PRIMARY KEY (id, cedula, pasaporte)
);

CREATE TABLE medico (
    id integer IDENTITY (1, 1),
    cedula varchar NOT NULL,
    pasaporte varchar NOT NULL,
    nombre1 char NOT NULL,
    nombre2 char NOT NULL,
    apellido1 char NOT NULL,
    apellido2 char NOT NULL,
    especialidad char NOT NULL,
    cargo char NOT NULL,
    PRIMARY KEY (id, cedula, pasaporte)
);

CREATE TABLE enfermera (
    id integer IDENTITY (1, 1),
    cedula varchar NOT NULL,
    pasaporte varchar NOT NULL,
    nombre1 char NOT NULL,
    nombre2 char NOT NULL,
    apellido1 char NOT NULL,
    apellido2 char NOT NULL,
    especialidad char NOT NULL,
    cargo char NOT NULL,
    PRIMARY KEY (id, cedula)
);

CREATE TABLE hisotiaclinica (
    id_paciente integer NOT NULL,
    id_medico integer NOT NULL,
    id_enfermera integer NOT NULL,
    fechavisita date NOT NULL,
    comentarios text NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE asignacion (
    id integer IDENTITY (1, 1),
    id_paciente integer NOT NULL,
    id_medico integer NOT NULL,
    id_enfermera integer NOT NULL,
    fechainicio date NOT NULL,
    fechafinal date NOT NULL,
    duracion date NOT NULL,
    PRIMARY KEY (id)
);
