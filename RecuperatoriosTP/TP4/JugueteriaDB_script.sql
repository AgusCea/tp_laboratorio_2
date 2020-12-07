USE [master]
GO
/****** Object:  Database [Jugueteria]    Script Date: 7/12/2020 09:06:21 ******/
CREATE DATABASE [Jugueteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jugueteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Jugueteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jugueteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Jugueteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Jugueteria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jugueteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jugueteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jugueteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jugueteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jugueteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jugueteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jugueteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jugueteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jugueteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jugueteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Jugueteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jugueteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jugueteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jugueteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jugueteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jugueteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jugueteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jugueteria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Jugueteria] SET  MULTI_USER 
GO
ALTER DATABASE [Jugueteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jugueteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jugueteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jugueteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Jugueteria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Jugueteria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Jugueteria] SET QUERY_STORE = OFF
GO
USE [Jugueteria]
GO
/****** Object:  Table [dbo].[Pelotas]    Script Date: 7/12/2020 09:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelotas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deporte] [varchar](50) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_Pelotas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoJuegos]    Script Date: 7/12/2020 09:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoJuegos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_VideoJuegos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pelotas] ON 

INSERT [dbo].[Pelotas] ([id], [deporte], [marca], [precio], [stock]) VALUES (1, N'Futbol', N'Nike', 1166, 10)
INSERT [dbo].[Pelotas] ([id], [deporte], [marca], [precio], [stock]) VALUES (2, N'Basquet', N'Molten', 2463, 6)
INSERT [dbo].[Pelotas] ([id], [deporte], [marca], [precio], [stock]) VALUES (3, N'Rugby', N'Gilbert', 1266, 6)
INSERT [dbo].[Pelotas] ([id], [deporte], [marca], [precio], [stock]) VALUES (4, N'Voley', N'Nike', 1173, 4)
SET IDENTITY_INSERT [dbo].[Pelotas] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoJuegos] ON 

INSERT [dbo].[VideoJuegos] ([id], [nombre], [marca], [precio], [stock]) VALUES (1, N'Dark Souls 3', N'From Software', 1436, 3)
INSERT [dbo].[VideoJuegos] ([id], [nombre], [marca], [precio], [stock]) VALUES (3, N'Fifa 21', N'Electronic Arts', 1933, 6)
INSERT [dbo].[VideoJuegos] ([id], [nombre], [marca], [precio], [stock]) VALUES (5, N'Resident Evil 7: Biohazard', N'Capcom', 1016, 2)
INSERT [dbo].[VideoJuegos] ([id], [nombre], [marca], [precio], [stock]) VALUES (6, N'God of War 4', N'Sony Interactive Entertainment', 1100, 4)
INSERT [dbo].[VideoJuegos] ([id], [nombre], [marca], [precio], [stock]) VALUES (7, N'Sekiro: Shadows Die Twice', N'From Software', 1600, 1)
SET IDENTITY_INSERT [dbo].[VideoJuegos] OFF
GO
USE [master]
GO
ALTER DATABASE [Jugueteria] SET  READ_WRITE 
GO
