ALTER TABLE `progettoindustriale`.`Commodity` 
ADD COLUMN IF NOT EXISTS `unit` VARCHAR(10) AFTER `value_USD`; 