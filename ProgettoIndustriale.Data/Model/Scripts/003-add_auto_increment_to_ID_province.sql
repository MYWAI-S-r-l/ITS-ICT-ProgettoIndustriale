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
