CREATE TABLE [dbo].[WeatherMeasurements] (
    [latitude]              NVARCHAR (50) NULL,
    [longitude]             NVARCHAR (50) NULL,
    [elevation]             NVARCHAR (50) NULL,
    [utc_offset_seconds]    NVARCHAR (50) NULL,
    [timezone]              NVARCHAR (50) NULL,
    [timezone_abbreviation] NVARCHAR (50) NULL
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Weather Measurements', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WeatherMeasurements';


GO

