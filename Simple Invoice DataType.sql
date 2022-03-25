USE [Therefore]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerNo] [int] NOT NULL,
	[Lastname] [varchar](50) NULL,
	[Firstname] [varchar](50) NULL,
	[Address] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


INSERT INTO [Therefore].[dbo].[Customer]
           ([CustomerNo]
           ,[Lastname]
           ,[Firstname]
           ,[Address])
     VALUES
           (1,'Lastname1','Firstname1','Vienna')
GO
INSERT INTO [Therefore].[dbo].[Customer]
           ([CustomerNo]
           ,[Lastname]
           ,[Firstname]
           ,[Address])
     VALUES

           (2,'Lastname2','Firstname2','Hamburg')
GO
INSERT INTO [Therefore].[dbo].[Customer]
           ([CustomerNo]
           ,[Lastname]
           ,[Firstname]
           ,[Address])
     VALUES

           (3,'Lastname3','Firstname3','London')
GO


