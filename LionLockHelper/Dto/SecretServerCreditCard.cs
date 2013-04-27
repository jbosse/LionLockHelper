using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerCreditCard
    {
        public string SecretName { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string CardType { get; set; }
        public string Notes { get; set; }

        public SecretServerCreditCard(Secret secret)
        {
            SecretName = secret.Name;
            FullName = secret.Items.First(item => item.FieldName.ToLower() == "fullname").Value;
            CardNumber = secret.Items.First(item => item.FieldName.ToLower() == "number").Value;
            ExpirationDate = secret.Items.First(item => item.FieldName.ToLower() == "expirationdate").Value;
            SecurityCode = secret.Items.First(item => item.FieldName.ToLower() == "securitycode").Value;
            CardType = secret.Items.First(item => item.FieldName.ToLower() == "cardtype").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}