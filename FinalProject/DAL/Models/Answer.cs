namespace DAL.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }

        public Answer(string AnswerText, bool IsRight)
        {
            this.AnswerText = AnswerText;
            this.IsRight = IsRight;
        }

        public Answer(int AnswerID, string AnswerText, bool IsRight)
            : this(AnswerText, IsRight)
        {
            this.AnswerID = AnswerID;
        }
    }
}
