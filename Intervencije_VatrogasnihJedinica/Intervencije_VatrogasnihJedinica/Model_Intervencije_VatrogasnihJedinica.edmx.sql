
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2020 23:29:01
-- Generated from EDMX file: C:\Users\HP 650 G2\Documents\GitHub\BazeProjekat\Intervencije_VatrogasnihJedinica\Intervencije_VatrogasnihJedinica\Model_Intervencije_VatrogasnihJedinica.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BazeProjekat];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OpstinaVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vatrogasne_Jedinice] DROP CONSTRAINT [FK_OpstinaVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_RadnikVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila] DROP CONSTRAINT [FK_VoziloVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_OpstinaIntervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije] DROP CONSTRAINT [FK_OpstinaIntervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Uvidjaj_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_Uvidjaj_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_UvidjajInspektor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_UvidjajInspektor];
GO
IF OBJECT_ID(N'[dbo].[FK_UvidjajZapisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zapisnici] DROP CONSTRAINT [FK_UvidjajZapisnik];
GO
IF OBJECT_ID(N'[dbo].[FK_SmenaRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_SmenaRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Intervencija_Smena_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencija_Smena] DROP CONSTRAINT [FK_Intervencija_Smena_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Intervencija_Smena_Smena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencija_Smena] DROP CONSTRAINT [FK_Intervencija_Smena_Smena];
GO
IF OBJECT_ID(N'[dbo].[FK_AlatVozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alati] DROP CONSTRAINT [FK_AlatVozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_PozarNavalno_Vozilo_Pozar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozarNavalno_Vozilo] DROP CONSTRAINT [FK_PozarNavalno_Vozilo_Pozar];
GO
IF OBJECT_ID(N'[dbo].[FK_PozarNavalno_Vozilo_Navalno_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozarNavalno_Vozilo] DROP CONSTRAINT [FK_PozarNavalno_Vozilo_Navalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_SmenaVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Smene] DROP CONSTRAINT [FK_SmenaVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_Intervencija_inherits_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija] DROP CONSTRAINT [FK_Tehnicka_Intervencija_inherits_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicko_Vozilo_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicko_Vozilo_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Pozar_inherits_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije_Pozar] DROP CONSTRAINT [FK_Pozar_inherits_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Navalno_Vozilo_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Navalno_Vozilo] DROP CONSTRAINT [FK_Navalno_Vozilo_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Cisterna_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Cisterna] DROP CONSTRAINT [FK_Cisterna_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vozac_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici_Vozac] DROP CONSTRAINT [FK_Vozac_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Vatrogasac_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici_Vatrogasac] DROP CONSTRAINT [FK_Vatrogasac_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Komandir_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici_Komandir] DROP CONSTRAINT [FK_Komandir_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Opstine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opstine];
GO
IF OBJECT_ID(N'[dbo].[Vatrogasne_Jedinice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vatrogasne_Jedinice];
GO
IF OBJECT_ID(N'[dbo].[Radnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici];
GO
IF OBJECT_ID(N'[dbo].[Vozila]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila];
GO
IF OBJECT_ID(N'[dbo].[Intervencije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije];
GO
IF OBJECT_ID(N'[dbo].[Uvidjaji]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uvidjaji];
GO
IF OBJECT_ID(N'[dbo].[Zapisnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zapisnici];
GO
IF OBJECT_ID(N'[dbo].[Inspektori]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inspektori];
GO
IF OBJECT_ID(N'[dbo].[Alati]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alati];
GO
IF OBJECT_ID(N'[dbo].[Smene]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Smene];
GO
IF OBJECT_ID(N'[dbo].[Intervencije_Tehnicka_Intervencija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije_Tehnicka_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Tehnicko_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Tehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[Intervencije_Pozar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije_Pozar];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Navalno_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Navalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Cisterna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Cisterna];
GO
IF OBJECT_ID(N'[dbo].[Radnici_Vozac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici_Vozac];
GO
IF OBJECT_ID(N'[dbo].[Radnici_Vatrogasac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici_Vatrogasac];
GO
IF OBJECT_ID(N'[dbo].[Radnici_Komandir]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici_Komandir];
GO
IF OBJECT_ID(N'[dbo].[Intervencija_Smena]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencija_Smena];
GO
IF OBJECT_ID(N'[dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[PozarNavalno_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PozarNavalno_Vozilo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Opstine'
CREATE TABLE [dbo].[Opstine] (
    [Id_Opstine] int IDENTITY(1,1) NOT NULL,
    [Naziv_Opstine] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vatrogasne_Jedinice'
CREATE TABLE [dbo].[Vatrogasne_Jedinice] (
    [Id_VSJ] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Id_Opstine] int  NOT NULL
);
GO

-- Creating table 'Radnici'
CREATE TABLE [dbo].[Radnici] (
    [JMBG] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Radno_Mesto] nvarchar(max)  NOT NULL,
    [Godina_Staza] nvarchar(max)  NOT NULL,
    [VatrogasnaJedinicaId_VSJ] int  NOT NULL,
    [SmenaSmenaId] int  NOT NULL
);
GO

-- Creating table 'Vozila'
CREATE TABLE [dbo].[Vozila] (
    [Id_Vozila] int IDENTITY(1,1) NOT NULL,
    [Marka] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Tip] int  NOT NULL,
    [Godiste] int  NOT NULL,
    [Nosivost] float  NOT NULL,
    [Id_VatrogasneJedinice] int  NULL
);
GO

-- Creating table 'Intervencije'
CREATE TABLE [dbo].[Intervencije] (
    [Id_Intervencije] int IDENTITY(1,1) NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Datum_I_Vreme] datetime  NOT NULL,
    [Id_Opstine] int  NULL
);
GO

-- Creating table 'Uvidjaji'
CREATE TABLE [dbo].[Uvidjaji] (
    [UvidjajId] int IDENTITY(1,1) NOT NULL,
    [Datum] datetime  NOT NULL,
    [IdInspektora] int  NOT NULL,
    [Intervencija_Id_Intervencije] int  NOT NULL
);
GO

-- Creating table 'Zapisnici'
CREATE TABLE [dbo].[Zapisnici] (
    [ZapisnikId] int IDENTITY(1,1) NOT NULL,
    [Tekst_Zapisnika] nvarchar(max)  NULL,
    [Uvidjaj_UvidjajId] int  NOT NULL
);
GO

-- Creating table 'Inspektori'
CREATE TABLE [dbo].[Inspektori] (
    [InspektorId] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Broj_Telefona] int  NULL
);
GO

-- Creating table 'Alati'
CREATE TABLE [dbo].[Alati] (
    [AlatId] int IDENTITY(1,1) NOT NULL,
    [Naziv_Alata] nvarchar(max)  NOT NULL,
    [Id_Vozila] int  NULL
);
GO

-- Creating table 'Smene'
CREATE TABLE [dbo].[Smene] (
    [SmenaId] int IDENTITY(1,1) NOT NULL,
    [Broj_Radnika] int  NOT NULL,
    [Broj_Smene] nvarchar(max)  NOT NULL,
    [VatrogasnaJedinica_Id_VSJ] int  NOT NULL
);
GO

-- Creating table 'Intervencije_Tehnicka_Intervencija'
CREATE TABLE [dbo].[Intervencije_Tehnicka_Intervencija] (
    [Id_Intervencije] int  NOT NULL
);
GO

-- Creating table 'Vozila_Tehnicko_Vozilo'
CREATE TABLE [dbo].[Vozila_Tehnicko_Vozilo] (
    [Id_Vozila] int  NOT NULL
);
GO

-- Creating table 'Intervencije_Pozar'
CREATE TABLE [dbo].[Intervencije_Pozar] (
    [Id_Intervencije] int  NOT NULL
);
GO

-- Creating table 'Vozila_Navalno_Vozilo'
CREATE TABLE [dbo].[Vozila_Navalno_Vozilo] (
    [Id_Vozila] int  NOT NULL
);
GO

-- Creating table 'Vozila_Cisterna'
CREATE TABLE [dbo].[Vozila_Cisterna] (
    [Id_Vozila] int  NOT NULL
);
GO

-- Creating table 'Radnici_Vozac'
CREATE TABLE [dbo].[Radnici_Vozac] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radnici_Vatrogasac'
CREATE TABLE [dbo].[Radnici_Vatrogasac] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radnici_Komandir'
CREATE TABLE [dbo].[Radnici_Komandir] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Intervencija_Smena'
CREATE TABLE [dbo].[Intervencija_Smena] (
    [Intervencije_Id_Intervencije] int  NOT NULL,
    [Vatrogasne_Smene_SmenaId] int  NOT NULL
);
GO

-- Creating table 'Tehnicka_IntervencijaTehnicko_Vozilo'
CREATE TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] (
    [Tehnicka_Intervencija_Id_Intervencije] int  NOT NULL,
    [Tehnicko_Vozilo_Id_Vozila] int  NOT NULL
);
GO

-- Creating table 'PozarNavalno_Vozilo'
CREATE TABLE [dbo].[PozarNavalno_Vozilo] (
    [Pozars_Id_Intervencije] int  NOT NULL,
    [Navalno_Vozilo_Id_Vozila] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_Opstine] in table 'Opstine'
ALTER TABLE [dbo].[Opstine]
ADD CONSTRAINT [PK_Opstine]
    PRIMARY KEY CLUSTERED ([Id_Opstine] ASC);
GO

-- Creating primary key on [Id_VSJ] in table 'Vatrogasne_Jedinice'
ALTER TABLE [dbo].[Vatrogasne_Jedinice]
ADD CONSTRAINT [PK_Vatrogasne_Jedinice]
    PRIMARY KEY CLUSTERED ([Id_VSJ] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [PK_Radnici]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Id_Vozila] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [PK_Vozila]
    PRIMARY KEY CLUSTERED ([Id_Vozila] ASC);
GO

-- Creating primary key on [Id_Intervencije] in table 'Intervencije'
ALTER TABLE [dbo].[Intervencije]
ADD CONSTRAINT [PK_Intervencije]
    PRIMARY KEY CLUSTERED ([Id_Intervencije] ASC);
GO

-- Creating primary key on [UvidjajId] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [PK_Uvidjaji]
    PRIMARY KEY CLUSTERED ([UvidjajId] ASC);
GO

-- Creating primary key on [ZapisnikId] in table 'Zapisnici'
ALTER TABLE [dbo].[Zapisnici]
ADD CONSTRAINT [PK_Zapisnici]
    PRIMARY KEY CLUSTERED ([ZapisnikId] ASC);
GO

-- Creating primary key on [InspektorId] in table 'Inspektori'
ALTER TABLE [dbo].[Inspektori]
ADD CONSTRAINT [PK_Inspektori]
    PRIMARY KEY CLUSTERED ([InspektorId] ASC);
GO

-- Creating primary key on [AlatId] in table 'Alati'
ALTER TABLE [dbo].[Alati]
ADD CONSTRAINT [PK_Alati]
    PRIMARY KEY CLUSTERED ([AlatId] ASC);
GO

-- Creating primary key on [SmenaId] in table 'Smene'
ALTER TABLE [dbo].[Smene]
ADD CONSTRAINT [PK_Smene]
    PRIMARY KEY CLUSTERED ([SmenaId] ASC);
GO

-- Creating primary key on [Id_Intervencije] in table 'Intervencije_Tehnicka_Intervencija'
ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija]
ADD CONSTRAINT [PK_Intervencije_Tehnicka_Intervencija]
    PRIMARY KEY CLUSTERED ([Id_Intervencije] ASC);
GO

-- Creating primary key on [Id_Vozila] in table 'Vozila_Tehnicko_Vozilo'
ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo]
ADD CONSTRAINT [PK_Vozila_Tehnicko_Vozilo]
    PRIMARY KEY CLUSTERED ([Id_Vozila] ASC);
GO

-- Creating primary key on [Id_Intervencije] in table 'Intervencije_Pozar'
ALTER TABLE [dbo].[Intervencije_Pozar]
ADD CONSTRAINT [PK_Intervencije_Pozar]
    PRIMARY KEY CLUSTERED ([Id_Intervencije] ASC);
GO

-- Creating primary key on [Id_Vozila] in table 'Vozila_Navalno_Vozilo'
ALTER TABLE [dbo].[Vozila_Navalno_Vozilo]
ADD CONSTRAINT [PK_Vozila_Navalno_Vozilo]
    PRIMARY KEY CLUSTERED ([Id_Vozila] ASC);
GO

-- Creating primary key on [Id_Vozila] in table 'Vozila_Cisterna'
ALTER TABLE [dbo].[Vozila_Cisterna]
ADD CONSTRAINT [PK_Vozila_Cisterna]
    PRIMARY KEY CLUSTERED ([Id_Vozila] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radnici_Vozac'
ALTER TABLE [dbo].[Radnici_Vozac]
ADD CONSTRAINT [PK_Radnici_Vozac]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radnici_Vatrogasac'
ALTER TABLE [dbo].[Radnici_Vatrogasac]
ADD CONSTRAINT [PK_Radnici_Vatrogasac]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radnici_Komandir'
ALTER TABLE [dbo].[Radnici_Komandir]
ADD CONSTRAINT [PK_Radnici_Komandir]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Intervencije_Id_Intervencije], [Vatrogasne_Smene_SmenaId] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [PK_Intervencija_Smena]
    PRIMARY KEY CLUSTERED ([Intervencije_Id_Intervencije], [Vatrogasne_Smene_SmenaId] ASC);
GO

-- Creating primary key on [Tehnicka_Intervencija_Id_Intervencije], [Tehnicko_Vozilo_Id_Vozila] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [PK_Tehnicka_IntervencijaTehnicko_Vozilo]
    PRIMARY KEY CLUSTERED ([Tehnicka_Intervencija_Id_Intervencije], [Tehnicko_Vozilo_Id_Vozila] ASC);
GO

-- Creating primary key on [Pozars_Id_Intervencije], [Navalno_Vozilo_Id_Vozila] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [PK_PozarNavalno_Vozilo]
    PRIMARY KEY CLUSTERED ([Pozars_Id_Intervencije], [Navalno_Vozilo_Id_Vozila] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_Opstine] in table 'Vatrogasne_Jedinice'
ALTER TABLE [dbo].[Vatrogasne_Jedinice]
ADD CONSTRAINT [FK_OpstinaVatrogasnaJedinica]
    FOREIGN KEY ([Id_Opstine])
    REFERENCES [dbo].[Opstine]
        ([Id_Opstine])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpstinaVatrogasnaJedinica'
CREATE INDEX [IX_FK_OpstinaVatrogasnaJedinica]
ON [dbo].[Vatrogasne_Jedinice]
    ([Id_Opstine]);
GO

-- Creating foreign key on [VatrogasnaJedinicaId_VSJ] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [FK_RadnikVatrogasnaJedinica]
    FOREIGN KEY ([VatrogasnaJedinicaId_VSJ])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([Id_VSJ])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadnikVatrogasnaJedinica'
CREATE INDEX [IX_FK_RadnikVatrogasnaJedinica]
ON [dbo].[Radnici]
    ([VatrogasnaJedinicaId_VSJ]);
GO

-- Creating foreign key on [Id_VatrogasneJedinice] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [FK_VoziloVatrogasnaJedinica]
    FOREIGN KEY ([Id_VatrogasneJedinice])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([Id_VSJ])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoziloVatrogasnaJedinica'
CREATE INDEX [IX_FK_VoziloVatrogasnaJedinica]
ON [dbo].[Vozila]
    ([Id_VatrogasneJedinice]);
GO

-- Creating foreign key on [Id_Opstine] in table 'Intervencije'
ALTER TABLE [dbo].[Intervencije]
ADD CONSTRAINT [FK_OpstinaIntervencija]
    FOREIGN KEY ([Id_Opstine])
    REFERENCES [dbo].[Opstine]
        ([Id_Opstine])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpstinaIntervencija'
CREATE INDEX [IX_FK_OpstinaIntervencija]
ON [dbo].[Intervencije]
    ([Id_Opstine]);
GO

-- Creating foreign key on [Intervencija_Id_Intervencije] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [FK_Uvidjaj_Intervencija]
    FOREIGN KEY ([Intervencija_Id_Intervencije])
    REFERENCES [dbo].[Intervencije]
        ([Id_Intervencije])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Uvidjaj_Intervencija'
CREATE INDEX [IX_FK_Uvidjaj_Intervencija]
ON [dbo].[Uvidjaji]
    ([Intervencija_Id_Intervencije]);
GO

-- Creating foreign key on [IdInspektora] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [FK_UvidjajInspektor]
    FOREIGN KEY ([IdInspektora])
    REFERENCES [dbo].[Inspektori]
        ([InspektorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UvidjajInspektor'
CREATE INDEX [IX_FK_UvidjajInspektor]
ON [dbo].[Uvidjaji]
    ([IdInspektora]);
GO

-- Creating foreign key on [Uvidjaj_UvidjajId] in table 'Zapisnici'
ALTER TABLE [dbo].[Zapisnici]
ADD CONSTRAINT [FK_UvidjajZapisnik]
    FOREIGN KEY ([Uvidjaj_UvidjajId])
    REFERENCES [dbo].[Uvidjaji]
        ([UvidjajId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UvidjajZapisnik'
CREATE INDEX [IX_FK_UvidjajZapisnik]
ON [dbo].[Zapisnici]
    ([Uvidjaj_UvidjajId]);
GO

-- Creating foreign key on [SmenaSmenaId] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [FK_SmenaRadnik]
    FOREIGN KEY ([SmenaSmenaId])
    REFERENCES [dbo].[Smene]
        ([SmenaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmenaRadnik'
CREATE INDEX [IX_FK_SmenaRadnik]
ON [dbo].[Radnici]
    ([SmenaSmenaId]);
GO

-- Creating foreign key on [Intervencije_Id_Intervencije] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [FK_Intervencija_Smena_Intervencija]
    FOREIGN KEY ([Intervencije_Id_Intervencije])
    REFERENCES [dbo].[Intervencije]
        ([Id_Intervencije])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Vatrogasne_Smene_SmenaId] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [FK_Intervencija_Smena_Smena]
    FOREIGN KEY ([Vatrogasne_Smene_SmenaId])
    REFERENCES [dbo].[Smene]
        ([SmenaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Intervencija_Smena_Smena'
CREATE INDEX [IX_FK_Intervencija_Smena_Smena]
ON [dbo].[Intervencija_Smena]
    ([Vatrogasne_Smene_SmenaId]);
GO

-- Creating foreign key on [Id_Vozila] in table 'Alati'
ALTER TABLE [dbo].[Alati]
ADD CONSTRAINT [FK_AlatVozilo]
    FOREIGN KEY ([Id_Vozila])
    REFERENCES [dbo].[Vozila]
        ([Id_Vozila])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlatVozilo'
CREATE INDEX [IX_FK_AlatVozilo]
ON [dbo].[Alati]
    ([Id_Vozila]);
GO

-- Creating foreign key on [Tehnicka_Intervencija_Id_Intervencije] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija]
    FOREIGN KEY ([Tehnicka_Intervencija_Id_Intervencije])
    REFERENCES [dbo].[Intervencije_Tehnicka_Intervencija]
        ([Id_Intervencije])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tehnicko_Vozilo_Id_Vozila] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]
    FOREIGN KEY ([Tehnicko_Vozilo_Id_Vozila])
    REFERENCES [dbo].[Vozila_Tehnicko_Vozilo]
        ([Id_Vozila])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo'
CREATE INDEX [IX_FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]
ON [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
    ([Tehnicko_Vozilo_Id_Vozila]);
GO

-- Creating foreign key on [Pozars_Id_Intervencije] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [FK_PozarNavalno_Vozilo_Pozar]
    FOREIGN KEY ([Pozars_Id_Intervencije])
    REFERENCES [dbo].[Intervencije_Pozar]
        ([Id_Intervencije])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Navalno_Vozilo_Id_Vozila] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [FK_PozarNavalno_Vozilo_Navalno_Vozilo]
    FOREIGN KEY ([Navalno_Vozilo_Id_Vozila])
    REFERENCES [dbo].[Vozila_Navalno_Vozilo]
        ([Id_Vozila])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PozarNavalno_Vozilo_Navalno_Vozilo'
CREATE INDEX [IX_FK_PozarNavalno_Vozilo_Navalno_Vozilo]
ON [dbo].[PozarNavalno_Vozilo]
    ([Navalno_Vozilo_Id_Vozila]);
GO

-- Creating foreign key on [VatrogasnaJedinica_Id_VSJ] in table 'Smene'
ALTER TABLE [dbo].[Smene]
ADD CONSTRAINT [FK_SmenaVatrogasnaJedinica]
    FOREIGN KEY ([VatrogasnaJedinica_Id_VSJ])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([Id_VSJ])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmenaVatrogasnaJedinica'
CREATE INDEX [IX_FK_SmenaVatrogasnaJedinica]
ON [dbo].[Smene]
    ([VatrogasnaJedinica_Id_VSJ]);
GO

-- Creating foreign key on [Id_Intervencije] in table 'Intervencije_Tehnicka_Intervencija'
ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija]
ADD CONSTRAINT [FK_Tehnicka_Intervencija_inherits_Intervencija]
    FOREIGN KEY ([Id_Intervencije])
    REFERENCES [dbo].[Intervencije]
        ([Id_Intervencije])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_Vozila] in table 'Vozila_Tehnicko_Vozilo'
ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicko_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([Id_Vozila])
    REFERENCES [dbo].[Vozila]
        ([Id_Vozila])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_Intervencije] in table 'Intervencije_Pozar'
ALTER TABLE [dbo].[Intervencije_Pozar]
ADD CONSTRAINT [FK_Pozar_inherits_Intervencija]
    FOREIGN KEY ([Id_Intervencije])
    REFERENCES [dbo].[Intervencije]
        ([Id_Intervencije])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_Vozila] in table 'Vozila_Navalno_Vozilo'
ALTER TABLE [dbo].[Vozila_Navalno_Vozilo]
ADD CONSTRAINT [FK_Navalno_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([Id_Vozila])
    REFERENCES [dbo].[Vozila]
        ([Id_Vozila])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_Vozila] in table 'Vozila_Cisterna'
ALTER TABLE [dbo].[Vozila_Cisterna]
ADD CONSTRAINT [FK_Cisterna_inherits_Vozilo]
    FOREIGN KEY ([Id_Vozila])
    REFERENCES [dbo].[Vozila]
        ([Id_Vozila])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radnici_Vozac'
ALTER TABLE [dbo].[Radnici_Vozac]
ADD CONSTRAINT [FK_Vozac_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radnici]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radnici_Vatrogasac'
ALTER TABLE [dbo].[Radnici_Vatrogasac]
ADD CONSTRAINT [FK_Vatrogasac_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radnici]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radnici_Komandir'
ALTER TABLE [dbo].[Radnici_Komandir]
ADD CONSTRAINT [FK_Komandir_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radnici]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------