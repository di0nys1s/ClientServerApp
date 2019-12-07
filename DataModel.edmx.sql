
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/03/2019 16:23:21
-- Generated from EDMX file: C:\Users\ozlem\source\repos\ClientServerApp\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [ServiceId] int  NOT NULL
);
GO

-- Creating table 'Spends'
CREATE TABLE [dbo].[Spends] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalSpend] nvarchar(max)  NOT NULL,
    [CallSpend] nvarchar(max)  NOT NULL,
    [MessageSpend] nvarchar(max)  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceName] nvarchar(max)  NOT NULL,
    [ServiceDescription] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Spends'
ALTER TABLE [dbo].[Spends]
ADD CONSTRAINT [PK_Spends]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ServiceId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ServiceClient]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceClient'
CREATE INDEX [IX_FK_ServiceClient]
ON [dbo].[Clients]
    ([ServiceId]);
GO

-- Creating foreign key on [ClientId] in table 'Spends'
ALTER TABLE [dbo].[Spends]
ADD CONSTRAINT [FK_ClientSpend]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSpend'
CREATE INDEX [IX_FK_ClientSpend]
ON [dbo].[Spends]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------