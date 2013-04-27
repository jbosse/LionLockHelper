using System;
using System.Linq;
using System.Text;
using System.Threading;
using LionLockHelper.Dto;
using LionLockHelper.SecretServerOnline;
using WatiN.Core;

namespace LionLockHelper
{
    public class SecretConverter
    {
        private readonly Browser _browser;
        private readonly bool _dryRun;
        private readonly SecretSummary[] _favorites;
        private readonly StringBuilder _log;

        public SecretConverter(Browser browser, bool dryRun, SecretSummary[] favorites, StringBuilder log)
        {
            _browser = browser;
            _dryRun = dryRun;
            _favorites = favorites;
            _log = log;
        }

        public void Convert(string template, Secret secret)
        {
            _browser.NativeBrowser.NavigateTo(new Uri("https://lionlock.com/App/Secret/SecretSelectTemplate"));
            switch (template)
            {
                case "Bank Account":
                    ConvertBankAccount(secret);
                    break;
                case "Credit Card":
                    ConvertCreditCard(secret);
                    break;
                case "Social Security Number":
                    ConvertSsn(secret);
                    break;
                case "License Key":
                    ConvertLicenseKey(secret);
                    break;
                case "KeyFile":
                    ConvertKeyFile(secret);
                    break;
                case "Certificate":
                    ConvertCertificate(secret);
                    break;
                case "Product License Key":
                    ConvertProductLicenceKey(secret);
                    break;
                case "Password":
                    ConvertPassword(secret);
                    break;
                case "Active Directory Account":
                    ConvertActiveDirectory(secret);
                    break;
                case "Windows Account":
                    ConvertWindowsAccounts(secret);
                    break;
                case "Remote Desktop Account":
                    ConvertRemoteDesktopAccount(secret);
                    break;
                case "Pin":
                    ConvertPin(secret);
                    break;
                case "Library Card":
                    ConvertLibraryCard(secret);
                    break;
                case "Rewards Card":
                    ConvertRewardsCard(secret);
                    break;
                case "Web Password":
                    ConvertWebPassword(secret);
                    break;
                case "Email Account":
                    ConvertEmailAccount(secret);
                    break;
                case "WiFi Key":
                    ConvertWifiKey(secret);
                    break;
                default:
                    throw new NotImplementedException();
            }
            Save(secret);
            FavoriteIfNeeded(secret);
            _log.AppendLine("---");
        }

        private void FavoriteIfNeeded(Secret secret)
        {
            if (_dryRun || !_browser.Url.Contains("secretId") || _favorites.All(f => f.SecretId != secret.Id))
            {
                return;
            }
            _log.AppendLine("Secret " + secret.Name + " favorited.");
            var newId = _browser.Url.Split('=').Last();
            _browser.GoTo("https://lionlock.com/App/Secret/SecretList");
            var tile = _browser.Div("SecretList_" + newId);
            tile.Click();
            var favButton = _browser.Link("SecretFavorite_" + newId);
            favButton.Click();
        }

        private void ConvertBankAccount(Secret secret)
        {
            var newSecret = new LionLockBankAcccount(new SecretServerBankAccount(secret));
            _browser.Link(Find.ByText("Bank Account")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.BankName;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.AccountNumber;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.RoutingNumber;
            _browser.TextField(Find.ById("Items_3__Value")).Value = newSecret.Address;
            _browser.TextField(Find.ById("Items_4__Value")).Value = newSecret.ContactPerson;
            _browser.TextField(Find.ById("Items_5__Value")).Value = newSecret.ContactPhone;
            _browser.TextField(Find.ById("Items_6__Value")).Value = newSecret.Notes;
        }

        private void ConvertCreditCard(Secret secret)
        {
            var newSecret = new LionLockCreditCard(new SecretServerCreditCard(secret));
            _browser.Link(Find.ByText("Credit Card")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.FullName;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.Number;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.CvvNumber;
            _browser.TextField(Find.ById("Items_3__Value")).Value = newSecret.ExpirationDate;
            _browser.TextField(Find.ById("Items_4__Value")).Value = newSecret.CardType;
            _browser.TextField(Find.ById("Items_5__Value")).Value = newSecret.Notes;
        }

        private void ConvertSsn(Secret secret)
        {
            var newSecret = new LionLockEmployeeInfo(new SecretServerSocialSecurityNumber(secret));
            _browser.Link(Find.ByText("Employee Info")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.FirstName;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.LastName;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.EmailAddress;
            _browser.TextField(Find.ById("Items_3__Value")).Value = newSecret.Address;
            _browser.TextField(Find.ById("Items_4__Value")).Value = newSecret.EmergencyContact;
            _browser.TextField(Find.ById("Items_5__Value")).Value = newSecret.WorkPhone;
            _browser.TextField(Find.ById("Items_6__Value")).Value = newSecret.HomePhone;
            _browser.TextField(Find.ById("Items_7__Value")).Value = newSecret.MobilePhone;
            _browser.TextField(Find.ById("Items_8__Value")).Value = newSecret.Ssn;
            _browser.TextField(Find.ById("Items_9__Value")).Value = newSecret.BirthDate;
            _browser.TextField(Find.ById("Items_10__Value")).Value = newSecret.StartDate;
            _browser.TextField(Find.ById("Items_11__Value")).Value = newSecret.Notes;
        }

        private void CreateLicenseKey(LionLockLicenseKey newSecret)
        {
            _browser.Link(Find.ByText("License Key")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.ProductName;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.LicensedTo;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.LicenseKey;
            _browser.TextField(Find.ById("Items_3__Value")).Value = newSecret.Notes;
        }

        private void CreatePassword(LionLockPassword newSecret)
        {
            _browser.Link(Find.ByText("Password")).Click();
            _browser.TextField(Find.ById("SecretName")).Value = newSecret.SecretName;
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.Description;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.Password;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.Notes;
        }

        private void CreatePinCode(LionLockPinCode newSecret)
        {
            _browser.Link(Find.ByText("Pin Code")).Click();
            _browser.TextField(Find.ById("SecretName")).Value = newSecret.SecretName;
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.PinCode;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.Notes;
        }

        private void CreateWebsitePassword(LionLockWebsitePassword newSecret)
        {
            _browser.Link(Find.ByText("Website Password")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.WebsiteAddress;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.UserName;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.Password;
            _browser.TextField(Find.ById("Items_3__Value")).Value = newSecret.Notes;
        }

        private void ConvertLicenseKey(Secret secret)
        {
            var newSecret = new LionLockLicenseKey(new SecretServerLicenseKey(secret));
            CreateLicenseKey(newSecret);
        }

        private void ConvertKeyFile(Secret secret)
        {
            var newSecret = new LionLockLicenseKey(new SecretServerKeyFile(secret));
            CreateLicenseKey(newSecret);
        }

        private void ConvertCertificate(Secret secret)
        {
            var newSecret = new LionLockLicenseKey(new SecretServerCertificate(secret));
            CreateLicenseKey(newSecret);
        }

        private void ConvertProductLicenceKey(Secret secret)
        {
            var newSecret = new LionLockLicenseKey(new SecretServerProductLicenseKey(secret));
            CreateLicenseKey(newSecret);
        }

        private void ConvertPassword(Secret secret)
        {
            var newSecret = new LionLockPassword(new SecretServerPassword(secret));
            CreatePassword(newSecret);
        }

        private void ConvertActiveDirectory(Secret secret)
        {
            var newSecret = new LionLockPassword(new SecretServerActiveDirectory(secret));
            CreatePassword(newSecret);
        }

        private void ConvertWindowsAccounts(Secret secret)
        {
            var newSecret = new LionLockPassword(new SecretServerWindowsAccount(secret));
            CreatePassword(newSecret);
        }

        private void ConvertRemoteDesktopAccount(Secret secret)
        {
            var newSecret = new LionLockPassword(new SecretServerRemoteDesktopAccount(secret));
            CreatePassword(newSecret);
        }

        private void ConvertPin(Secret secret)
        {
            var newSecret = new LionLockPinCode(new SecretServerPin(secret));
            CreatePinCode(newSecret);
        }

        private void ConvertLibraryCard(Secret secret)
        {
            var newSecret = new LionLockPinCode(new SecretServerLibraryCard(secret));
            CreatePinCode(newSecret);
        }

        private void ConvertRewardsCard(Secret secret)
        {
            var newSecret = new LionLockPinCode(new SecretServerRewardsCard(secret));
            CreatePinCode(newSecret);
        }

        private void ConvertWebPassword(Secret secret)
        {
            var newSecret = new LionLockWebsitePassword(new SecretServerWebPassword(secret));
            CreateWebsitePassword(newSecret);
        }

        private void ConvertEmailAccount(Secret secret)
        {
            var newSecret = new LionLockWebsitePassword(new SecretServerEmailAccount(secret));
            CreateWebsitePassword(newSecret);

        }

        private void ConvertWifiKey(Secret secret)
        {
            var newSecret = new LionLockWirelessPassword(new SecretServerWifiKey(secret));
            _browser.Link(Find.ByText("Wireless Password")).Click();
            _browser.TextField(Find.ById("Items_0__Value")).Value = newSecret.NetworkName;
            _browser.TextField(Find.ById("Items_1__Value")).Value = newSecret.Password;
            _browser.TextField(Find.ById("Items_2__Value")).Value = newSecret.Notes;
        }

        private void Save(Secret secret)
        {
            if (_dryRun)
            {
                _log.AppendLine("Dry Run: Secret " + secret.Name + " converted.");
                _browser.Link("Cancel").Click();
                return;
            }
            _browser.Button("Save").Click();
            if (!_browser.Url.Contains("SecretShare"))
            {
                _log.AppendLine("* warning * Secret " + secret.Name + " conversion had issue requiring manual intervention.");
                Console.WriteLine("There is an issue. Please resolve and hit enter to continue.");
                Console.ReadLine();
            }
            if (_browser.Url.Contains("Error"))
            {
                _log.AppendLine("*** ERROR *** Secret " + secret.Name + " conversion error.");
                return;
            }
            var newId = _browser.Url.Split('=').Last();
            _log.AppendLine("Secret " + secret.Name + " converted (old: " + secret.Id + ", new: " + newId + ").");
        }
    }
}