DROP PROCEDURE RealizarVenda

CREATE PROCEDURE RealizarVenda
	@IdCliente int,
	@DataVenda  datetime 


AS
BEGIN
	INSERT INTO Venda
	( 
		IdCliente,
		DataVenda
	)values
	(
		@IdCliente,
		@DataVenda	
	)
	RETURN SCOPE_IDENTITY()		
END


CREATE PROCEDURE EditarItenVenda
	@idVendaItem int,
	@ItemQtd int

AS
BEGIN
	UPDATE VendaItem
		SET ItemQtd= @ItemQtd
		WHERE IdItemVenda=@idVendaItem		
	
END
CREATE PROCEDURE DeletarItenVenda
	@idVendaItem int
AS
BEGIN
	DELETE FROM VendaItem		
		WHERE IdItemVenda=@idVendaItem		
	
END

CREATE PROCEDURE ListarVenda
AS
BEGIN
	SELECT  v.IdVenda,
			cli.IdCliente,
			cli.Nome,
			v.DataVenda,
			sum(vi.ItemQtd*vi.ValorUnitario) as valor
		FROM Venda v WITH(NOLOCK)
			INNER JOIN Cliente cli WITH(NOLOCK)
				ON v.IdCliente=cli.IdCliente
			INNER JOIN VendaItem vi WITH(NOLOCK)
				ON v.IdVenda=vi.IdVenda
			GROUP BY CLI.IdCliente,cli.Nome,VI.IdVenda,v.DataVenda, v.IdVenda, v.IdCliente
			
			
END

CREATE PROCEDURE BuscarVenda
	@Id int
AS
BEGIN
	SELECT  v.IdVenda,
			cli.IdCliente,
			cli.Nome,
			v.DataVenda,
			sum(vi.ItemQtd*vi.ValorUnitario) as valor
		FROM Venda v WITH(NOLOCK)
			INNER JOIN Cliente cli WITH(NOLOCK)
				ON v.IdCliente=cli.IdCliente
			INNER JOIN VendaItem vi WITH(NOLOCK)
				ON v.IdVenda=vi.IdVenda
			WHERE v.IdVenda= @Id
			GROUP BY CLI.IdCliente,cli.Nome,VI.IdVenda,v.DataVenda, v.IdVenda, v.IdCliente
			
			
END




SELECT  	vi.IdVenda,
			vi.IdProduto,		
			p.Produto,
			vi.ItemQtd,
			vi.ValorUnitario,
			(vi.ItemQtd*vi.ValorUnitario)AS ValorTotalItem
		FROM Venda v WITH(NOLOCK)
			INNER JOIN Cliente cli WITH(NOLOCK)
				ON v.IdCliente=cli.IdCliente
			INNER JOIN VendaItem vi WITH(NOLOCK)
				ON v.IdVenda=vi.IdVenda
			INNER JOIN Produto p WITH(NOLOCK)
				ON p.IdProduto=vi.IdProduto
		WHERE VI.IdVenda=35
