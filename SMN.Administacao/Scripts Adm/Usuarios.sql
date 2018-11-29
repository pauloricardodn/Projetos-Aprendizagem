CREATE TABLE Usuario (
    Codigo INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR (80),
    Login VARCHAR (80),
    Senha VARBINARY (MAX),
    Status SMALLINT
)


-- Cadastrar Usuario
CREATE PROCEDURE CadUsuario
	@Nome VARCHAR (80),
	@Login VARCHAR (80),
    @Senha VARCHAR (40),
    @Status SMALLINT
AS
BEGIN
	INSERT INTO Usuario 
	(
		Nome, 
		Login,
		Senha,
		Status
	)
	VALUES 
	(
		@Nome,
		@Login,
		PWDENCRYPT(@Senha),
		@Status
	)
END
--Alterar Usuario
CREATE PROCEDURE AltUsuario
	@Codigo INT,
	@Nome VARCHAR (80),
	@Login VARCHAR (80),
    @Senha VARBINARY (MAX),
    @Status SMALLINT
AS
BEGIN
	UPDATE Usuario
		SET Nome=@Nome, 
		    Login=@Login,
		    Senha=PWDENCRYPT(@Senha),
		    Status=@Status
	WHERE 
		Codigo=@Codigo

END


--Consulta Login

CREATE PROCEDURE AutUsuario
	@Login VARCHAR (80),
	@Senha VARBINARY (MAX)
AS
BEGIN
	SELECT Codigo, Nome
	FROM Usuario
	WHERE Login = @Login
	AND PWDCOMPARE(@Senha, Senha) = 1
	AND Status = 1
END
--Listar Usuarios


INSERT INTO Usuario 
	(
		Nome, 
		Login,
		Senha,
		Status
	)
	VALUES 
	(
		'Paulo Ricardo',
		'pauloricardodn',
		PWDENCRYPT('paulo21'),
		1
	)
	select Nome,Login,PWDENCRYPT(Senha)  from Usuario

	SELECT Codigo, Nome
	FROM Usuario
	WHERE Login = 'pauloricardodn'
	AND PWDCOMPARE('paulo21', Senha) = 1
	AND Status = 1