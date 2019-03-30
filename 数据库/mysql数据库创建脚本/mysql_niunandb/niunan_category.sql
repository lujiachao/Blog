-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: niunan
-- ------------------------------------------------------
-- Server version	5.5.53

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
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `caname` varchar(64) DEFAULT NULL,
  `bh` varchar(64) DEFAULT NULL,
  `pbh` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'2016-09-07 21:18:25','博客','01','0',NULL),(17,'2009-09-21 21:57:43','ASP.NET','0101','01',''),(19,'2009-09-24 22:36:42','PHP','0102','01',''),(20,'2009-09-29 11:12:53','随笔','0103','01',''),(23,'2009-10-21 16:56:19','下载','0104','01',''),(24,'2009-10-22 16:09:47','javascript','0105','01',''),(25,'2009-10-22 16:50:57','SQL','0106','01',''),(26,'2009-10-30 15:23:36','正则表达式','0107','01',''),(27,'2009-11-01 19:27:51','linux','0108','01',''),(28,'2009-11-05 10:27:15','JAVA','0109','01',''),(29,'2009-11-15 15:57:37','jQuery','0110','01',''),(30,'2010-01-07 16:42:50','工具使用','0111','01',''),(31,'2011-01-29 10:49:49','原创视频','0112','01',''),(34,'2014-12-03 14:09:08','android','0114','01',''),(35,'2014-12-04 14:14:56','MSSQL','0115','01',''),(36,'2015-02-22 13:23:41','mono','0116','01',''),(37,'2015-04-29 21:45:16','WP开发','0117','01',''),(38,'2015-09-09 12:31:53','支付宝','0118','01',''),(39,'2016-03-10 15:21:16','微信支付','0119','01',''),(40,'2016-03-13 20:09:04','c#','0120','01',''),(41,'2016-03-16 00:12:36','.NET','0121','01',''),(42,'2016-03-22 13:28:51','HTML5','0122','01',''),(43,'2016-04-13 12:53:39','vs','0123','01',''),(44,'2016-05-01 21:06:20','xamarin','0124','01',''),(45,'2016-05-07 13:39:53','sqlite','0125','01',''),(46,'2016-07-30 09:47:52','WEB','0126','01',''),(47,'2016-09-22 12:53:28','win10','0127','01',''),(48,'2016-10-06 18:04:51','mon;db','0128','01',''),(49,'2016-10-13 12:03:42','开发','0129','01',''),(50,'2016-10-20 22:19:42','apache','0130','01',''),(51,'2016-10-27 11:31:49','css','0131','01',''),(52,'2016-11-17 16:04:22','html','0132','01',''),(53,'2017-02-13 18:06:39','nginx','0133','01',''),(54,'2017-02-18 15:26:47','wpf','0134','01','');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-08 22:33:09
