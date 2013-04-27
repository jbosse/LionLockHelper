using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerKeyFile
    {
        public string SecretName { get; set; }
        public string Key { get; set; }

        public SecretServerKeyFile(Secret secret)
        {
            SecretName = secret.Name;
            Key = secret.Items.First(item => item.FieldName.ToLower() == "key").Value;
        }
    }
}