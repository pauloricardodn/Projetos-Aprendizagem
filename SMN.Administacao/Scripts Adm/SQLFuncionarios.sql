CREATE TABLE Funcionarios(
	IdFuncionario INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Endereco VARCHAR(60) NOT NULL,
	Sexo VARCHAR(10) NOT NULL,
	DataNasc DATE NOT NULL
);
CREATE PROCEDURE CadastrarFunc
	@Nome VARCHAR(50),
	@Endereco VARCHAR(60),
	@Sexo VARCHAR(10),
	@DataNasc DATE 
AS
BEGIN
	INSERT INTO Funcionarios
	(
		Nome,
		Endereco,
		Sexo,
		DataNasc
	)VALUES
	(
		@Nome,
		@Endereco,
		@Sexo,
		@DataNasc

	)

END;

CREATE PROCEDURE listarFunc

AS
BEGIN
SELECT *
	FROM Funcionarios
END;

CREATE PROCEDURE AlterarFunc
	@Id int,
	@Nome VARCHAR(50),
	@Endereco VARCHAR(60),
	@Sexo VARCHAR(10),
	@DataNasc DATE 
AS
BEGIN
	UPDATE Funcionarios
		set Nome=@Nome,
		    Endereco=@Endereco,
		    Sexo=@Sexo,
		    DataNasc=@DataNasc
	WHERE IdFuncionario = @Id
	
END;


CREATE PROCEDURE ListarFuncPorId
	@Id int
AS
BEGIN
	SELECT *
	FROM Funcionarios
	WHERE IdFuncionario = @Id
END

CREATE PROCEDURE DeletarFunc
	@Id int
	
AS
BEGIN
	delete 
	from Funcionarios
		
	WHERE IdFuncionario = @Id
	
END