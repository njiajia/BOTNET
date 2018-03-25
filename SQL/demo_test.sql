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
-- Table structure for table `test`
--

DROP TABLE IF EXISTS `test`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `test` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `option1` varchar(45) DEFAULT NULL,
  `option2` varchar(45) DEFAULT NULL,
  `option3` varchar(45) DEFAULT NULL,
  `option4` varchar(45) DEFAULT NULL,
  `correctAns` varchar(45) DEFAULT NULL,
  `qn1` varchar(45) DEFAULT NULL,
  `qn2` varchar(45) DEFAULT NULL,
  `qn3` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `test`
--

LOCK TABLES `test` WRITE;
/*!40000 ALTER TABLE `test` DISABLE KEYS */;
INSERT INTO `test` VALUES (1,',','}',':',';',';','var name = ','\"JON\" ',''),(2,'\"1\";','1;','[1];','\'1\';','1;','','int zone = ',''),(3,'.{};','.();',';','.<>;','.();','','moveRight ',''),(4,'()','();','.();',';','.();','','damage',''),(5,';',':','.',';;',';',' ','attack()',' '),(6,';',':','\"\"','.',';','if (hp<0){','lose()','}'),(7,'[Err]','Err','\"Err\"','\'Err\'','\"Err\"','','var errmsg = ',';'),(8,'2;','\"2\";','\'2\';','2;','2;','int x = 1;','int y = ','int z = x + y;'),(9,';','\"\"','?',':',';','','powerAttack()',NULL),(10,'return null;','return [null];','return \"null\"','return \'null\'','return null','function a(){','','}'),(11,'\"world\";','\'world\'','world','world;','\"world\";','var j = \"hello\";','var w = ','var k = j + w;'),(12,':myfn()','myfn()','= myfn','; myfn','= myfn','','function ',NULL),(13,'killed();','killed;','\"killed\";','killed.();','killed();','if (health<0){',NULL,'}'),(14,'\"welcome\";','welcome;','(welcome);','[welcome];','\"welcome\"','var a = \"You are\"','var b = ',NULL);
/*!40000 ALTER TABLE `test` ENABLE KEYS */;
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
