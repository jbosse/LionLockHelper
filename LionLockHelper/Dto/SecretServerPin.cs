using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerPin
    {
        public string SecretName { get; set; }
        public string PinCode { get; set; }
        public string Notes { get; set; }

        public SecretServerPin(Secret secret)
        {
            SecretName = secret.Name;
            PinCode = secret.Items.First(item => item.FieldName.ToLower() == "pincode").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}