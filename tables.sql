USE [PetDemo]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 22/10/2019 10:00:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Status */
CREATE TABLE [dbo].[Status](
	[Idx] [int] NOT NULL,
	[ActivityStatus] [nvarchar](50) NOT NULL,
	[RowVersion] [bigint] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/* ActivityType */
CREATE TABLE [dbo].[ActivityType](
	[Idx] [bigint] IDENTITY(9,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[RowVersion] [bigint] NOT NULL,
	[Code] [nchar](10) NOT NULL,
 CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/* Activity */
CREATE TABLE [dbo].[Activity](
	[Idx] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[BBPActivityID] [nvarchar](50) NOT NULL,
	[RowVersion] [bigint] NOT NULL,
	[ActivityTypeID] [bigint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
	[ScheduleDueDate] [datetime] NULL,
	[Unannounced] [int] NOT NULL,
	[StandardsVersion] [int] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_ActivityType] FOREIGN KEY([ActivityTypeID])
REFERENCES [dbo].[ActivityType] ([Idx])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_ActivityType]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([Idx])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Status]
GO

/*Assignment*/
CREATE TABLE [dbo].[Assignment](
	[Idx] [bigint] IDENTITY(1,1) NOT NULL,
	[ActivityID] [bigint] NOT NULL,
	[Created] [datetime] NOT NULL,
	[RowVersion] [bigint] NOT NULL,
	[ScopeOfEOs] [nvarchar](300) NULL,
	[EmailSent] [bit] NULL,
	[EmailSentDate] [datetime] NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ActivityID] UNIQUE NONCLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Activity] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activity] ([Idx])
GO

ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Activity]
GO

ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Assignment] FOREIGN KEY([Idx])
REFERENCES [dbo].[Assignment] ([Idx])
GO

ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Assignment]
GO

/* Surveyor*/
CREATE TABLE [dbo].[Surveyor](
	[Idx] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[RowVersion] [bigint] NOT NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nchar](10) NULL,
	[Token] [nvarchar](256) NULL,
 CONSTRAINT [PK_Surveyor] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/* SurveyorAssignmentRole*/
CREATE TABLE [dbo].[SurveyorAssignmentRole](
	[Idx] [bigint] IDENTITY(1,1) NOT NULL,
	[SurveyorID] [bigint] NOT NULL,
	[RowVersion] [bigint] NOT NULL,
	[AssignmentID] [bigint] NOT NULL,
	[InActive] [bit] NOT NULL,
 CONSTRAINT [PK_SurveyorRole] PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SurveyorAssignmentRole]  WITH CHECK ADD  CONSTRAINT [FK_SurveyorRole_Assignment] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[Assignment] ([Idx])
GO

ALTER TABLE [dbo].[SurveyorAssignmentRole] CHECK CONSTRAINT [FK_SurveyorRole_Assignment]
GO


ALTER TABLE [dbo].[SurveyorAssignmentRole]  WITH CHECK ADD  CONSTRAINT [FK_SurveyorRole_Surveyor] FOREIGN KEY([SurveyorID])
REFERENCES [dbo].[Surveyor] ([Idx])
GO

ALTER TABLE [dbo].[SurveyorAssignmentRole] CHECK CONSTRAINT [FK_SurveyorRole_Surveyor]
GO



