CREATE PROC InsertarUsuarios
@Usuario AS VARCHAR(MAX),
@Clave AS VARCHAR(MAX),
@Icono AS VARBINARY(MAX),
@Estado AS VARCHAR(MAX)
AS
IF EXISTS (SELECT Usuario FROM USUARIO WHERE Usuario=@Usuario)
RAISERROR('Usuario ya registrado',16,1)
ELSE
INSERT INTO USUARIO
VALUES (@Usuario,@Clave,@Icono,@Estado)