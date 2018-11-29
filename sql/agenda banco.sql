USE [master]
GO

/****** Object:  Database [AgentaBanco]    Script Date: 06/10/2017 14:39:02 ******/
CREATE DATABASE [AgentaBanco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgentaBanco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AgentaBanco.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AgentaBanco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AgentaBanco_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [AgentaBanco] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgentaBanco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AgentaBanco] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AgentaBanco] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AgentaBanco] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AgentaBanco] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AgentaBanco] SET ARITHABORT OFF 
GO

ALTER DATABASE [AgentaBanco] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AgentaBanco] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AgentaBanco] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AgentaBanco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AgentaBanco] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AgentaBanco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AgentaBanco] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AgentaBanco] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AgentaBanco] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AgentaBanco] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AgentaBanco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AgentaBanco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AgentaBanco] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AgentaBanco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AgentaBanco] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AgentaBanco] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AgentaBanco] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AgentaBanco] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [AgentaBanco] SET  MULTI_USER 
GO

ALTER DATABASE [AgentaBanco] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AgentaBanco] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AgentaBanco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AgentaBanco] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [AgentaBanco] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AgentaBanco] SET  READ_WRITE 
GO

