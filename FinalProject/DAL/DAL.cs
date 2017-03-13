namespace DAL
{
    using System;
    using System.Collections.Generic;
    using Models;
    using System.Data;
    using System.Data.SqlClient;

    public class TestDAL : IDAL
    {
        public TestDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string connectionString;

        private void AddParam<T>(IDbCommand command, string namePar, T value, DbType type)
        {
            var Sel = command.CreateParameter();
            Sel.ParameterName = namePar;
            Sel.DbType = type;

            if (value != null)
                Sel.Value = value;
            else
                Sel.Value = DBNull.Value;

            command.Parameters.Add(Sel);
        }

        /// <summary>
        /// создание нового теста
        /// </summary>
        /// <param name="test">тест для создания</param>
        /// <param name="User">кто создает</param>
        public bool CreateTest(Test test, string User)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(t.Name) FROM Tests t LEFT JOIN Users u ON t.Author = u.[User] WHERE TypeUser < " + (Int16)Role.User + " and Name = @Name and Author = @Author";
                AddParam<string>(command, "@Name", test.NameTest, DbType.String);
                AddParam<string>(command, "@Author", User, DbType.String);
                int count = (int)command.ExecuteScalar();

                if (test.Questions.Count == 0 || count != 0) return false;

                DateTime date = DateTime.Now;
                command.CommandText = "INSERT INTO Tests (Name, [Time], [Count], Author, [Date]) OUTPUT inserted.TestID VALUES (@Name2, @Time, @Count, @Author2, CONVERT(datetime, '" +
                    date.ToString("s").Replace("T", " ") + "', 121))";
                AddParam<string>(command, "@Name2", test.NameTest, DbType.String);
                AddParam<int>(command, "@Time", test.Time, DbType.Int32);
                AddParam<int>(command, "@Count", test.Questions.Count, DbType.Int32);
                AddParam<string>(command, "@Author2", User, DbType.String);
                int testID = (int)command.ExecuteScalar();
                int k = 0;

                foreach (Question x in test.Questions)
                {
                    command.CommandText = "INSERT INTO Questions (TestID, QuestionText, [File], TypeQuestion) OUTPUT inserted.QuestionID VALUES (@TestID" + k +
                        ", @QuestionText" + k + ", @File" + k + ", @Type" + k + ")";
                    AddParam<int>(command, "@TestID" + k, testID, DbType.Int32);
                    AddParam<string>(command, "@QuestionText" + k, x.QuestionText, DbType.String);
                    AddParam<string>(command, "@File" + k, x.File, DbType.String);
                    AddParam<Int16>(command, "@Type" + k, (Int16)x.TypeQuest, DbType.Int16);
                    int questionID = (int)command.ExecuteScalar();

                    foreach (Answer y in x.Answers)
                    {
                        command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsRight) VALUES (@QuestionID" + k +
                            ", @AnswerText" + k + ", @IsRight" + k + ")";
                        AddParam<int>(command, "@QuestionID" + k, questionID, DbType.Int32);
                        AddParam<string>(command, "@AnswerText" + k, y.AnswerText, DbType.String);
                        AddParam<bool>(command, "@IsRight" + k, y.IsRight, DbType.Boolean);
                        int i = command.ExecuteNonQuery();
                        k++;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// проверка на корректность ввода данных
        /// </summary>
        /// <param name="User">пользователь</param>
        /// <param name="Password">пароль пользователя</param>
        public bool IsRightLogPass(string User, string Password, out Role typeUsers)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TypeUser FROM Users WHERE [User] = @User AND Passwd = @Password";
                AddParam<string>(command, "@User", User, DbType.String);
                AddParam<string>(command, "@Password", Password, DbType.String);
                var reader = command.ExecuteReader();
                short i = 0;

                if (reader.Read())
                {
                    i = (Int16)reader.GetInt16(0);
                }

                typeUsers = (i >= (short)Role.Administrator && i <= (short)Role.User) ? (Role)i : Role.User;
                return i >= (short)Role.Administrator && i <= (short)Role.User;
            }
        }

        /// <summary>
        /// изменить пароль пользователя
        /// </summary>
        /// <param name="goal">пароль который меняем</param>
        public bool ChangePassword(string goal, string OldPassword, string NewPassword)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT Passwd FROM Users WHERE [User] = @gola";
                AddParam<string>(command, "@gola", goal, DbType.String);
                string dbOldPassword = (string)command.ExecuteScalar();

                if (!OldPassword.Equals(dbOldPassword)) return false;

                command.CommandText = "UPDATE Users SET Passwd = @NewPass WHERE [User] = @gola";
                AddParam<string>(command, "@goal", goal, DbType.String);
                AddParam<string>(command, "@NewPass", NewPassword, DbType.String);
                int i = command.ExecuteNonQuery();
                return true;
            }
        }

        /// <summary>
        /// проверка на существование пользователя
        /// </summary>
        /// <param name="User">имя пользователя</param>
        public bool ExistUser(string User)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT([User]) FROM Users WHERE [User] = @User";
                AddParam<string>(command, "@User", User, DbType.String);
                int count = (int)command.ExecuteScalar();

                return count != 0;
            }
        }

        /// <summary>
        /// поиск теста по имени
        /// </summary>
        /// <param name="TestName">часть имени теста</param>
        /// <returns></returns>
        public List<Test> SearchTest(string TestName)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TestID, Name, [Time], [Count], Author, Date FROM Tests";
                var reader = command.ExecuteReader();
                List<Test> list = new List<Test>();

                while (reader.Read())
                {
                    string name = reader.GetString(1);

                    if (name.IndexOf(TestName) != -1)
                    {
                        Test test = new Test(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt16(3), reader.GetString(4), reader.GetDateTime(5), null);
                        list.Add(test);
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// получить информацию о пройденных тестах
        /// </summary>
        /// <param name="User">пользователь, проходивший тесты</param>
        /// <returns></returns>
        public List<ResultTest> GetResultTests(string User)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT r.TestID, CountTrueAnswers, r.[Time], t.Name FROM Result r INNER JOIN Tests t " +
                    "ON r.TestID = t.TestID WHERE [User] = @User";
                AddParam<string>(command, "@User", User, DbType.String);
                var reader = command.ExecuteReader();
                List<ResultTest> list = new List<ResultTest>();

                while (reader.Read())
                {
                    ResultTest res = new ResultTest(reader.GetInt32(0), reader.GetString(3), reader.GetInt16(1), reader.GetInt32(2));
                    list.Add(res);
                }

                return list;
            }
        }

        /// <summary>
        /// получить детальную информацию о выбранном тесте
        /// </summary>
        /// <param name="User">пользователь, который прошел тест</param>
        /// <param name="TestID">пройденный тест</param>
        /// <returns></returns>
        public List<ShareResultTest> GetShareResultTest(string User, int TestID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT QuestionID, TrueAnswer FROM ShareResult WHERE [User] = @User";
                AddParam<string>(command, "@User", User, DbType.String);
                var reader = command.ExecuteReader();
                List<ShareResultTest> list = new List<ShareResultTest>();

                while (reader.Read())
                {
                    ShareResultTest res = new ShareResultTest(reader.GetInt32(0), reader.GetBoolean(1));
                    list.Add(res);
                }

                return list;
            }
        }

        /// <summary>
        /// получить тест
        /// </summary>
        /// <param name="TestID">нужный тест</param>
        public Test GetTest(int TestID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Name, [Time], Author, [Date] FROM Tests WHERE TestID = @TestID";
                AddParam<int>(command, "@TestID", TestID, DbType.Int32);
                var reader = command.ExecuteReader();
                Test test = new Test(0, null, 0);

                while (reader.Read())
                {
                    test = new Test(TestID, reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetDateTime(3), null);
                }

                reader.Close();
                command.CommandText = "SELECT QuestionID, QuestionText, [File], TypeQuestion FROM Questions WHERE TestID = @TestID1";
                AddParam<int>(command, "@TestID1", TestID, DbType.Int32);
                reader = command.ExecuteReader();
                List<Question> questions = new List<Question>();

                while (reader.Read())
                {
                    string File = reader.IsDBNull(2) ? null : reader.GetString(2);
                    Question quest = new Question(reader.GetInt32(0), reader.GetString(1), File, (TypeQuestion)reader.GetInt16(3), null);
                    questions.Add(quest);
                }

                reader.Close();
                List<Question> newQuest = new List<Question>();
                int k = 0;

                foreach (Question x in questions)
                {
                    command.CommandText = "SELECT AnswerID, AnswerText, IsRight FROM Answers WHERE QuestionID = @QuestionID" + k;
                    AddParam<int>(command, "@QuestionID" + k, x.QuestionID, DbType.Int32);
                    k++;
                    reader = command.ExecuteReader();
                    List<Answer> answers = new List<Answer>();

                    while (reader.Read())
                    {
                        Answer answer = new Answer(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));
                        answers.Add(answer);
                    }

                    Question NewQuestion = new Question(x.QuestionID, x.QuestionText, x.File, x.TypeQuest, answers);
                    newQuest.Add(NewQuestion);
                    reader.Close();
                }

                return new Test(test.TestID, test.NameTest, test.Time, test.User, test.Date, newQuest);
            }
        }

        /// <summary>
        /// создать пользователя
        /// </summary>
        /// <param name="Name">имя пользователя</param>
        /// <param name="Password">пароль пользователя</param>
        public void CreateUser(string Name, string Password)
        {
            if (ExistUser(Name)) return;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Users ([User], Passwd, TypeUser) VALUES (@User, @Passwd, @TypeUser)";
                AddParam<string>(command, "@User", Name, DbType.String);
                AddParam<string>(command, "@Passwd", Password, DbType.String);
                AddParam<Int16>(command, "@TypeUser", (Int16)Role.User, DbType.Int16);
                int i = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// переводим пользователя в другую группу
        /// </summary>
        /// <param name="person">кто переводит</param>
        /// <param name="goal">кого переводят</param>
        public bool ChangeStatus(string person, string goal, Role typeUser)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TypeUser FROM Users WHERE [User] = @UserType";
                AddParam<string>(command, "@UserType", person, DbType.String);
                int type = (Int16)command.ExecuteScalar();

                if (type != (int)Role.Administrator || person.Equals(goal)) return false;

                command.CommandText = "UPDATE Users SET TypeUser = @NewType WHERE [User] = @User";
                AddParam<string>(command, "@User", goal, DbType.String);
                AddParam<Int16>(command, "@NewType", (Int16)typeUser, DbType.Int16);
                type = command.ExecuteNonQuery();
                return true;
            }
        }

        //удалить ответ
        public void DeleteAnswer(int AnswerID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Answers WHERE AnswerID = @AnswerID";
                AddParam<int>(command, "@AnswerID", AnswerID, DbType.Int32);
                int i = command.ExecuteNonQuery();
            }
        }

        public void DeleteQuestion(int QuestionID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT AnswerID FROM Answers WHERE QuestionID = @Question";
                AddParam<int>(command, "@Question", QuestionID, DbType.Int32);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DeleteAnswer(reader.GetInt32(0));
                }

                reader.Close();
                command.CommandText = "DELETE FROM ShareResult WHERE QuestionID = @QuestionID1";
                AddParam<int>(command, "@QuestionID1", QuestionID, DbType.Int32);
                int i = command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Questions WHERE QuestionID = @QuestionID2";
                AddParam<int>(command, "@QuestionID2", QuestionID, DbType.Int32);
                i = command.ExecuteNonQuery();
            }
        }

        public void DeleteTest(int TestID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT QuestionID FROM Questions WHERE TestID = @TestID";
                AddParam<int>(command, "@TestID", TestID, DbType.Int32);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DeleteQuestion(reader.GetInt32(0));
                }

                reader.Close();
                command.CommandText = "DELETE FROM Result WHERE TestID = @TestID1";
                AddParam<int>(command, "@TestID1", TestID, DbType.Int32);
                int i = command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Tests WHERE TestID = @TestID2";
                AddParam<int>(command, "@TestID2", TestID, DbType.Int32);
                i = command.ExecuteNonQuery();
            }
        }

        public void WriteResult(string User, ResultTest result, List<ShareResultTest> shareResult)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "IF(EXISTS (SELECT * FROM Result WHERE [User] = @User AND TestID = @TestID)) " +
                    "UPDATE Result SET CountTrueAnswers = @CountTrueAnswers, [Time] = @Time WHERE[User] = @User AND TestID = @TestID " +
                    "ELSE INSERT  INTO Result ([User], TestID, CountTrueAnswers, [Time]) VALUES(@User, @TestID, @CountTrueAnswers, @Time)";
                AddParam<string>(command, "@User", User, DbType.String);
                AddParam<int>(command, "@TestID", result.TestID, DbType.Int32);
                AddParam<Int16>(command, "@CountTrueAnswers", (Int16)result.CountTrueAnswers, DbType.Int16);
                AddParam<int>(command, "@Time", result.Time, DbType.Int32);
                int i = command.ExecuteNonQuery();
                int k = 0;

                foreach (ShareResultTest x in shareResult)
                {
                    command.CommandText = "IF(EXISTS (SELECT * FROM ShareResult WHERE [User] = @User" + k + " AND QuestionID = @QuestionID" + k + ")) " +
                        "UPDATE ShareResult SET TrueAnswer = @TrueAnswer" + k + " WHERE[User] = @User" + k + " AND QuestionID = @QuestionID" + k + " " +
                        "ELSE INSERT INTO ShareResult ([User], QuestionID, TrueAnswer) VALUES(@User" + k + ", @QuestionID" + k + ", @TrueAnswer" + k + ")";
                    AddParam<string>(command, "@User" + k, User, DbType.String);
                    AddParam<int>(command, "@QuestionID" + k, x.QuestionID, DbType.Int32);
                    AddParam<bool>(command, "@TrueAnswer" + k, x.TrueAnswer, DbType.Boolean);
                    i = command.ExecuteNonQuery();
                    k++;
                }
            }
        }
    }
}
