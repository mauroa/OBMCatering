USE [master]
GO
/****** Object:  Database [OBMCatering]    Script Date: 12/12/2019 6:18:52 PM ******/
CREATE DATABASE [OBMCatering]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OBMCatering', FILENAME = N'C:\Git\OBMCatering\db\OBMCatering.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OBMCatering_log', FILENAME = N'C:\Git\OBMCatering\db\OBMCatering_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OBMCatering] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OBMCatering].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OBMCatering] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OBMCatering] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OBMCatering] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OBMCatering] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OBMCatering] SET ARITHABORT OFF 
GO
ALTER DATABASE [OBMCatering] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OBMCatering] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OBMCatering] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OBMCatering] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OBMCatering] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OBMCatering] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OBMCatering] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OBMCatering] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OBMCatering] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OBMCatering] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OBMCatering] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OBMCatering] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OBMCatering] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OBMCatering] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OBMCatering] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OBMCatering] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OBMCatering] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OBMCatering] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OBMCatering] SET  MULTI_USER 
GO
ALTER DATABASE [OBMCatering] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OBMCatering] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OBMCatering] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OBMCatering] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [OBMCatering]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [nvarchar](50) NULL,
	[Fecha] [datetime] NOT NULL,
	[Mensaje] [nvarchar](max) NOT NULL,
	[IDTipoMensaje] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[CUIT] [nchar](11) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Domicilio] [nvarchar](max) NOT NULL,
	[IDLocalidad] [int] NOT NULL,
	[CodigoPostal] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[IDTipoCliente] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[CUIT] [nchar](11) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Domicilio] [nvarchar](max) NOT NULL,
	[IDLocalidad] [int] NOT NULL,
	[CodigoPostal] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosOrdenesCompra]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosOrdenesCompra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadosOrdenesCompra] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosRecetas]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosRecetas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadosRecetas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IDOrdenVenta] [int] NOT NULL,
	[Cobrada] [bit] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientesRecetas]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientesRecetas](
	[IDReceta] [int] NOT NULL,
	[IDIngrediente] [int] NOT NULL,
	[Cantidad] [decimal](10, 2) NOT NULL,
	[IDUnidadMedida] [int] NOT NULL,
 CONSTRAINT [PK_IngredientesReceta] PRIMARY KEY CLUSTERED 
(
	[IDReceta] ASC,
	[IDIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsOrdenesCompra]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsOrdenesCompra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDOrdenCompra] [int] NOT NULL,
	[IDIngrediente] [int] NOT NULL,
	[Cantidad] [decimal](10, 2) NOT NULL,
	[IDUnidadMedida] [int] NOT NULL,
 CONSTRAINT [PK_ItemsOrdenesCompra] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsOrdenesPago]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsOrdenesPago](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDOrdenPago] [int] NOT NULL,
	[IDItemOrdenCompra] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_ItemsOrdenesPago] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[ID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[IDProvincia] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesCompra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDOrdenVenta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IDEstadoOrdenCompra] [int] NOT NULL,
 CONSTRAINT [PK_OrdenesCompra] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesPago]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesPago](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IDProveedor] [nchar](11) NOT NULL,
	[Pagada] [bit] NOT NULL,
 CONSTRAINT [PK_OrdenesPago] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesVenta]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesVenta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [nchar](11) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Comensales] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Aprobada] [bit] NOT NULL,
 CONSTRAINT [PK_OrdenesVenta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilesUsuario]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilesUsuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PerfilesUsuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreciosIngredientes]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreciosIngredientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDIngrediente] [int] NOT NULL,
	[Precio] [decimal](10, 2) NULL,
	[Cantidad] [decimal](10, 2) NULL,
	[IDUnidadMedida] [int] NULL,
 CONSTRAINT [PK_PreciosIngredientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[CUIT] [nchar](11) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Domicilio] [nvarchar](max) NOT NULL,
	[IDLocalidad] [int] NOT NULL,
	[CodigoPostal] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ID] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recetas]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recetas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Detalle] [nvarchar](max) NULL,
	[IDEstadoReceta] [int] NOT NULL,
 CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecetasOrdenesVenta]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecetasOrdenesVenta](
	[IDOrdenVenta] [int] NOT NULL,
	[IDReceta] [int] NOT NULL,
 CONSTRAINT [PK_RecetasOrdenesVenta] PRIMARY KEY CLUSTERED 
(
	[IDOrdenVenta] ASC,
	[IDReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposClientes]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposClientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposClientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposMensajesBitacora]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposMensajesBitacora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoMensajeBitacora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesMedida]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesMedida](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unidad] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_UnidadesMedida] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/12/2019 6:18:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Nick] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IDPerfil] [int] NOT NULL,
	[CambiarPassword] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Nick] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_TipoMensajeBitacora] FOREIGN KEY([IDTipoMensaje])
REFERENCES [dbo].[TiposMensajesBitacora] ([ID])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_TipoMensajeBitacora]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuarios] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([Nick])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuarios]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([IDLocalidad])
REFERENCES [dbo].[Localidades] ([ID])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposClientes] FOREIGN KEY([IDTipoCliente])
REFERENCES [dbo].[TiposClientes] ([ID])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposClientes]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Localidades] FOREIGN KEY([IDLocalidad])
REFERENCES [dbo].[Localidades] ([ID])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Localidades]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_OrdenesVenta] FOREIGN KEY([IDOrdenVenta])
REFERENCES [dbo].[OrdenesVenta] ([ID])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_OrdenesVenta]
GO
ALTER TABLE [dbo].[IngredientesRecetas]  WITH CHECK ADD  CONSTRAINT [FK_IngredientesReceta_Ingredientes] FOREIGN KEY([IDIngrediente])
REFERENCES [dbo].[Ingredientes] ([ID])
GO
ALTER TABLE [dbo].[IngredientesRecetas] CHECK CONSTRAINT [FK_IngredientesReceta_Ingredientes]
GO
ALTER TABLE [dbo].[IngredientesRecetas]  WITH CHECK ADD  CONSTRAINT [FK_IngredientesReceta_Recetas] FOREIGN KEY([IDReceta])
REFERENCES [dbo].[Recetas] ([ID])
GO
ALTER TABLE [dbo].[IngredientesRecetas] CHECK CONSTRAINT [FK_IngredientesReceta_Recetas]
GO
ALTER TABLE [dbo].[IngredientesRecetas]  WITH CHECK ADD  CONSTRAINT [FK_IngredientesRecetas_UnidadesMedida] FOREIGN KEY([IDUnidadMedida])
REFERENCES [dbo].[UnidadesMedida] ([ID])
GO
ALTER TABLE [dbo].[IngredientesRecetas] CHECK CONSTRAINT [FK_IngredientesRecetas_UnidadesMedida]
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrdenesCompra_Ingredientes] FOREIGN KEY([IDIngrediente])
REFERENCES [dbo].[Ingredientes] ([ID])
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra] CHECK CONSTRAINT [FK_ItemsOrdenesCompra_Ingredientes]
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrdenesCompra_OrdenesCompra] FOREIGN KEY([IDOrdenCompra])
REFERENCES [dbo].[OrdenesCompra] ([ID])
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra] CHECK CONSTRAINT [FK_ItemsOrdenesCompra_OrdenesCompra]
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrdenesCompra_UnidadesMedida] FOREIGN KEY([IDUnidadMedida])
REFERENCES [dbo].[UnidadesMedida] ([ID])
GO
ALTER TABLE [dbo].[ItemsOrdenesCompra] CHECK CONSTRAINT [FK_ItemsOrdenesCompra_UnidadesMedida]
GO
ALTER TABLE [dbo].[ItemsOrdenesPago]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrdenesPago_ItemsOrdenesCompra] FOREIGN KEY([IDItemOrdenCompra])
REFERENCES [dbo].[ItemsOrdenesCompra] ([ID])
GO
ALTER TABLE [dbo].[ItemsOrdenesPago] CHECK CONSTRAINT [FK_ItemsOrdenesPago_ItemsOrdenesCompra]
GO
ALTER TABLE [dbo].[ItemsOrdenesPago]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrdenesPago_OrdenesPago] FOREIGN KEY([IDOrdenPago])
REFERENCES [dbo].[OrdenesPago] ([ID])
GO
ALTER TABLE [dbo].[ItemsOrdenesPago] CHECK CONSTRAINT [FK_ItemsOrdenesPago_OrdenesPago]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([IDProvincia])
REFERENCES [dbo].[Provincias] ([ID])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_EstadosOrdenesCompra] FOREIGN KEY([IDEstadoOrdenCompra])
REFERENCES [dbo].[EstadosOrdenesCompra] ([ID])
GO
ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_EstadosOrdenesCompra]
GO
ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesCompra_OrdenesVenta] FOREIGN KEY([IDOrdenVenta])
REFERENCES [dbo].[OrdenesVenta] ([ID])
GO
ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK_OrdenesCompra_OrdenesVenta]
GO
ALTER TABLE [dbo].[OrdenesPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPago_Proveedores] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[Proveedores] ([CUIT])
GO
ALTER TABLE [dbo].[OrdenesPago] CHECK CONSTRAINT [FK_OrdenesPago_Proveedores]
GO
ALTER TABLE [dbo].[OrdenesVenta]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesVenta_Clientes] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Clientes] ([CUIT])
GO
ALTER TABLE [dbo].[OrdenesVenta] CHECK CONSTRAINT [FK_OrdenesVenta_Clientes]
GO
ALTER TABLE [dbo].[PreciosIngredientes]  WITH CHECK ADD  CONSTRAINT [FK_PreciosIngredientes_Ingredientes] FOREIGN KEY([IDIngrediente])
REFERENCES [dbo].[Ingredientes] ([ID])
GO
ALTER TABLE [dbo].[PreciosIngredientes] CHECK CONSTRAINT [FK_PreciosIngredientes_Ingredientes]
GO
ALTER TABLE [dbo].[PreciosIngredientes]  WITH CHECK ADD  CONSTRAINT [FK_PreciosIngredientes_UnidadesMedida] FOREIGN KEY([IDUnidadMedida])
REFERENCES [dbo].[UnidadesMedida] ([ID])
GO
ALTER TABLE [dbo].[PreciosIngredientes] CHECK CONSTRAINT [FK_PreciosIngredientes_UnidadesMedida]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Localidades] FOREIGN KEY([IDLocalidad])
REFERENCES [dbo].[Localidades] ([ID])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Localidades]
GO
ALTER TABLE [dbo].[Recetas]  WITH CHECK ADD  CONSTRAINT [FK_Recetas_EstadosRecetas] FOREIGN KEY([IDEstadoReceta])
REFERENCES [dbo].[EstadosRecetas] ([ID])
GO
ALTER TABLE [dbo].[Recetas] CHECK CONSTRAINT [FK_Recetas_EstadosRecetas]
GO
ALTER TABLE [dbo].[RecetasOrdenesVenta]  WITH CHECK ADD  CONSTRAINT [FK_RecetasOrdenesVenta_OrdenesVenta] FOREIGN KEY([IDOrdenVenta])
REFERENCES [dbo].[OrdenesVenta] ([ID])
GO
ALTER TABLE [dbo].[RecetasOrdenesVenta] CHECK CONSTRAINT [FK_RecetasOrdenesVenta_OrdenesVenta]
GO
ALTER TABLE [dbo].[RecetasOrdenesVenta]  WITH CHECK ADD  CONSTRAINT [FK_RecetasOrdenesVenta_Recetas] FOREIGN KEY([IDReceta])
REFERENCES [dbo].[Recetas] ([ID])
GO
ALTER TABLE [dbo].[RecetasOrdenesVenta] CHECK CONSTRAINT [FK_RecetasOrdenesVenta_Recetas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_PerfilesUsuario] FOREIGN KEY([IDPerfil])
REFERENCES [dbo].[PerfilesUsuario] ([ID])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_PerfilesUsuario]
GO
USE [master]
GO
ALTER DATABASE [OBMCatering] SET  READ_WRITE 
GO
