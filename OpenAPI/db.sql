USE [VolunteerSystem]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [varchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[Point] [float] NULL,
	[Address] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountClaim]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[IdentityUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AccountClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountLogin]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLogin](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[IdentityUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AccountLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountRole]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountRole](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[IdentityUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AccountRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Activity]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[EventID] [int] NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK_dbo.Activity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configuaration]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuaration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_dbo.Configuaration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[StartTime] [datetime] NULL,
	[FinishTime] [datetime] NULL,
	[Location] [nvarchar](max) NULL,
	[TimeCreated] [datetime] NULL,
	[OrganizationMemberID] [int] NULL,
	[Public] [bit] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventComment]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventComment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[AccountID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.EventComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventType]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.EventType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventVolunteer]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventVolunteer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[TimeCreated] [datetime] NULL,
	[Status] [nchar](10) NULL,
	[AccountID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.EventVolunteer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventVolunteerType]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventVolunteerType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeID] [int] NULL,
	[EventID] [int] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.EventVolunteerType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[OrganizationMemberID] [int] NULL,
	[Public] [bit] NULL,
	[TimeCreated] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsComment]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsComment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NewsID] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[TimeCreated] [datetime] NULL,
	[Status] [bit] NULL,
	[AccountID] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.NewsComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[TimeCreate] [datetime] NULL,
	[Creator] [nvarchar](128) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Organization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrganizationMember]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationMember](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [int] NULL,
	[TimeCreated] [datetime] NULL,
	[Status] [bit] NULL,
	[AccountID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.OrganizationMember] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/3/2019 2:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccountClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountClaim_dbo.Account_IdentityUser_Id] FOREIGN KEY([IdentityUser_Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountClaim] CHECK CONSTRAINT [FK_dbo.AccountClaim_dbo.Account_IdentityUser_Id]
GO
ALTER TABLE [dbo].[AccountLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountLogin_dbo.Account_IdentityUser_Id] FOREIGN KEY([IdentityUser_Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountLogin] CHECK CONSTRAINT [FK_dbo.AccountLogin_dbo.Account_IdentityUser_Id]
GO
ALTER TABLE [dbo].[AccountRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountRole_dbo.Account_IdentityUser_Id] FOREIGN KEY([IdentityUser_Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountRole] CHECK CONSTRAINT [FK_dbo.AccountRole_dbo.Account_IdentityUser_Id]
GO
ALTER TABLE [dbo].[AccountRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountRole_dbo.Role_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[AccountRole] CHECK CONSTRAINT [FK_dbo.AccountRole_dbo.Role_IdentityRole_Id]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Activity_dbo.Event_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([ID])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_dbo.Activity_dbo.Event_EventID]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Event_dbo.OrganizationMember_OrganizationMemberID] FOREIGN KEY([OrganizationMemberID])
REFERENCES [dbo].[OrganizationMember] ([ID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_dbo.Event_dbo.OrganizationMember_OrganizationMemberID]
GO
ALTER TABLE [dbo].[EventComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventComment_dbo.Account_Account_Id] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[EventComment] CHECK CONSTRAINT [FK_dbo.EventComment_dbo.Account_Account_Id]
GO
ALTER TABLE [dbo].[EventComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventComment_dbo.Event_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([ID])
GO
ALTER TABLE [dbo].[EventComment] CHECK CONSTRAINT [FK_dbo.EventComment_dbo.Event_EventID]
GO
ALTER TABLE [dbo].[EventVolunteer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventVolunteer_dbo.Account_Account_Id] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[EventVolunteer] CHECK CONSTRAINT [FK_dbo.EventVolunteer_dbo.Account_Account_Id]
GO
ALTER TABLE [dbo].[EventVolunteer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventVolunteer_dbo.Event_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([ID])
GO
ALTER TABLE [dbo].[EventVolunteer] CHECK CONSTRAINT [FK_dbo.EventVolunteer_dbo.Event_EventID]
GO
ALTER TABLE [dbo].[EventVolunteerType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventVolunteerType_dbo.Event_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventVolunteerType] CHECK CONSTRAINT [FK_dbo.EventVolunteerType_dbo.Event_EventID]
GO
ALTER TABLE [dbo].[EventVolunteerType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventVolunteerType_dbo.EventType_EventTypeID] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([ID])
GO
ALTER TABLE [dbo].[EventVolunteerType] CHECK CONSTRAINT [FK_dbo.EventVolunteerType_dbo.EventType_EventTypeID]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_dbo.News_dbo.OrganizationMember_OrganizationMemberID] FOREIGN KEY([OrganizationMemberID])
REFERENCES [dbo].[OrganizationMember] ([ID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_dbo.News_dbo.OrganizationMember_OrganizationMemberID]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NewsComment_dbo.Account_Account_Id] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_dbo.NewsComment_dbo.Account_Account_Id]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NewsComment_dbo.News_NewsID] FOREIGN KEY([NewsID])
REFERENCES [dbo].[News] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_dbo.NewsComment_dbo.News_NewsID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Organization_dbo.Account_Creator] FOREIGN KEY([Creator])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_dbo.Organization_dbo.Account_Creator]
GO
ALTER TABLE [dbo].[OrganizationMember]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrganizationMember_dbo.Account_Account_Id] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[OrganizationMember] CHECK CONSTRAINT [FK_dbo.OrganizationMember_dbo.Account_Account_Id]
GO
ALTER TABLE [dbo].[OrganizationMember]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrganizationMember_dbo.Account_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrganizationMember] CHECK CONSTRAINT [FK_dbo.OrganizationMember_dbo.Account_AccountID]
GO
ALTER TABLE [dbo].[OrganizationMember]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrganizationMember_dbo.Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([ID])
GO
ALTER TABLE [dbo].[OrganizationMember] CHECK CONSTRAINT [FK_dbo.OrganizationMember_dbo.Organization_OrganizationID]
GO
