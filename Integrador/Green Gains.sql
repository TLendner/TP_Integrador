USE [master]
GO
/****** Object:  Database [Green Gains]    Script Date: 30/3/2025 14:52:31 ******/
CREATE DATABASE [Green Gains]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Green Gains', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Green Gains.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Green Gains_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Green Gains_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Green Gains] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Green Gains].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Green Gains] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Green Gains] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Green Gains] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Green Gains] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Green Gains] SET ARITHABORT OFF 
GO
ALTER DATABASE [Green Gains] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Green Gains] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Green Gains] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Green Gains] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Green Gains] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Green Gains] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Green Gains] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Green Gains] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Green Gains] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Green Gains] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Green Gains] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Green Gains] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Green Gains] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Green Gains] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Green Gains] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Green Gains] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Green Gains] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Green Gains] SET RECOVERY FULL 
GO
ALTER DATABASE [Green Gains] SET  MULTI_USER 
GO
ALTER DATABASE [Green Gains] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Green Gains] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Green Gains] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Green Gains] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Green Gains] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Green Gains] SET QUERY_STORE = OFF
GO
USE [Green Gains]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[Id_compra] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Id_producto] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[Id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[id_historial] [int] IDENTITY(1,1) NOT NULL,
	[fecha_reciclaje] [date] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[id_historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[nombre] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
	[calificacion] [int] NOT NULL,
	[imagen] [varbinary](max) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TachosVerdes]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TachosVerdes](
	[Id_tacho] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Ubicacion] [geography] NOT NULL,
 CONSTRAINT [PK__TachosVe__3214EC07C1BED2D8] PRIMARY KEY CLUSTERED 
(
	[Id_tacho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/3/2025 14:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[mail] [varchar](50) NOT NULL,
	[puntos] [int]  NULL,
	[admin] [bit] NOT NULL,
	[pregunta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([id_categoria], [nombre]) VALUES (1, N'botellas')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
INSERT [dbo].[Productos] ([id_producto], [descripcion], [nombre], [stock], [puntos], [id_categoria], [calificacion], [imagen]) VALUES (1, N'hola', N'botella', 5, 5, 1, 5, NULL)
GO
SET IDENTITY_INSERT [dbo].[TachosVerdes] ON 

INSERT [dbo].[TachosVerdes] ([Id_tacho], [Nombre], [Descripcion], [Ubicacion]) VALUES (1, N'Tacho Verde 1', N'Tacho cerca de la plaza', 0xE6100000010CED40E8CD184F41C062FB64F068374DC0)
INSERT [dbo].[TachosVerdes] ([Id_tacho], [Nombre], [Descripcion], [Ubicacion]) VALUES (2, N'Tacho Verde 2', N'Tacho en el parque', 0xE6100000010CF697DD93874D41C0C442AD69DE314DC0)
INSERT [dbo].[TachosVerdes] ([Id_tacho], [Nombre], [Descripcion], [Ubicacion]) VALUES (3, N'Tacho Verde 3', N'Tacho cerca de la escuela', 0xE6100000010CCDCCCCCCCC4C41C0713D0AD7A3304DC0)
SET IDENTITY_INSERT [dbo].[TachosVerdes] OFF
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_id_puntos]  DEFAULT ((0)) FOR [puntos]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_admin]  DEFAULT ((0)) FOR [admin]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Productos] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Productos]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuario] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuario]
GO
ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Usuario]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
USE [master]
GO
ALTER DATABASE [Green Gains] SET  READ_WRITE 
GO
