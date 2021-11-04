CREATE TABLE Persona
(
IdPersona INT NOT NULL,
Nombre VARCHAR2(50),
ApellidoPaterno VARCHAR2(50),
ApellidoMaterno VARCHAR(50),
primary key(IdPersona)
);
CREATE OR REPLACE PROCEDURE AddPersona
(p_IdPersona int,
p_Nombre VARCHAR2,
p_ApellidoPaterno VARCHAR2,
p_ApellidoMaterno VARCHAR2
)
AS
BEGIN
INSERT INTO Persona VALUES(p_IdPersona,p_Nombre,p_ApellidoPaterno, p_ApellidoMaterno);
END;


EXEC addpersona(1,'Samuel','Garcia','Ballinas');
EXEC addpersona(2,'Oriana','Garcia','Hernandez');

SELECT*FROM persona;

CREATE OR REPLACE PROCEDURE UpdatePersona
(p_IdPersona in persona.idpersona%TYPE,
p_Nombre in persona.nombre%TYPE,
p_ApellidoPaterno in persona.apellidopaterno%TYPE,
p_ApellidoMaterno in persona.apellidomaterno%TYPE
)
AS
BEGIN
UPDATE persona SET
Nombre=p_Nombre,
ApellidoPaterno=p_ApellidoPaterno,
ApellidoMaterno=p_ApellidoMaterno
WHERE IdPersona = p_IdPersona;
END;
EXEC addpersona(3,'Brenda','Sanchez','Sanchez');
SELECT*FROM persona;

CREATE OR REPLACE PROCEDURE DeletePersona
(p_IdPersona INT)
AS
BEGIN
DELETE FROM persona WHERE IdPersona = p_IdPersona;
END;

EXEC deletepersona(3)

CREATE OR REPLACE PROCEDURE GetAllPersona
(p_IdPersona out int,
p_Nombre out VARCHAR2,
p_ApellidoPaterno out VARCHAR2,
p_ApellidoMaterno out VARCHAR2
)
AS
BEGIN
SELECT IdPersona, Nombre, ApellidoPaterno, ApellidoMaterno INTO p_IdPersona, p_Nombre, p_ApellidoPaterno,p_ApellidoMaterno FROM persona;
END;
var p_IdPersona int;
var p_Nombre VARCHAR2(50);
var p_ApellidoPaterno VARCHAR2(50);
var p_ApellidoMaterno VARCHAR2(50);

EXECUTE getallpersona(p_IdPersona,p_Nombre,p_ApellidoPaterno,p_ApellidoMaterno);