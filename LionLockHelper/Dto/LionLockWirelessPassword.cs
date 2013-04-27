namespace LionLockHelper.Dto
{
    public class LionLockWirelessPassword
    {
        public string NetworkName { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public LionLockWirelessPassword(SecretServerWifiKey secret)
        {
            NetworkName = secret.Ssid;
            Password = secret.Key;
            Notes = string.Format("Key Type: {0}\nOriginal Secret Name: {1}", secret.KeyType, secret.SecretName);
        }
    }
}