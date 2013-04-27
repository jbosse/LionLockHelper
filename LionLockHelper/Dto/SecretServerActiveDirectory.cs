using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerActiveDirectory
    {
        public string SecretName { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public SecretServerActiveDirectory(Secret secret)
        {
            SecretName = secret.Name;
            Domain = secret.Items.First(item => item.FieldName.ToLower() == "domain").Value;
            Username = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}