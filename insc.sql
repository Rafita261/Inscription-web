-- MySQL dump 10.13  Distrib 8.0.42, for Linux (x86_64)
--
-- Host: localhost    Database: Inscription
-- ------------------------------------------------------
-- Server version	8.0.42-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Annee_Univ`
--

DROP TABLE IF EXISTS `Annee_Univ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Annee_Univ` (
  `Annee` date NOT NULL,
  PRIMARY KEY (`Annee`),
  UNIQUE KEY `Annee` (`Annee`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Annee_Univ`
--

LOCK TABLES `Annee_Univ` WRITE;
/*!40000 ALTER TABLE `Annee_Univ` DISABLE KEYS */;
INSERT INTO `Annee_Univ` VALUES ('2023-09-01'),('2024-09-01');
/*!40000 ALTER TABLE `Annee_Univ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Attribut_Formulaire`
--

DROP TABLE IF EXISTS `Attribut_Formulaire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Attribut_Formulaire` (
  `NumAttribut` varchar(12) NOT NULL,
  `NomAttribut` varchar(512) DEFAULT NULL,
  `TypeAttribut` enum('text','number','radio','checkbox','date','file','email') DEFAULT NULL,
  `Obligatoire` tinyint(1) DEFAULT NULL,
  `Annee` date DEFAULT NULL,
  `CodeEcole` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`NumAttribut`),
  KEY `fk_attribut_annee` (`Annee`),
  KEY `fk_attribut_ecole` (`CodeEcole`),
  CONSTRAINT `fk_attribut_annee` FOREIGN KEY (`Annee`) REFERENCES `Annee_Univ` (`Annee`),
  CONSTRAINT `fk_attribut_ecole` FOREIGN KEY (`CodeEcole`) REFERENCES `Ecole` (`CodeEcole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Attribut_Formulaire`
--

LOCK TABLES `Attribut_Formulaire` WRITE;
/*!40000 ALTER TABLE `Attribut_Formulaire` DISABLE KEYS */;
INSERT INTO `Attribut_Formulaire` VALUES ('ATT01','Téléphone','text',1,'2023-09-01','ECL01'),('ATT02','Date de naissance','date',1,'2023-09-01','ECL01'),('ATT03','CV','file',0,'2024-09-01','ECL02'),('ATT04','Sexe','radio',1,'2024-09-01','ECL02');
/*!40000 ALTER TABLE `Attribut_Formulaire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Choix`
--

DROP TABLE IF EXISTS `Choix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Choix` (
  `NumChoix` varchar(12) NOT NULL,
  `Valeur` varchar(128) DEFAULT NULL,
  `NumAttribut` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`NumChoix`),
  KEY `NumAttribut` (`NumAttribut`),
  CONSTRAINT `Choix_ibfk_1` FOREIGN KEY (`NumAttribut`) REFERENCES `Attribut_Formulaire` (`NumAttribut`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Choix`
--

LOCK TABLES `Choix` WRITE;
/*!40000 ALTER TABLE `Choix` DISABLE KEYS */;
INSERT INTO `Choix` VALUES ('CHX01','M','ATT04'),('CHX02','F','ATT04');
/*!40000 ALTER TABLE `Choix` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ecole`
--

DROP TABLE IF EXISTS `Ecole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Ecole` (
  `CodeEcole` varchar(12) NOT NULL,
  `NomEcole` varchar(32) NOT NULL,
  `Logo` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`CodeEcole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ecole`
--

LOCK TABLES `Ecole` WRITE;
/*!40000 ALTER TABLE `Ecole` DISABLE KEYS */;
INSERT INTO `Ecole` VALUES ('ECL01','École de Génie Informatique','logo1.png'),('ECL02','Institut de Commerce','logo2.png');
/*!40000 ALTER TABLE `Ecole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Etudiant`
--

DROP TABLE IF EXISTS `Etudiant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Etudiant` (
  `IM` varchar(32) NOT NULL,
  `NomEtudiant` varchar(32) NOT NULL,
  `Prenoms` varchar(32) DEFAULT NULL,
  `Email` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`IM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Etudiant`
--

LOCK TABLES `Etudiant` WRITE;
/*!40000 ALTER TABLE `Etudiant` DISABLE KEYS */;
INSERT INTO `Etudiant` VALUES ('ETU001','Diallo','Amadou Ousmane','adou.diallo@example.com'),('ETU002','Kouassi','Jean-Marie','kouassi.jean@example.com'),('ETU003','Traoré','Fatoumata','fatou.traore@example.com');
/*!40000 ALTER TABLE `Etudiant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Inscription`
--

DROP TABLE IF EXISTS `Inscription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Inscription` (
  `IM` varchar(12) NOT NULL,
  `CodeParcours` varchar(32) NOT NULL,
  `Annee` date NOT NULL,
  `Datefin` date DEFAULT NULL,
  PRIMARY KEY (`IM`,`CodeParcours`,`Annee`),
  KEY `CodeParcours` (`CodeParcours`),
  CONSTRAINT `Inscription_ibfk_1` FOREIGN KEY (`IM`) REFERENCES `Etudiant` (`IM`),
  CONSTRAINT `Inscription_ibfk_2` FOREIGN KEY (`CodeParcours`) REFERENCES `Parcours` (`CodeParcours`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Inscription`
--

LOCK TABLES `Inscription` WRITE;
/*!40000 ALTER TABLE `Inscription` DISABLE KEYS */;
/*!40000 ALTER TABLE `Inscription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Niveau`
--

DROP TABLE IF EXISTS `Niveau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Niveau` (
  `CodeNiveau` varchar(4) NOT NULL,
  `CodeParcours` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`CodeNiveau`),
  KEY `CodeParcours` (`CodeParcours`),
  CONSTRAINT `Niveau_ibfk_1` FOREIGN KEY (`CodeParcours`) REFERENCES `Parcours` (`CodeParcours`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Niveau`
--

LOCK TABLES `Niveau` WRITE;
/*!40000 ALTER TABLE `Niveau` DISABLE KEYS */;
INSERT INTO `Niveau` VALUES ('L1','PARC01'),('L2','PARC01'),('L3','PARC01'),('M1','PARC02'),('M2','PARC02');
/*!40000 ALTER TABLE `Niveau` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Parcours`
--

DROP TABLE IF EXISTS `Parcours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Parcours` (
  `CodeParcours` varchar(12) NOT NULL,
  `NomParcours` varchar(32) NOT NULL,
  `CodeEcole` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`CodeParcours`),
  KEY `CodeEcole` (`CodeEcole`),
  CONSTRAINT `Parcours_ibfk_1` FOREIGN KEY (`CodeEcole`) REFERENCES `Ecole` (`CodeEcole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Parcours`
--

LOCK TABLES `Parcours` WRITE;
/*!40000 ALTER TABLE `Parcours` DISABLE KEYS */;
INSERT INTO `Parcours` VALUES ('PARC01','Informatique Appliquée','ECL01'),('PARC02','Marketing Digital','ECL02');
/*!40000 ALTER TABLE `Parcours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Valeur_Attribut`
--

DROP TABLE IF EXISTS `Valeur_Attribut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Valeur_Attribut` (
  `IM` varchar(32) NOT NULL,
  `NumAttribut` varchar(12) NOT NULL,
  `ValeurText` varchar(64) DEFAULT NULL,
  `ValeurDate` date DEFAULT NULL,
  `ValeurNumber` int DEFAULT NULL,
  PRIMARY KEY (`IM`,`NumAttribut`),
  KEY `NumAttribut` (`NumAttribut`),
  CONSTRAINT `Valeur_Attribut_ibfk_1` FOREIGN KEY (`IM`) REFERENCES `Etudiant` (`IM`),
  CONSTRAINT `Valeur_Attribut_ibfk_2` FOREIGN KEY (`NumAttribut`) REFERENCES `Attribut_Formulaire` (`NumAttribut`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Valeur_Attribut`
--

LOCK TABLES `Valeur_Attribut` WRITE;
/*!40000 ALTER TABLE `Valeur_Attribut` DISABLE KEYS */;
INSERT INTO `Valeur_Attribut` VALUES ('ETU001','ATT01','0600112233',NULL,NULL),('ETU001','ATT02',NULL,'2001-05-22',NULL),('ETU002','ATT01','0700998877',NULL,NULL);
/*!40000 ALTER TABLE `Valeur_Attribut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Valeur_Choix`
--

DROP TABLE IF EXISTS `Valeur_Choix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Valeur_Choix` (
  `IM` varchar(12) NOT NULL,
  `NumChoix` varchar(12) NOT NULL,
  PRIMARY KEY (`IM`,`NumChoix`),
  KEY `NumChoix` (`NumChoix`),
  CONSTRAINT `Valeur_Choix_ibfk_1` FOREIGN KEY (`IM`) REFERENCES `Etudiant` (`IM`),
  CONSTRAINT `Valeur_Choix_ibfk_2` FOREIGN KEY (`NumChoix`) REFERENCES `Choix` (`NumChoix`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Valeur_Choix`
--

LOCK TABLES `Valeur_Choix` WRITE;
/*!40000 ALTER TABLE `Valeur_Choix` DISABLE KEYS */;
INSERT INTO `Valeur_Choix` VALUES ('ETU001','CHX01'),('ETU002','CHX02');
/*!40000 ALTER TABLE `Valeur_Choix` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-12 16:59:16
