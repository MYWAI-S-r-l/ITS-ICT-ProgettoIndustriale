SELECT CONCAT('ALTER TABLE `progettoindustriale`.`', TABLE_NAME, '` MODIFY COLUMN `', COLUMN_NAME, '` DOUBLE;') AS query
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'progettoindustriale' 
  AND DATA_TYPE = 'decimal';
 
 -- Qui sotto per comodità l'output generato dallo script soprastante, nonché lo script da usare per cambiare i datatype. 
 -- Non è obbligatorio runnare lo script in alto, salvo cambiamenti al DB che allora richiedono un copia e incolla del suo output. 
 
ALTER TABLE `progettoindustriale`.`Commodity` MODIFY COLUMN `value_USD` DOUBLE;
ALTER TABLE `progettoindustriale`.`Generation` MODIFY COLUMN `Generation_ghw` DOUBLE;
ALTER TABLE `progettoindustriale`.`Load` MODIFY COLUMN `forecast_total_load_MW` DOUBLE; 
ALTER TABLE `progettoindustriale`.`Price` MODIFY COLUMN `base_price_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`Price` MODIFY COLUMN `incentive_component_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`Price` MODIFY COLUMN `unbalance_price_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`Province` MODIFY COLUMN `surface` DOUBLE;
ALTER TABLE `progettoindustriale`.`Province` MODIFY COLUMN `altitude` DOUBLE;
ALTER TABLE `progettoindustriale`.`Province` MODIFY COLUMN `population_density` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `temperature_2m_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `dewpoint_2m_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `relative_humidity_2m_percent` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `apparent_temperature_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `cloudcover_percent` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `windspeed_10m_km_h` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `windspeed_80m_km_h` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `surface_pressure_hPa` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `rain_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `snowfall_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `shower_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `precipitation_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`Weather` MODIFY COLUMN `snow_depth_meters` DOUBLE;

