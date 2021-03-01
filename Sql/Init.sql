DROP DATABASE IF EXISTS [CompanyBankAccountsDB]
GO


CREATE DATABASE [CompanyBankAccountsDB]
GO


USE [CompanyBankAccountsDB]
GO



/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/02/2021 9:12:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[BankAccounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](max) NOT NULL,
	[CompanyID] [nvarchar](max) NOT NULL,
	[BankName] [nvarchar](100) NOT NULL,
	[BankBranch] [nvarchar](100) NOT NULL,
	[AccountNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[CompaniesHoldings](
	[CompanyID] [nvarchar](max) NULL,
	[Holding] [int] NOT NULL,
	[UserID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_CompaniesHoldings] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CompaniesHoldings] ADD  DEFAULT (N'') FOR [UserID]
GO


CREATE TABLE [dbo].[Users](
	[ID] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[FamilyName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[CompanyNumber] [nvarchar](16) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[LastLoginDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Email]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [FirstName]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [FamilyName]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [PhoneNumber]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [CompanyName]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [CompanyNumber]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Password]
GO


INSERT INTO [dbo].[Users]
           ([ID]
           ,[Email]
           ,[FirstName]
           ,[FamilyName]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[CompanyName]
           ,[CompanyNumber]
           ,[Password]
           ,[LastLoginDate])
     VALUES
           ('11111111'
           ,'1@test.com'
           ,N'א'
           ,N'ישראלי'
           ,'0512345678'
           ,'1990-01-01 00:00:00.0000000'
           ,N'שלמה יזמות ובניו'
           ,'5165758854'
           ,'11111111'
           ,Null)
GO


INSERT INTO [dbo].[Users]
           ([ID]
           ,[Email]
           ,[FirstName]
           ,[FamilyName]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[CompanyName]
           ,[CompanyNumber]
           ,[Password]
           ,[LastLoginDate])
     VALUES
           ('22222222'
           ,'2@test.com'
           ,N'ב'
           ,N'ישראלי'
           ,'0512345677'
           ,'1990-01-01 00:00:00.0000000'
           ,N'שלמית יזמות ובנותיה'
           ,'5165758852'
           ,'22222222'
           ,Null)
GO


INSERT INTO [dbo].[Users]
           ([ID]
           ,[Email]
           ,[FirstName]
           ,[FamilyName]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[CompanyName]
           ,[CompanyNumber]
           ,[Password]
           ,[LastLoginDate])
     VALUES
           ('33333333'
           ,'3@test.com'
           ,N'ג'
           ,N'ישראלי'
           ,'0512345676'
           ,'1990-01-01 00:00:00.0000000'
           ,N'שלמה יזמות בעמ'
           ,'5165758853'
           ,'33333333'
           ,Null)
GO


INSERT INTO [dbo].[Users]
           ([ID]
           ,[Email]
           ,[FirstName]
           ,[FamilyName]
           ,[PhoneNumber]
           ,[DateOfBirth]
           ,[CompanyName]
           ,[CompanyNumber]
           ,[Password]
           ,[LastLoginDate])
     VALUES
           ('44444444'
           ,'4@test.com'
           ,N'ד'
           ,N'ישראלי'
           ,'0512345675'
           ,'1990-01-01 00:00:00.0000000'
           ,N'שטראוס יזמות'
           ,'5165758855'
           ,'44444444'
           ,Null)
GO