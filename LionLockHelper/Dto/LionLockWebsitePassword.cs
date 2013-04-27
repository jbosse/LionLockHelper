namespace LionLockHelper.Dto
{
    public class LionLockWebsitePassword
    {
        public string WebsiteAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public LionLockWebsitePassword(SecretServerWebPassword secret)
        {
            WebsiteAddress = secret.Url;
            UserName = secret.UserName;
            Password = secret.Password;
            Notes = secret.Notes;
        }

        public LionLockWebsitePassword(SecretServerEmailAccount secret)
        {
            WebsiteAddress = secret.IncomingServer;
            UserName = secret.Username;
            Password = secret.Password;
            Notes = string.Format("Incoming Server: {0}\nOutgoing Server: {1}\nEmail Address: {2}\n{3}", secret.IncomingServer, secret.OutgoingServer, secret.EmailAddress, secret.Notes);
        }
    }
}