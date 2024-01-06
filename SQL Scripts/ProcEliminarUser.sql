CREATE PROC eliminarUsuario
@IdUsuario INT
AS
DELETE FROM USUARIO WHERE IdUsuario=@IdUsuario