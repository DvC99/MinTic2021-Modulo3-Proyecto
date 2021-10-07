USE MinTic2021;

ALTER TABLE administrador
ADD CONSTRAINT FK_admipaciente
FOREIGN KEY (id_paciente) REFERENCES paciente(id);

ALTER TABLE administrador
ADD CONSTRAINT FK_admiasignacion
FOREIGN KEY (id_asignacion) REFERENCES asignacion(id);

ALTER TABLE asignacion
ADD CONSTRAINT FK_asigpaciente
FOREIGN KEY (id_paciente) REFERENCES paciente(id);	

ALTER TABLE asignacion
ADD CONSTRAINT FK_asigmedico
FOREIGN KEY (id_medico) REFERENCES medico(id);

ALTER TABLE asignacion
ADD CONSTRAINT FK_asigenfermera
FOREIGN KEY (id_enfermera) REFERENCES asignacion(id);	

ALTER TABLE historiaclinica
ADD CONSTRAINT FK_histclinicapaciente
FOREIGN KEY (id_paciente) REFERENCES paciente(id);	

ALTER TABLE historiaclinica
ADD CONSTRAINT FK_histclinicamedico
FOREIGN KEY (id_medico) REFERENCES medico(id);	

ALTER TABLE historiaclinica
ADD CONSTRAINT FK_histclinienfermera
FOREIGN KEY (id_enfermera) REFERENCES asignacion(id);

ALTER TABLE paciente
ADD CONSTRAINT FK_pacineteasig
FOREIGN KEY ( id_asignacion) REFERENCES asignacion(id);

ALTER TABLE paciente
ADD CONSTRAINT FK_pacientehistoclinica
FOREIGN KEY ( id_historiaclinica) REFERENCES hisotiaclinica(id);

ALTER TABLE paciente
ADD CONSTRAINT FK_pacienteadmini
FOREIGN KEY ( id_administrador) REFERENCES administrador(id);