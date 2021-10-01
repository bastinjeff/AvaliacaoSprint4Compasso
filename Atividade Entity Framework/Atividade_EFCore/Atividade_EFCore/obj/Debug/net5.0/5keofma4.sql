IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cidades] (
    [Id] guid NOT NULL,
    [Nome] varchar(max) NOT NULL,
    [Populacao] int NOT NULL,
    [TaxaCriminalidade] float NOT NULL,
    [ImpostoSobreProduto] float NOT NULL,
    [EstadoCalamidade] bit NOT NULL,
    CONSTRAINT [PK_Cidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [funcionarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [CidadeId] guid NULL,
    CONSTRAINT [PK_funcionarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_funcionarios_Cidades_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [Cidades] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_funcionarios_CidadeId] ON [funcionarios] ([CidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211001141538_Inicial', N'5.0.10');
GO

COMMIT;
GO

