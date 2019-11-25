-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: testefcamara
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `listacompras`
--

DROP TABLE IF EXISTS `listacompras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `listacompras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data_lista` date DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `listacompras_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listacompras`
--

LOCK TABLES `listacompras` WRITE;
/*!40000 ALTER TABLE `listacompras` DISABLE KEYS */;
INSERT INTO `listacompras` VALUES (2,'2019-07-30',3,'Compra Mercado'),(3,'2019-07-30',1,'Compra Feira'),(4,'2019-07-30',1,'Compra Feira'),(6,'2019-11-24',6,'Escola'),(7,'2019-11-24',6,'Escola'),(8,'2019-11-24',6,'Escola'),(9,'2019-11-24',6,'Atacado'),(10,'2019-11-24',6,'Pet Shop'),(11,'2019-11-24',10,'Mercado'),(13,'2019-11-24',10,'Açougue'),(14,'2019-11-25',10,'Escola'),(15,'2019-11-25',10,'Mercado'),(16,'2019-11-25',10,'Mercado'),(17,'2019-11-25',10,'Mercado'),(18,'2019-11-25',10,'Mercado'),(19,'2019-11-25',10,'Mercado'),(20,'2019-11-25',10,'Mercado'),(21,'2019-11-25',10,'Mercado'),(22,'2019-11-25',10,'Mercado'),(23,'2019-11-25',10,'Mercado');
/*!40000 ALTER TABLE `listacompras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `comprado` tinyint(1) DEFAULT NULL,
  `id_lista` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_lista` (`id_lista`),
  CONSTRAINT `produto_ibfk_1` FOREIGN KEY (`id_lista`) REFERENCES `listacompras` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES (2,'Pão',0,3),(4,'Margarina',0,3),(5,'Sardinha',1,4),(6,'Sardinha',1,4),(7,'Ameixa',1,11),(10,'Chocolate',0,11);
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL,
  `senha` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'JeffehCG','123456789'),(3,'jeffersonn@gmail.com.br','5352334534'),(4,'jeff@gmail.com.bol','5352334534'),(5,'jeff@gmail.com.uol','5352334534'),(6,'jeff@gmail.uol','5352334534'),(7,'teste@gmail.com','dsfsadfgds'),(8,'Rodrigo@gmail.com','sdfdasfsdafa'),(9,'teste@teste.com','sdfsafas'),(10,'jeff@gmail.com','123456');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'testefcamara'
--

--
-- Dumping routines for database 'testefcamara'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-11-24 23:16:00
