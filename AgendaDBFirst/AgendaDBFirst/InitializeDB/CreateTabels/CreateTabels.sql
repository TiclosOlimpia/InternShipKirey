CREATE TABLE IstoricApeluri
(
	Id int,
	NrTelefon varchar (255),
	DataSiOra DateTime,
	Durata int,
	Ptimit bit,
	CONSTRAINT PK_IstoricApeluri PRIMARY KEY(Id),
	FOREIGN KEY(NrTelefon) REFERENCES Agenda(NrTelefon)
);

CREATE TABLE Agenda
(
	Nume varchar(255),
	Prenume varchar(255),
	NrTelefon varchar (255),
	DataNasterii date,
	Stat varchar(255)
);