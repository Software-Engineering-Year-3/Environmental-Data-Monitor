CREATE TABLE [dbo].[WaterQualityMeasurements] (
    [Date]             DATE             NOT NULL,
    [Time]             TIME (7)         NOT NULL,
    [Nitrate_mg_l_1]   FLOAT (53)       NOT NULL,
    [Nitrite_mg_l_1]   FLOAT (53)       NOT NULL,
    [Phosphate_mg_l_1] DECIMAL (18, 10) NOT NULL,
    [EC_cfu_100ml]     TINYINT          NULL
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Water quality data ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WaterQualityMeasurements';


GO

