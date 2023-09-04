-- Schema progettoindustriale
DROP SCHEMA IF EXISTS `progettoindustriale`;

CREATE SCHEMA IF NOT EXISTS `progettoindustriale`;
USE `progettoindustriale`;

-- Table `progettoindustriale`.`Macrozone`
DROP TABLE IF EXISTS `progettoindustriale`.`Macrozone`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Macrozone` (
  `ID_macrozone` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(10) NULL,
  `bidding_zone` VARCHAR(10) NULL,
  PRIMARY KEY (`ID_macrozone`))
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Region`
DROP TABLE IF EXISTS `progettoindustriale`.`Region`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Region` (
  `ID_region` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `COD_macrozone` INT NOT NULL,
  PRIMARY KEY (`ID_region`),
  INDEX `fk_Region_Macrozone_idx` (`COD_macrozone` ASC) VISIBLE,
  CONSTRAINT `fk_Region_Macrozone`
    FOREIGN KEY (`COD_macrozone`)
    REFERENCES `progettoindustriale`.`Macrozone` (`ID_macrozone`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Province`
DROP TABLE IF EXISTS `progettoindustriale`.`Province`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Province` (
  `ID_province` INT NOT NULL,
  `name` VARCHAR(50) NULL,
  `longitude` VARCHAR(20) NULL,
  `latitude` VARCHAR(20) NULL,
  `surface` DECIMAL NULL,
  `altitude` DECIMAL NULL,
  `residents` INT NULL,
  `population_density` DECIMAL(5,2) NULL,
  `number_cities` TINYINT NULL,
  `COD_region` INT NOT NULL,
  PRIMARY KEY (`ID_province`),
  INDEX `fk_Province_Region1_idx` (`COD_Region` ASC) VISIBLE,
  CONSTRAINT `fk_Province_Region1`
    FOREIGN KEY (`COD_region`)
    REFERENCES `progettoindustriale`.`Region` (`ID_region`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Date`
DROP TABLE IF EXISTS `progettoindustriale`.`Date`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Date` (
  `ID_date` INT NOT NULL AUTO_INCREMENT,
  `date_time` TIMESTAMP NULL,
  `year` SMALLINT NULL,
  `month` TINYINT NULL,
  `day` TINYINT NULL,
  `time` TIME NULL,
  PRIMARY KEY (`ID_date`))
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Commodity`
DROP TABLE IF EXISTS `progettoindustriale`.`Commodity`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Commodity` (
  `ID_commodity` INT NOT NULL,
  `name` VARCHAR(20) NULL,
  `value_USD` DECIMAL(5,2) NULL,
  `COD_date` INT NOT NULL,
  PRIMARY KEY (`ID_commodity`),
  INDEX `fk_Commodity_Date1_idx` (`COD_date` ASC) VISIBLE,
  CONSTRAINT `fk_Commodity_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Industry`
DROP TABLE IF EXISTS `progettoindustriale`.`Industry`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Industry` (
  `ID_industry` INT NOT NULL AUTO_INCREMENT,
  `count_active` INT NULL,
  `name` VARCHAR(45) NULL,
  `COD_province` INT NOT NULL,
  PRIMARY KEY (`ID_industry`),
  INDEX `fk_Industry_Province1_idx` (`COD_province` ASC) VISIBLE,
  CONSTRAINT `fk_Industry_Province1`
    FOREIGN KEY (`COD_province`)
    REFERENCES `progettoindustriale`.`Province` (`ID_province`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Weather`
DROP TABLE IF EXISTS `progettoindustriale`.`Weather`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Weather` (
  `ID_weather` INT NOT NULL AUTO_INCREMENT,
  `temperature_2m_Celsius` DECIMAL(4,2) NULL,
  `dewpoint_2m_Celsius` DECIMAL(4,2) NULL,
  `relative_humidity_2m_percent` DECIMAL(5,2) NULL,
  `apparent_temperature_Celsius` DECIMAL(4,2) NULL,
  `cloudcover_percent` DECIMAL(5,1) NULL,
  `windspeed_10m_km_h` DECIMAL(4,1) NULL,
  `windspeed_80m_km_h` DECIMAL(5,1) NULL,
  `surface_pressure_hPa` DECIMAL(5,2) NULL,
  `rain_mm` DECIMAL(5,2) NULL,
  `snowfall_mm` DECIMAL(5,2) NULL,
  `shower_mm` DECIMAL(5,2) NULL,
  `precipitation_mm` DECIMAL(5,2) NULL,
  `snow_depth_meters` DECIMAL(5,2) NULL,
  `is_day_bool` TINYINT(1) NULL,
  `COD_province` INT NOT NULL,
  `COD_date` INT NOT NULL,
  PRIMARY KEY (`ID_weather`),
  INDEX `fk_Weather_Province1_idx` (`COD_province` ASC) VISIBLE,
  INDEX `fk_Weather_Date1_idx` (`COD_date` ASC) VISIBLE,
  CONSTRAINT `fk_Weather_Province1`
    FOREIGN KEY (`COD_province`)
    REFERENCES `progettoindustriale`.`Province` (`ID_province`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Weather_Date1`
    FOREIGN KEY (`COD_Date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Generation`
DROP TABLE IF EXISTS `progettoindustriale`.`Generation`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Generation` (
  `ID_generation` INT NOT NULL AUTO_INCREMENT,
  `Generation_ghw` DECIMAL(5,2) NULL,
  `type` VARCHAR(45) NULL,
  `COD_date` INT NOT NULL,
  PRIMARY KEY (`ID_generation`),
  INDEX `fk_Generation_Date1_idx` (`COD_date` ASC) VISIBLE,
  CONSTRAINT `fk_Generation_Date1`
    FOREIGN KEY (`COD_Date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Load`
DROP TABLE IF EXISTS `progettoindustriale`.`Load`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Load` (
  `ID_load` INT NOT NULL AUTO_INCREMENT,
  `total_load_MW` INT NULL,
  `forecast_total_load_MW` DECIMAL(10,3) NULL,
  `COD_date` INT NOT NULL,
  `COD_macrozone` INT NOT NULL,
  PRIMARY KEY (`ID_load`),
  INDEX `fk_Load_Date1_idx` (`COD_date` ASC) VISIBLE,
  INDEX `fk_Load_Macrozone1_idx` (`COD_macrozone` ASC) VISIBLE,
  CONSTRAINT `fk_Load_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Load_Macrozone1`
    FOREIGN KEY (`COD_macrozone`)
    REFERENCES `progettoindustriale`.`Macrozone` (`ID_macrozone`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- Table `progettoindustriale`.`Price`
DROP TABLE IF EXISTS `progettoindustriale`.`Price`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Price` (
  `ID_price` INT NOT NULL,
  `base_price_EURxMWh` DECIMAL(7,3) NULL,
  `incentive_component_EURxMWh` DECIMAL(7,3) NULL,
  `unbalance_price_EURxMWh` DECIMAL(7,3) NULL,
  `COD_macrozone` INT NOT NULL,
  `COD_date` INT NOT NULL,
  PRIMARY KEY (`ID_price`),
  INDEX `fk_Price_Macrozone1_idx` (`COD_macrozone` ASC) VISIBLE,
  INDEX `fk_Prezzi_Date1_idx` (`COD_date` ASC) VISIBLE,
  CONSTRAINT `fk_Price_Macrozone1`
    FOREIGN KEY (`COD_macrozone`)
    REFERENCES `progettoindustriale`.`Macrozone` (`ID_macrozone`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Price_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


create or replace table `progettoindustriale`.`Token`(
`id` INT NOT NULL AUTO_INCREMENT,
`TokenType` VARCHAR(20) not null,
`AccessToken` VARCHAR(50) not null,
`Provider` VARCHAR(50) not null,
PRIMARY KEY (`id`)
);

create or replace table `progettoindustriale`.`ApiCallsLogs`(
`id` INT NOT NULL AUTO_INCREMENT,
`apiCallName` VARCHAR(50) not null,
`callFrequency` VARCHAR(5) not null,
`lastSuccessfulRun` TIMESTAMP not null,
PRIMARY KEY (`id`)
);


ALTER TABLE `progettoindustriale`.`Commodity` 
ADD COLUMN IF NOT EXISTS `unit` VARCHAR(10) AFTER `value_USD`; 

ALTER TABLE `progettoindustriale`.`commodity` MODIFY COLUMN `value_USD` DOUBLE;
ALTER TABLE `progettoindustriale`.`generation` MODIFY COLUMN `Generation_ghw` DOUBLE;
ALTER TABLE `progettoindustriale`.`load` MODIFY COLUMN `total_load_MW` DOUBLE;
ALTER TABLE `progettoindustriale`.`load` MODIFY COLUMN `forecast_total_load_MW` DOUBLE;
ALTER TABLE `progettoindustriale`.`price` MODIFY COLUMN `base_price_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`price` MODIFY COLUMN `incentive_component_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`price` MODIFY COLUMN `unbalance_price_EURxMWh` DOUBLE;
ALTER TABLE `progettoindustriale`.`province` MODIFY COLUMN `surface` DOUBLE;
ALTER TABLE `progettoindustriale`.`province` MODIFY COLUMN `altitude` DOUBLE;
ALTER TABLE `progettoindustriale`.`province` MODIFY COLUMN `population_density` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `temperature_2m_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `dewpoint_2m_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `relative_humidity_2m_percent` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `apparent_temperature_Celsius` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `cloudcover_percent` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `windspeed_10m_km_h` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `windspeed_80m_km_h` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `surface_pressure_hPa` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `rain_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `snowfall_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `shower_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `precipitation_mm` DOUBLE;
ALTER TABLE `progettoindustriale`.`weather` MODIFY COLUMN `snow_depth_meters` DOUBLE;


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


ALTER TABLE `progettoindustriale`.`Province`
MODIFY COLUMN `number_cities` INT NULL;


ALTER TABLE `progettoindustriale`.`Industry`
RENAME COLUMN IF EXISTS `Name` TO `description`;

ALTER TABLE `progettoindustriale`.`Industry`
ADD COLUMN IF NOT EXISTS `ateco_code` VARCHAR(10) NULL AFTER `description`,
MODIFY COLUMN `description` VARCHAR(255);


ALTER TABLE `progettoindustriale`.`date` 
RENAME COLUMN IF EXISTS `time` TO `hour`;

ALTER TABLE `progettoindustriale`.`date` 
MODIFY COLUMN `hour` INT NULL;


ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN date_time datetime NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `year` smallint(6) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `month` tinyint(4) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `day` tinyint(4) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `hour` int NOT NULL;


ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `name` varchar(40);

ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `unit` varchar(30);


ALTER TABLE `progettoindustriale`.`Date`
MODIFY COLUMN `date_time` DATETIME NULL;


ALTER TABLE progettoindustriale.`load` MODIFY COLUMN total_load_MW double DEFAULT NULL NULL;


ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `name` varchar(40);

ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `unit` varchar(30);


ALTER TABLE `progettoindustriale`.`Macrozone`
MODIFY COLUMN `bidding_zone` VARCHAR(20);

--PROCEDURES

DELIMITER //

CREATE PROCEDURE ResetAutoIncrement()
BEGIN
    -- Ripristina l'ID auto-incrementale per la tabella macrozone
    SET @macrozoneSql = 'ALTER TABLE macrozone AUTO_INCREMENT = 1;';
    PREPARE macrozoneStmt FROM @macrozoneSql;
    EXECUTE macrozoneStmt;
    DEALLOCATE PREPARE macrozoneStmt;

    -- Ripristina l'ID auto-incrementale per la tabella region
    SET @regionSql = 'ALTER TABLE region AUTO_INCREMENT = 1;';
    PREPARE regionStmt FROM @regionSql;
    EXECUTE regionStmt;
    DEALLOCATE PREPARE regionStmt;

    -- Ripristina l'ID auto-incrementale per la tabella province
    SET @provinceSql = 'ALTER TABLE province AUTO_INCREMENT = 1;';
    PREPARE provinceStmt FROM @provinceSql;
    EXECUTE provinceStmt;
    DEALLOCATE PREPARE provinceStmt;

    -- Ripristina l'ID auto-incrementale per la tabella industry
    SET @industrySql = 'ALTER TABLE industry AUTO_INCREMENT = 1;';
    PREPARE industryStmt FROM @industrySql;
    EXECUTE industryStmt;
    DEALLOCATE PREPARE industryStmt;
   
    
    SET @generationSql = 'ALTER TABLE generation AUTO_INCREMENT = 1;';
    PREPARE generationStmt FROM @generationSql;
    EXECUTE generationStmt;
    DEALLOCATE PREPARE generationStmt;
   
    
    SET @loadSql = 'ALTER TABLE `progettoindustriale`.`load` AUTO_INCREMENT = 1;';
    PREPARE loadStmt FROM @loadSql;
    EXECUTE loadStmt;
    DEALLOCATE PREPARE loadStmt;
END //

DELIMITER ;


DROP PROCEDURE IF EXISTS PopulateDates;

DELIMITER //

CREATE PROCEDURE IF NOT EXISTS PopulateDates()
BEGIN
	
    DECLARE `start_date` DATETIME;
    DECLARE `end_date` DATETIME;
    DECLARE `current_date` DATETIME;
    
    SET `start_date` = '2021-01-01 00:00:00';
    SET `end_date` = '2026-12-31 23:59:00';
    SET `current_date` = `start_date`;
    
    WHILE `current_date` <= `end_date` DO
        INSERT INTO `progettoindustriale`.`date` (`date_time`, `year`, `month`, `day`, `hour`)
        VALUES (`current_date`, YEAR(`current_date`), MONTH(`current_date`), DAY(`current_date`), HOUR(`current_date`));
        
        SET `current_date` = DATE_ADD(`current_date`, INTERVAL 1 HOUR);
    END WHILE;
    
END //

DELIMITER ;


CALL PopulateDates();
