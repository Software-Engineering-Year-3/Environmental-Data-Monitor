CREATE TABLE [dbo].[WaterMetadata] (
    [Site_Name]     NVARCHAR (50) NOT NULL,
    [Sample_Period] NVARCHAR (50) NOT NULL,
    [Location]      NVARCHAR (50) NOT NULL,
    [column4]       NVARCHAR (1)  NULL,
    CONSTRAINT [PK_WaterMetadata] PRIMARY KEY CLUSTERED ([Site_Name] ASC)
);


GO

