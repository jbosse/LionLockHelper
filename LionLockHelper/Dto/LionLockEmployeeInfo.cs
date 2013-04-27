using System;
using System.Linq;

namespace LionLockHelper.Dto
{
    public class LionLockEmployeeInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Ssn { get; set; }
        public string BirthDate { get; set; }
        public string StartDate { get; set; }
        public string Notes { get; set; }

        public LionLockEmployeeInfo(SecretServerSocialSecurityNumber secret)
        {
            FirstName = secret.Name.Split(Convert.ToChar(" ")).First();
            LastName = secret.Name.Split(Convert.ToChar(" ")).Last();
            EmailAddress = string.Empty;
            Address = string.Empty;
            EmergencyContact = string.Empty;
            WorkPhone = string.Empty;
            HomePhone = string.Empty;
            MobilePhone = string.Empty;
            BirthDate = string.Empty;
            StartDate = string.Empty;
            Ssn = secret.Ssn;
            Notes = secret.Notes;
        }
    }
}