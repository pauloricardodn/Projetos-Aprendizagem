CREATE TABLE Cliente(
	IdCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Endereco VARCHAR(120) NOT NULL,
	Celular vARCHAR (14) NOT NULL,
	Sexo VARCHAR (10) NOT NULL,
	Cpf CHAR(14) NOT NULL,
	DataNasc DATE NOT NULL,
	DataCad DATE NOT NULL	
);

Alter table Cliente
	alter Celular vARCHAR (14)
	      
--CRIADA
CREATE PROCEDURE CadCliente
	@Nome VARCHAR(50),
	@Endereco VARCHAR(80),
	@Celular vARCHAR (11),
	@Sexo VARCHAR(10),
	@Cpf CHAR(11),
	@Datanasc DATE,
	@DataCad DATE
AS
BEGIN
	INSERT INTO Cliente
	(
		Nome,
		Endereco,
		Celular,
		Sexo,
		Cpf,
		DataNasc,
		DataCad		
	)VALUES
	(
		@Nome,
		@Endereco,
		@Celular,
		@Sexo,
		@Cpf,
		@Datanasc,
		@DataCad
	)
END
--CRIADA
CREATE PROCEDURE AltCliente
	@IdCliente int,
	@Nome VARCHAR(50),
	@Endereco VARCHAR(80),
	@Celular vARCHAR (11),
	@Sexo VARCHAR(10),
	@Cpf CHAR(11),
	@Datanasc DATE,
	@DataCad DATE
AS
BEGIN
	UPDATE Cliente
		SET Nome=@Nome,
		Endereco=@Endereco,
		Celular=@Celular,
		Sexo=@Sexo,
		Cpf=@Cpf,
		DataNasc=@Datanasc,
		DataCad=@DataCad
		WHERE IdCliente=@IdCliente
END
--CRIADA
CREATE PROCEDURE ListarCliente
AS
BEGIN
	SELECT *
		FROM Cliente

END;

CREATE PROCEDURE ListarClientePorID
	@Id int
AS
BEGIN
	SELECT *
		FROM Cliente
		WHERE IdCliente=@Id

END;

CREATE PROCEDURE DeletarCliente
	@Id int
AS
BEGIN
	DELETE
		FROM Cliente
	Where IdCliente=@Id

END;