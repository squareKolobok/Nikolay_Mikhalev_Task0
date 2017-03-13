CREATE DATABASE SysTestKnowledge

CREATE TABLE SysTestKnowledge.dbo.TypeUsers
(
	TypeUser smallint NOT NULL PRIMARY KEY IDENTITY(1,1),
	Comment nvarchar(20) NOT NULL
);

CREATE TABLE SysTestKnowledge.dbo.Users
(
	[User] nvarchar(15) NOT NULL PRIMARY KEY,
	Passwd nvarchar(30) NOT NULL,
	TypeUser smallint NOT NULL REFERENCES TypeUsers(TypeUser)
);

CREATE TABLE SysTestKnowledge.dbo.Tests
(
	TestID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(40) NOT NULL,
	[Time] int NOT NULL,
	[Count] smallint NOT NULL,
	Author nvarchar(15) NOT NULL REFERENCES Users([User]),
	[Date] datetime NOT NULL
);

CREATE TABLE SysTestKnowledge.dbo.TypeQuestions
(
	TypeQuestion smallint NOT NULL PRIMARY KEY IDENTITY(1,1),
	Comment nvarchar(50) NOT NULL
);

CREATE TABLE SysTestKnowledge.dbo.Questions
(
	QuestionID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	TestID int NOT NULL REFERENCES Tests(TestID),
	QuestionText nvarchar(max) NOT NULL,
	[File] nvarchar(max) NULL,
	TypeQuestion smallint NOT NULL REFERENCES TypeQuestions(TypeQuestion)
);

CREATE TABLE SysTestKnowledge.dbo.Answers
(
	AnswerID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	QuestionID int NOT NULL REFERENCES Questions(QuestionID),
	AnswerText nvarchar(40) NOT NULL,
	IsRight bit NOT NULL
);

CREATE TABLE SysTestKnowledge.dbo.Result
(
	[User] nvarchar(15) NOT NULL REFERENCES Users([User]),
	TestID int NOT NULL REFERENCES Tests(TestID),
	CountTrueAnswers smallint NOT NULL,
	[Time] int NOT NULL,
	PRIMARY KEY([User], TestID)
);

CREATE TABLE SysTestKnowledge.dbo.ShareResult
(
	[User] nvarchar(15) NOT NULL REFERENCES Users([User]),
	QuestionID int NOT NULL REFERENCES Questions(QuestionID),
	TrueAnswer bit NOT NULL,
	PRIMARY KEY([User], QuestionID)
);

INSERT INTO SysTestKnowledge.dbo.TypeUsers (Comment) VALUES ('Administrator'), ('Moderator'), ('User');

INSERT INTO SysTestKnowledge.dbo.Users ([User], Passwd, TypeUser) 
VALUES ('Admin', '1234', 1), ('Moder','111', 2), ('Pupkin', 'qwerty', 2), ('Vasya', '1pinkrose', 3), ('Petya', 'lhfrjy', 3);

INSERT INTO SysTestKnowledge.dbo.Tests (Name, [Time], [Count], Author, [Date])
VALUES ('������� ���', 1800, 10, 'Moder', CONVERT(datetime, '2017-02-27 18:06:00.00', 121)), 
('����� ������', 1200, 5, 'Pupkin', CONVERT(datetime, '2017-02-27 18:06:00.00', 121))

INSERT INTO SysTestKnowledge.dbo.TypeQuestions (Comment) VALUES ('One Answer'), ('Multi Answer')

INSERT INTO SysTestKnowledge.dbo.Questions (TestID, QuestionText, TypeQuestion)
VALUES (3, '�� ������ ������� ������ ���?', 1), (3, '��� � ��� ����?', 2), (3, '�� ������ ��������� ����� �� �����?', 1),
(3, '��� �� ������� ����?', 1), (3, '������� ���������� ������� �������?', 1), (3, '������� ���������� �������� �������?', 1),
(3, '������� ���������� ��������� �������?', 1), (3, '���� ��������?', 1), (3, '���� � �����������?', 1), (3, '���� �������?', 1),
(4, '�� ������ ��� ��?', 1), (4, '�� ������ ���� ����?', 1), (4, '�� ������� �����?', 1), 
(4, '�� ���� ���� ��� � ����� � ���������?', 1), (4, '������� ����� � ������������ "����� ���"?', 1) 

INSERT INTO SysTestKnowledge.dbo.Answers (QuestionID, AnswerText, IsRight)
VALUES (1 ,'��', 1), (1, '���', 0), (2, '� �������', 1), (2, '�� ����', 1), (2, '� ��������', 0), (2, '� �������', 0), (2, '� �����', 0),
(3, '��', 1), (3, '���', 0), (4, '� ������', 0), (4, '�� ��������', 0), (4, '� �����', 1), (5, '30 �����', 0), (5, '5 �����', 0), (5, '2 ����', 1),
(6, '30 �����', 0), (6, '5 �����', 0), (6, '2 ����', 0), (6, '10 �����', 1), (7, '�� �� ����������', 0), (7, '2 ����', 0), (7, '45 ������', 1),
(8, '���', 0), (8, '��', 1), (9, '���', 0), (9, '��', 1), (10, '��', 0), (10, '���', 1), (11, '���', 1), (11, '��', 0), (12, '��', 0), (12, '���', 1),
(13, '��', 1), (13, '���', 0), (14, '���', 0), (14, '��', 1), (15, '8', 0), (15, '4', 1), (15, '2', 0), (15, '5', 0)