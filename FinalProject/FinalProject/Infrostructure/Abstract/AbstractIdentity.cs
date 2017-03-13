namespace FinalProject.Models.Abstract
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Xml.Serialization;

    [Serializable]
    public abstract class AbstractIdentity<TAccount, TRole> : MarshalByRefObject, IIdentity
    {

        private bool _isInitialized = false;

        public string Name { get; set; }
        public string AuthenticationType
        {
            get
            {
                return String.Format("CustomizeAuthentication_{0}", typeof(TAccount).Name);
            }
        }
        public string[] Role { get; set; }
        public TRole[] Roles { get; set; }
        public bool IsAuthenticated
        {
            get { return Name != null; }
        }
        public bool CheckRole(TRole role)
        {
            return Role.All(r => r.Equals(role.ToString()));
        }

        public void SetAccount(TAccount account)
        {
            Name = GetName(account);


            Roles = GetRole(account);
            Role = Roles.Select(c => c.ToString()).ToArray();
            InitializeMoreFields(account);
            _isInitialized = true;
        }
        protected virtual void InitializeMoreFields(TAccount account) { }

        protected abstract long GetId(TAccount account);
        protected abstract string GetName(TAccount account);
        protected abstract TRole[] GetRole(TAccount account);

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
        public static TIdenty Deserialize<TIdenty>(string value)
            where TIdenty : AbstractIdentity<TAccount, TRole>
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(TIdenty));
                return (TIdenty)formatter.Deserialize(stream);
            }
        }
    }
}