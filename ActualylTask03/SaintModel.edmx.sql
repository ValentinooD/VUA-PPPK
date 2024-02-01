
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2024 16:32:45
-- Generated from EDMX file: D:\VUA\PPPK\ActualylTask03\SaintModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [task003];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SaintImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_SaintImage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Saints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Saints];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Saints'
CREATE TABLE [dbo].[Saints] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [WhenHeBecame] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [SaintId] int  NOT NULL,
    [ContentType] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Saints'
ALTER TABLE [dbo].[Saints]
ADD CONSTRAINT [PK_Saints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SaintId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_SaintImage]
    FOREIGN KEY ([SaintId])
    REFERENCES [dbo].[Saints]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SaintImage'
CREATE INDEX [IX_FK_SaintImage]
ON [dbo].[Images]
    ([SaintId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------