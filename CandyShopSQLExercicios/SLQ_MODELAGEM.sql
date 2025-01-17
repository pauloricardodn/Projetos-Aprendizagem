CREATE DATABASE CANDYSHOP

USE CANDYSHOP;

CREATE TABLE CLIENTE(
	CLI_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CLI_NOME VARCHAR(40) NOT NULL,
	CLI_SEXO VARCHAR(10) NOT NULL,
	CLI_DATA_NASC DATE NOT NULL,
	CLI_ATIVO BIT DEFAULT 1
);

CREATE TABLE Cliente(
	IdCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(40) NOT NULL,
	Sexo VARCHAR(10) NOT NULL,
	DataNascimento DATE NOT NULL,
	Ativo BIT DEFAULT 1
);

CREATE TABLE TIPO_PRODUTO(
	TPRO_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TPRO_NOME_TIPO_PROD VARCHAR(30)NOT NULL
)

CREATE TABLE TipoProduto(
	IdTipoProduto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(30)NOT NULL
)


CREATE TABLE MARCA_PRODUTO(
	MARCA_PROD_ID INT IDENTITY(1,1) PRIMARY KEY,
	MARCA_PROD_NOME VARCHAR(40) NOT NULL
)

CREATE TABLE MarcaProduto(
	IdMarcaProduto INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(40) NOT NULL
)

CREATE TABLE PRODUTO(
	PROD_ID INT IDENTITY(1,1) PRIMARY KEY,
	TPRO_ID INT NOT NULL,
	MARCA_PROD_ID INT NOT NULL,
	PROD_NOME VARCHAR(60) NOT NULL,
	PROD_VAL_COMPRA MONEY NOT NULL,
	PROD_VAL_VENDA MONEY NOT NULL,
	PROD_QTD_ESTOQUE INT NOT NULL
	CONSTRAINT FK_TIPO_PROD_ID FOREIGN KEY (TPRO_ID) REFERENCES TIPO_PRODUTO(TPRO_ID),
	CONSTRAINT FK_MARCA_PROD_ID FOREIGN KEY (MARCA_PROD_ID) REFERENCES MARCA_PRODUTO(MARCA_PROD_ID) 
)

CREATE TABLE Produto(
	IdProduto INT IDENTITY(1,1) PRIMARY KEY,
	IdTipoProduto INT NOT NULL,
	IdMarcaProduto INT NOT NULL,
	Nome VARCHAR(60) NOT NULL,
	ValorCompra MONEY NOT NULL,
	ValorVenda MONEY NOT NULL,
	QuantidadeEstoque DECIMAL(10, 4) NOT NULL
	CONSTRAINT FK_IdTipoProduto FOREIGN KEY (IdTipoProduto) REFERENCES TIPO_PRODUTO(TPRO_ID),
	CONSTRAINT FK_MARCA_PROD_ID FOREIGN KEY (MARCA_PROD_ID) REFERENCES MARCA_PRODUTO(MARCA_PROD_ID) 
)

CREATE TABLE VENDA(
	VEN_ID INT IDENTITY(1,1) PRIMARY KEY,
	CLI_ID INT NOT NULL,
	VEN_DATA_VENDA DATE NOT NULL,
	VEN_DATA_PAGAMENTO DATE NULL,
	CONSTRAINT FK_CLIENTE_ID FOREIGN KEY (CLI_ID) REFERENCES CLIENTE(CLI_ID)
)
CREATE TABLE VENDA_ITEM(
	VEN_ITEM_ID INT IDENTITY(1,1) PRIMARY KEY,
	VEN_ID INT NOT NULL,
	PROD_ID INT NOT NULL,
	VEN_ITEM_QTD INT NOT NULL,
	CONSTRAINT FK_VENDA_ID FOREIGN KEY (VEN_ID) REFERENCES VENDA(VEN_ID),
	CONSTRAINT FK_PRODUTO_ID FOREIGN KEY (PROD_ID) REFERENCES PRODUTO(PROD_ID)
)