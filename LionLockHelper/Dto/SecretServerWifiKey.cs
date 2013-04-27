using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerWifiKey
    {
        public string SecretName { get; set; }
        public string Ssid { get; set; }
        public string KeyType { get; set; }
        public string Key { get; set; }

        public SecretServerWifiKey(Secret secret)
        {
            SecretName = secret.Name;
            Ssid = secret.Items.First(item => item.FieldName.ToLower() == "ssid").Value;
            KeyType = secret.Items.First(item => item.FieldName.ToLower() == "key type").Value;
            Key = secret.Items.First(item => item.FieldName.ToLower() == "key").Value;
        }
    }
}