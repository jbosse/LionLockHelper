namespace LionLockHelper.Dto
{
    public class LionLockLicenseKey
    {
        public string ProductName { get; set; }
        public string LicensedTo { get; set; }
        public string LicenseKey { get; set; }
        public string Notes { get; set; }

        public LionLockLicenseKey(SecretServerLicenseKey secret)
        {
            ProductName = secret.SoftwareName;
            LicenseKey = secret.LicenseKey;
            LicensedTo = secret.SecretName;
            Notes = string.Format("This secret had a file. Please see {0}.", secret.File);
        }

        public LionLockLicenseKey(SecretServerKeyFile secret)
        {
            ProductName = secret.SecretName;
            LicenseKey = "see notes";
            LicensedTo = string.Empty;
            Notes = secret.Key;
        }

        public LionLockLicenseKey(SecretServerCertificate secret)
        {
            ProductName = secret.SecretName;
            LicenseKey = secret.File;
            LicensedTo = secret.Name;
            Notes = secret.Notes;
        }

        public LionLockLicenseKey(SecretServerProductLicenseKey secret)
        {
            ProductName = secret.SecretName;
            LicenseKey = secret.LicenseKey;
            LicensedTo = secret.LicensedTo;
            Notes = secret.Notes;
        }
    }
}