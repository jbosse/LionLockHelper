using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerLicenseKey
    {
        public string SecretName { get; set; }
        public string SoftwareName { get; set; }
        public string LicenseKey { get; set; }
        public string File { get; set; }
        public string Notes { get; set; }

        public SecretServerLicenseKey(Secret secret)
        {
            SecretName = secret.Name;
            SoftwareName = secret.Items.First(item => item.FieldName.ToLower() == "software name").Value;
            LicenseKey = secret.Items.First(item => item.FieldName.ToLower() == "license key").Value;
            File = string.Format("https://secretserveronline.com/SecretView.aspx?secretid={0}", secret.Id);
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}