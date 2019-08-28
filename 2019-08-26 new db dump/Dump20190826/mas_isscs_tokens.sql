-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: mas_isscs
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tokens`
--

DROP TABLE IF EXISTS `tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tokens` (
  `TokenID` int(11) NOT NULL AUTO_INCREMENT,
  `TokenAuditID` int(10) unsigned NOT NULL,
  `ProblemName` varchar(50) NOT NULL,
  `Location` varchar(80) NOT NULL,
  `AttentionLevel` int(11) NOT NULL,
  `Description` text,
  PRIMARY KEY (`TokenID`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tokens`
--

LOCK TABLES `tokens` WRITE;
/*!40000 ALTER TABLE `tokens` DISABLE KEYS */;
INSERT INTO `tokens` VALUES (30,37,'Liquid Leak','New Office Building',45,'ඉක්මන් පිලිසකර කිරීමක් අවශ්යයි	                '),(31,38,'විදුලි කාන්දුවක්/බිත්ති ඉරි තැලීමක්','නව ගොඩනැගිල්ල',71,'ඉක්මනින් පිලිසකර කරන්න..අවදානම් තත්වයක්\r\n										                '),(32,39,'Water Leak','A Block',42,'Need Quick Action\r\n										                '),(33,40,'Central line leak','Engineering Department Building',73,'Need a quick reparation\r\n										                '),(34,41,'Central Oil leak','New Building',68,'aaasasasas\r\n										                '),(35,42,'Fire','Office Building',100,'Dangerous Up                                                               \r\n										                \r\n										                \r\n										                \r\n										                \r\n										                '),(36,43,'Central Mismatching1','New A3 Building2',52,'ASASAS ASFSBSHFG JSHDJSHDJS SHSIDHSIDHS SLJLPJF JXXBCNXCB IAIADIAS\r\n										                '),(37,44,'Central Mismatching','New A3 Building6',52,'ASASAS ASFSBSHFG JSHDJSHDJS SHSIDHSIDHS SLJLPJF JXXBCNXCB IAIADIAS\r\n										                ');
/*!40000 ALTER TABLE `tokens` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-26 21:26:44
