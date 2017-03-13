namespace FinalProject.Models
{
    using DAL.Models;

    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
    }
}