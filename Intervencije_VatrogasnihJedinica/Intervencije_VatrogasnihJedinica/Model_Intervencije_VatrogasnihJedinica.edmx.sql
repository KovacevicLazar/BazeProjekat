
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/09/2021 10:31:10
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

IF OBJECT_ID(N'[dbo].[FK_AlatVozilo_Alat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlatVozilo] DROP CONSTRAINT [FK_AlatVozilo_Alat];
GO
IF OBJECT_ID(N'[dbo].[FK_AlatVozilo_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlatVozilo] DROP CONSTRAINT [FK_AlatVozilo_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Cisterna_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Cisterna] DROP CONSTRAINT [FK_Cisterna_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_InspektorUvidjaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_InspektorUvidjaj];
GO
IF OBJECT_ID(N'[dbo].[FK_Intervencija_Smena_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencija_Smena] DROP CONSTRAINT [FK_Intervencija_Smena_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Intervencija_Smena_Smena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencija_Smena] DROP CONSTRAINT [FK_Intervencija_Smena_Smena];
GO
IF OBJECT_ID(N'[dbo].[FK_IntervencijaUvidjaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_IntervencijaUvidjaj];
GO
IF OBJECT_ID(N'[dbo].[FK_KomandirVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Komandiri] DROP CONSTRAINT [FK_KomandirVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_Navalno_Vozilo_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Navalno_Vozilo] DROP CONSTRAINT [FK_Navalno_Vozilo_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_OpstinaIntervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije] DROP CONSTRAINT [FK_OpstinaIntervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_OpstinaVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vatrogasne_Jedinice] DROP CONSTRAINT [FK_OpstinaVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_Pozar_inherits_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije_Pozar] DROP CONSTRAINT [FK_Pozar_inherits_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_PozarNavalno_Vozilo_Navalno_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozarNavalno_Vozilo] DROP CONSTRAINT [FK_PozarNavalno_Vozilo_Navalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_PozarNavalno_Vozilo_Pozar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozarNavalno_Vozilo] DROP CONSTRAINT [FK_PozarNavalno_Vozilo_Pozar];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_RadnikVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_SmenaRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_SmenaRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_Intervencija_inherits_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija] DROP CONSTRAINT [FK_Tehnicka_Intervencija_inherits_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tehnicko_Vozilo_inherits_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo] DROP CONSTRAINT [FK_Tehnicko_Vozilo_inherits_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_VatrogasnaJedinicaSmena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Smene] DROP CONSTRAINT [FK_VatrogasnaJedinicaSmena];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila] DROP CONSTRAINT [FK_VoziloVatrogasnaJedinica];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alati]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alati];
GO
IF OBJECT_ID(N'[dbo].[AlatVozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlatVozilo];
GO
IF OBJECT_ID(N'[dbo].[Inspektori]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inspektori];
GO
IF OBJECT_ID(N'[dbo].[Intervencija_Smena]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencija_Smena];
GO
IF OBJECT_ID(N'[dbo].[Intervencije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije];
GO
IF OBJECT_ID(N'[dbo].[Intervencije_Pozar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije_Pozar];
GO
IF OBJECT_ID(N'[dbo].[Intervencije_Tehnicka_Intervencija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije_Tehnicka_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[Komandiri]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Komandiri];
GO
IF OBJECT_ID(N'[dbo].[Opstine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opstine];
GO
IF OBJECT_ID(N'[dbo].[PozarNavalno_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PozarNavalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[Radnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici];
GO
IF OBJECT_ID(N'[dbo].[Smene]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Smene];
GO
IF OBJECT_ID(N'[dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[Uvidjaji]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uvidjaji];
GO
IF OBJECT_ID(N'[dbo].[Vatrogasne_Jedinice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vatrogasne_Jedinice];
GO
IF OBJECT_ID(N'[dbo].[Vozila]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Cisterna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Cisterna];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Navalno_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Navalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[Vozila_Tehnicko_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila_Tehnicko_Vozilo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Opstine'
CREATE TABLE [dbo].[Opstine] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Naziv_Opstine] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vatrogasne_Jedinice'
CREATE TABLE [dbo].[Vatrogasne_Jedinice] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Id_Opstine] int  NOT NULL
);
GO

-- Creating table 'Vozila'
CREATE TABLE [dbo].[Vozila] (
    [ID] int IDENTITY(1,1) NOT NULL,
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
    [ID] int IDENTITY(1,1) NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Datum_I_Vreme] datetime  NOT NULL,
    [Id_Opstine] int  NULL,
    [Obrisana] bit  NOT NULL,
    [Tip] int  NOT NULL
);
GO

-- Creating table 'Inspektori'
CREATE TABLE [dbo].[Inspektori] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Broj_Telefona] nvarchar(max)  NULL
);
GO

-- Creating table 'Alati'
CREATE TABLE [dbo].[Alati] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Naziv_Alata] nvarchar(max)  NOT NULL,
    [Tip] int  NOT NULL
);
GO

-- Creating table 'Smene'
CREATE TABLE [dbo].[Smene] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Broj_Radnika] int  NOT NULL,
    [Broj_Smene] int  NOT NULL,
    [VatrogasnaJedinicaID] int  NOT NULL
);
GO

-- Creating table 'Radnici'
CREATE TABLE [dbo].[Radnici] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Radno_Mesto] int  NOT NULL,
    [Godine_Rada] int  NOT NULL,
    [VatrogasnaJedinicaID] int  NOT NULL,
    [SmenaID] int  NOT NULL
);
GO

-- Creating table 'Uvidjaji'
CREATE TABLE [dbo].[Uvidjaji] (
    [ID] int  NOT NULL,
    [Datum] datetime  NOT NULL,
    [Tekst_Zapisnika] nvarchar(max)  NOT NULL,
    [InspektorID] int  NOT NULL
);
GO

-- Creating table 'Komandiri'
CREATE TABLE [dbo].[Komandiri] (
    [ID] int  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Intervencije_Tehnicka_Intervencija'
CREATE TABLE [dbo].[Intervencije_Tehnicka_Intervencija] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Vozila_Tehnicko_Vozilo'
CREATE TABLE [dbo].[Vozila_Tehnicko_Vozilo] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Intervencije_Pozar'
CREATE TABLE [dbo].[Intervencije_Pozar] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Vozila_Navalno_Vozilo'
CREATE TABLE [dbo].[Vozila_Navalno_Vozilo] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Vozila_Cisterna'
CREATE TABLE [dbo].[Vozila_Cisterna] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'Intervencija_Smena'
CREATE TABLE [dbo].[Intervencija_Smena] (
    [Intervencije_ID] int  NOT NULL,
    [Smene_ID] int  NOT NULL
);
GO

-- Creating table 'Tehnicka_IntervencijaTehnicko_Vozilo'
CREATE TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo] (
    [Intervencije_ID] int  NOT NULL,
    [Vozila_ID] int  NOT NULL
);
GO

-- Creating table 'PozarNavalno_Vozilo'
CREATE TABLE [dbo].[PozarNavalno_Vozilo] (
    [Pozari_ID] int  NOT NULL,
    [Vozila_ID] int  NOT NULL
);
GO

-- Creating table 'AlatVozilo'
CREATE TABLE [dbo].[AlatVozilo] (
    [Alati_ID] int  NOT NULL,
    [Vozila_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Opstine'
ALTER TABLE [dbo].[Opstine]
ADD CONSTRAINT [PK_Opstine]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vatrogasne_Jedinice'
ALTER TABLE [dbo].[Vatrogasne_Jedinice]
ADD CONSTRAINT [PK_Vatrogasne_Jedinice]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [PK_Vozila]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Intervencije'
ALTER TABLE [dbo].[Intervencije]
ADD CONSTRAINT [PK_Intervencije]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Inspektori'
ALTER TABLE [dbo].[Inspektori]
ADD CONSTRAINT [PK_Inspektori]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Alati'
ALTER TABLE [dbo].[Alati]
ADD CONSTRAINT [PK_Alati]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Smene'
ALTER TABLE [dbo].[Smene]
ADD CONSTRAINT [PK_Smene]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [PK_Radnici]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [PK_Uvidjaji]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Komandiri'
ALTER TABLE [dbo].[Komandiri]
ADD CONSTRAINT [PK_Komandiri]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Intervencije_Tehnicka_Intervencija'
ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija]
ADD CONSTRAINT [PK_Intervencije_Tehnicka_Intervencija]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vozila_Tehnicko_Vozilo'
ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo]
ADD CONSTRAINT [PK_Vozila_Tehnicko_Vozilo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Intervencije_Pozar'
ALTER TABLE [dbo].[Intervencije_Pozar]
ADD CONSTRAINT [PK_Intervencije_Pozar]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vozila_Navalno_Vozilo'
ALTER TABLE [dbo].[Vozila_Navalno_Vozilo]
ADD CONSTRAINT [PK_Vozila_Navalno_Vozilo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vozila_Cisterna'
ALTER TABLE [dbo].[Vozila_Cisterna]
ADD CONSTRAINT [PK_Vozila_Cisterna]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Intervencije_ID], [Smene_ID] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [PK_Intervencija_Smena]
    PRIMARY KEY CLUSTERED ([Intervencije_ID], [Smene_ID] ASC);
GO

-- Creating primary key on [Intervencije_ID], [Vozila_ID] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [PK_Tehnicka_IntervencijaTehnicko_Vozilo]
    PRIMARY KEY CLUSTERED ([Intervencije_ID], [Vozila_ID] ASC);
GO

-- Creating primary key on [Pozari_ID], [Vozila_ID] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [PK_PozarNavalno_Vozilo]
    PRIMARY KEY CLUSTERED ([Pozari_ID], [Vozila_ID] ASC);
GO

-- Creating primary key on [Alati_ID], [Vozila_ID] in table 'AlatVozilo'
ALTER TABLE [dbo].[AlatVozilo]
ADD CONSTRAINT [PK_AlatVozilo]
    PRIMARY KEY CLUSTERED ([Alati_ID], [Vozila_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_Opstine] in table 'Vatrogasne_Jedinice'
ALTER TABLE [dbo].[Vatrogasne_Jedinice]
ADD CONSTRAINT [FK_OpstinaVatrogasnaJedinica]
    FOREIGN KEY ([Id_Opstine])
    REFERENCES [dbo].[Opstine]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpstinaVatrogasnaJedinica'
CREATE INDEX [IX_FK_OpstinaVatrogasnaJedinica]
ON [dbo].[Vatrogasne_Jedinice]
    ([Id_Opstine]);
GO

-- Creating foreign key on [Id_VatrogasneJedinice] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [FK_VoziloVatrogasnaJedinica]
    FOREIGN KEY ([Id_VatrogasneJedinice])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([ID])
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
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpstinaIntervencija'
CREATE INDEX [IX_FK_OpstinaIntervencija]
ON [dbo].[Intervencije]
    ([Id_Opstine]);
GO

-- Creating foreign key on [Intervencije_ID] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [FK_Intervencija_Smena_Intervencija]
    FOREIGN KEY ([Intervencije_ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Smene_ID] in table 'Intervencija_Smena'
ALTER TABLE [dbo].[Intervencija_Smena]
ADD CONSTRAINT [FK_Intervencija_Smena_Smena]
    FOREIGN KEY ([Smene_ID])
    REFERENCES [dbo].[Smene]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Intervencija_Smena_Smena'
CREATE INDEX [IX_FK_Intervencija_Smena_Smena]
ON [dbo].[Intervencija_Smena]
    ([Smene_ID]);
GO

-- Creating foreign key on [Intervencije_ID] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicka_Intervencija]
    FOREIGN KEY ([Intervencije_ID])
    REFERENCES [dbo].[Intervencije_Tehnicka_Intervencija]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Vozila_ID] in table 'Tehnicka_IntervencijaTehnicko_Vozilo'
ALTER TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]
    FOREIGN KEY ([Vozila_ID])
    REFERENCES [dbo].[Vozila_Tehnicko_Vozilo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo'
CREATE INDEX [IX_FK_Tehnicka_IntervencijaTehnicko_Vozilo_Tehnicko_Vozilo]
ON [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]
    ([Vozila_ID]);
GO

-- Creating foreign key on [Pozari_ID] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [FK_PozarNavalno_Vozilo_Pozar]
    FOREIGN KEY ([Pozari_ID])
    REFERENCES [dbo].[Intervencije_Pozar]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Vozila_ID] in table 'PozarNavalno_Vozilo'
ALTER TABLE [dbo].[PozarNavalno_Vozilo]
ADD CONSTRAINT [FK_PozarNavalno_Vozilo_Navalno_Vozilo]
    FOREIGN KEY ([Vozila_ID])
    REFERENCES [dbo].[Vozila_Navalno_Vozilo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PozarNavalno_Vozilo_Navalno_Vozilo'
CREATE INDEX [IX_FK_PozarNavalno_Vozilo_Navalno_Vozilo]
ON [dbo].[PozarNavalno_Vozilo]
    ([Vozila_ID]);
GO

-- Creating foreign key on [VatrogasnaJedinicaID] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [FK_RadnikVatrogasnaJedinica]
    FOREIGN KEY ([VatrogasnaJedinicaID])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadnikVatrogasnaJedinica'
CREATE INDEX [IX_FK_RadnikVatrogasnaJedinica]
ON [dbo].[Radnici]
    ([VatrogasnaJedinicaID]);
GO

-- Creating foreign key on [SmenaID] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [FK_SmenaRadnik]
    FOREIGN KEY ([SmenaID])
    REFERENCES [dbo].[Smene]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmenaRadnik'
CREATE INDEX [IX_FK_SmenaRadnik]
ON [dbo].[Radnici]
    ([SmenaID]);
GO

-- Creating foreign key on [VatrogasnaJedinicaID] in table 'Smene'
ALTER TABLE [dbo].[Smene]
ADD CONSTRAINT [FK_VatrogasnaJedinicaSmena]
    FOREIGN KEY ([VatrogasnaJedinicaID])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VatrogasnaJedinicaSmena'
CREATE INDEX [IX_FK_VatrogasnaJedinicaSmena]
ON [dbo].[Smene]
    ([VatrogasnaJedinicaID]);
GO

-- Creating foreign key on [ID] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [FK_IntervencijaUvidjaj]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InspektorID] in table 'Uvidjaji'
ALTER TABLE [dbo].[Uvidjaji]
ADD CONSTRAINT [FK_InspektorUvidjaj]
    FOREIGN KEY ([InspektorID])
    REFERENCES [dbo].[Inspektori]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InspektorUvidjaj'
CREATE INDEX [IX_FK_InspektorUvidjaj]
ON [dbo].[Uvidjaji]
    ([InspektorID]);
GO

-- Creating foreign key on [ID] in table 'Komandiri'
ALTER TABLE [dbo].[Komandiri]
ADD CONSTRAINT [FK_KomandirVatrogasnaJedinica]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vatrogasne_Jedinice]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Alati_ID] in table 'AlatVozilo'
ALTER TABLE [dbo].[AlatVozilo]
ADD CONSTRAINT [FK_AlatVozilo_Alat]
    FOREIGN KEY ([Alati_ID])
    REFERENCES [dbo].[Alati]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Vozila_ID] in table 'AlatVozilo'
ALTER TABLE [dbo].[AlatVozilo]
ADD CONSTRAINT [FK_AlatVozilo_Vozilo]
    FOREIGN KEY ([Vozila_ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlatVozilo_Vozilo'
CREATE INDEX [IX_FK_AlatVozilo_Vozilo]
ON [dbo].[AlatVozilo]
    ([Vozila_ID]);
GO

-- Creating foreign key on [ID] in table 'Intervencije_Tehnicka_Intervencija'
ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija]
ADD CONSTRAINT [FK_Tehnicka_Intervencija_inherits_Intervencija]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Tehnicko_Vozilo'
ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicko_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Intervencije_Pozar'
ALTER TABLE [dbo].[Intervencije_Pozar]
ADD CONSTRAINT [FK_Pozar_inherits_Intervencija]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Navalno_Vozilo'
ALTER TABLE [dbo].[Vozila_Navalno_Vozilo]
ADD CONSTRAINT [FK_Navalno_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Cisterna'
ALTER TABLE [dbo].[Vozila_Cisterna]
ADD CONSTRAINT [FK_Cisterna_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------