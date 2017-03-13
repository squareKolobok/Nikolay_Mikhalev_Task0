namespace FinalProject.Models.Abstract
{
    using System.Security.Principal;

    public interface IRule
    {
        bool Check(IIdentity user);
    }
}
