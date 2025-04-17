CREATE TABLE [dbo].[AirMetadata] (
    [SiteName]           NVARCHAR (50) NOT NULL,
    [Latitude]           FLOAT (53)    NOT NULL,
    [Longitude]          FLOAT (53)    NOT NULL,
    [Elevation]          TINYINT       NOT NULL,
    [utc_offset_seconds] TINYINT       NOT NULL,
    [Agglomeration]      NVARCHAR (50) NOT NULL,
    [LocalAuthority]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AirMetadata1] PRIMARY KEY CLUSTERED ([SiteName] ASC)
);


GO

