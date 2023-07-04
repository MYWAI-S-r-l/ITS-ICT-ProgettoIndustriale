SELECT CONCAT('ALTER TABLE `progettoindustriale`.`', TABLE_NAME, '` MODIFY COLUMN `', COLUMN_NAME, '` DOUBLE;') AS query
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'progettoindustriale' 
  AND DATA_TYPE = 'decimal';
 
-- Questo script ritorna una fila di queries da runnare a loro volta per modificare ogni datatype DECIMAL in DOUBLE.
-- Se l'output è vuoto, significa che non sono presenti datatype DECIMAL nel database.
