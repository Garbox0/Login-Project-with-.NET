CREATE PROC editarUsuario
@IdUsuario INT,
@Usuario AS VARCHAR(MAX),
@Clave VARCHAR(MAX),
@Icono IMAGE,
@Estado VARCHAR(MAX)
AS 
IF EXISTS (SELECT Usuario FROM USUARIO WHERE Usuario = @Usuario AND IdUsuario<>@IdUsuario)
RAISERROR ('Usuario en uso, elige otro nombre de usuario', 16,1)
ELSE
UPDATE USUARIO SET Usuario=@Usuario , Clave=@Clave , Icono=@Icono , Estado=@Estado
WHERE IdUsuario=@IdUsuario