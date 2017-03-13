namespace DAL.Models
{
    public class ResultTest
    {
        public int TestID { get; private set; }
        public string TestName { get; private set; }
        public int CountTrueAnswers { get; private set; }
        public int Time { get; private set; }

        public ResultTest(int TestID, int CountTrueAnswers, int Time)
        {
            this.TestID = TestID;
            this.CountTrueAnswers = CountTrueAnswers;
            this.Time = Time;
        }

        public ResultTest(int TestID, string TestName, int CountTrueAnswers, int Time)
            : this(TestID, CountTrueAnswers, Time)
        {
            this.TestName = TestName;
        }
    }
}
