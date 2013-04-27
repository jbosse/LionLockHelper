using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerProductLicenseKey
    {
        public string SecretName { get; set; }
        public string LicensedTo { get; set; }
        public string ProductName { get; set; }
        public string LicenseKey { get; set; }
        public string Notes { get; set; }

        public SecretServerProductLicenseKey(Secret secret)
        {
            SecretName = secret.Name;
            LicensedTo = secret.Items.First(item => item.FieldName.ToLower() == "licensed to").Value;
            ProductName = secret.Items.First(item => item.FieldName.ToLower() == "product name").Value;
            LicenseKey = secret.Items.First(item => item.FieldName.ToLower() == "license key").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}