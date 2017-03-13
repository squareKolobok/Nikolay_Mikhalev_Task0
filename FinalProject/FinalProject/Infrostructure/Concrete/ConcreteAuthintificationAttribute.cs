namespace FinalProject.Infrostructure.Relase
{
    using DAL.Models;
    using FinalProject.Models.Abstract;
    using System.Linq;

    public class ConcreteAuthintificationAttribute : AbstractAutintificateAttribute
    {
        private readonly ConcreteRuleFactory _ruleFactory = new ConcreteRuleFactory();

        public ConcreteAuthintificationAttribute(params Role[] allowedRole) : 
            base(allowedRole.Any())
        {
            AddRule(_ruleFactory.Create(account => allowedRole.Intersect(account.Roles).Any()));

            AddRule(_ruleFactory.Create(account => account.Roles.Any(c => c == Role.Administrator)));
        }
    }
}