USE [master]
GO
/****** Object:  Database [Bookstore]    Script Date: 7/25/2013 1:53:00 PM ******/
CREATE DATABASE [Bookstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bookstore', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Bookstore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bookstore_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Bookstore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bookstore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bookstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bookstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bookstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bookstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bookstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bookstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bookstore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bookstore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bookstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bookstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bookstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bookstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bookstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bookstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bookstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bookstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bookstore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bookstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bookstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bookstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bookstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bookstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bookstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bookstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bookstore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bookstore] SET  MULTI_USER 
GO
ALTER DATABASE [Bookstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bookstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bookstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bookstore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Bookstore]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 7/25/2013 1:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/25/2013 1:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ISBN] [numeric](13, 0) NULL,
	[Price] [money] NULL,
	[Website] [varchar](255) NULL,
 CONSTRAINT [PK_Books_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 7/25/2013 1:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAuthors](
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors_1] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 7/25/2013 1:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[CreationDate] [date] NULL,
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Notes] [ntext] NULL,
 CONSTRAINT [PK_Reviews_1] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_AuthorName]    Script Date: 7/25/2013 1:53:00 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_AuthorName] ON [dbo].[Authors]
(
	[AuthorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [BookTitle_index]    Script Date: 7/25/2013 1:53:00 PM ******/
CREATE NONCLUSTERED INDEX [BookTitle_index] ON [dbo].[Books]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_ISBN]    Script Date: 7/25/2013 1:53:00 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_ISBN] ON [dbo].[Books]
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Authors]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Books]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Authors]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Books]
GO
USE [master]
GO
ALTER DATABASE [Bookstore] SET  READ_WRITE 
GO
