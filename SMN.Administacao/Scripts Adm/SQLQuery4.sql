USE [Administracao]
GO
/****** Object:  StoredProcedure [dbo].[InserirProduto]    Script Date: 07/11/2017 17:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InserirProduto]
	@Produto varchar(50),
	@QtdEstoque decimal ,
	@ValCompra decimal,
	@ValVenda decimal
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