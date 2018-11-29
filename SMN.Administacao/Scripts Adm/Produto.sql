USE [Administracao]


CREATE TABLE Produto(
	IdProduto int IDENTITY(1,1) NOT NULL,
	Produto varchar(50) NOT NULL,
	QtdEstoque decimal NOT NULL,
	ValCompra float NOT NULL,
	ValVenda float NOT NULL
) 

CREATE PROCEDURE InserirProduto
	@Produto varchar(50),
	@QtdEstoque decimal ,
	@ValCompra float,
	@ValVenda float
AS
BEGIN
	INSERT INTO Produto
	(
		Produto,
		QtdEstoque,
		ValCompra,
		ValVenda
	)VALUES
	(
		@Produto,
		@QtdEstoque,
		@ValCompra,
		@ValVenda	
	)
END


CREATE PROCEDURE AlterarProduto
	@IdProduto int,
	@Produto varchar(50),
	@QtdEstoque decimal,
	@ValCompra float,
	@ValVenda float
AS
BEGIN
	UPDATE Produto
		SET	Produto=@Produto,
		QtdEstoque=@QtdEstoque,
		ValCompra=@ValCompra,
		ValVenda=@ValVenda	
		WHERE IdProduto=@IdProduto
END


--
CREATE PROCEDURE SelecionarProduto
AS
BEGIN
	SELECT *
		FROM Produto
END

CREATE PROCEDURE BuscarProduto
	@IdProduto int
AS
BEGIN
	SELECT *
		FROM Produto
		WHERE IdProduto=@IdProduto
END


CREATE PROCEDURE ExcluirProduto
	@IdProduto int
AS
BEGIN
	DELETE
		FROM Produto
		WHERE IdProduto=@IdProduto
END







