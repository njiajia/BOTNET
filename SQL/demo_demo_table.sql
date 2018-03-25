-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: demo
-- ------------------------------------------------------
-- Server version	5.6.25-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `demo_table`
--

DROP TABLE IF EXISTS `demo_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `demo_table` (
  `ID` int(11) NOT NULL,
  `Question` varchar(45) DEFAULT NULL,
  `correct` varchar(45) DEFAULT NULL,
  `wrong1` varchar(45) DEFAULT NULL,
  `wrong2` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Unity Demo Table';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `demo_table`
--

LOCK TABLES `demo_table` WRITE;
/*!40000 ALTER TABLE `demo_table` DISABLE KEYS */;
INSERT INTO `demo_table` VALUES (1,'Press a','a','g','v'),(2,'Press 5','5','2','0'),(3,'Press g','g','*','3'),(4,'Press +','+','f','c'),(5,'Press c','c','53','gha'),(6,'Press t','t','3','d'),(7,'Press b','b','5','w'),(8,'Press r','r','g','c'),(9,'Press 2','2','v','a'),(10,'Press 7','7','e','k'),(11,'Press \\','\\','/',';'),(12,'Press .','.','*','`'),(13,'Press [','[',']','[]'),(14,'Press q','q','f','o'),(15,'press p','p','q','m'),(16,'Press k','k','l','u'),(17,'Press v','v','f','k'),(18,'Press y','y','a','0'),(19,'Press h','h','e','k'),(20,'press 6','6','f','a'),(21,'press JITA','JITA','AMARR','RENS'),(22,'Press Nova','Nova','Luna','Helios'),(23,'Press Luminaire','Luminaire','Orvolle','Sarum'),(24,'Press Jackdaw','Jackdaw','Hecate','Svipul'),(25,'Press Moros','Moros','Naglfar','Chimera'),(26,'Press Avatar','Avatar','Ragnarok','Erebus'),(27,'Press Tengu','Tengu','Proteus','Legion'),(28,'Press Ishtar','Ishtar','Eagle','Rapier'),(29,'Press Rook','Rook','Falcon','Occator'),(30,'Press Caracal','Caracal','Cheetah','Wolf');
/*!40000 ALTER TABLE `demo_table` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-14 15:48:45
