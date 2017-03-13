namespace FinalProject.Models.Abstract
{
    //TAccount -   Тип аккаунта в бизнес логике.
    public interface IAuthorizeService<in TAccount>
    {
        void SignIn(TAccount account, bool createPersistentCookie);
        void SignOut();
    }
}
