namespace Mikhalev_Nikolay_Task01
{
    using System;

    internal class Employee : User
    {
        public const string POST = "cleaner";
        public const int EXPERIENCE = 25;
        private string post;
        private int experience;
        public string Post {
            get
            {
                return post;
            }
            set
            {
                post = value;
                experience = 0;
            }
        }
        public int Experience
        {
            get
            {
                return experience;
            }
            private set
            {
                experience = value;
            }
        }

        public Employee(string Surname, string name, string patronymic, DateTime birthdate, string Post, DateTime Experience)
            : base(Surname, name, patronymic, birthdate)
        {
            this.Post = Post;
            DateTime date = new DateTime(Experience.Year - 18, Experience.Month, Experience.Day);
            this.Experience = 0;

            if (date > birthdate)
                this.Experience = new DateTime(DateTime.Now.Year, Experience.Month, Experience.Day) < DateTime.Now ? DateTime.Now.Year - Experience.Year - 1 :
                    DateTime.Now.Year - Experience.Year;
        }

        public Employee()
            :base()
        {
            Post = POST;
            Experience = EXPERIENCE;
        }
    }
}