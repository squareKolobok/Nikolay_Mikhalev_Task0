namespace FinalProject.Infrostructure.Relase
{
    using DAL.Models;
    using FinalProject.Models;
    using FinalProject.Models.Abstract;
    using System;
    using System.Collections.Generic;

    public class ConcreteIdentity : AbstractIdentity<Account, Role>
    {
        protected override long GetId(Account account)
        {
            return 1;
        }

        protected override string GetName(Account account)
        {
            return account.Login;
        }

        protected override Role[] GetRole(Account account)
        {
            List<Role> role = new List<Role>();
            role.Add(account.role);

            foreach (Role x in Enum.GetValues(typeof(Role)))
            {
                if (x > account.role)
                    role.Add(x);
            }

            return role.ToArray();
        }
    }
}