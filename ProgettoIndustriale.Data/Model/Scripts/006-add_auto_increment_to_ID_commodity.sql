ALTER TABLE `progettoindustriale`.`Commodity`
DROP FOREIGN KEY IF EXISTS `fk_Commodity_Date1`;

ALTER TABLE `progettoindustriale`.`Commodity`
MODIFY COLUMN `ID_commodity` INT NOT NULL AUTO_INCREMENT;

ALTER TABLE `progettoindustriale`.`Commodity`
ADD CONSTRAINT `fk_Commodity_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
