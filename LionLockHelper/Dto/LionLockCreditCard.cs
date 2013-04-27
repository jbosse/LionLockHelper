namespace LionLockHelper.Dto
{
    public class LionLockCreditCard
    {
        public string FullName { get; set; }
        public string Number { get; set; }
        public string CvvNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CardType { get; set; }
        public string Notes { get; set; }

        public LionLockCreditCard(SecretServerCreditCard secret)
        {
            FullName = secret.FullName;
            Number = secret.CardNumber;
            CvvNumber = secret.SecurityCode;
            ExpirationDate = secret.ExpirationDate;
            CardType = secret.CardType;
            Notes = secret.Notes;
        }
    }
}