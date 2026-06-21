CREATE DATABASE  IF NOT EXISTS `fastpartdb` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `fastpartdb`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fastpartdb
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `IdAdmin` int NOT NULL AUTO_INCREMENT,
  `FullName` varchar(100) NOT NULL,
  `Login` varchar(45) NOT NULL,
  `Password` varchar(30) NOT NULL,
  PRIMARY KEY (`IdAdmin`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES (1,'Осин Егор Алексеевич','1','1'),(2,'Иван Иванов','admin1','pass123'),(3,'Ольга Петрова','admin2','secure456');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `IdCart` int NOT NULL AUTO_INCREMENT,
  `IdUser` int NOT NULL,
  `IdPart` int NOT NULL,
  `Amount` int NOT NULL,
  PRIMARY KEY (`IdCart`),
  KEY `fk_Cart_User1_idx` (`IdUser`),
  KEY `fk_Cart_Part1_idx` (`IdPart`),
  CONSTRAINT `fk_Cart_Part1` FOREIGN KEY (`IdPart`) REFERENCES `part` (`IdPart`),
  CONSTRAINT `fk_Cart_User1` FOREIGN KEY (`IdUser`) REFERENCES `user` (`IdUser`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
INSERT INTO `cart` VALUES (1,1,2,2),(2,1,4,4),(3,2,3,1);
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `IdCategory` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`IdCategory`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Двигатель'),(2,'Тормозная система'),(3,'Подвеска'),(4,'Электрика'),(5,'Кузовные детали');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `media`
--

DROP TABLE IF EXISTS `media`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `media` (
  `IdMedia` int NOT NULL AUTO_INCREMENT,
  `Content` varchar(1000) NOT NULL,
  PRIMARY KEY (`IdMedia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `media`
--

LOCK TABLES `media` WRITE;
/*!40000 ALTER TABLE `media` DISABLE KEYS */;
INSERT INTO `media` VALUES (1,'https://interkom-l.ru/upload/iblock/7ab/7abd731ab6c0f3b3d084bba8c9c541b2.jpg'),(2,'https://www.boschautoparts.com/documents/647135/656978/BlueDiscPads_PDP_Carousel.jpg'),(3,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkO6luejD3BK-Pm9SIPxl5Qamf0v3EdboSFA&s'),(4,'https://cdn.britannica.com/81/124281-004-2156738E/Spark-plug.jpg');
/*!40000 ALTER TABLE `media` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oemnumber`
--

DROP TABLE IF EXISTS `oemnumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `oemnumber` (
  `IdOemNumber` int NOT NULL AUTO_INCREMENT,
  `Number` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`IdOemNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oemnumber`
--

LOCK TABLES `oemnumber` WRITE;
/*!40000 ALTER TABLE `oemnumber` DISABLE KEYS */;
INSERT INTO `oemnumber` VALUES (1,'OEM123456789'),(2,'OEM987654321'),(3,'OEM555666777'),(4,'OEM111222333');
/*!40000 ALTER TABLE `oemnumber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `IdOrder` int NOT NULL AUTO_INCREMENT,
  `IdUser` int NOT NULL,
  `OrderDate` date NOT NULL,
  `Status` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`IdOrder`),
  KEY `fk_Order_User_idx` (`IdUser`),
  CONSTRAINT `fk_Order_User` FOREIGN KEY (`IdUser`) REFERENCES `user` (`IdUser`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (6,1,'2026-05-13','Новый'),(7,2,'2026-05-17','Новый'),(11,2,'2026-05-21','Завершен'),(12,2,'2026-05-21','Завершен'),(14,1,'2026-05-20','Завершен'),(16,1,'2026-05-20','Завершен'),(17,1,'2026-06-16','Новый');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderpart`
--

DROP TABLE IF EXISTS `orderpart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderpart` (
  `IdOrder` int NOT NULL,
  `IdPart` int NOT NULL,
  `Amount` int NOT NULL,
  PRIMARY KEY (`IdOrder`,`IdPart`),
  KEY `fk_Order_has_Part_Part1_idx` (`IdPart`),
  KEY `fk_Order_has_Part_Order1_idx` (`IdOrder`),
  CONSTRAINT `fk_Order_has_Part_Order1` FOREIGN KEY (`IdOrder`) REFERENCES `order` (`IdOrder`),
  CONSTRAINT `fk_Order_has_Part_Part1` FOREIGN KEY (`IdPart`) REFERENCES `part` (`IdPart`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderpart`
--

LOCK TABLES `orderpart` WRITE;
/*!40000 ALTER TABLE `orderpart` DISABLE KEYS */;
INSERT INTO `orderpart` VALUES (6,2,2),(6,4,4),(7,1,1),(7,3,2),(11,1,2),(12,1,2),(14,1,1),(16,1,1),(17,1,1);
/*!40000 ALTER TABLE `orderpart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `part`
--

DROP TABLE IF EXISTS `part`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `part` (
  `IdPart` int NOT NULL AUTO_INCREMENT,
  `IdMedia` int NOT NULL,
  `IdCategory` int NOT NULL,
  `IdOemNumber` int NOT NULL,
  `Name` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Amount` int NOT NULL,
  `Description` varchar(5000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Weight` varchar(45) NOT NULL,
  `Volume` varchar(45) NOT NULL,
  `Price` int DEFAULT NULL,
  PRIMARY KEY (`IdPart`),
  KEY `fk_Part_Media1_idx` (`IdMedia`),
  KEY `fk_part_Category1_idx` (`IdCategory`),
  KEY `fk_part_OemNumber1_idx` (`IdOemNumber`),
  CONSTRAINT `fk_part_Category1` FOREIGN KEY (`IdCategory`) REFERENCES `category` (`IdCategory`),
  CONSTRAINT `fk_Part_Media1` FOREIGN KEY (`IdMedia`) REFERENCES `media` (`IdMedia`),
  CONSTRAINT `fk_part_OemNumber1` FOREIGN KEY (`IdOemNumber`) REFERENCES `oemnumber` (`IdOemNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `part`
--

LOCK TABLES `part` WRITE;
/*!40000 ALTER TABLE `part` DISABLE KEYS */;
INSERT INTO `part` VALUES (1,1,1,1,'Поршень двигателя 1.7L',47,'Высококачественный поршень для бензиновых двигателей.','0.5 кг','0.001 м3',1300),(2,2,2,2,'Тормозные колодки передние',120,'Колодки тормозные дисковые, комплект на переднюю ось.','1.2 кг','0.002 м3',3400),(3,3,3,3,'Амортизатор задний',40,'Газомасляный задний амортизатор для комфортной езды.','3.5 кг','0.015 м3',5000),(4,4,4,4,'Свеча зажигания иридиевая',500,'Иридиевая свеча с увеличенным сроком службы.','0.05 кг','0.0001 м3',1100);
/*!40000 ALTER TABLE `part` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profilephoto`
--

DROP TABLE IF EXISTS `profilephoto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profilephoto` (
  `IdProfilePhoto` int NOT NULL AUTO_INCREMENT,
  `Photo` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`IdProfilePhoto`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profilephoto`
--

LOCK TABLES `profilephoto` WRITE;
/*!40000 ALTER TABLE `profilephoto` DISABLE KEYS */;
INSERT INTO `profilephoto` VALUES (1,'avatar_user1.png'),(2,'avatar_user2.png'),(3,'default_avatar.png'),(4,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnISVbZgwd7PHd8W_5vtCG1ItSg1ap9d0P6Q&s'),(5,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnISVbZgwd7PHd8W_5vtCG1ItSg1ap9d0P6Q&s');
/*!40000 ALTER TABLE `profilephoto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `IdReview` int NOT NULL AUTO_INCREMENT,
  `IdPart` int NOT NULL,
  `IdUser` int NOT NULL,
  `ReviewText` varchar(5000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Rating` int NOT NULL,
  `ReviewDate` date DEFAULT NULL,
  PRIMARY KEY (`IdReview`),
  KEY `fk_Review_user1_idx` (`IdUser`),
  KEY `fk_Review_part1_idx` (`IdPart`),
  CONSTRAINT `fk_Review_part1` FOREIGN KEY (`IdPart`) REFERENCES `part` (`IdPart`),
  CONSTRAINT `fk_Review_user1` FOREIGN KEY (`IdUser`) REFERENCES `user` (`IdUser`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
INSERT INTO `review` VALUES (1,1,1,'Отличные колодки, не скрипят, тормозят мягко.',5,'2024-03-15'),(2,2,2,'Амортизаторы неплохие, но жестковаты для наших дорог.',4,'2025-03-15'),(3,1,1,'щас чет скрипят',4,'2025-03-15'),(4,2,1,'Тормоза колодки параша блять я в лексус въебаласт',1,'2026-06-15'),(5,1,1,'у меня двигатель взорвался',1,'2026-06-16'),(6,3,1,'ахахахаххахахахаха',5,'2026-06-16');
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `IdUser` int NOT NULL AUTO_INCREMENT,
  `IdProfilePhoto` int NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Login` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Password` varchar(30) NOT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `DeliveryAddress` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`IdUser`),
  KEY `fk_User_ProfilePhoto1_idx` (`IdProfilePhoto`),
  CONSTRAINT `fk_User_ProfilePhoto1` FOREIGN KEY (`IdProfilePhoto`) REFERENCES `profilephoto` (`IdProfilePhoto`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,5,'Мария Сидорова','mary_sid','1','88005553533','куда то'),(2,3,'Дмитрий Кузнецов','dimon99','userpass3',NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-21 18:47:09
