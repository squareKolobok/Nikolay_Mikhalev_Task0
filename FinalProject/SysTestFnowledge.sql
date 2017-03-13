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
VALUES ('Который час', 1800, 10, 'Moder', CONVERT(datetime, '2017-02-27 18:06:00.00', 121)), 
('Какая погода', 1200, 5, 'Pupkin', CONVERT(datetime, '2017-02-27 18:06:00.00', 121))

INSERT INTO SysTestKnowledge.dbo.TypeQuestions (Comment) VALUES ('One Answer'), ('Multi Answer')

INSERT INTO SysTestKnowledge.dbo.Questions (TestID, QuestionText, TypeQuestion)
VALUES (3, 'Вы знаете который сейчас год?', 1), (3, 'Где у вас часы?', 2), (3, 'Вы умеете разбирать время по часам?', 1),
(3, 'Где вы храните часы?', 1), (3, 'Сколько показывает часовая стрелка?', 1), (3, 'Сколько показывает минутная стрелка?', 1),
(3, 'Сколько показывает секундная стрелка?', 1), (3, 'часы заведены?', 1), (3, 'часы с циферблатом?', 1), (3, 'часы рабочие?', 1),
(4, 'Вы знаете где вы?', 1), (4, 'Вы знаете куда идти?', 1), (4, 'ВЫ читаете книги?', 1), 
(4, 'ВЫ били хоть раз в жизни в билиотеке?', 1), (4, 'Сколько томов в произведении "Тихий Дон"?', 1) 

INSERT INTO SysTestKnowledge.dbo.Answers (QuestionID, AnswerText, IsRight)
VALUES (1 ,'Да', 1), (1, 'Нет', 0), (2, 'В кармане', 1), (2, 'На руке', 1), (2, 'В телефоне', 0), (2, 'В ремонте', 0), (2, 'У друга', 0),
(3, 'Да', 1), (3, 'Нет', 0), (4, 'В камоде', 0), (4, 'На тумбочке', 0), (4, 'В сейфе', 1), (5, '30 минут', 0), (5, '5 часов', 0), (5, '2 часа', 1),
(6, '30 минут', 0), (6, '5 часов', 0), (6, '2 часа', 0), (6, '10 минут', 1), (7, 'Ее не существует', 0), (7, '2 часа', 0), (7, '45 секунд', 1),
(8, 'Нет', 0), (8, 'Да', 1), (9, 'Нет', 0), (9, 'Да', 1), (10, 'Да', 0), (10, 'Нет', 1), (11, 'Нет', 1), (11, 'Да', 0), (12, 'Да', 0), (12, 'Нет', 1),
(13, 'Да', 1), (13, 'Нет', 0), (14, 'Нет', 0), (14, 'Да', 1), (15, '8', 0), (15, '4', 1), (15, '2', 0), (15, '5', 0)