using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerWebPassword
    {
        public string SecretName { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public SecretServerWebPassword(Secret secret)
        {
            SecretName = secret.Name;
            Url = secret.Items.First(item => item.FieldName.ToLower() == "url").Value;
            UserName = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}