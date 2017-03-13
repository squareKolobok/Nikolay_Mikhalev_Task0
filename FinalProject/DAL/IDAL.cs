namespace DAL
{
    using Models;
    using System.Collections.Generic;

    interface IDAL
    {
        List<Test> SearchTest(string TestName);

        //получение общей информации по тестам
        List<ResultTest> GetResultTests(string User);

        //получение подробной информации по тесту
        List<ShareResultTest> GetShareResultTest(string User, int TestID);

        //получение списка вопросов и ответов данного теста
        Test GetTest(int TestID);

        //добавление пользователя
        void CreateUser(string Name, string Password);

        //изменение статуса пользователя
        bool ChangeStatus(string person, string goal, Role typeUser);

        //удаление ответа теста
        void DeleteAnswer(int AnswerID);

        //удаление вопроса теста
        void DeleteQuestion(int QuestionID);

        //удаление теста
        void DeleteTest(int TestID);

        //запись пройденного теста
        void WriteResult(string User, ResultTest result, List<ShareResultTest> shareResult);
    }
}
