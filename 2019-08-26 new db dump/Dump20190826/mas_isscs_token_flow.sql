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
-- Table structure for table `token_flow`
--

DROP TABLE IF EXISTS `token_flow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `token_flow` (
  `TokenFlowID` int(11) NOT NULL AUTO_INCREMENT,
  `TokenAuditID` int(11) NOT NULL,
  `TokenManagerStatus` varchar(200) NOT NULL,
  `DeptLeaderStatus` varchar(100) NOT NULL,
  `FinalVerification` varchar(45) NOT NULL,
  PRIMARY KEY (`TokenFlowID`),
  UNIQUE KEY `TokenFlowID_UNIQUE` (`TokenFlowID`),
  UNIQUE KEY `TokenAuditID_UNIQUE` (`TokenAuditID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `token_flow`
--

LOCK TABLES `token_flow` WRITE;
/*!40000 ALTER TABLE `token_flow` DISABLE KEYS */;
INSERT INTO `token_flow` VALUES (2,37,'Production VSM 04','Pending','Pending'),(3,38,'Production VSM 03','Pending','Pending'),(4,39,'Technical','Pending','Pending'),(5,40,'Production Engineering','Pending','Pending'),(6,41,'Factory Engineering','Pending','Pending'),(7,42,'Pending','Pending','Pending'),(8,43,'Quality','Pending','Pending'),(9,44,'Pending','Pending','Pending');
/*!40000 ALTER TABLE `token_flow` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-26 21:26:43
