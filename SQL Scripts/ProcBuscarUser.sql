CREATE PROC buscarUsuario
@Buscador VARCHAR(50)
AS
SELECT * FROM USUARIO
WHERE Usuario + Clave LIKE '%' + @Buscador + '%'