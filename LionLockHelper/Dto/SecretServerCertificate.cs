using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerCertificate
    {
        public string SecretName { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
        public string Notes { get; set; }
        

        public SecretServerCertificate(Secret secret)
        {
            SecretName = secret.Name;
            Name = secret.Items.First(item => item.FieldName.ToLower() == "name").Value;
            File = string.Format("https://secretserveronline.com/SecretView.aspx?secretid={0}", secret.Id);
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}