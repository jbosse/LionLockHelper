using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerRemoteDesktopAccount
    {
        public string SecretName { get; set; }
        public string Computer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string Notes { get; set; }

        public SecretServerRemoteDesktopAccount(Secret secret)
        {
            SecretName = secret.Name;
            Computer = secret.Items.First(item => item.FieldName.ToLower() == "computer").Value;
            Username = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Domain = secret.Items.First(item => item.FieldName.ToLower() == "domain").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}