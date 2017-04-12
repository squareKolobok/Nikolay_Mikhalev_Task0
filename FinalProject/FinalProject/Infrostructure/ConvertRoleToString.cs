namespace FinalProject.Infrostructure
{
    using DAL.Models;
    using System;

    public class ConvertRoleToString
    {
        public static string Convert(Role role)
        {
            switch (role)
            {
                case Role.Administrator: return "Administrator";
                case Role.Moderator: return "Moderator";
                default: return "User";
            }
        }
    }
}