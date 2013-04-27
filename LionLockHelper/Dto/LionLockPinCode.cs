namespace LionLockHelper.Dto
{
    public class LionLockPinCode
    {
        public string SecretName { get; set; }
        public string PinCode { get; set; }
        public string Notes { get; set; }

        public LionLockPinCode(SecretServerPin secret)
        {
            SecretName = secret.SecretName;
            PinCode = secret.PinCode;
            Notes = secret.Notes;
        }

        public LionLockPinCode(SecretServerLibraryCard secret)
        {
            SecretName = secret.SecretName;
            PinCode = secret.Pin;
            Notes = string.Format("Library: {0}\nCard Number: {1}", secret.Library, secret.CardNumber);
        }

        public LionLockPinCode(SecretServerRewardsCard secret)
        {
            SecretName = secret.SecretName;
            PinCode = "0000";
            Notes = string.Format("Card Number: {0}\n{1}", secret.CardNumber, secret.Notes);
        }
    }
}