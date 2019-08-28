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
-- Table structure for table `token_image`
--

DROP TABLE IF EXISTS `token_image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `token_image` (
  `TokenImageID` int(11) NOT NULL AUTO_INCREMENT,
  `TokenID` int(10) unsigned NOT NULL,
  `ImagePath` text NOT NULL,
  PRIMARY KEY (`TokenImageID`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `token_image`
--

LOCK TABLES `token_image` WRITE;
/*!40000 ALTER TABLE `token_image` DISABLE KEYS */;
INSERT INTO `token_image` VALUES (34,37,'~/Image/18921962-1903825633193612-2862064419361595657-n_orig193546532.jpg'),(35,37,'~/Image/01464375933-petrol-hatti-takibi-ve-kayip-kacak-tespiti193546632.jpg'),(36,38,'~/Image/electric-safety-01193757225.jpeg'),(37,38,'~/Image/17-1024x682193758718.jpg'),(38,39,'~/Image/safety first191615932.jpg'),(39,39,'~/Image/hazard-poison-sign-animated-gif-5191615939.gif'),(40,40,'~/Image/1191228958.jpg'),(41,40,'~/Image/water1191229018.jpg'),(42,41,'~/Image/01464375933-petrol-hatti-takibi-ve-kayip-kacak-tespiti195418780.jpg'),(43,41,'~/Image/electric-safety-01195418818.jpeg'),(44,42,'~/Image/56-apple-512194104045.png'),(45,42,'~/Image/1200px-.NET_Core_Logo.svg194104048.png'),(46,43,'~/Image/water1190146849.jpg'),(47,43,'~/Image/0190146885.jpg'),(48,44,'~/Image/water1190209849.jpg'),(49,44,'~/Image/0190209855.jpg');
/*!40000 ALTER TABLE `token_image` ENABLE KEYS */;
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
