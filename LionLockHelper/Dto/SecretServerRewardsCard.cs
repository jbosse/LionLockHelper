using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerRewardsCard
    {
        public string SecretName { get; set; }
        public string CardNumber { get; set; }
        public string Notes { get; set; }

        public SecretServerRewardsCard(Secret secret)
        {
            SecretName = secret.Name;
            CardNumber = secret.Items.First(item => item.FieldName.ToLower() == "cardnumber").Value;
            Notes = secret.Items.First(item => item.FieldName.ToLower() == "notes").Value;
        }
    }
}