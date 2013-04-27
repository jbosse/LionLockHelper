using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerEmailAccount
    {
        public string SecretName { get; set; }
        public string EmailAddress { get; set; }
        public string IncomingServer { get; set; }
        public string OutgoingServer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public SecretServerEmailAccount(Secret secret)
        {
            SecretName = secret.Name;
            EmailAddress = secret.Items.First(item => item.FieldName.ToLower() == "email address").Value;
            IncomingServer = secret.Items.First(item => item.FieldName.ToLower() == "incoming server").Value;
            OutgoingServer = secret.Items.First(item => item.FieldName.ToLower() == "outgoing server").Value;
            Username = secret.Items.First(item => item.FieldName.ToLower() == "username").Value;
            Password = secret.Items.First(item => item.FieldName.ToLower() == "password").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}