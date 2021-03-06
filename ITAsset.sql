USE [master]
GO
/****** Object:  Database [.ITASSET]    Script Date: 6/9/2020 10:05:43 AM ******/
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
/****** Object:  Table [dbo].[AssetView]    Script Date: 6/9/2020 10:05:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetView](
	[AssetID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[AssetName] [nvarchar](50) NOT NULL,
	[PurchaseDate] [date] NOT NULL,
	[PurchaseLocation] [nvarchar](70) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetView_1] PRIMARY KEY CLUSTERED 
(
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/9/2020 10:05:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Authentication] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](30) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 6/9/2020 10:05:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AssetView] ON 

INSERT [dbo].[AssetView] ([AssetID], [VendorID], [AssetName], [PurchaseDate], [PurchaseLocation], [Status], [LastUpdate]) VALUES (1, 6, N'ASUS Motherboard', CAST(N'2020-06-04' AS Date), N'12/41 North Terrace, Bankstown, Nsw', N'Borrowing', CAST(N'2020-06-07T12:15:13.000' AS DateTime))
INSERT [dbo].[AssetView] ([AssetID], [VendorID], [AssetName], [PurchaseDate], [PurchaseLocation], [Status], [LastUpdate]) VALUES (2, 4, N'Dell Laptop', CAST(N'2020-06-01' AS Date), N'asfkdhadskfhasdkgfkjhjs', N'Borrowing', CAST(N'2020-06-07T20:06:58.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[AssetView] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FullName], [Username], [Password], [Authentication], [Email]) VALUES (1, N'JATT', N'admin', N'admin', N'Administrator', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (4, N'ATMC')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (5, N'JB Hi-Fi')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (6, N'Harvey Norman')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (7, N'DELL Center')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (8, N'ASUS Center')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (9, N'sdsdfsdf')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (10, N'asasfasf')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (11, N'Razor')
INSERT [dbo].[Vendor] ([VendorID], [VendorName]) VALUES (12, N'Apple')
SET IDENTITY_INSERT [dbo].[Vendor] OFF
GO
ALTER TABLE [dbo].[AssetView]  WITH CHECK ADD  CONSTRAINT [FK_AssetView_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([VendorID])
GO
ALTER TABLE [dbo].[AssetView] CHECK CONSTRAINT [FK_AssetView_Vendor]
GO
USE [master]
GO
ALTER DATABASE [.ITASSET] SET  READ_WRITE 
GO
