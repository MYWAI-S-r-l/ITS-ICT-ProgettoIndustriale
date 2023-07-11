-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: progettoindustrialetest
-- ------------------------------------------------------
-- Server version	5.5.5-10.11.3-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `commodity`
--

drop database if exists progettoindustrialeTest;

create database progettoindustrialeTest;

use progettoindustrialeTest;

DROP TABLE IF EXISTS `commodity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commodity` (
  `ID_commodity` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `value_USD` double DEFAULT NULL,
  `unit` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_commodity`),
  KEY `fk_Commodity_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Commodity_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commodity`
--

LOCK TABLES `commodity` WRITE;
/*!40000 ALTER TABLE `commodity` DISABLE KEYS */;
INSERT INTO `commodity` VALUES (1,'Brent',76.48,'$/Barile',1),(2,'Kevin',77.48,'$/Barile',3),(3,'Stephen',76.5,'$/Barile',5),(4,'Milla',79.87,'$/Barile',2),(5,'Carl',76.97,'$/Barile',6),(6,'Tommmas',80.16,'$/Barile',4);
/*!40000 ALTER TABLE `commodity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `date`
--

DROP TABLE IF EXISTS `date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `date` (
  `ID_date` int(11) NOT NULL AUTO_INCREMENT,
  `date_time` datetime DEFAULT NULL,
  `year` smallint(6) DEFAULT NULL,
  `month` tinyint(4) DEFAULT NULL,
  `day` tinyint(4) DEFAULT NULL,
  `hour` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_date`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `date`
--

LOCK TABLES `date` WRITE;
/*!40000 ALTER TABLE `date` DISABLE KEYS */;
INSERT INTO `date` VALUES (1,'2019-06-19 00:00:00',2019,6,19,1),(2,'2019-12-20 00:00:00',2019,12,20,2),(3,'2020-08-27 00:00:00',2020,8,27,3),(4,'2021-05-16 00:00:00',2021,5,16,4),(5,'2022-10-30 00:00:00',2022,10,30,5),(6,'2023-07-06 00:00:00',2023,7,6,6);
/*!40000 ALTER TABLE `date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `generation`
--

DROP TABLE IF EXISTS `generation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `generation` (
  `ID_generation` int(11) NOT NULL AUTO_INCREMENT,
  `Generation_ghw` double DEFAULT NULL,
  `type` varchar(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_generation`),
  KEY `fk_Generation_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Generation_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generation`
--

LOCK TABLES `generation` WRITE;
/*!40000 ALTER TABLE `generation` DISABLE KEYS */;
INSERT INTO `generation` VALUES (1,274.47,'Solar',1),(2,260.87,'Wind',5),(3,300.65,'Water',3),(4,270.3,'Rain',4),(5,290.65,'Geothermal',6),(6,285.69,'Solar',2);
/*!40000 ALTER TABLE `generation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `industry`
--

DROP TABLE IF EXISTS `industry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `industry` (
  `ID_industry` int(11) NOT NULL AUTO_INCREMENT,
  `count_active` int(11) DEFAULT NULL,
  `description` varchar(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `ateco_code` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `COD_province` int(11) NOT NULL,
  PRIMARY KEY (`ID_industry`),
  KEY `fk_Industry_Province1_idx` (`COD_province`),
  CONSTRAINT `fk_Industry_Province1` FOREIGN KEY (`COD_province`) REFERENCES `province` (`ID_province`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `industry`
--

LOCK TABLES `industry` WRITE;
/*!40000 ALTER TABLE `industry` DISABLE KEYS */;
INSERT INTO `industry` VALUES (1,50,'descr.1','a',1),(2,65,'descr.2','b',5),(3,70,'descr.3','c',7),(4,33,'descr.4','a',2),(5,59,'descr.5','b',4),(6,94,'descr.6','a',1),(7,46,'descr.7','c',6);
/*!40000 ALTER TABLE `industry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `load`
--

DROP TABLE IF EXISTS `load`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `load` (
  `ID_load` int(11) NOT NULL AUTO_INCREMENT,
  `total_load_MW` int(11) DEFAULT NULL,
  `forecast_total_load_MW` double DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  `COD_macrozone` int(11) NOT NULL,
  PRIMARY KEY (`ID_load`),
  KEY `fk_Load_Date1_idx` (`COD_date`),
  KEY `fk_Load_Macrozone1_idx` (`COD_macrozone`),
  CONSTRAINT `fk_Load_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Load_Macrozone1` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `load`
--

LOCK TABLES `load` WRITE;
/*!40000 ALTER TABLE `load` DISABLE KEYS */;
INSERT INTO `load` VALUES (1,10,11.2,1,2),(2,18,13.5,5,1),(3,29,15,2,6),(4,31,10.6,4,4),(5,50,9.4,6,3),(6,6,18,3,5);
/*!40000 ALTER TABLE `load` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `macrozone`
--

DROP TABLE IF EXISTS `macrozone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `macrozone` (
  `ID_macrozone` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `bidding_zone` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`ID_macrozone`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `macrozone`
--

LOCK TABLES `macrozone` WRITE;
/*!40000 ALTER TABLE `macrozone` DISABLE KEYS */;
INSERT INTO `macrozone` VALUES (1,'Nord','Nord-Est'),(2,'Nord','Nord-Est'),(3,'Nord','Nord-Est'),(4,'Nord','Nord-Est'),(5,'Nord','Nord-Est'),(6,'Sud','Nord-Est'),(7,'Est','Nord-Est');
/*!40000 ALTER TABLE `macrozone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `price`
--

DROP TABLE IF EXISTS `price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `price` (
  `ID_price` int(11) NOT NULL AUTO_INCREMENT,
  `base_price_EURxMWh` double DEFAULT NULL,
  `incentive_component_EURxMWh` double DEFAULT NULL,
  `unbalance_price_EURxMWh` double DEFAULT NULL,
  `COD_macrozone` int(11) NOT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_price`),
  KEY `fk_Price_Macrozone1_idx` (`COD_macrozone`),
  KEY `fk_Prezzi_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Price_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Price_Macrozone1` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `price`
--

LOCK TABLES `price` WRITE;
/*!40000 ALTER TABLE `price` DISABLE KEYS */;
INSERT INTO `price` VALUES (1,15.22,14.22,10.22,3,1),(2,12.22,11.22,14.22,2,6),(3,18.22,17.22,13.22,7,4),(4,25.22,26.22,10.22,5,3),(5,10.22,9.22,16.22,4,2),(6,9.22,10.22,19.22,1,5);
/*!40000 ALTER TABLE `price` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `province` (
  `ID_province` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `longitude` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `latitude` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `surface` double DEFAULT NULL,
  `altitude` double DEFAULT NULL,
  `residents` int(11) DEFAULT NULL,
  `population_density` double DEFAULT NULL,
  `number_cities` int(11) DEFAULT NULL,
  `COD_region` int(11) NOT NULL,
  PRIMARY KEY (`ID_province`),
  KEY `fk_Province_Region1_idx` (`COD_region`),
  CONSTRAINT `fk_Province_Region1` FOREIGN KEY (`COD_region`) REFERENCES `region` (`ID_region`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'Rome','15.4963655','40.9027835',21,1,2873,1,121,2),(2,'Genoa','11.4963655','46.9027835',35,2,12873,2,200,5),(3,'Turin','10.4963655','48.9027835',28,6,9873,9,158,1),(4,'Milan','16.4963655','41.9027835',40,12,1873,6,368,3),(5,'Venice','19.4963655','39.9027835',26,8,35873,4,312,6),(6,'Florence','20.4963655','60.9027835',23,2,6873,5,1587,4),(7,'Naples','14.4963655','43.9027835',38,7,5873,2,3685,7);
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `region`
--

DROP TABLE IF EXISTS `region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `region` (
  `ID_region` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `COD_macrozone` int(11) NOT NULL,
  PRIMARY KEY (`ID_region`),
  KEY `fk_Region_Macrozone_idx` (`COD_macrozone`),
  CONSTRAINT `fk_Region_Macrozone` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `region`
--

LOCK TABLES `region` WRITE;
/*!40000 ALTER TABLE `region` DISABLE KEYS */;
INSERT INTO `region` VALUES (1,'Lazio',1),(2,'Liguria',2),(3,'Veneto',5),(4,'Abruzzo',3),(5,'Piemonte',4),(6,'Toscana',7),(7,'Calabria',6);
/*!40000 ALTER TABLE `region` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weather`
--

DROP TABLE IF EXISTS `weather`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weather` (
  `ID_weather` int(11) NOT NULL AUTO_INCREMENT,
  `temperature_2m_Celsius` double DEFAULT NULL,
  `dewpoint_2m_Celsius` double DEFAULT NULL,
  `relative_humidity_2m_percent` double DEFAULT NULL,
  `apparent_temperature_Celsius` double DEFAULT NULL,
  `cloudcover_percent` double DEFAULT NULL,
  `windspeed_10m_km_h` double DEFAULT NULL,
  `windspeed_80m_km_h` double DEFAULT NULL,
  `surface_pressure_hPa` double DEFAULT NULL,
  `rain_mm` double DEFAULT NULL,
  `snowfall_mm` double DEFAULT NULL,
  `shower_mm` double DEFAULT NULL,
  `precipitation_mm` double DEFAULT NULL,
  `snow_depth_meters` double DEFAULT NULL,
  `is_day_bool` tinyint(1) DEFAULT NULL,
  `COD_province` int(11) NOT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_weather`),
  KEY `fk_Weather_Province1_idx` (`COD_province`),
  KEY `fk_Weather_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Weather_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Weather_Province1` FOREIGN KEY (`COD_province`) REFERENCES `province` (`ID_province`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weather`
--

LOCK TABLES `weather` WRITE;
/*!40000 ALTER TABLE `weather` DISABLE KEYS */;
INSERT INTO `weather` VALUES (1,20,25,40,24,44,30,78,40,10,0,11,12,0,1,2,1),(2,18,27,70,19,80,15,75,35,15,5,15,14,0,2,1,6),(3,23,29,62.5,25,56,18,62,45,6,15,13,16,0,4,6,4),(4,15,20,50,22,46,35,70,23,20,25,23,9,0,6,4,5),(5,10,25,55.6,28,30,40,55,18,18,35,20,5,0,5,5,3),(6,6,18,60,20,8,6,82,55,12,6,50,0,0,3,3,2);
/*!40000 ALTER TABLE `weather` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'progettoindustrialetest'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

