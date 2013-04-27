namespace LionLockHelper.Dto
{
    public class LionLockPassword
    {
        public string SecretName { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public LionLockPassword(SecretServerPassword secret)
        {
            SecretName = secret.SecretName;
            Description = secret.Resource;
            Password = secret.Password;
            Notes = string.Format("Username: {0}\n{1}", secret.Username, secret.Notes);
        }

        public LionLockPassword(SecretServerActiveDirectory secret)
        {
            SecretName = secret.SecretName;
            Description = secret.Domain;
            Password = secret.Password;
            Notes = string.Format("Username: {0}\n{1}", secret.Username, secret.Notes);
        }

        public LionLockPassword(SecretServerWindowsAccount secret)
        {
            SecretName = secret.SecretName;
            Description = secret.Machine;
            Password = secret.Password;
            Notes = string.Format("Username: {0}\n{1}", secret.Username, secret.Notes);
        }

        public LionLockPassword(SecretServerRemoteDesktopAccount secret)
        {
            SecretName = secret.SecretName;
            Description = secret.Computer;
            Password = secret.Password;
            Notes = string.Format("Username: {0}\nDomain: {1}\n{2}", secret.Username, secret.Domain, secret.Notes);
        }
    }
}