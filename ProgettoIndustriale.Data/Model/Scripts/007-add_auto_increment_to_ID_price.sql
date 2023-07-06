ALTER TABLE `progettoindustriale`.`Price`
DROP FOREIGN KEY IF EXISTS `fk_Price_Macrozone1`,
DROP FOREIGN KEY IF EXISTS `fk_Price_Date1`;

ALTER TABLE `progettoindustriale`.`Price`
MODIFY COLUMN `ID_price` INT NOT NULL AUTO_INCREMENT;

ALTER TABLE `progettoindustriale`.`Price`
ADD CONSTRAINT `fk_Price_Macrozone1`
    FOREIGN KEY (`COD_macrozone`)
    REFERENCES `progettoindustriale`.`Macrozone` (`ID_macrozone`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Price_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
