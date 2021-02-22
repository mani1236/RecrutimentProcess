USE [Recruitment]
GO

/****** Object:  Table [dbo].[CandidateDetails]    Script Date: 2/22/2021 8:16:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CandidateDetails](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Skill] [varchar](20) NULL,
	[DOB] [datetime] NULL,
	[Position] [varchar](20) NULL,
	[FeedBack] [varchar](max) NULL,
	[InterviewLevel] [int] NULL,
	[email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Decision] [nchar](20) NULL,
 CONSTRAINT [PK_CandidateDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


