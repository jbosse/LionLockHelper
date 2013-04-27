using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerSocialSecurityNumber
    {
        public string SecretName { get; set; }
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Notes { get; set; }

        public SecretServerSocialSecurityNumber(Secret secret)
        {
            SecretName = secret.Name;
            Name = secret.Items.First(item => item.FieldName.ToLower() == "name").Value;
            Ssn = secret.Items.First(item => item.FieldName.ToLower() == "ssn").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}