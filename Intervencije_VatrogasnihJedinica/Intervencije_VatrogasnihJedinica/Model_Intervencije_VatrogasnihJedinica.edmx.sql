
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2021 12:08:50
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
IF OBJECT_ID(N'[dbo].[FK_VoziloVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila] DROP CONSTRAINT [FK_VoziloVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_OpstinaIntervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intervencije] DROP CONSTRAINT [FK_OpstinaIntervencija];
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
IF OBJECT_ID(N'[dbo].[FK_RadnikVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_RadnikVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_SmenaRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici] DROP CONSTRAINT [FK_SmenaRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_VatrogasnaJedinicaSmena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Smene] DROP CONSTRAINT [FK_VatrogasnaJedinicaSmena];
GO
IF OBJECT_ID(N'[dbo].[FK_IntervencijaUvidjaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_IntervencijaUvidjaj];
GO
IF OBJECT_ID(N'[dbo].[FK_InspektorUvidjaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uvidjaji] DROP CONSTRAINT [FK_InspektorUvidjaj];
GO
IF OBJECT_ID(N'[dbo].[FK_KomandirVatrogasnaJedinica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Komandiri] DROP CONSTRAINT [FK_KomandirVatrogasnaJedinica];
GO
IF OBJECT_ID(N'[dbo].[FK_AlatVozilo_Alat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlatVozilo] DROP CONSTRAINT [FK_AlatVozilo_Alat];
GO
IF OBJECT_ID(N'[dbo].[FK_AlatVozilo_Vozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlatVozilo] DROP CONSTRAINT [FK_AlatVozilo_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikRadnikUSmeni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadniciUSmenama] DROP CONSTRAINT [FK_RadnikRadnikUSmeni];
GO
IF OBJECT_ID(N'[dbo].[FK_SmenaRadnikUSmeni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadniciUSmenama] DROP CONSTRAINT [FK_SmenaRadnikUSmeni];
GO
IF OBJECT_ID(N'[dbo].[FK_IntervencijaRadnikUSmeni_Intervencija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntervencijaRadnikUSmeni] DROP CONSTRAINT [FK_IntervencijaRadnikUSmeni_Intervencija];
GO
IF OBJECT_ID(N'[dbo].[FK_IntervencijaRadnikUSmeni_RadnikUSmeni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntervencijaRadnikUSmeni] DROP CONSTRAINT [FK_IntervencijaRadnikUSmeni_RadnikUSmeni];
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

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Opstine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opstine];
GO
IF OBJECT_ID(N'[dbo].[Vatrogasne_Jedinice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vatrogasne_Jedinice];
GO
IF OBJECT_ID(N'[dbo].[Vozila]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila];
GO
IF OBJECT_ID(N'[dbo].[Intervencije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intervencije];
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
IF OBJECT_ID(N'[dbo].[Radnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici];
GO
IF OBJECT_ID(N'[dbo].[Uvidjaji]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uvidjaji];
GO
IF OBJECT_ID(N'[dbo].[Komandiri]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Komandiri];
GO
IF OBJECT_ID(N'[dbo].[RadniciUSmenama]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadniciUSmenama];
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
IF OBJECT_ID(N'[dbo].[Tehnicka_IntervencijaTehnicko_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tehnicka_IntervencijaTehnicko_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[PozarNavalno_Vozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PozarNavalno_Vozilo];
GO
IF OBJECT_ID(N'[dbo].[AlatVozilo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlatVozilo];
GO
IF OBJECT_ID(N'[dbo].[IntervencijaRadnikUSmeni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IntervencijaRadnikUSmeni];
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
    [Id_Opstine] int  NOT NULL,
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
    [NazivSmene] nvarchar(max)  NOT NULL,
    [VatrogasnaJedinicaID] int  NOT NULL,
    [DatumPrvogDezurstva] datetime  NOT NULL
);
GO

-- Creating table 'Radnici'
CREATE TABLE [dbo].[Radnici] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Radno_Mesto] int  NOT NULL,
    [DatumPocetkaRada] datetime  NOT NULL,
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

-- Creating table 'RadniciUSmenama'
CREATE TABLE [dbo].[RadniciUSmenama] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DatumPocetkaRada] datetime  NOT NULL,
    [DatumKrajaRada] datetime  NULL,
    [RadnikID] int  NOT NULL,
    [SmenaID] int  NOT NULL
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

-- Creating table 'IntervencijaRadnikUSmeni'
CREATE TABLE [dbo].[IntervencijaRadnikUSmeni] (
    [Intervencije_ID] int  NOT NULL,
    [RadniciSaSmenama_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'RadniciUSmenama'
ALTER TABLE [dbo].[RadniciUSmenama]
ADD CONSTRAINT [PK_RadniciUSmenama]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Intervencije_ID], [RadniciSaSmenama_Id] in table 'IntervencijaRadnikUSmeni'
ALTER TABLE [dbo].[IntervencijaRadnikUSmeni]
ADD CONSTRAINT [PK_IntervencijaRadnikUSmeni]
    PRIMARY KEY CLUSTERED ([Intervencije_ID], [RadniciSaSmenama_Id] ASC);
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
    ON DELETE Cascade ON UPDATE NO ACTION;
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
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Vozila_ID] in table 'AlatVozilo'
ALTER TABLE [dbo].[AlatVozilo]
ADD CONSTRAINT [FK_AlatVozilo_Vozilo]
    FOREIGN KEY ([Vozila_ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlatVozilo_Vozilo'
CREATE INDEX [IX_FK_AlatVozilo_Vozilo]
ON [dbo].[AlatVozilo]
    ([Vozila_ID]);
GO

-- Creating foreign key on [RadnikID] in table 'RadniciUSmenama'
ALTER TABLE [dbo].[RadniciUSmenama]
ADD CONSTRAINT [FK_RadnikRadnikUSmeni]
    FOREIGN KEY ([RadnikID])
    REFERENCES [dbo].[Radnici]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadnikRadnikUSmeni'
CREATE INDEX [IX_FK_RadnikRadnikUSmeni]
ON [dbo].[RadniciUSmenama]
    ([RadnikID]);
GO

-- Creating foreign key on [SmenaID] in table 'RadniciUSmenama'
ALTER TABLE [dbo].[RadniciUSmenama]
ADD CONSTRAINT [FK_SmenaRadnikUSmeni]
    FOREIGN KEY ([SmenaID])
    REFERENCES [dbo].[Smene]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmenaRadnikUSmeni'
CREATE INDEX [IX_FK_SmenaRadnikUSmeni]
ON [dbo].[RadniciUSmenama]
    ([SmenaID]);
GO

-- Creating foreign key on [Intervencije_ID] in table 'IntervencijaRadnikUSmeni'
ALTER TABLE [dbo].[IntervencijaRadnikUSmeni]
ADD CONSTRAINT [FK_IntervencijaRadnikUSmeni_Intervencija]
    FOREIGN KEY ([Intervencije_ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RadniciSaSmenama_Id] in table 'IntervencijaRadnikUSmeni'
ALTER TABLE [dbo].[IntervencijaRadnikUSmeni]
ADD CONSTRAINT [FK_IntervencijaRadnikUSmeni_RadnikUSmeni]
    FOREIGN KEY ([RadniciSaSmenama_Id])
    REFERENCES [dbo].[RadniciUSmenama]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntervencijaRadnikUSmeni_RadnikUSmeni'
CREATE INDEX [IX_FK_IntervencijaRadnikUSmeni_RadnikUSmeni]
ON [dbo].[IntervencijaRadnikUSmeni]
    ([RadniciSaSmenama_Id]);
GO

-- Creating foreign key on [ID] in table 'Intervencije_Tehnicka_Intervencija'
ALTER TABLE [dbo].[Intervencije_Tehnicka_Intervencija]
ADD CONSTRAINT [FK_Tehnicka_Intervencija_inherits_Intervencija]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Tehnicko_Vozilo'
ALTER TABLE [dbo].[Vozila_Tehnicko_Vozilo]
ADD CONSTRAINT [FK_Tehnicko_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Intervencije_Pozar'
ALTER TABLE [dbo].[Intervencije_Pozar]
ADD CONSTRAINT [FK_Pozar_inherits_Intervencija]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Intervencije]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Navalno_Vozilo'
ALTER TABLE [dbo].[Vozila_Navalno_Vozilo]
ADD CONSTRAINT [FK_Navalno_Vozilo_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Vozila_Cisterna'
ALTER TABLE [dbo].[Vozila_Cisterna]
ADD CONSTRAINT [FK_Cisterna_inherits_Vozilo]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Vozila]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- INDEXI
-- -------------------------------------------------


CREATE INDEX Intervencija_Tip_OpstinaID_Idx ON [dbo].Intervencije (Id_Opstine, Tip);

CREATE INDEX RadnikSmena_DatumKrajaRada_Idx ON [dbo].RadniciUSmenama (DatumKrajaRada);

CREATE INDEX RadnikSmena_DatumPocetkaRada_Idx ON [dbo].RadniciUSmenama (DatumPocetkaRada);

CREATE INDEX Alat_Tip_Idx ON [dbo].Alati (Tip);




-- --------------------------------------------------
-- TRIGERI
-- -------------------------------------------------

-- --------------------------------------------------
-- TRIGER ZA OPSTINU
-- -------------------------------------------------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================

Create TRIGGER [dbo].[Trigger_Opstina_ioD]  ON [dbo].[Opstine] 
instead of delete
AS 
declare @Id int;
declare @Message varchar(300);
declare @VatrogasneJediniceID varchar(250);
declare @IntervencijeID varchar(250);

set @Message = ''
set @VatrogasneJediniceID = ''
set @IntervencijeID = ''

BEGIN
	Select @Id = Opstine.ID from Opstine join deleted on deleted.ID = Opstine.ID
	If(@Id is null)
	begin
		Raiserror('Ne postoji opština sa ovim ID-em',16,1)
		Return
	end
	else
	begin
		Select @VatrogasneJediniceID = CONCAT(@VatrogasneJediniceID, Vatrogasne_Jedinice.ID , '; ') from Vatrogasne_Jedinice where Id_Opstine = @Id
        if(@VatrogasneJediniceID != '')
		    begin
			    set @Message= CONCAT('Na teritoriji opštine se nalaze vatrogasne jedinice sa ID-em: ', @VatrogasneJediniceID);
		    end

		Select @IntervencijeID = CONCAT(@IntervencijeID, Intervencije.ID , '; ') from Intervencije where Id_Opstine = @Id
		if(@IntervencijeID != '')
		    begin
			    set @Message= CONCAT(@Message,' U ovoj opštini su se dogodile intervencije sa ID-em: ', @IntervencijeID);
		    end

		if(@Message != '')
		    begin
			    set @Message= CONCAT('Brisanje nije moguće!! ',@Message);
			    Raiserror(@Message,16,1)
			    return
		    end
		else
		    begin 
			    delete from Opstine where ID = @Id
		    end
	end
END

-- --------------------------------------------------
-- TRIGER ZA Tehnicko vozilo
-- -------------------------------------------------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
CREATE TRIGGER [dbo].[Trigger_Tehnicko_Vozilo_ioD]  ON [dbo].[Vozila_Tehnicko_Vozilo] 
instead of delete
AS 
declare @Id int;
declare @Message varchar(300);
declare @IdIntervencija varchar(300);

set @Message = ''
set @IdIntervencija=''

BEGIN
	Select @Id = Vozila_Tehnicko_Vozilo.ID from Vozila_Tehnicko_Vozilo join deleted on deleted.ID = Vozila_Tehnicko_Vozilo.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji vozilo sa ovim ID-em',16,1)
		    Return
	    end
	else
	    begin
		    Select  @IdIntervencija = Concat(@IdIntervencija, Intervencije_ID , '; ') from Tehnicka_IntervencijaTehnicko_Vozilo where Vozila_ID = @Id
		    if(@IdIntervencija != '')
		        begin 
			        set @Message = Concat('Brisanje nije moguće!! Vozlio je učestvovalo na Intervencijama sa ID-em: ',@IdIntervencija);
			        Raiserror(@Message ,16,1)
			        Return
		        end
            else
                begin
                    delete from Vozila_Tehnicko_Vozilo where ID = @Id
                end
	    end
END



-- --------------------------------------------------
-- TRIGER ZA NAVALNO VOZILO
-- -------------------------------------------------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
create TRIGGER [dbo].[Trigger_Navalno_Vozilo_ioD]  ON [dbo].[Vozila_Navalno_Vozilo] 
instead of delete
AS 
declare @Id int;
declare @Message varchar(300);
declare @IdIntervencija varchar(300);
set @Message = ''
set @IdIntervencija = ''

BEGIN
	Select @Id = Vozila_Navalno_Vozilo.ID from Vozila_Navalno_Vozilo join deleted on deleted.ID = Vozila_Navalno_Vozilo.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji vozilo sa ovim ID-em',16,1)
		    Return
	    end
	else
	    begin
		    Select  @IdIntervencija = Concat(@IdIntervencija, Pozari_ID , '; ') from PozarNavalno_Vozilo where Vozila_ID = @Id
		    if(@IdIntervencija != '')
		        begin 
			        set @Message = Concat('Brisanje nije moguće!! Vozlio je učestvovalo na Intervencijama sa ID-em: ',@IdIntervencija);
			        Raiserror(@Message ,16,1)
			        Return
		        end
            ELSE
                begin
                    delete from Vozila_Navalno_Vozilo where ID = @Id
                end
	    end
END


-- --------------------------------------------------
-- TRIGER ZA INSPEKTORA
-- -------------------------------------------------


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
Create TRIGGER [dbo].[Trigger_Inspektor_ioD]  ON [dbo].[Inspektori]
instead of delete
AS 

declare @Id int;
declare @Message varchar(1000);
declare @IdUvidjaja varchar(500);

set @Message = ''
set @IdUvidjaja = ''

BEGIN
	Select @Id = Inspektori.ID from Inspektori join deleted on deleted.ID = Inspektori.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji inspektor sa ovim ID-em',16,1)
		    Return
	    end
    else
	    begin
		    Select  @IdUvidjaja = Concat(@IdUvidjaja, ID , '; ') from Uvidjaji where InspektorID = @Id
		    if(@IdUvidjaja != '')
		        begin
			        set @Message = CONCAT('Brisanje nije moguće!! Inspektor je vršio uviđaje sa ID-em: ', @IdUvidjaja)
			        Raiserror(@Message,16,1)
			        Return
		        end
            else
		        begin 
			        delete from Inspektori where ID = @Id
		        end
	    end
END


-- --------------------------------------------------
-- TRIGER ZA VATROGASNU JEDINICU
-- -------------------------------------------------


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create TRIGGER [dbo].[Trigger_Vatrogasna_Jedinica_ioD]  ON [dbo].[Vatrogasne_Jedinice] 
instead of delete
AS 
declare @Id int;
declare @Message varchar(1000);
declare @IdIntervencija varchar(500);
declare @IdVozila varchar(500);
declare @IdRadnika varchar(500);
declare @IdKomandira varchar(300);

set @Message = ''
set @IdIntervencija = ''
set @IdVozila = ''
set @IdRadnika = ''
set @IdKomandira = ''

BEGIN
	Select @Id = Vatrogasne_Jedinice.ID from Vatrogasne_Jedinice join deleted on deleted.ID = Vatrogasne_Jedinice.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji vatrogasna jedinica sa ovim ID-em',16,1)
		    Return
	    end
	else
	    begin
		    Select  @IdRadnika = Concat(@IdRadnika, ID , '; ') from Radnici where VatrogasnaJedinicaID = @Id
		    if(@IdRadnika != '')
		        begin 
			        set @IdRadnika = Concat('Radnike sa ID-em: ', @IdRadnika);
		        end

		    Select  @IdVozila = Concat(@IdVozila, ID , '; ') from Vozila where Id_VatrogasneJedinice = @Id
		    if(@IdVozila != '')
		        begin 
			        set @IdVozila = Concat('Vozila sa ID-em: ', @IdVozila);
		        end

		    Select  @IdKomandira = ID  from Komandiri where ID = @Id /*id komandira je isti kao id Vatrogasne jedinice*/
		    if(@IdKomandira != '')
		        begin 
			        set @IdKomandira = Concat('Komandira sa ID-em: ', @IdKomandira);
		        end

            Select DISTINCT @IdIntervencija = Concat(@IdIntervencija, IRUS.Intervencije_ID , '; ') from IntervencijaRadnikUSmeni IRUS inner join RadniciUSmenama RUS ON IRUS.RadniciSaSmenama_Id = RUS.Id inner join Smene S on S.ID = RUS.SmenaID  where S.VatrogasnaJedinicaID = @Id
		    if(@IdIntervencija != '')
		        begin 
			        set @IdIntervencija = Concat(' Vatrogasna jedinica je učestvovala na intervencijama sa ID-em: ', @IdIntervencija);
		        end

		    if(@IdRadnika != '' or @IdVozila != '' or @IdKomandira != '' or @IdIntervencija != '')
		        begin
			        set @Message = CONCAT('Brisanje nije moguće!! Vatrogasna jedinica sadrži: ',@IdRadnika, @IdVozila, @IdKomandira, @IdIntervencija)
			        Raiserror(@Message,16,1)
			        Return
		        end
		    else
		        begin 
                    delete from Smene where VatrogasnaJedinicaID = @Id
			        delete from Vatrogasne_Jedinice where ID = @Id
		        end
	    end
END


-- --------------------------------------------------
-- TRIGER ZA RADNIKA
-- -------------------------------------------------


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
create TRIGGER [dbo].[Trigger_Radnik_ioD]  ON [dbo].[Radnici]
instead of delete
AS 

declare @Id int;
declare @Message varchar(1000);
declare @IdIntervencija varchar(500);

set @Message = ''
set @IdIntervencija = ''

BEGIN
	Select @Id = Radnici.ID from Radnici join deleted on deleted.ID = Radnici.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji radnik sa ovim ID-em',16,1)
		    Return
	    end 
    else
	    begin

		    Select  @IdIntervencija = Concat(@IdIntervencija, IRS.Intervencije_ID , '; ') from IntervencijaRadnikUSmeni IRS inner join RadniciUSmenama RUS on IRS.RadniciSaSmenama_Id = RUS.Id where RUS.RadnikID = @Id
		    if(@IdIntervencija != '')
		        begin
			        set @IdIntervencija = CONCAT('Brisanje nije moguće!! Radnik je učestvovao na intervencijama sa ID-em: ', @IdIntervencija)
			        Raiserror(@IdIntervencija, 16, 1)
			        Return
		        end 
            else
		        begin
			        delete from RadniciUSmenama where RadnikID = @Id
			        delete from Radnici where ID = @Id
		        end
	    end
END



-- --------------------------------------------------
-- TRIGER ZA TEHNICKE INTERVENCIJE
-- -------------------------------------------------


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
create TRIGGER [dbo].[Trigger_TehnickaIntervencija_ioD]  ON [dbo].Intervencije_Tehnicka_Intervencija
instead of delete
AS 

declare @Id int;
declare @Message varchar(1000);
declare @IdSmena varchar(500);
declare @IdRadnika varchar(500);
declare @IdVozila varchar(500);

set @Message = ''
set @IdSmena = ''
set @IdRadnika = ''
set @IdVozila = ''

BEGIN
	Select @Id = Intervencije.ID from Intervencije join deleted on deleted.ID = Intervencije.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji intervencija sa ovim ID-em',16,1)
		    Return
	    end 
    else
	    begin

		    Select DISTINCT @IdSmena = Concat(@IdSmena,  RUS.SmenaID , '; ') from IntervencijaRadnikUSmeni IRUS inner join RadniciUSmenama RUS on  IRUS.RadniciSaSmenama_Id = RUS.Id where IRUS.Intervencije_ID = @Id
		    if(@IdSmena != '')
		        begin
			        set @IdSmena = CONCAT('Smene sa ID-em: ', @IdSmena)
		        end 

            Select @IdRadnika = Concat(@IdRadnika, RUS.RadnikID , '; ')  from IntervencijaRadnikUSmeni IRUS inner join RadniciUSmenama RUS on  IRUS.RadniciSaSmenama_Id = RUS.Id where IRUS.Intervencije_ID = @Id
		    if(@IdRadnika != '')
		        begin
			        set @IdRadnika = CONCAT('Radnici sa ID-em: ', @IdRadnika)
		        end 

            Select @IdVozila = Concat(@IdVozila, Vozila_ID , '; ')  from Tehnicka_IntervencijaTehnicko_Vozilo where Intervencije_ID = @Id
		    if(@IdVozila != '')
		        begin
			        set @IdVozila = CONCAT('Vozila sa ID-em: ', @IdVozila)
		        end 

            if(@IdSmena != '' or @IdRadnika != '' or @IdVozila != '')
		        begin
			        set @Message = CONCAT('Brisanje nije moguće!! Na intervenciji su učestvovali: ', @IdRadnika, @IdSmena, @IdVozila)
			        Raiserror(@Message,16,1)
			        Return
		        end
            else
		        begin
			        delete from Intervencije_Tehnicka_Intervencija where ID = @Id
		        end
	    end
END


-- --------------------------------------------------
-- TRIGER ZA POŽARE
-- -------------------------------------------------


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<LAZAR KOVACEVIC>
-- =============================================
create TRIGGER [dbo].[Trigger_IntervencijePozar_ioD]  ON [dbo].Intervencije_Pozar
instead of delete
AS 

declare @Id int;
declare @Message varchar(1000);
declare @IdSmena varchar(500);
declare @IdRadnika varchar(500);
declare @IdVozila varchar(500);

set @Message = ''
set @IdSmena = ''
set @IdRadnika = ''
set @IdVozila = ''

BEGIN
	Select @Id = Intervencije.ID from Intervencije join deleted on deleted.ID = Intervencije.ID
	If(@Id is null)
	    begin
		    Raiserror('Ne postoji intervencija sa ovim ID-em',16,1)
		    Return
	    end 
    else
	    begin

		    Select DISTINCT @IdSmena = Concat(@IdSmena, RUS.SmenaID, '; ')  from IntervencijaRadnikUSmeni IRUS inner join RadniciUSmenama RUS on  IRUS.RadniciSaSmenama_Id = RUS.Id where IRUS.Intervencije_ID = @Id
		    if(@IdSmena != '')
		        begin
			        set @IdSmena = CONCAT('Smene sa ID-em: ', @IdSmena)
		        end 

            Select @IdRadnika =  Concat(@IdRadnika, RUS.RadnikID, '; ')  from IntervencijaRadnikUSmeni IRUS inner join RadniciUSmenama RUS on  IRUS.RadniciSaSmenama_Id = RUS.Id where IRUS.Intervencije_ID = @Id
		    if(@IdRadnika != '')
		        begin
			        set @IdRadnika = CONCAT('Radnici sa ID-em: ', @IdRadnika)
		        end 

            Select @IdVozila =  Concat(@IdVozila, Vozila_ID, '; ')  from PozarNavalno_Vozilo where Pozari_ID = @Id
		    if(@IdVozila != '')
		        begin
			        set @IdVozila = CONCAT('Vozila sa ID-em: ', @IdVozila)
		        end 

            if(@IdSmena != '' or @IdRadnika != '' or @IdVozila != '')
		        begin
			        set @Message = CONCAT('Brisanje nije moguće!! Na intervenciji su učestvovali: ', @IdRadnika,@IdSmena, @IdVozila)
			        Raiserror(@Message,16,1)
			        Return
		        end
            else
		        begin
			        delete from Intervencije_Pozar where ID = @Id
		        end
	    end
END



-- --------------------------------------------------
-- Script has ended
-- -------------------------------------------------
