namespace FinalProject.Infrostructure
{
    using System.Security.Principal;
    using System.Web;

    interface IAuth<TAccount>
    {
        void Login(TAccount account);

        void Logout();
    }
}
