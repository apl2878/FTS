USE [master]
GO
/****** Object:  Database [FoodTrade]    Script Date: 5/22/2016 1:55:35 AM ******/
CREATE DATABASE [FoodTrade]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodTrade', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FoodTrade.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodTrade_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FoodTrade_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FoodTrade] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodTrade].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodTrade] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodTrade] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodTrade] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodTrade] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodTrade] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodTrade] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodTrade] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FoodTrade] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodTrade] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodTrade] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodTrade] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodTrade] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodTrade] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodTrade] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodTrade] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodTrade] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoodTrade] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodTrade] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodTrade] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodTrade] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodTrade] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodTrade] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodTrade] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodTrade] SET RECOVERY FULL 
GO
ALTER DATABASE [FoodTrade] SET  MULTI_USER 
GO
ALTER DATABASE [FoodTrade] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodTrade] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodTrade] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodTrade] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FoodTrade]
GO
/****** Object:  Table [dbo].[Consumer]    Script Date: 5/22/2016 1:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consumer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Team] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_Consumer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/22/2016 1:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[MSRP] [money] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 5/22/2016 1:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SupplierProduct]    Script Date: 5/22/2016 1:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupplierProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[SRP] [money] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_SupplierProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Consumer] ADD  CONSTRAINT [DF_Consumer_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Consumer] ADD  CONSTRAINT [DF_Consumer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_MSRP]  DEFAULT ((0)) FOR [MSRP]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SupplierProduct] ADD  CONSTRAINT [DF_SupplierProduct_Stock]  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[SupplierProduct] ADD  CONSTRAINT [DF_SupplierProduct_Price]  DEFAULT ((0)) FOR [SRP]
GO
ALTER TABLE [dbo].[SupplierProduct] ADD  CONSTRAINT [DF_SupplierProduct_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[SupplierProduct] ADD  CONSTRAINT [DF_SupplierProduct_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SupplierProduct]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierProduct] CHECK CONSTRAINT [FK_SupplierProduct_Product]
GO
ALTER TABLE [dbo].[SupplierProduct]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProduct_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierProduct] CHECK CONSTRAINT [FK_SupplierProduct_Supplier]
GO
USE [master]
GO
ALTER DATABASE [FoodTrade] SET  READ_WRITE 
GO
