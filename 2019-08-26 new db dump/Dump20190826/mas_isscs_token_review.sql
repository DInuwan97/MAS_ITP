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
-- Table structure for table `token_review`
--

DROP TABLE IF EXISTS `token_review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `token_review` (
  `TokenReviewID` int(11) NOT NULL AUTO_INCREMENT,
  `TokenAuditID` int(11) NOT NULL,
  `SpecialActs` text,
  `RepairDepartment` varchar(100) NOT NULL,
  `SentDate` text NOT NULL,
  `SentUser` varchar(45) NOT NULL,
  PRIMARY KEY (`TokenReviewID`),
  UNIQUE KEY `TokenAuditID_UNIQUE` (`TokenAuditID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `token_review`
--

LOCK TABLES `token_review` WRITE;
/*!40000 ALTER TABLE `token_review` DISABLE KEYS */;
INSERT INTO `token_review` VALUES (13,38,'Urgent','Production VSM 03','2019-07-28 11:15:09','dinuwan@gmail.com'),(14,37,'Urgent','Production VSM 04','2019-08-03 16:14:35','dinuwan@gmail.com'),(15,41,'Urgent','Factory Engineering','2019-07-30 10:30:03','jayan@gmail.com'),(16,40,'Urgent','Production Engineering','2019-07-30 09:18:54','dinuwan@gmail.com'),(17,39,'Urgent','Technical','2019-08-01 15:50:51','budhdhika@maholdings.com'),(18,43,'Urgent','Quality','2019-08-25 12:04:39','dinuwan@gmail.com');
/*!40000 ALTER TABLE `token_review` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-26 21:26:46
