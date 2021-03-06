USE [CognizantTask]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 4/11/2019 12:02:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[TemplatePath] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCases]    Script Date: 4/11/2019 12:02:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[Path] [varchar](500) NULL,
	[InputFilePath] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSubmissions]    Script Date: 4/11/2019 12:02:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSubmissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [varchar](100) NULL,
	[UserSubmissionFilePath] [varchar](max) NULL,
	[IsSuccess] [bit] NULL,
	[TaskId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 
GO
INSERT [dbo].[Tasks] ([Id], [Name], [TemplatePath]) VALUES (2, N'Max array value', N'..\..\..\Templates\MaxArrayValueTemplate.txt')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [TemplatePath]) VALUES (3, N'Min array value', N'..\..\..\Templates\MinArrayValueTemplate.txt')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [TemplatePath]) VALUES (5, N'Bubble sort', N'..\..\..\Templates\BubbleSortTemplate.txt')
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[TestCases] ON 
GO
INSERT [dbo].[TestCases] ([Id], [TaskId], [Path], [InputFilePath]) VALUES (1, 5, N'..\..\..\TestCases\BubbleSortTestCase.txt', N'..\..\..\InputFiles\BubbleSort.txt')
GO
INSERT [dbo].[TestCases] ([Id], [TaskId], [Path], [InputFilePath]) VALUES (2, 2, N'..\..\..\TestCases\MaxArrayValueTestCase.txt', N'..\..\..\InputFiles\MaxArrayValue.txt')
GO
INSERT [dbo].[TestCases] ([Id], [TaskId], [Path], [InputFilePath]) VALUES (4, 3, N'..\..\..\TestCases\MinArrayValueTestCase.txt', N'..\..\..\InputFiles\MinArrayValue.txt')
GO
SET IDENTITY_INSERT [dbo].[TestCases] OFF
GO
ALTER TABLE [dbo].[TestCases]  WITH CHECK ADD FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[UserSubmissions]  WITH CHECK ADD FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
