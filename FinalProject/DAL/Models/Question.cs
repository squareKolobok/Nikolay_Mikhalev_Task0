namespace DAL.Models
{
    using System.Collections.Generic;

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get;set; }
        public string File { get; set; }
        public TypeQuestion TypeQuest { get; set; }
        public List<Answer> Answers { get; set; }

        public Question(int QuestionID, string QuestionText, string File, TypeQuestion TypeQuest, List<Answer> Answers)
        {
            this.QuestionID = QuestionID;
            this.QuestionText = QuestionText;
            this.File = File;
            this.TypeQuest = TypeQuest;
            this.Answers = Answers;
        }
    }
}
