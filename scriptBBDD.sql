USE [master]
GO
/****** Object:  Database [StarWars]    Script Date: 06/09/2021 11:04:39 ******/
CREATE DATABASE [StarWars]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StarWars', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\StarWars.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StarWars_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\StarWars_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StarWars] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StarWars].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StarWars] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StarWars] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StarWars] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StarWars] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StarWars] SET ARITHABORT OFF 
GO
ALTER DATABASE [StarWars] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StarWars] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StarWars] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StarWars] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StarWars] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StarWars] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StarWars] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StarWars] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StarWars] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StarWars] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StarWars] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StarWars] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StarWars] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StarWars] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StarWars] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StarWars] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StarWars] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StarWars] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StarWars] SET  MULTI_USER 
GO
ALTER DATABASE [StarWars] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StarWars] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StarWars] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StarWars] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StarWars] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StarWars] SET QUERY_STORE = OFF
GO
USE [StarWars]
GO
/****** Object:  Table [dbo].[Armies]    Script Date: 06/09/2021 11:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armies](
	[idArmy] [int] IDENTITY(1,1) NOT NULL,
	[armyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Armies] PRIMARY KEY CLUSTERED 
(
	[idArmy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 06/09/2021 11:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[idShip] [int] IDENTITY(1,1) NOT NULL,
	[idArmy] [int] NULL,
	[shipName] [nvarchar](50) NULL,
	[power] [int] NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[idShip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Weapons]    Script Date: 06/09/2021 11:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weapons](
	[idWeapon] [int] IDENTITY(1,1) NOT NULL,
	[idShip] [int] NULL,
	[weaponName] [nvarchar](150) NULL,
	[power] [int] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Weapons] PRIMARY KEY CLUSTERED 
(
	[idWeapon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Armies] ON 

INSERT [dbo].[Armies] ([idArmy], [armyName]) VALUES (1, N'Imperio (lado oscuro)')
INSERT [dbo].[Armies] ([idArmy], [armyName]) VALUES (2, N'Resistencia')
SET IDENTITY_INSERT [dbo].[Armies] OFF
GO
SET IDENTITY_INSERT [dbo].[Ships] ON 

INSERT [dbo].[Ships] ([idShip], [idArmy], [shipName], [power]) VALUES (1, 1, N'Estrella de la muerte', 2500)
INSERT [dbo].[Ships] ([idShip], [idArmy], [shipName], [power]) VALUES (2, 1, N'AT-AT', 100)
INSERT [dbo].[Ships] ([idShip], [idArmy], [shipName], [power]) VALUES (3, 2, N'X-Wins', 600)
INSERT [dbo].[Ships] ([idShip], [idArmy], [shipName], [power]) VALUES (4, 2, N'Halcón Milenario', 400)
SET IDENTITY_INSERT [dbo].[Ships] OFF
GO
SET IDENTITY_INSERT [dbo].[Weapons] ON 

INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (1, 1, N'Superláser ', 2000, 1)
INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (2, 2, N'Laser', 200, 2)
INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (3, 3, N'Laser doble', 200, 2)
INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (4, 3, N'Bomba', 1000, 1)
INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (5, 4, N'Laser trasero', 200, 1)
INSERT [dbo].[Weapons] ([idWeapon], [idShip], [weaponName], [power], [cantidad]) VALUES (6, 1, N'Torretas', 50, 1000)
SET IDENTITY_INSERT [dbo].[Weapons] OFF
GO
ALTER TABLE [dbo].[Ships]  WITH CHECK ADD  CONSTRAINT [FK_Ships_Armies] FOREIGN KEY([idArmy])
REFERENCES [dbo].[Armies] ([idArmy])
GO
ALTER TABLE [dbo].[Ships] CHECK CONSTRAINT [FK_Ships_Armies]
GO
ALTER TABLE [dbo].[Weapons]  WITH CHECK ADD  CONSTRAINT [FK_Weapons_Ships] FOREIGN KEY([idShip])
REFERENCES [dbo].[Ships] ([idShip])
GO
ALTER TABLE [dbo].[Weapons] CHECK CONSTRAINT [FK_Weapons_Ships]
GO
USE [master]
GO
ALTER DATABASE [StarWars] SET  READ_WRITE 
GO
