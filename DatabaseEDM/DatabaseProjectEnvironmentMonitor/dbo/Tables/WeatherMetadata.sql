CREATE TABLE [dbo].[WeatherMetadata] (
    [latitude]              FLOAT (53)    NULL,
    [longitude]             FLOAT (53)    NULL,
    [elevation]             TINYINT       NULL,
    [utc_offset_seconds]    TINYINT       NULL,
    [timezone]              NVARCHAR (50) NULL,
    [timezone_abbreviation] NVARCHAR (50) NULL
);


GO

