namespace FinalProject.Infrostructure.Relase
{
    using DAL.Models;
    using FinalProject.Models;
    using FinalProject.Models.Abstract;

    public class ConcreteRuleFactory : RuleFactory<ConcreteIdentity, Account, Role>
    {
    }
}