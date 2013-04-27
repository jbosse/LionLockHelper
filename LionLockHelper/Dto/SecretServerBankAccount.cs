using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerBankAccount
    {
        public string SecretName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string BankName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string Notes { get; set; }

        public SecretServerBankAccount(Secret secret)
        {
            SecretName = secret.Name;
            AccountNumber = secret.Items.First(item => item.FieldName.ToLower() == "bankaccountnumber").Value;
            RoutingNumber = secret.Items.First(item => item.FieldName.ToLower() == "transitroutingnumber").Value;
            BankName = secret.Items.First(item => item.FieldName.ToLower() == "nameofbank").Value;
            Address1 = secret.Items.First(item => item.FieldName.ToLower() == "address1").Value;
            Address2 = secret.Items.First(item => item.FieldName.ToLower() == "address2").Value;
            Address3 = secret.Items.First(item => item.FieldName.ToLower() == "address3").Value;
            ContactPerson = secret.Items.First(item => item.FieldName.ToLower() == "contactperson").Value;
            ContactPhone = secret.Items.First(item => item.FieldName.ToLower() == "contactphone").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}