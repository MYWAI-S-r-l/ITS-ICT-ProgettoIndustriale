-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: progettoindustriale
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

DROP TABLE IF EXISTS `commodity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commodity` (
  `ID_commodity` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  `value_USD` decimal(5,2) DEFAULT NULL,
  `unit` varchar(10) DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_commodity`),
  KEY `fk_Commodity_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Commodity_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commodity`
--

LOCK TABLES `commodity` WRITE;
/*!40000 ALTER TABLE `commodity` DISABLE KEYS */;
INSERT INTO `commodity` VALUES (1,'Brent',76.48,'$/Barile',1),(2,'Kevin',77.48,'$/Barile',3),(3,'Stephen',76.50,'$/Barile',5),(4,'Milla',79.87,'$/Barile',2),(5,'Carl',76.97,'$/Barile',6),(6,'Tommmas',80.16,'$/Barile',4);
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
  `date_time` timestamp NULL DEFAULT NULL,
  `year` smallint(6) DEFAULT NULL,
  `month` tinyint(4) DEFAULT NULL,
  `day` tinyint(4) DEFAULT NULL,
  `hour` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_date`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `date`
--

LOCK TABLES `date` WRITE;
/*!40000 ALTER TABLE `date` DISABLE KEYS */;
INSERT INTO `date` VALUES (1,'2019-06-18 22:00:00',2019,6,19,1),(2,'2019-12-19 23:00:00',2019,12,20,2),(3,'2020-08-26 22:00:00',2020,8,27,3),(4,'2021-05-15 22:00:00',2021,5,16,4),(5,'2022-10-29 22:00:00',2022,10,30,5),(6,'2023-07-05 22:00:00',2023,7,6,6);
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
  `Generation_ghw` decimal(5,2) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_generation`),
  KEY `fk_Generation_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Generation_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generation`
--

LOCK TABLES `generation` WRITE;
/*!40000 ALTER TABLE `generation` DISABLE KEYS */;
INSERT INTO `generation` VALUES (1,274.47,'Solar',1),(2,260.87,'Wind',5),(3,300.65,'Water',3),(4,270.30,'Rain',4),(5,290.65,'Geothermal',6),(6,285.69,'Solar',2);
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
  `description` varchar(100) DEFAULT NULL,
  `ateco_code` varchar(10) DEFAULT NULL,
  `COD_province` int(11) NOT NULL,
  PRIMARY KEY (`ID_industry`),
  KEY `fk_Industry_Province1_idx` (`COD_province`),
  CONSTRAINT `fk_Industry_Province1` FOREIGN KEY (`COD_province`) REFERENCES `province` (`ID_province`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
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
  `forecast_total_load_MW` decimal(10,3) DEFAULT NULL,
  `COD_date` int(11) NOT NULL,
  `COD_macrozone` int(11) NOT NULL,
  PRIMARY KEY (`ID_load`),
  KEY `fk_Load_Date1_idx` (`COD_date`),
  KEY `fk_Load_Macrozone1_idx` (`COD_macrozone`),
  CONSTRAINT `fk_Load_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Load_Macrozone1` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `load`
--

LOCK TABLES `load` WRITE;
/*!40000 ALTER TABLE `load` DISABLE KEYS */;
INSERT INTO `load` VALUES (1,10,11.200,1,2),(2,18,13.500,5,1),(3,29,15.000,2,6),(4,31,10.600,4,4),(5,50,9.400,6,3),(6,6,18.000,3,5);
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
  `name` varchar(10) DEFAULT NULL,
  `bidding_zone` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID_macrozone`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
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
  `base_price_EURxMWh` decimal(7,3) DEFAULT NULL,
  `incentive_component_EURxMWh` decimal(7,3) DEFAULT NULL,
  `unbalance_price_EURxMWh` decimal(7,3) DEFAULT NULL,
  `COD_macrozone` int(11) NOT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_price`),
  KEY `fk_Price_Macrozone1_idx` (`COD_macrozone`),
  KEY `fk_Prezzi_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Price_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Price_Macrozone1` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `price`
--

LOCK TABLES `price` WRITE;
/*!40000 ALTER TABLE `price` DISABLE KEYS */;
INSERT INTO `price` VALUES (1,15.220,14.220,10.220,3,1),(2,12.220,11.220,14.220,2,6),(3,18.220,17.220,13.220,7,4),(4,25.220,26.220,10.220,5,3),(5,10.220,9.220,16.220,4,2),(6,9.220,10.220,19.220,1,5);
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
  `name` varchar(50) DEFAULT NULL,
  `longitude` varchar(20) DEFAULT NULL,
  `latitude` varchar(20) DEFAULT NULL,
  `surface` decimal(10,0) DEFAULT NULL,
  `altitude` decimal(10,0) DEFAULT NULL,
  `residents` int(11) DEFAULT NULL,
  `population_density` decimal(5,2) DEFAULT NULL,
  `number_cities` int(11) DEFAULT NULL,
  `COD_region` int(11) NOT NULL,
  PRIMARY KEY (`ID_province`),
  KEY `fk_Province_Region1_idx` (`COD_region`),
  CONSTRAINT `fk_Province_Region1` FOREIGN KEY (`COD_region`) REFERENCES `region` (`ID_region`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'Rome','15.4963655','40.9027835',21,1,2873,1.00,121,2),(2,'Genoa','11.4963655','46.9027835',35,2,12873,2.00,200,5),(3,'Turin','10.4963655','48.9027835',28,6,9873,9.00,158,1),(4,'Milan','16.4963655','41.9027835',40,12,1873,6.00,368,3),(5,'Venice','19.4963655','39.9027835',26,8,35873,4.00,312,6),(6,'Florence','20.4963655','60.9027835',23,2,6873,5.00,1587,4),(7,'Naples','14.4963655','43.9027835',38,7,5873,2.00,3685,7);
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
  `name` varchar(45) DEFAULT NULL,
  `COD_macrozone` int(11) NOT NULL,
  PRIMARY KEY (`ID_region`),
  KEY `fk_Region_Macrozone_idx` (`COD_macrozone`),
  CONSTRAINT `fk_Region_Macrozone` FOREIGN KEY (`COD_macrozone`) REFERENCES `macrozone` (`ID_macrozone`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
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
  `temperature_2m_Celsius` decimal(4,2) DEFAULT NULL,
  `dewpoint_2m_Celsius` decimal(4,2) DEFAULT NULL,
  `relative_humidity_2m_percent` decimal(5,2) DEFAULT NULL,
  `apparent_temperature_Celsius` decimal(4,2) DEFAULT NULL,
  `cloudcover_percent` decimal(5,1) DEFAULT NULL,
  `windspeed_10m_km_h` decimal(4,1) DEFAULT NULL,
  `windspeed_80m_km_h` decimal(5,1) DEFAULT NULL,
  `surface_pressure_hPa` decimal(5,2) DEFAULT NULL,
  `rain_mm` decimal(5,2) DEFAULT NULL,
  `snowfall_mm` decimal(5,2) DEFAULT NULL,
  `shower_mm` decimal(5,2) DEFAULT NULL,
  `precipitation_mm` decimal(5,2) DEFAULT NULL,
  `snow_depth_meters` decimal(5,2) DEFAULT NULL,
  `is_day_bool` tinyint(1) DEFAULT NULL,
  `COD_province` int(11) NOT NULL,
  `COD_date` int(11) NOT NULL,
  PRIMARY KEY (`ID_weather`),
  KEY `fk_Weather_Province1_idx` (`COD_province`),
  KEY `fk_Weather_Date1_idx` (`COD_date`),
  CONSTRAINT `fk_Weather_Date1` FOREIGN KEY (`COD_date`) REFERENCES `date` (`ID_date`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Weather_Province1` FOREIGN KEY (`COD_province`) REFERENCES `province` (`ID_province`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weather`
--

LOCK TABLES `weather` WRITE;
/*!40000 ALTER TABLE `weather` DISABLE KEYS */;
INSERT INTO `weather` VALUES (1,20.00,25.00,40.00,24.00,44.0,30.0,78.0,40.00,10.00,0.00,11.00,12.00,0.00,1,2,1),(2,18.00,27.00,70.00,19.00,80.0,15.0,75.0,35.00,15.00,5.00,15.00,14.00,0.00,2,1,6),(3,23.00,29.00,62.50,25.00,56.0,18.0,62.0,45.00,6.00,15.00,13.00,16.00,0.00,4,6,4),(4,15.00,20.00,50.00,22.00,46.0,35.0,70.0,23.00,20.00,25.00,23.00,9.00,0.00,6,4,5),(5,10.00,25.00,55.60,28.00,30.0,40.0,55.0,18.00,18.00,35.00,20.00,5.00,0.00,5,5,3),(6,6.00,18.00,60.00,20.00,8.0,6.0,82.0,55.00,12.00,6.00,50.00,0.00,0.00,3,3,2);
/*!40000 ALTER TABLE `weather` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'progettoindustriale'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-11 11:29:31
