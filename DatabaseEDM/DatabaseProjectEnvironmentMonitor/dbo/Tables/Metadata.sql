CREATE TABLE [dbo].[Metadata] (
    [Category]              NVARCHAR (50)  NULL,
    [Quantity]              NVARCHAR (50)  NOT NULL,
    [Symbol]                NVARCHAR (50)  NOT NULL,
    [Unit]                  NVARCHAR (50)  NOT NULL,
    [Unit_description]      NVARCHAR (50)  NOT NULL,
    [Measurement_frequency] NVARCHAR (50)  NOT NULL,
    [Safe_level]            FLOAT (53)     NULL,
    [Reference]             NVARCHAR (200) NULL,
    [Sensor]                NVARCHAR (50)  NOT NULL,
    [URL]                   NVARCHAR (150) NOT NULL
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Metadata table', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Metadata';


GO

