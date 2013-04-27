namespace LionLockHelper.Dto
{
    public class LionLockBankAcccount
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string Notes { get; set; }
        
        public LionLockBankAcccount(SecretServerBankAccount secret)
        {
            BankName = secret.BankName;
            AccountNumber = secret.AccountNumber;
            RoutingNumber = secret.RoutingNumber;
            Address = ConvertAddress(secret.Address1, secret.Address2, secret.Address3);
            ContactPerson = secret.ContactPerson;
            ContactPhone = secret.ContactPhone;
            Notes = secret.Notes;
        }

        private string ConvertAddress(string address1, string address2, string address3)
        {
            var address = address1;
            if (!string.IsNullOrWhiteSpace(address2))
            {
                address += "\n" + address2;
            }
            if (!string.IsNullOrWhiteSpace(address3))
            {
                address += "\n" + address3;
            }
            return address;
        }
    }
}