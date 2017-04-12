namespace FinalProject.Models
{
    using DAL.Models;

    public class Login
    {
        public string Name { get; set; }
        public string Password { get; set; }
        Role role { get; set; }
    }
}