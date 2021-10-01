﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [dbo.Cidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(max) NOT NULL,
    [Populacao] int NOT NULL,
    [TaxaCriminalidade] float NOT NULL,
    [ImpostoSobreProduto] float NOT NULL,
    [EstadoCalamidade] bit NOT NULL,
    CONSTRAINT [PK_dbo.Cidades] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211001125252_Inicial', N'5.0.10');
GO

COMMIT;
GO

