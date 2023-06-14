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
  PRIMARY KEY (`id`))
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
ENGINE = InnoDB

-- Table `progettoindustriale`.`Province`
DROP TABLE IF EXISTS `progettoindustriale`.`Province`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Province` (
  `ID_province` INT NOT NULL,
  `name` VARCHAR(50) NULL,
  `longitude` VARCHAR(20) NULL,
  `latitudine` VARCHAR(20) NULL,
  `surface` DECIMAL NULL,
  `altitude` DECIMAL NULL,
  `residenti` INT NULL,
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
ENGINE = InnoDB

-- Table `progettoindustriale`.`Date`
DROP TABLE IF EXISTS `progettoindustriale`.`Date`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Date` (
  `ID_date` INT NOT NULL AUTO_INCREMENT,
  `date_time` TIMESTAMP NULL,
  `year` SMALLINT NULL,
  `month` TINYINT NULL,
  `day` TINYINT NULL,
  `time` TIME NULL,
  PRIMARY KEY (`id`));

-- Table `progettoindustriale`.`Commodity`
DROP TABLE IF EXISTS `progettoindustriale`.`Commodity`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Commodity` (
  `ID_commodity` INT NOT NULL,
  `name` VARCHAR(20) NULL,
  `value_USD_MB_tu` DECIMAL(5,2) NULL,
  `COD_date` INT NOT NULL,
  PRIMARY KEY (`ID_commodity`),
  INDEX `fk_Commodity_Date1_idx` (`COD_date` ASC) VISIBLE,
  CONSTRAINT `fk_Commodity_Date1`
    FOREIGN KEY (`COD_date`)
    REFERENCES `progettoindustriale`.`Date` (`ID_date`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

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
    ON UPDATE NO ACTION);

-- Table `progettoindustriale`.`Weather`
DROP TABLE IF EXISTS `progettoindustriale`.`Weather`;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Weather` (
  `ID_weather` INT NOT NULL AUTO_INCREMENT,
  `temperature_2_m_Celsius` DECIMAL(4,2) NULL,
  `dewpoint_2m_Celsius` DECIMAL(4,2) NULL,
  `relativehumidity_2m_percent` DECIMAL(5,2) NULL,
  `apparent_temperature_Celsius` DECIMAL(4,2) NULL,
  `cloudcover_percent` DECIMAL(5,1) NULL,
  `windspeed_10m_km_h` DECIMAL(4,1) NULL,
  `windspeed_80m_km_h` DECIMAL(5,1) NULL,
  `surface_pressure_hPa` DECIMAL(5,2) NULL,
  `rain_mm` DECIMAL(5,2) NULL,
  `snowfall_mm` DECIMAL(5,2) NULL,
  `showers_mm` DECIMAL(5,2) NULL,
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
    ON UPDATE NO ACTION);

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


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
