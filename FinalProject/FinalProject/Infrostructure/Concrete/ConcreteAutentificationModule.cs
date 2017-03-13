namespace FinalProject.Infrostructure.Relase
{
    using DAL.Models;
    using FinalProject.Models;
    using FinalProject.Models.Abstract;

    public class ConcreteAutentificationModule : AbstractAutentificationModule<ConcreteIdentity, Account, Role>
    {
    }
}