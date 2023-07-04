ALTER TABLE `progettoindustriale`.`Industry`
RENAME COLUMN IF EXISTS `Name` TO `description`;

ALTER TABLE `progettoindustriale`.`Industry`
ADD COLUMN IF NOT EXISTS `ateco_code` VARCHAR(10) NULL AFTER `description`,
MODIFY COLUMN `description` VARCHAR(255);