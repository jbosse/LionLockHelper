using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerWindowsAccount
    {
        public string SecretName { get; set; }
        public string Machine { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public SecretServerWindowsAccount(Secret secret)
        {
            SecretName = secret.Name;
            Machine = secret.Items.First(item => item.FieldName.ToLower() == "machine").Value;
            Username = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}