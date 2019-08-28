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
-- Table structure for table `token_audit`
--

DROP TABLE IF EXISTS `token_audit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `token_audit` (
  `TokenAuditID` int(11) NOT NULL AUTO_INCREMENT,
  `AddedUser` varchar(80) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `AddedDate` text NOT NULL,
  PRIMARY KEY (`TokenAuditID`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `token_audit`
--

LOCK TABLES `token_audit` WRITE;
/*!40000 ALTER TABLE `token_audit` DISABLE KEYS */;
INSERT INTO `token_audit` VALUES (1,'dddd','fgfgf','2019-06-30 19:34:31'),(2,'Dinuwan','safety','5'),(3,'Dinuwan','safety','5'),(4,'ffg','Sustainability','5'),(5,'ISSCS_V_1._2.Models.UserLogin','Safety','5'),(6,'dinuwan@gmail.com','Sustainability','5'),(7,'ashan@gmail.com','Safety','2019-06-30 22:08:15'),(8,'dinuwan@gmail.com','Sustainability','2019-06-30 23:20:51'),(9,'dinuwan@gmail.com','Sustainability','2019-07-01 00:21:29'),(10,'dinuwan@gmail.com','Sustainability','2019-07-01 00:23:59'),(11,'dinuwan@gmail.com','Safety','2019-07-01 00:32:23'),(12,'ashan@gmail.com','Sustainability','2019-07-01 00:33:45'),(13,'ashan@gmail.com','Sustainability','2019-07-01 02:04:56'),(14,'dinuwan@gmail.com','Sustainability','2019-07-01 11:59:20'),(15,'dinuwan@gmail.com','Sustainability','2019-07-01 13:31:32'),(16,'dinuwan@gmail.com','Safety','2019-07-02 22:29:56'),(17,'dinuwan@gmail.com','Sustainability','2019-07-02 22:33:43'),(18,'damith@gmail.com','hfhfkjdfjkdf','2019-07-05 09:49:27'),(19,'damith@gmail.com','wewe','2019-07-05 09:50:26'),(20,'dinuwan@gmail.com','sd','2019-07-05 09:52:25'),(21,'dinuwan@gmail.com','ddff','2019-07-05 09:53:14'),(22,'damith@gmail.com','fd','2019-07-05 09:55:01'),(23,'damith@gmail.com','Safety','2019-07-05 10:12:13'),(24,'damith@gmail.com','Safety','2019-07-05 10:28:07'),(25,'ashan@gmail.com','Sustainability','2019-07-05 10:36:18'),(26,'dinuwan@gmail.com','Safety','2019-07-06 09:31:38'),(27,'dinuwan@gmail.com','Safety','2019-07-09 15:46:26'),(28,'dinuwan@gmail.com','Sustainability','2019-07-09 18:13:27'),(29,'dinuwan@gmail.com','Safety','2019-07-09 18:39:46'),(30,'dinuwan@gmail.com','Sustainability','2019-07-09 18:45:38'),(31,'dinuwan@gmail.com','Sustainability','2019-07-10 14:04:13'),(32,'damith@gmail.com','Sustainability','2019-07-10 15:17:42'),(33,'damith@gmail.com','Safety','2019-07-10 15:33:17'),(34,'dinuwan@gmail.com','Sustainability','2019-07-14 08:37:38'),(35,'jayan@gmail.com','Sustainability','2019-07-21 21:28:24'),(36,'jayan@gmail.com','Sustainability','2019-07-22 14:21:02'),(37,'jayan@gmail.com','Sustainability','2019-07-22 14:35:46'),(38,'jayan@gmail.com','Safety','2019-07-22 14:37:58'),(39,'dinuwan@gmail.com','Safety','2019-07-22 20:16:16'),(40,'ashan@gmail.com','Sustainability','2019-07-24 23:12:30'),(41,'dinuwan@gmail.com','Sustainability','2019-07-29 16:54:19'),(42,'budhdhika@maholdings.com','Safety','2019-07-30 09:41:04'),(43,'budhdhika@maholdings.com','Sustainability','2019-08-25 09:01:49'),(44,'budhdhika@maholdings.com','Sustainability','2019-08-25 09:02:09');
/*!40000 ALTER TABLE `token_audit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-26 21:26:45
