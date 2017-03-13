namespace FinalProject.Infrostructure.Relase
{
    using Abstract;
    using DAL.Models;
    using FinalProject.Models;
    using FinalProject.Models.Abstract;
    using System;

    public class ConcreteAuthorizeService : AbstractAuthorizeService<ConcreteIdentity, Account, Role>
    {
    }
}