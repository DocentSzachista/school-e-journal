USE [SchoolEJournal]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[SecondName] [varchar](20) NULL,
	[LastName] [varchar](40) NOT NULL,
	[PhoneNumber] [varchar](12) NOT NULL,
	[Email] [varchar](40) NOT NULL,
	[UserType] [int] NOT NULL,
	[ParentId] [int] NULL,
	[ClassId] [int] NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplayUsers]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DisplayUsers]
AS
SELECT        UserId, FirstName, SecondName, LastName, PhoneNumber, Email
FROM            dbo.Users
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](15) NOT NULL,
	[SupervisingTeacherId] [int] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplayAllClasses]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DisplayAllClasses]
AS
SELECT        dbo.Classes.ClassId, dbo.Users.FirstName, dbo.Users.LastName, dbo.Users.Email, dbo.Classes.ClassName
FROM            dbo.Classes LEFT OUTER JOIN
                         dbo.Users ON dbo.Classes.SupervisingTeacherId = dbo.Users.UserId
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[GradeGroupId] [int] NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradesGroups]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradesGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Weight] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_GradesGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplaySubjectGrades]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DisplaySubjectGrades]
AS
SELECT   TOP (100) PERCENT dbo.Users.FirstName, dbo.Users.LastName, dbo.GradesGroups.Name, dbo.Grades.Value
FROM         dbo.Users INNER JOIN
                         dbo.Grades ON dbo.Users.UserId = dbo.Grades.StudentId INNER JOIN
                         dbo.GradesGroups ON dbo.Grades.GradeGroupId = dbo.GradesGroups.Id
ORDER BY dbo.GradesGroups.Name DESC
GO
/****** Object:  Table [dbo].[TeachersMembership]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachersMembership](
	[TeacherMembershipId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[SubjectId] [int] NULL,
 CONSTRAINT [PK_TeachersMembership_1] PRIMARY KEY CLUSTERED 
(
	[TeacherMembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](30) NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplaySubjectInfo]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DisplaySubjectInfo]
AS
SELECT        dbo.Subjects.SubjectId, dbo.Subjects.SubjectName, dbo.Users.FirstName, dbo.Users.LastName, dbo.Users.Email
FROM            dbo.Users INNER JOIN
                         dbo.TeachersMembership ON dbo.Users.UserId = dbo.TeachersMembership.TeacherId INNER JOIN
                         dbo.Subjects ON dbo.TeachersMembership.SubjectId = dbo.Subjects.SubjectId
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[LessonId] [int] IDENTITY(1,1) NOT NULL,
	[Topic] [varchar](30) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DisplayLessons]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DisplayLessons]
AS
SELECT        dbo.Lessons.StartTime, dbo.Lessons.EndTime, dbo.Lessons.Topic, dbo.Lessons.SubjectId, dbo.Subjects.SubjectName, dbo.Classes.ClassName
FROM            dbo.Lessons INNER JOIN
                         dbo.Subjects ON dbo.Lessons.SubjectId = dbo.Subjects.SubjectId INNER JOIN
                         dbo.Classes ON dbo.Subjects.ClassId = dbo.Classes.ClassId
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendances](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[Attended] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
 CONSTRAINT [PK_Attendances] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginData]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginData](
	[LoginDataId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_LoginData] PRIMARY KEY CLUSTERED 
(
	[LoginDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCD_ClassName]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCD_ClassName] ON [dbo].[Classes]
(
	[ClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCD_GradeName]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCD_GradeName] ON [dbo].[GradesGroups]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_Topic]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCI_Topic] ON [dbo].[Lessons]
(
	[Topic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_Login]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCI_Login] ON [dbo].[LoginData]
(
	[Login] ASC,
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_Subject]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCI_Subject] ON [dbo].[Subjects]
(
	[SubjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_UserData]    Script Date: 01.01.2022 21:03:14 ******/
CREATE NONCLUSTERED INDEX [NCI_UserData] ON [dbo].[Users]
(
	[FirstName] ASC,
	[LastName] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendances] ADD  CONSTRAINT [DF_Attendances_Attended]  DEFAULT ((0)) FOR [Attended]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendances_Lessons] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([LessonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendances_Lessons]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Users] FOREIGN KEY([SupervisingTeacherId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Users]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_GradesGroups] FOREIGN KEY([GradeGroupId])
REFERENCES [dbo].[GradesGroups] ([Id])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_GradesGroups]
GO
ALTER TABLE [dbo].[GradesGroups]  WITH CHECK ADD  CONSTRAINT [FK_GradesGroups_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GradesGroups] CHECK CONSTRAINT [FK_GradesGroups_Subjects]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Lessons] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Subjects_Lessons]
GO
ALTER TABLE [dbo].[LoginData]  WITH CHECK ADD  CONSTRAINT [FK_LoginData_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginData] CHECK CONSTRAINT [FK_LoginData_Users]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Classes]
GO
ALTER TABLE [dbo].[TeachersMembership]  WITH CHECK ADD  CONSTRAINT [FK_TeachersMembership_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeachersMembership] CHECK CONSTRAINT [FK_TeachersMembership_Subjects]
GO
ALTER TABLE [dbo].[TeachersMembership]  WITH CHECK ADD  CONSTRAINT [FK_TeachersMembership_Users] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TeachersMembership] CHECK CONSTRAINT [FK_TeachersMembership_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Classes]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Users]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [CK_Attendances] CHECK  (([Attended]>=(0)))
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [CK_Attendances]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [CK_LessonId] CHECK  (([LessonId]>(0)))
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [CK_LessonId]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [CK_StudentId] CHECK  (([StudentId]>(0)))
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [CK_StudentId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [CK_Grades_Grade] CHECK  (([Value]>=(1) AND [Value]<=(6)))
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [CK_Grades_Grade]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [CK_Grades_GradeGroup_Id] CHECK  (([GradeGroupId]>(0)))
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [CK_Grades_GradeGroup_Id]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [CK_Grades_StudentId] CHECK  (([StudentId]>(0)))
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [CK_Grades_StudentId]
GO
ALTER TABLE [dbo].[GradesGroups]  WITH CHECK ADD  CONSTRAINT [CK_GradesGroups_SubjectId] CHECK  (([SubjectId]>(0)))
GO
ALTER TABLE [dbo].[GradesGroups] CHECK CONSTRAINT [CK_GradesGroups_SubjectId]
GO
ALTER TABLE [dbo].[GradesGroups]  WITH CHECK ADD  CONSTRAINT [CK_GradesGroups_Weight] CHECK  (([Weight]>(0)))
GO
ALTER TABLE [dbo].[GradesGroups] CHECK CONSTRAINT [CK_GradesGroups_Weight]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [CK_Check_Date] CHECK  (([StartTime]<[EndTime]))
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [CK_Check_Date]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [CK_Lessons] CHECK  (([SubjectId]>(0)))
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [CK_Lessons]
GO
ALTER TABLE [dbo].[LoginData]  WITH CHECK ADD  CONSTRAINT [CK_LoginData_Login] CHECK  ((len([Login])>(5)))
GO
ALTER TABLE [dbo].[LoginData] CHECK CONSTRAINT [CK_LoginData_Login]
GO
ALTER TABLE [dbo].[LoginData]  WITH CHECK ADD  CONSTRAINT [CK_LoginData_UserId] CHECK  (([UserId]>(0)))
GO
ALTER TABLE [dbo].[LoginData] CHECK CONSTRAINT [CK_LoginData_UserId]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [CK_SubjectsClassId] CHECK  (([ClassId]>(0)))
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [CK_SubjectsClassId]
GO
ALTER TABLE [dbo].[TeachersMembership]  WITH CHECK ADD  CONSTRAINT [CK_SubjectId] CHECK  (([SubjectId]>(0)))
GO
ALTER TABLE [dbo].[TeachersMembership] CHECK CONSTRAINT [CK_SubjectId]
GO
ALTER TABLE [dbo].[TeachersMembership]  WITH CHECK ADD  CONSTRAINT [CK_TeacherId] CHECK  (([TeacherId]>(0)))
GO
ALTER TABLE [dbo].[TeachersMembership] CHECK CONSTRAINT [CK_TeacherId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_ClassId] CHECK  (([ClassId]>(0)))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_ClassId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_ParentId] CHECK  (([ParentId]>(0)))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_ParentId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_PhoneNumber] CHECK  ((len([PhoneNumber])>(8)))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_PhoneNumber]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_UserType] CHECK  (([UserType]>=(0) AND [UserType]<=(4)))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_UserType]
GO
/****** Object:  StoredProcedure [dbo].[AddCredentials]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCredentials] 
	-- Add the parameters for the stored procedure here
	 @password varchar,
	 @id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO LoginData (Login, Password, UserId) 
	VALUES(CONCAT('login', @id), @password, @id );
END
GO
/****** Object:  StoredProcedure [dbo].[SelectUserData]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectUserData]
	@UserId int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM DisplayUsers
	WHERE UserId = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DisplayUserWithSpecifiedUserType]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DisplayUserWithSpecifiedUserType]
	-- Add the parameters for the stored procedure here
	@userType int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserId, FirstName, LastName, Email 
	FROM Users 
	WHERE UserType = @userType;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DML_Class]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Damian RAczkowski 
-- Create date: <Create Date,,>
-- Description:	Procedure to store DML operations 
-- =============================================
CREATE PROCEDURE [dbo].[SP_DML_Class]
	-- Add the parameters for the stored procedure here
	@classId int = NULL,
	@teacherId int = NULL,
	@className varchar(15) = '',
	@ACTION varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @ACTION = 'INSERT'
	BEGIN
		INSERT INTO Classes 
		VALUES(@className, @teacherId);
	END
	IF @ACTION = 'UPDATE'
	begin
		UPDATE Classes 
		SET ClassName = @className , SupervisingTeacherId = @teacherId 
		WHERE ClassId = @classId;
	end
	IF @ACTION = 'DELETE'
	BEGIN
		DELETE FROM Classes 
		WHERE ClassId = @classId;
	END
    -- Insert statements for procedure here
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DML_SUBJ_WITH_LESSONS]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Add range of dates into lesson for current subject 
-- =============================================
CREATE PROCEDURE [dbo].[SP_DML_SUBJ_WITH_LESSONS]
	@subjectName varchar(30),
	@className varchar(30),
	@teacherId int,
	@startDate datetime,
	@endDate datetime,
	@endDay datetime,
	@subjectId int = NULL,
	@interval int = 7,
	@ACTION varchar(10)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @currentDate date = @startDate;
	DECLARE @endCurrDay date = @endDay;
	DECLARE @ClassId int ;
	DECLARE @createdSubId int;

	SELECT @ClassId = ClassId   
	FROM Classes
	WHERE ClassName LIKE @className;
	
	IF @ACTION = 'INSERT'
	BEGIN
		INSERT INTO Subjects (SubjectName, ClassId) VALUES(@subjectName, @ClassId);
		SET @createdSubId = @@IDENTITY;
		INSERT INTO TeachersMembership VALUES(@teacherId, @createdSubId);
		WHILE (@currentDate < @endDate)
		BEGIN
			
			INSERT INTO Lessons (StartTime, EndTime, SubjectId) 
			VALUES
			(
				@currentDate, 
				@endCurrDay,
				@createdSubId
			)
			SET @currentDate = DATEADD(DAY, @interval, @currentDate);
			SET @endCurrDay =  DATEADD(DAY, @interval, @endCurrDay);  
		END
	END
	IF @ACTION = 'UPDATE'
	BEGIN
		DELETE FROM Lessons 
		WHERE SubjectId = @subjectId;
		WHILE (@currentDate < @endDate)
		WHILE (@currentDate < @endDate)
		BEGIN
			
			INSERT INTO Lessons (StartTime, EndTime, SubjectId) 
			VALUES
			(
				@currentDate, 
				@endCurrDay,
				@createdSubId
			)
			SET @currentDate = DATEADD(DAY, @interval, @currentDate);
			SET @endCurrDay =  DATEADD(DAY, @interval, @endCurrDay);  
		END
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_DML_Subject]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DML_Subject]
	@teacherId int = NULL,
	@subjectName as varchar(100) = '',
	@subjectId as int = NULL,
	@ACTION as varchar(100) ,
	@className as varchar(15) = NUll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE  @classId int;
	
	SELECT @classId = ClassId   
	FROM Classes
	WHERE ClassName LIKE @className;
	
	SET NOCOUNT ON;
	IF @ACTION = 'INSERT'
	BEGIN	
		INSERT INTO Subjects (SubjectName, ClassId) 
		VALUES(@subjectName, @classId);
		INSERT INTO TeachersMembership VALUES(@teacherId, @@IDENTITY);
	END
	IF @ACTION = 'UPDATE'
	BEGIN 
		UPDATE Subjects 
		SET SubjectName = @subjectName, ClassId = @classId 
		WHERE SubjectId =@subjectId;
		UPDATE TeachersMembership 
		SET teacherId=@teacherId
		WHERE SubjectId =@subjectId;
	END
	IF @ACTION = 'DELETE'
	BEGIN
		DELETE FROM Subjects WHERE SubjectId = @subjectId;
		DELETE FROM TeachersMembership WHERE SubjectId = @subjectId;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DML_Users]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DML_Users]
	@firstName as varchar(30) = NULL,
	@lastName as varchar(40) =NULL,
	@phoneNumber as varchar(12) = NULL,
	@email as varchar(40) = NULL,
	@userType as int = 1,
	@classId as int = NULL,
	@parentId as int = NULL,
	@secondName as varchar(20) = NULL,
	@userId as int = NULL,
	@ACTION as varchar(100),
	@password as varchar = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @ACTION = 'INSERT'
	BEGIN
    -- Insert statements for procedure here
		INSERT INTO Users (FirstName, SecondName, LastName, PhoneNumber, Email, ClassId, ParentId, UserType)
		VALUES(@firstName, @secondName, @lastName, @phoneNumber, @email, @classId, @parentId, @userType);
		
		EXEC dbo.AddCredentials @password, @@IDENTITY;
	END
	IF @ACTION = 'UPDATE'
	BEGIN 
		UPDATE Users 
		SET FirstName = @firstName, SecondName = @secondName, LastName = @lastName, Email = @email, PhoneNumber = @phoneNumber, ClassId= @classId, ParentId = @parentId, UserType = @userType
		WHERE UserId = @userId;
	END
	IF @ACTION = 'DELETE'
	BEGIN


		DELETE FROM Attendances WHERE StudentId = @userId;
		DELETE FROM Grades WHERE StudentId = @userId;
		
		
		DELETE FROM Users WHERE UserId = @userId;
	END
END
GO
/****** Object:  Trigger [dbo].[ADD_LOGIN_FOR_USERS]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[ADD_LOGIN_FOR_USERS]
ON [dbo].[Users]
FOR INSERT 
AS
BEGIN
		INSERT INTO LoginData (Login, Password, UserId) 
		SELECT 
			CONCAT('logins', UserId), 'haslo1234', UserId 
			FROM inserted;
END

GO
ALTER TABLE [dbo].[Users] DISABLE TRIGGER [ADD_LOGIN_FOR_USERS]
GO
/****** Object:  Trigger [dbo].[AddStudentAttendance]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[AddStudentAttendance] 
ON [dbo].[Users] 
AFTER INSERT
AS
BEGIN
 
INSERT INTO Attendances (attended, StudentId, LessonId)  
	SELECT 0, UserId, Lessons.LessonId 
	FROM inserted
	JOIN Subjects ON Subjects.ClassId = inserted.ClassId
	JOIN Lessons ON Lessons.SubjectId = Subjects.SubjectId
END

GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [AddStudentAttendance]
GO
/****** Object:  Trigger [dbo].[DeleteStudentAttendance]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[DeleteStudentAttendance] 
ON [dbo].[Users] 
AFTER DELETE 
AS
BEGIN
	DELETE FROM Attendances   
	WHERE StudentId IN (SELECT  UserId
					   FROM deleted)	
END
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [DeleteStudentAttendance]
GO
/****** Object:  Trigger [dbo].[UpdateStudentAttendance]    Script Date: 01.01.2022 21:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[UpdateStudentAttendance] 
ON [dbo].[Users] 
AFTER UPDATE 
AS
BEGIN
	INSERT INTO Attendances (attended, StudentId, LessonId)  
	SELECT 0, UserId, Lessons.LessonId 
	FROM inserted
	JOIN Subjects ON Subjects.ClassId = inserted.ClassId
	JOIN Lessons ON Lessons.SubjectId = Subjects.SubjectId
END
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [UpdateStudentAttendance]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Classes"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 86
               Left = 436
               Bottom = 216
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayAllClasses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayAllClasses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Lessons"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Subjects"
            Begin Extent = 
               Top = 13
               Left = 241
               Bottom = 139
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Classes"
            Begin Extent = 
               Top = 6
               Left = 743
               Bottom = 119
               Right = 944
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayLessons'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayLessons'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GradesGroups"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grades"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplaySubjectGrades'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplaySubjectGrades'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TeachersMembership"
            Begin Extent = 
               Top = 28
               Left = 424
               Bottom = 141
               Right = 631
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Subjects"
            Begin Extent = 
               Top = 19
               Left = 748
               Bottom = 150
               Right = 918
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplaySubjectInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplaySubjectInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 3000
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DisplayUsers'
GO
