using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerPassword
    {
        public string SecretName { get; set; }
        public string Resource { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public SecretServerPassword(Secret secret)
        {
            SecretName = secret.Name;
            Resource = secret.Items.First(item => item.FieldName.ToLower() == "server").Value;
            Username = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}