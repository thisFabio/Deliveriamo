USE [master]
GO
/****** Object:  Database [DeliveriamoDB]    Script Date: 27/09/2022 07:39:56 ******/
CREATE DATABASE [DeliveriamoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeliveriamoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeliveriamoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeliveriamoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeliveriamoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DeliveriamoDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeliveriamoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeliveriamoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeliveriamoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeliveriamoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DeliveriamoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeliveriamoDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DeliveriamoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DeliveriamoDB] SET  MULTI_USER 
GO
ALTER DATABASE [DeliveriamoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeliveriamoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeliveriamoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeliveriamoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DeliveriamoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DeliveriamoDB] SET QUERY_STORE = OFF
GO
USE [DeliveriamoDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessType]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessTypeName] [nvarchar](max) NOT NULL,
	[BusinessTypeDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BusinessType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[OrderDescription] [nvarchar](max) NULL,
	[OrderTotalAmount] [decimal](18, 2) NOT NULL,
	[OrderCreationDateTime] [datetime2](7) NOT NULL,
	[DeliveryTime] [decimal](18, 2) NOT NULL,
	[LastUpdateDateTime] [datetime2](7) NOT NULL,
	[OrderStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PriceUnit] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Barcode] [nvarchar](max) NULL,
	[UrlImage] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Firstname] [nvarchar](max) NOT NULL,
	[Lastname] [nvarchar](max) NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[RoleId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[ShopKeeper] [bit] NOT NULL,
	[ExtendedCompanyName] [nvarchar](max) NULL,
	[BusinessName] [nvarchar](max) NULL,
	[VatNumber] [nvarchar](max) NULL,
	[CompanyStreetAddress] [nvarchar](max) NULL,
	[CompanyCivicNumber] [nvarchar](max) NULL,
	[CompanyPostalCode] [nvarchar](max) NULL,
	[CompanyCity] [nvarchar](max) NULL,
	[CompanyCountry] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[BusinessTypeId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProduct]    Script Date: 27/09/2022 07:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220822103435_urlImage', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823044125_shopkeepertypeid', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825060939_deletecategory', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825072135_DeleteCategory2', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220826131901_provacascade', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828085925_cascadeoption', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828091418_cascadeoption2', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828105143_OrderTable', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220917094613_fixedUserTable', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220917095239_fixedUserForeignKey', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220917100231_deletedShopKeeperTypeColumn', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220919052335_businessType2', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220923202822_newOrderTableFields', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220924054000_updateOrderandProductTables', N'6.0.6')
GO
SET IDENTITY_INSERT [dbo].[BusinessType] ON 

INSERT [dbo].[BusinessType] ([Id], [BusinessTypeName], [BusinessTypeDescription]) VALUES (1, N'Ristorante', N'Ristorazione')
INSERT [dbo].[BusinessType] ([Id], [BusinessTypeName], [BusinessTypeDescription]) VALUES (2, N'Supermercato', N'Distribuzione')
INSERT [dbo].[BusinessType] ([Id], [BusinessTypeName], [BusinessTypeDescription]) VALUES (3, N'Negozio', N'Oggettistica')
SET IDENTITY_INSERT [dbo].[BusinessType] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Ristorazione', N'Ristoranti')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Alimentari', N'Negozio aliment')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (9, N'Vineria', N'Vineria')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (11, N'giocattoleria', N'giocattoli')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserId], [PaymentMethod], [OrderDescription], [OrderTotalAmount], [OrderCreationDateTime], [DeliveryTime], [LastUpdateDateTime], [OrderStatus]) VALUES (1, 1, N'Credit Card', N'schimica dal kebabbaro', CAST(15.00 AS Decimal(18, 2)), CAST(N'2022-09-24T08:09:58.1436940' AS DateTime2), CAST(45.00 AS Decimal(18, 2)), CAST(N'2022-09-24T08:09:58.1437706' AS DateTime2), N'completato')
INSERT [dbo].[Order] ([Id], [UserId], [PaymentMethod], [OrderDescription], [OrderTotalAmount], [OrderCreationDateTime], [DeliveryTime], [LastUpdateDateTime], [OrderStatus]) VALUES (2, 1, N'Credit Card', N'schimicazza', CAST(20.00 AS Decimal(18, 2)), CAST(N'2022-09-26T06:18:20.3752443' AS DateTime2), CAST(45.00 AS Decimal(18, 2)), CAST(N'2022-09-26T06:18:20.4059341' AS DateTime2), N'WaitingForApproval')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderProduct] ON 

INSERT [dbo].[OrderProduct] ([Id], [OrderId], [ProductId]) VALUES (1, 1, 8)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [ProductId]) VALUES (2, 2, 8)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [ProductId]) VALUES (3, 2, 22)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [PriceUnit], [Description], [CategoryId], [Barcode], [UrlImage], [Status], [CreationTime], [LastUpdate]) VALUES (8, N'Kebab', CAST(2.50 AS Decimal(18, 2)), N'panino', 1, N'3564685', N'https://recipesblob.oetker.com/files/1477b95c4c434225a977caedefd4f5ea/43df75bae33b4c71a9e66072f96b6f0f/964x526/kebabjpg.webp', 1, CAST(N'2022-08-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [PriceUnit], [Description], [CategoryId], [Barcode], [UrlImage], [Status], [CreationTime], [LastUpdate]) VALUES (18, N'Champagne', CAST(400.00 AS Decimal(18, 2)), N'Vino', 9, N'w43476', N'https://images.vivino.com/thumbs/VRFy7lnWRUmR5v7HIOsJpw_pb_x600.png', 1, CAST(N'2022-07-06T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-06T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [PriceUnit], [Description], [CategoryId], [Barcode], [UrlImage], [Status], [CreationTime], [LastUpdate]) VALUES (22, N'Io non ho paura', CAST(7.50 AS Decimal(18, 2)), N'Libro Nicolò', 9, N'w2409tu8', N'https://images-na.ssl-images-amazon.com/images/I/81b2zZjzeqL.jpg', 1, CAST(N'2022-07-28T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-29T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Dob], [Gender], [PhoneNumber], [RoleId], [Enabled], [ShopKeeper], [ExtendedCompanyName], [BusinessName], [VatNumber], [CompanyStreetAddress], [CompanyCivicNumber], [CompanyPostalCode], [CompanyCity], [CompanyCountry], [ImageUrl], [BusinessTypeId]) VALUES (1, N'string', N'b45cffe084dd3d20d928bee85e7b0f21', N'burney', N'Mcneil', CAST(N'2022-08-22T22:29:19.2133333' AS DateTime2), N'M', N'0680020364', 1, 1, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Dob], [Gender], [PhoneNumber], [RoleId], [Enabled], [ShopKeeper], [ExtendedCompanyName], [BusinessName], [VatNumber], [CompanyStreetAddress], [CompanyCivicNumber], [CompanyPostalCode], [CompanyCity], [CompanyCountry], [ImageUrl], [BusinessTypeId]) VALUES (3, N'flavione1@twiga.com', N'63c3f28b4ed400f612f7ed20b7534000', N'Flavio', N'Briatore', CAST(N'1942-09-15T09:51:34.2400000' AS DateTime2), N'M', N'+377 99 99 25 50', 2, 1, 1, N'Twiga Montecarlo PLY', N'Twiga', N'1230', N'Avenue Princesse', N'10', N'98000', N'Montecarlo', N'Principato di Monaco', NULL, 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Dob], [Gender], [PhoneNumber], [RoleId], [Enabled], [ShopKeeper], [ExtendedCompanyName], [BusinessName], [VatNumber], [CompanyStreetAddress], [CompanyCivicNumber], [CompanyPostalCode], [CompanyCity], [CompanyCountry], [ImageUrl], [BusinessTypeId]) VALUES (4, N'crazy.management@crazypizza.com', N'297aae72cc4d0d068f46a9158469e34d', N'Flavio', N'Briatore', CAST(N'1942-09-15T09:51:34.2400000' AS DateTime2), N'M', N'+39 02 20 02 22', 2, 1, 1, N'Crazy Pizza S.r.l', N'Crazy Pizza', N'1111111', N'Via Ravizza', N'12', N'20100', N'Milano', N'Italia', N'https://www.scattidigusto.it/wp-content/uploads/2020/08/pizza-margherita-Crazy-Pizza-Flavio-Briatore.jpeg', 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Dob], [Gender], [PhoneNumber], [RoleId], [Enabled], [ShopKeeper], [ExtendedCompanyName], [BusinessName], [VatNumber], [CompanyStreetAddress], [CompanyCivicNumber], [CompanyPostalCode], [CompanyCity], [CompanyCountry], [ImageUrl], [BusinessTypeId]) VALUES (5, N'zoo.plus@zooplus.it', N'dc1d252540c77435ae6d4d9090df0a85', N'Fabrizio', N'Albona', CAST(N'1982-04-25T09:51:34.2400000' AS DateTime2), N'M', N'+39 02 20 02 22', 2, 1, 1, N'Zoo Plus S.r.l', N'Zoo Plus', N'334445667', N'Via del corso', N'132', N'34570', N'Matera', N'Italia', N'https://www.focus.it/codice-sconto/static/shop/8122/logo/Codice-Sconto-Zooplus-2017.png?width=200&height=200', 1)
INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Dob], [Gender], [PhoneNumber], [RoleId], [Enabled], [ShopKeeper], [ExtendedCompanyName], [BusinessName], [VatNumber], [CompanyStreetAddress], [CompanyCivicNumber], [CompanyPostalCode], [CompanyCity], [CompanyCountry], [ImageUrl], [BusinessTypeId]) VALUES (6, N'alimentari.concetta@libero.it', N'693b28d4d42c8fafe0f1d43d25ebe7d0', N'Concetta', N'De vitis', CAST(N'1960-08-22T09:51:34.2400000' AS DateTime2), N'F', N'+39 084 20 02 22', 2, 1, 1, N'Alimentari Concetta S.r.l', N'Alimentari Concetta', N'334445667', N'Traversa Sambuco', N'19', N'81046', N'Grazzanise', N'Italia', N'https://www.ilprincipedeisapori.it/wp-content/uploads/2019/03/IMG_0022.jpg', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProduct] ON 

INSERT [dbo].[UserProduct] ([Id], [ProductId], [UserId]) VALUES (2, 8, 1)
SET IDENTITY_INSERT [dbo].[UserProduct] OFF
GO
/****** Object:  Index [IX_OrderProduct_OrderId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_OrderId] ON [dbo].[OrderProduct]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProduct_ProductId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_ProductId] ON [dbo].[OrderProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_BusinessTypeId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_User_BusinessTypeId] ON [dbo].[User]
(
	[BusinessTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_RoleId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_User_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserProduct_ProductId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_UserProduct_ProductId] ON [dbo].[UserProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserProduct_UserId]    Script Date: 27/09/2022 07:39:56 ******/
CREATE NONCLUSTERED INDEX [IX_UserProduct_UserId] ON [dbo].[UserProduct]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [LastUpdateDateTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__BusinessTy__6E01572D]  DEFAULT ((0)) FOR [BusinessTypeId]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order_OrderId]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_BusinessType_BusinessTypeId] FOREIGN KEY([BusinessTypeId])
REFERENCES [dbo].[BusinessType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_BusinessType_BusinessTypeId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleId]
GO
ALTER TABLE [dbo].[UserProduct]  WITH CHECK ADD  CONSTRAINT [FK_UserProduct_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProduct] CHECK CONSTRAINT [FK_UserProduct_Product_ProductId]
GO
ALTER TABLE [dbo].[UserProduct]  WITH CHECK ADD  CONSTRAINT [FK_UserProduct_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserProduct] CHECK CONSTRAINT [FK_UserProduct_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [DeliveriamoDB] SET  READ_WRITE 
GO
