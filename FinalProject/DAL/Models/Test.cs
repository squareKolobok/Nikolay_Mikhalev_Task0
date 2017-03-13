namespace DAL.Models
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public int TestID { get; private set; }
        public string NameTest { get; private set; }
        public int Time { get; private set; }
        public int Count { get; private set; }
        public string User { get; private set; }
        public DateTime Date { get; private set; }
        public List<Question> Questions { get; private set; }

        public Test(int TestID, string NameTest, int Time)
        {
            this.TestID = TestID;
            this.NameTest = NameTest;
            this.Time = Time;
        }
        public Test(int TestID, string NameTest, int Time, List<Question> Questions)
            : this(TestID, NameTest, Time)
        {
            this.Questions = Questions;
            Count = Questions != null ? Questions.Count : 0;
        }
        public Test(int TestID, string NameTest, int Time, string User, DateTime Date, List<Question> Questions)
            : this(TestID, NameTest, Time, Questions)
        {
            this.User = User;
            this.Date = Date;
            Count = Questions != null ? Questions.Count : 0;
        }

        public Test(int TestID, string NameTest, int Time, int Count, string User, DateTime Date, List<Question> Questions)
            : this(TestID, NameTest, Time, User, Date, Questions)
        {
            this.Count = Count;
        }
    }
}
