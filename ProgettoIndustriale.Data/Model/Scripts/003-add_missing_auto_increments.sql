-- Set auto_increment to ID_province
ALTER TABLE `progettoindustriale`.`Industry`
DROP FOREIGN KEY IF EXISTS `fk_Industry_Province1`;

ALTER TABLE `progettoindustriale`.`Weather`
DROP FOREIGN KEY IF EXISTS `fk_Weather_Province1`;

ALTER TABLE `progettoindustriale`.`Province`
MODIFY COLUMN `ID_province` INT NOT NULL AUTO_INCREMENT;

ALTER TABLE `progettoindustriale`.`Industry`
ADD CONSTRAINT `fk_Industry_Province1`
    FOREIGN KEY (`COD_province`)
    REFERENCES `progettoindustriale`.`Province` (`ID_province`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
   
ALTER TABLE `progettoindustriale`.`Weather`
ADD CONSTRAINT `fk_Weather_Province1`
    FOREIGN KEY (`COD_province`)
    REFERENCES `progettoindustriale`.`Province` (`ID_province`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
   
   
-- Set auto_increment to ID_commodity
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

   
-- Set auto_increment to ID_price
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



