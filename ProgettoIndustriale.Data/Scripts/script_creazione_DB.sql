-- MySQL Script generated by MySQL Workbench
-- Mon Jun 12 16:48:38 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema progettoindustriale
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `progettoindustriale` ;

-- -----------------------------------------------------
-- Schema progettoindustriale
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `progettoindustriale`;
USE `progettoindustriale` ;

-- -----------------------------------------------------
-- Table `progettoindustriale`.`Macroareas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Macroareas` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Macroareas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(10) NULL,
  `bidding_zone` VARCHAR(10) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Regions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Regions` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Regions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `Macroareas_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Regioni_Macrozone_idx` (`Macroareas_id` ASC) VISIBLE,
  CONSTRAINT `fk_Regioni_Macrozone`
    FOREIGN KEY (`Macroareas_id`)
    REFERENCES `progettoindustriale`.`Macroareas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Provinces`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Provinces` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Provinces` (
  `id` INT NOT NULL,
  `name` VARCHAR(50) NULL,
  `longitude` VARCHAR(20) NULL,
  `latitudine` VARCHAR(20) NULL,
  `surface` DECIMAL NULL,
  `altitude` DECIMAL NULL,
  `residenti` INT NULL,
  `population_density` DECIMAL(5,2) NULL,
  `number_cities` TINYINT NULL,
  `Regions_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Province_Regioni1_idx` (`Regions_id` ASC) VISIBLE,
  CONSTRAINT `fk_Province_Regioni1`
    FOREIGN KEY (`Regions_id`)
    REFERENCES `progettoindustriale`.`Regions` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Dates`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Dates` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Dates` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date_time` TIMESTAMP NULL,
  `year` SMALLINT NULL,
  `month` TINYINT NULL,
  `day` TINYINT NULL,
  `time` TIME NULL,
  PRIMARY KEY (`id`));


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Commodities`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Commodities` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Commodities` (
  `id` INT NOT NULL,
  `name` VARCHAR(20) NULL,
  `value_$/MB tu` DECIMAL(5,2) NULL,
  `Dates_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Commodities_Data1_idx` (`Dates_id` ASC) VISIBLE,
  CONSTRAINT `fk_Commodities_Data1`
    FOREIGN KEY (`Dates_id`)
    REFERENCES `progettoindustriale`.`Dates` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Industries`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Industries` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Industries` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `count_active` INT NULL,
  `name` VARCHAR(45) NULL,
  `Provinces_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Industrie_Province1_idx` (`Provinces_id` ASC) VISIBLE,
  CONSTRAINT `fk_Industrie_Province1`
    FOREIGN KEY (`Provinces_id`)
    REFERENCES `progettoindustriale`.`Provinces` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Weather`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Weather` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Weather` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `temperature_2_m - °C` DECIMAL(4,2) NULL,
  `dewpoint_2m - °C` DECIMAL(4,2) NULL,
  `relativehumidity_2m - %` DECIMAL(5,2) NULL,
  `apparent_temperature -°C` DECIMAL(4,2) NULL,
  `cloudcover - %` DECIMAL(5,1) NULL,
  `windspeed_10m - km/h` DECIMAL(4,1) NULL,
  `windspeed_80m - km/h` DECIMAL(5,1) NULL,
  `surface_pressure - hPa` DECIMAL(5,2) NULL,
  `rain - mm` DECIMAL(5,2) NULL,
  `snowfall - mm` DECIMAL(5,2) NULL,
  `showers - mm` DECIMAL(5,2) NULL,
  `precipitation - mm` DECIMAL(5,2) NULL,
  `snow_depth - meters` DECIMAL(5,2) NULL,
  `is_day - bool` TINYINT(1) NULL,
  `Provinces_id` INT NOT NULL,
  `Dates_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Meteo_Province1_idx` (`Provinces_id` ASC) VISIBLE,
  INDEX `fk_Meteo_Data1_idx` (`Dates_id` ASC) VISIBLE,
  CONSTRAINT `fk_Meteo_Province1`
    FOREIGN KEY (`Provinces_id`)
    REFERENCES `progettoindustriale`.`Provinces` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Meteo_Data1`
    FOREIGN KEY (`Dates_id`)
    REFERENCES `progettoindustriale`.`Dates` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Generation`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Generation` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Generation` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Generation_ghw` DECIMAL(5,2) NULL,
  `type` VARCHAR(45) NULL,
  `Dates_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Generation_Data1_idx` (`Dates_id` ASC) VISIBLE,
  CONSTRAINT `fk_Generation_Data1`
    FOREIGN KEY (`Dates_id`)
    REFERENCES `progettoindustriale`.`Dates` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Loads`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Loads` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Loads` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `total_load_MW` INT NULL,
  `forecast_total_load_MW` DECIMAL(10,3) NULL,
  `Dates_id` INT NOT NULL,
  `Macroareas_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Loads_Data1_idx` (`Dates_id` ASC) VISIBLE,
  INDEX `fk_Loads_Macrozone1_idx` (`Macroareas_id` ASC) VISIBLE,
  CONSTRAINT `fk_Loads_Data1`
    FOREIGN KEY (`Dates_id`)
    REFERENCES `progettoindustriale`.`Dates` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Loads_Macrozone1`
    FOREIGN KEY (`Macroareas_id`)
    REFERENCES `progettoindustriale`.`Macroareas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `progettoindustriale`.`Prices`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `progettoindustriale`.`Prices` ;

CREATE TABLE IF NOT EXISTS `progettoindustriale`.`Prices` (
  `id` INT NOT NULL,
  `base_price_EurxMWh` DECIMAL(7,3) NULL,
  `incentive_component_EurxMWh` DECIMAL(7,3) NULL,
  `unbalance_price_EURxMWh` DECIMAL(7,3) NULL,
  `Macroareas_id` INT NOT NULL,
  `Dates_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Prezzi_Macrozone1_idx` (`Macroareas_id` ASC) VISIBLE,
  INDEX `fk_Prezzi_Data1_idx` (`Dates_id` ASC) VISIBLE,
  CONSTRAINT `fk_Prezzi_Macrozone1`
    FOREIGN KEY (`Macroareas_id`)
    REFERENCES `progettoindustriale`.`Macroareas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Prezzi_Data1`
    FOREIGN KEY (`Dates_id`)
    REFERENCES `progettoindustriale`.`Dates` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;