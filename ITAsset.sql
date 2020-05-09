USE [master]
GO
/****** Object:  Database [.ITASSET]    Script Date: 5/7/2020 12:09:28 PM ******/
CREATE DATABASE [.ITASSET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'.ITASSET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\.ITASSET.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'.ITASSET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\.ITASSET_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [.ITASSET] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [.ITASSET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [.ITASSET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [.ITASSET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [.ITASSET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [.ITASSET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [.ITASSET] SET ARITHABORT OFF 
GO
ALTER DATABASE [.ITASSET] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [.ITASSET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [.ITASSET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [.ITASSET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [.ITASSET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [.ITASSET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [.ITASSET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [.ITASSET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [.ITASSET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [.ITASSET] SET  DISABLE_BROKER 
GO
ALTER DATABASE [.ITASSET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [.ITASSET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [.ITASSET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [.ITASSET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [.ITASSET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [.ITASSET] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [.ITASSET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [.ITASSET] SET RECOVERY FULL 
GO
ALTER DATABASE [.ITASSET] SET  MULTI_USER 
GO
ALTER DATABASE [.ITASSET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [.ITASSET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [.ITASSET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [.ITASSET] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [.ITASSET] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'.ITASSET', N'ON'
GO
ALTER DATABASE [.ITASSET] SET QUERY_STORE = OFF
GO
USE [.ITASSET]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/7/2020 12:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Authentication] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [.ITASSET] SET  READ_WRITE 
GO