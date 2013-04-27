using System.Linq;
using LionLockHelper.SecretServerOnline;

namespace LionLockHelper.Dto
{
    public class SecretServerLibraryCard
    {
        public string SecretName { get; set; }
        public string Library { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }

        public SecretServerLibraryCard(Secret secret)
        {
            SecretName = secret.Name;
            Library = secret.Items.First(item => item.FieldName.ToLower() == "library").Value;
            CardNumber = secret.Items.First(item => item.FieldName.ToLower() == "card number").Value;
            Pin = secret.Items.First(item => item.FieldName.ToLower() == "pin").Value;
        }

    }
}