USE [master]
GO
/****** Object:  Database [pr9901_20]    Script Date: 22.06.2022 21:11:35 ******/
CREATE DATABASE [pr9901_20]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pr9901_20', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pr9901_20.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pr9901_20_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pr9901_20_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pr9901_20].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pr9901_20] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pr9901_20] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pr9901_20] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pr9901_20] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pr9901_20] SET ARITHABORT OFF 
GO
ALTER DATABASE [pr9901_20] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [pr9901_20] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pr9901_20] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pr9901_20] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pr9901_20] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pr9901_20] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pr9901_20] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pr9901_20] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pr9901_20] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pr9901_20] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pr9901_20] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pr9901_20] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pr9901_20] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pr9901_20] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pr9901_20] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pr9901_20] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pr9901_20] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pr9901_20] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pr9901_20] SET  MULTI_USER 
GO
ALTER DATABASE [pr9901_20] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pr9901_20] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pr9901_20] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pr9901_20] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pr9901_20] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pr9901_20] SET QUERY_STORE = OFF
GO
USE [pr9901_20]
GO
/****** Object:  User [loric]    Script Date: 22.06.2022 21:11:47 ******/
CREATE USER [loric] FOR LOGIN [loric] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Kvartira]    Script Date: 22.06.2022 21:11:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kvartira](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ploshad] [float] NULL,
	[kolvo_prozhiv] [int] NOT NULL,
	[adres] [varchar](150) NULL,
	[platelshik] [int] NULL,
 CONSTRAINT [PK_Kvartira] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kvitanzia]    Script Date: 22.06.2022 21:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kvitanzia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[platelshik] [int] NULL,
	[kvartira] [int] NULL,
	[srok] [date] NULL,
	[data_pred] [date] NULL,
	[data_posl] [date] NULL,
	[summa] [float] NULL,
	[peni] [float] NULL,
 CONSTRAINT [PK_Kvitanzia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platelshik]    Script Date: 22.06.2022 21:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platelshik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fam] [varchar](100) NULL,
	[name] [varchar](100) NULL,
 CONSTRAINT [PK_Platelshik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Visible_Kvitanzia]    Script Date: 22.06.2022 21:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Visible_Kvitanzia] AS
Select k.id AS ИД, RTRIM(p.fam) + ' ' + RTRIM(p.name) AS Плательщик, kv.adres AS Квартира, data_pred AS 'Предыдущие показания', srok AS 'Крайний срок', data_posl AS 'Последние начисления', summa AS Сумма, peni AS Пени from Kvitanzia k inner join Platelshik p on k.platelshik = p.id inner join Kvartira kv on k.kvartira = kv.id



GO
/****** Object:  Table [dbo].[History]    Script Date: 22.06.2022 21:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ID_kvitanzii] [int] NOT NULL,
	[Operation] [nvarchar](200) NOT NULL,
	[Date_operation] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kvar]    Script Date: 22.06.2022 21:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kvar](
	[id] [int] NOT NULL,
	[ploshad] [varchar](100) NOT NULL,
	[kolvochel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kvitanciya]    Script Date: 22.06.2022 21:11:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kvitanciya](
	[id] [int] NOT NULL,
	[summa] [float] NOT NULL,
	[peni] [float] NULL,
	[datepredpokaz] [date] NULL,
	[datepocledpokaz] [date] NULL,
	[platel] [int] NOT NULL,
	[kvar] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[platel]    Script Date: 22.06.2022 21:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[platel](
	[id] [int] NOT NULL,
	[fam] [varchar](100) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vladenie]    Script Date: 22.06.2022 21:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vladenie](
	[id] [int] NOT NULL,
	[platel] [varchar](100) NOT NULL,
	[kvar] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (1, 24, N'Добавлена квитанция, плательщиком 3 на сумму 2050 рубля', CAST(N'2022-06-22T20:51:14.090' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (2, 23, N'Удалена квитанция, плательщика 3 на сумму 2050 рубля', CAST(N'2022-06-22T20:52:00.740' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (3, 17, N'Удалена квитанция, плательщика 14 на сумму 1234 рубля', CAST(N'2022-06-22T20:52:44.920' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (4, 18, N'Удалена квитанция, плательщика 3 на сумму 2050 рубля', CAST(N'2022-06-22T20:52:44.920' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (5, 20, N'Удалена квитанция, плательщика 17 на сумму 1223 рубля', CAST(N'2022-06-22T20:52:44.920' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (6, 21, N'Удалена квитанция, плательщика 3 на сумму 2050 рубля', CAST(N'2022-06-22T20:52:44.920' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (7, 24, N'Удалена квитанция, плательщика 3 на сумму 2050 рубля', CAST(N'2022-06-22T20:52:44.920' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (8, 5, N'Изменена квитанция, плательщика 2 на сумму 1300 рубля', CAST(N'2022-06-22T20:55:33.463' AS DateTime))
INSERT [dbo].[History] ([Id], [ID_kvitanzii], [Operation], [Date_operation]) VALUES (9, 25, N'Добавлена квитанция, плательщиком 18 на сумму 1567 рубля', CAST(N'2022-06-22T20:59:35.387' AS DateTime))
SET IDENTITY_INSERT [dbo].[History] OFF
INSERT [dbo].[kvar] ([id], [ploshad], [kolvochel]) VALUES (1, N'130 м квадратных', 1)
INSERT [dbo].[kvar] ([id], [ploshad], [kolvochel]) VALUES (2, N'230 м квадратных', 3)
INSERT [dbo].[kvar] ([id], [ploshad], [kolvochel]) VALUES (3, N'190 м квадратных', 2)
SET IDENTITY_INSERT [dbo].[Kvartira] ON 

INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (1, 20, 2, N'Великий Новгород Кочетова 3 100', 1)
INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (2, 15, 1, N'Великий Новгород Ломоносова 10 6', 2)
INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (3, 30, 3, N'Великий Новгород Мира 29 36', 3)
INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (14, 8, 1, N'Попова 10 123', 14)
INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (15, 12, 1, N'Нехинская 6 124', 17)
INSERT [dbo].[Kvartira] ([id], [ploshad], [kolvo_prozhiv], [adres], [platelshik]) VALUES (16, 9, 1, N'Мира 7 23', 18)
SET IDENTITY_INSERT [dbo].[Kvartira] OFF
INSERT [dbo].[kvitanciya] ([id], [summa], [peni], [datepredpokaz], [datepocledpokaz], [platel], [kvar]) VALUES (1, 1890, 0, CAST(N'2022-01-17' AS Date), CAST(N'2022-02-17' AS Date), 1, 3)
INSERT [dbo].[kvitanciya] ([id], [summa], [peni], [datepredpokaz], [datepocledpokaz], [platel], [kvar]) VALUES (2, 2890, 0, CAST(N'2022-01-15' AS Date), CAST(N'2022-02-15' AS Date), 2, 1)
INSERT [dbo].[kvitanciya] ([id], [summa], [peni], [datepredpokaz], [datepocledpokaz], [platel], [kvar]) VALUES (3, 1590, 0, CAST(N'2022-01-17' AS Date), CAST(N'2022-02-15' AS Date), 3, 2)
SET IDENTITY_INSERT [dbo].[Kvitanzia] ON 

INSERT [dbo].[Kvitanzia] ([id], [platelshik], [kvartira], [srok], [data_pred], [data_posl], [summa], [peni]) VALUES (5, 2, 2, CAST(N'2022-04-30' AS Date), CAST(N'2022-03-30' AS Date), CAST(N'2022-05-02' AS Date), 1300, 150)
INSERT [dbo].[Kvitanzia] ([id], [platelshik], [kvartira], [srok], [data_pred], [data_posl], [summa], [peni]) VALUES (7, 1, 1, CAST(N'2022-06-22' AS Date), CAST(N'2022-06-22' AS Date), CAST(N'2022-06-22' AS Date), 1850, 150)
INSERT [dbo].[Kvitanzia] ([id], [platelshik], [kvartira], [srok], [data_pred], [data_posl], [summa], [peni]) VALUES (9, 3, 3, CAST(N'2022-05-30' AS Date), CAST(N'2022-04-30' AS Date), CAST(N'2022-06-03' AS Date), 2090, 1500)
INSERT [dbo].[Kvitanzia] ([id], [platelshik], [kvartira], [srok], [data_pred], [data_posl], [summa], [peni]) VALUES (25, 18, 16, CAST(N'2022-06-23' AS Date), CAST(N'2022-06-08' AS Date), CAST(N'2022-06-11' AS Date), 1567, 54)
SET IDENTITY_INSERT [dbo].[Kvitanzia] OFF
INSERT [dbo].[platel] ([id], [fam], [name], [adres]) VALUES (1, N'Иванов', N'Иван Иванович', N'Великий Новгород Кочетова 3 100')
INSERT [dbo].[platel] ([id], [fam], [name], [adres]) VALUES (2, N'Петров', N'Петр Петрович', N'Великий Новгород Ломоносова 10 6')
INSERT [dbo].[platel] ([id], [fam], [name], [adres]) VALUES (3, N'Алексеев', N'Алексей Алексеевич', N'Великий Новгород Мира 29 36')
SET IDENTITY_INSERT [dbo].[Platelshik] ON 

INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (1, N'Иванов', N'Иван Иванович')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (2, N'Петров', N'Петр Петрович')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (3, N'Алексеев', N'Алексей Алексеевич')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (14, N'Сизова', N'Анна Эдуардовна')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (15, N'Сизова', N'Анна Эдуардовна')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (16, N'Сизова', N'Анна Эдуардовна')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (17, N'Васильев', N'Василий Васильевич')
INSERT [dbo].[Platelshik] ([id], [fam], [name]) VALUES (18, N'Васильева', N'Василиса Васильевна')
SET IDENTITY_INSERT [dbo].[Platelshik] OFF
INSERT [dbo].[vladenie] ([id], [platel], [kvar]) VALUES (1, N'1', 3)
INSERT [dbo].[vladenie] ([id], [platel], [kvar]) VALUES (2, N'2', 1)
INSERT [dbo].[vladenie] ([id], [platel], [kvar]) VALUES (3, N'3', 2)
ALTER TABLE [dbo].[History] ADD  DEFAULT (getdate()) FOR [Date_operation]
GO
ALTER TABLE [dbo].[Kvartira]  WITH CHECK ADD  CONSTRAINT [FK_Kvartira_Platelshik] FOREIGN KEY([platelshik])
REFERENCES [dbo].[Platelshik] ([id])
GO
ALTER TABLE [dbo].[Kvartira] CHECK CONSTRAINT [FK_Kvartira_Platelshik]
GO
ALTER TABLE [dbo].[Kvitanzia]  WITH CHECK ADD  CONSTRAINT [FK_kvitanzia_Kvartira] FOREIGN KEY([kvartira])
REFERENCES [dbo].[Kvartira] ([id])
GO
ALTER TABLE [dbo].[Kvitanzia] CHECK CONSTRAINT [FK_kvitanzia_Kvartira]
GO
ALTER TABLE [dbo].[Kvitanzia]  WITH CHECK ADD  CONSTRAINT [FK_kvitanzia_Platelshik] FOREIGN KEY([platelshik])
REFERENCES [dbo].[Platelshik] ([id])
GO
ALTER TABLE [dbo].[Kvitanzia] CHECK CONSTRAINT [FK_kvitanzia_Platelshik]
GO
/****** Object:  StoredProcedure [dbo].[Delete_kvitanzia]    Script Date: 22.06.2022 21:12:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_kvitanzia] (@id int)
AS
BEGIN
	SET NOCOUNT ON
	Delete Kvitanzia where id =  @id
END 
GO
/****** Object:  StoredProcedure [dbo].[Insert_Kvartira]    Script Date: 22.06.2022 21:12:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Insert_Kvartira] (@plosh float, @kolvo int, @adres varchar(150), @plat int)
AS
BEGIN
	SET NOCOUNT ON
INSERT INTO Kvartira(ploshad, kolvo_prozhiv, adres, platelshik)
VALUES		(@plosh, @kolvo, @adres, @plat)
END 
GO
/****** Object:  StoredProcedure [dbo].[Insert_Kvitanzia]    Script Date: 22.06.2022 21:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Insert_Kvitanzia] (@plat int, @kvar int, @srok date, @data_pred date, @data_posl date, @summa float, @peni float)
AS
BEGIN
	SET NOCOUNT ON
INSERT INTO Kvitanzia(platelshik, kvartira, srok, data_pred, data_posl, summa, peni)
VALUES		(@plat, @kvar, @srok, @data_pred, @data_posl, @summa, @peni)
END 
GO
/****** Object:  StoredProcedure [dbo].[Insert_Platelshik]    Script Date: 22.06.2022 21:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Insert_Platelshik] (@fm varchar(100), @nm varchar(100))
AS
BEGIN
	SET NOCOUNT ON
INSERT INTO Platelshik(fam, name)
VALUES		(@fm, @nm)
END 
GO
/****** Object:  StoredProcedure [dbo].[Update_kvitanzia]    Script Date: 22.06.2022 21:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Update_kvitanzia](@p int, @kv int, @pred_pokaz date, @sr date, @posl_nachisl date, @s float, @pen float)
AS 
BEGIN
	SET NOCOUNT ON
	Update Kvitanzia set data_pred = @pred_pokaz, data_posl = @posl_nachisl, srok = @sr, summa = @s, peni = @pen where platelshik = @p and kvartira = @kv
END 
GO
USE [master]
GO
ALTER DATABASE [pr9901_20] SET  READ_WRITE 
GO
