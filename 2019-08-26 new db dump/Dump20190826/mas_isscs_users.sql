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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `UserEmail` varchar(100) NOT NULL,
  `UserMobile` int(11) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `ConfirmPassword` varchar(100) NOT NULL,
  `UserDepartment` varchar(100) NOT NULL,
  `UserType` varchar(40) NOT NULL,
  `UserImage` text,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Dinuwan Kalubowila','dinuwan@gmail.com',712184518,'asdf','asdf','MOS','Token Manager',NULL),(2,'Dinuwan Klaubowila','kalubowila@gmail.com',712184518,'123','123','RM','Employee','~/userimages/android-icon-21190529854.png'),(3,'Hilary Kalubowila','hkkalubowila@live.com',777610400,'123','123','RM','Employee','System.Web.HttpPostedFileWrapper'),(4,'Samitha Perera','kalubowila@live.com',712184518,'123','123','Cutting','Employee','System.Web.HttpPostedFileWrapper'),(5,'Buddhi Kalubowila','buddhi@yahoo.com',712187042,'123','123','Cutting','Department Leader',NULL),(6,'Ashan Perera','ashan@gmail.com',712184518,'123','123','Factory Engineering','Department Leader',NULL),(7,'Damith Perera','damith@gmail.com',712184518,'123','123','Autonomation','Factory Management',NULL),(8,'Jayan Perera','jayan@gmail.com',712184518,'456','456','FG','Token Manager',NULL),(9,'Hiranya Buddhi','budhdhika@maholdings.com',712987042,'123','123','Factory Engineering','Administrator',NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-26 21:26:47
