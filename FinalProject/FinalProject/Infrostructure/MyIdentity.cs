namespace FinalProject.Infrostructure
{
    using DAL.Models;
    using FinalProject.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Principal;
    using System.Text;
    using System.Xml.Serialization;

    [Serializable]
    public class MyIdentity : IIdentity
    {
        private bool _isInitialized = false;
        private Account account;
        private Role role;
        public string[] Role { get; private set; }

        public string AuthenticationType
        {
            get
            {
                return String.Format("CustomizeAuthentication_{0}", typeof(Account).Name);
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return account != null;
            }
        }

        public string Name
        {
            get
            {
                return account.Login;
            }
        }

        public void Init(Account account)
        {
            this.account = account;
            role = account.role;
            _isInitialized = true;
            SetRoles();
    }

        private void SetRoles()
        {
            List<string> list = new List<string>();
            foreach (Role x in Enum.GetValues(typeof(Role)))
            {
                if (role <= x)
                {
                    list.Add(ConvertRoleToString.Convert(x));
                }
            }

            Role = list.ToArray();
        }

        public string Serialize()
        {
            if (!_isInitialized)
                throw new Exception();

            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(GetType());
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static MyIdentity Deserialize(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(MyIdentity));
                return (MyIdentity)formatter.Deserialize(stream);
            }
        }
    }
}