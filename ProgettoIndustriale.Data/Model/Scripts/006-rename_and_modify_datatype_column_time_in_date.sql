ALTER TABLE `progettoindustriale`.`date` 
RENAME COLUMN IF EXISTS `time` TO `hour`;

ALTER TABLE `progettoindustriale`.`date` 
MODIFY COLUMN `hour` INT NULL;

