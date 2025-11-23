-- Initial create script for Prova domain (ProvaContext)
-- Creates database if not exists and all domain tables with constraints

IF DB_ID(N'ProvaAuth') IS NULL
BEGIN
    CREATE DATABASE [ProvaAuth];
END
GO

USE [ProvaAuth];
GO

-- Cliente
IF OBJECT_ID('dbo.Cliente', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Cliente (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        Nome VARCHAR(100) NOT NULL,
        Documento VARCHAR(20) NOT NULL,
        Email VARCHAR(100) NULL,
        Telefone VARCHAR(20) NULL,
        Ativo BIT NOT NULL,
        CONSTRAINT PK_Cliente PRIMARY KEY (Id)
    );
END
GO

-- Produto
IF OBJECT_ID('dbo.Produto', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Produto (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        Nome VARCHAR(100) NOT NULL,
        Descricao VARCHAR(255) NULL,
        Preco DECIMAL(18,2) NOT NULL,
        Estoque INT NOT NULL,
        Ativo BIT NOT NULL,
        CONSTRAINT PK_Produto PRIMARY KEY (Id)
    );
END
GO

-- Pedido
IF OBJECT_ID('dbo.Pedido', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Pedido (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        ClienteId UNIQUEIDENTIFIER NOT NULL,
        DataPedido DATETIME NOT NULL,
        Total DECIMAL(18,2) NOT NULL DEFAULT(0),
        CONSTRAINT PK_Pedido PRIMARY KEY (Id),
        CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (ClienteId) REFERENCES dbo.Cliente (Id) ON DELETE NO ACTION
    );
END
GO

-- ItemPedido
IF OBJECT_ID('dbo.ItemPedido', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ItemPedido (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        PedidoId UNIQUEIDENTIFIER NOT NULL,
        ProdutoId UNIQUEIDENTIFIER NOT NULL,
        Quantidade INT NOT NULL,
        Preco DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_ItemPedido PRIMARY KEY (Id),
        CONSTRAINT FK_ItemPedido_Pedido FOREIGN KEY (PedidoId) REFERENCES dbo.Pedido (Id) ON DELETE CASCADE,
        CONSTRAINT FK_ItemPedido_Produto FOREIGN KEY (ProdutoId) REFERENCES dbo.Produto (Id) ON DELETE NO ACTION
    );
END
GO

-- Trigger to maintain Pedido.Total as sum of its ItemPedido (Preco * Quantidade)
IF OBJECT_ID('dbo.trg_ItemPedido_UpdatePedidoTotal', 'TR') IS NULL
BEGIN
    EXEC('CREATE TRIGGER dbo.trg_ItemPedido_UpdatePedidoTotal
    ON dbo.ItemPedido
    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;

        ;WITH AffectedPedidos AS (
            SELECT DISTINCT PedidoId FROM inserted
            UNION
            SELECT DISTINCT PedidoId FROM deleted
        )

        UPDATE p
        SET Total = ISNULL((SELECT SUM(i.Preco * i.Quantidade) FROM dbo.ItemPedido i WHERE i.PedidoId = ap.PedidoId), 0)
        FROM dbo.Pedido p
        INNER JOIN AffectedPedidos ap ON p.Id = ap.PedidoId;
    END')
END
GO

-- Optional: add indexes on foreign keys for performance
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Pedido_ClienteId')
    CREATE INDEX IX_Pedido_ClienteId ON dbo.Pedido (ClienteId);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_ItemPedido_PedidoId')
    CREATE INDEX IX_ItemPedido_PedidoId ON dbo.ItemPedido (PedidoId);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_ItemPedido_ProdutoId')
    CREATE INDEX IX_ItemPedido_ProdutoId ON dbo.ItemPedido (ProdutoId);
