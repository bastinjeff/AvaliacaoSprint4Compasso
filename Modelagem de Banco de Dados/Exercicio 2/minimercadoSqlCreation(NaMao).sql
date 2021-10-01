CREATE DATABASE IF NOT EXISTS minimercado;

CREATE TABLE CategoriaDeProduto(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Categoria VARCHAR(100) NOT NULL
);

CREATE TABLE Vendedor(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Nome VARCHAR(200) NOT NULL,
    CPF CHAR(11) NOT NULL
);

CREATE TABLE PRODUTOS(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Nome VARCHAR(200) NOT NULL,
    ValorUnitario DOUBLE NOT NULL,
	CategoriaId INT NOT NULL,
    
    FOREIGN KEY (CategoriaId) REFERENCES CategoriaDeProduto(Id)
);

CREATE TABLE ESTOQUE(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Lote VARCHAR(45) NOT NULL,
    Quantidade INT NOT NULL,
    ProdutosId INT NOT NULL,
    
    FOREIGN KEY (ProdutosId) REFERENCES Produtos(Id)

);

CREATE TABLE VENDAS(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    DataVenda DATE NOT NULL,
    VendedorId INT NOT NULL,
    
    FOREIGN KEY (VendedorId) REFERENCES Vendedor(Id)
);

CREATE TABLE Vendas_Estoque(
	Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    VendaId INT NOT NULL,
    EstoqueId INT NOT NULL,
    QuantiaVendida INT NOT NULL,
    ValorUnitario DOUBLE NOT NULL,
    
    FOREIGN KEY (VendaId) REFERENCES Vendas(Id),
    FOREIGN KEY (EstoqueId) REFERENCES Estoque(Id)

);