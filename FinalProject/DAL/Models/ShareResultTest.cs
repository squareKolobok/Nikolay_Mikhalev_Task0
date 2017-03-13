namespace DAL.Models
{
    public class ShareResultTest
    {
        public int QuestionID { get; private set; }
        public bool TrueAnswer { get; private set; }

        public ShareResultTest(int QuestionID, bool TrueAnswer)
        {
            this.QuestionID = QuestionID;
            this.TrueAnswer = TrueAnswer;
        }
    }
}
