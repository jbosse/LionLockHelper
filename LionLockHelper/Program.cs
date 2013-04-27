using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LionLockHelper.SecretServerOnline;
using ServiceStack.Text;
using WatiN.Core;

namespace LionLockHelper
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            var service = new SSWebServiceSoapClient();
            Console.WriteLine("username:");
            var username = Console.ReadLine();
            Console.WriteLine("password:"); 
            var password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("org:");
            var org = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("dry run (y/n):");
            var dryRun = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("authenticating...");
            var result = service.Authenticate(username, password, org, "");
            var authToken = result.Token;
            Console.Clear();
            Console.WriteLine("getting secrets...");
            var summaries = service.SearchSecrets(authToken, "").SecretSummaries;
            Console.Clear();
            Console.WriteLine("getting templates...");
            var me = service.GetSecretTemplates(authToken).SecretTemplates;
            var templates = new List<TemplateCount>();
            Console.Clear();
            Console.Write("checking templates");
            var templateStringBuilder = new StringBuilder();
            var secretStringBuilder = new StringBuilder();
            secretStringBuilder.AppendLine("{\"d\":[");
            var log = new StringBuilder();            
            
            Console.Clear();
            var browser = new IE("https://lionlock.com/App/Account/Login");
            Console.WriteLine("Login then press enter.");
            Console.ReadLine();
            Console.Clear();
            var favorites = service.GetFavorites(authToken);
            var converter = new SecretConverter(browser, dryRun.ToLower() == "y", favorites.SecretSummaries, log);


            foreach (var secretSummary in summaries)
            {
                var percent = (int) ((Array.IndexOf(summaries, secretSummary)/(double) summaries.Length)*100);
                RenderConsoleProgress(percent, '+', ConsoleColor.Green, "Loading Secrets, " + percent + "% Completed (" + secretSummary.SecretName + ")");
                var secret = service.GetSecret(authToken, secretSummary.SecretId);
                var template = me.First(t => t.Id == secretSummary.SecretTypeId);


                converter.Convert(template.Name, secret.Secret);
                
                if (secret.Secret.Items.Any(item => item.IsFile))
                {
                    log.AppendLine(secret.Secret.Name + " has a file (" + template.Name + ").");
                }
                if (templates.All(t => t.Name != template.Name))
                {
                    secretStringBuilder.AppendLine(secret.ToJson());
                    templates.Add(new TemplateCount {Name = template.Name, Count = 1});
                    templateStringBuilder.AppendLine(template.ToJson());
                }
                else
                {
                    templates.First(t => t.Name == template.Name).Count++;
                }
                secretStringBuilder.AppendLine(",");
            }


            RenderConsoleProgress(100, '+', ConsoleColor.Green, "Loading Secrets, 100% Completed");
            Console.Clear();
            secretStringBuilder.AppendLine("]}");
            var text = "";
            foreach (var template in templates)
            {
                text = text + string.Format("{0} ({1})", template.Name, template.Count);
                Console.Out.WriteLine("{0} ({1})", template.Name, template.Count);

                text = text + "\n";
            }
            Console.ReadLine();
            //File.WriteAllText("D:\\SecretStats.txt", text);
            File.WriteAllText("D:\\Log.txt", log.ToString());
            //File.WriteAllText("D:\\TemplateExport.txt", templateStringBuilder.ToString());
            //File.WriteAllText("D:\\SecretExport.json", secretStringBuilder.ToString());
        }

        public static void OverwriteConsoleMessage(string message)
        {
            Console.CursorLeft = 0;
            int maxCharacterWidth = Console.WindowWidth - 1;
            if (message.Length > maxCharacterWidth)
            {
                message = message.Substring(0, maxCharacterWidth - 3) + "...";
            }
            message = message + new string(' ', maxCharacterWidth - message.Length);
            Console.Write(message);
        }

        public static void RenderConsoleProgress(int percentage)
        {
            RenderConsoleProgress(percentage, '\u2590', Console.ForegroundColor, "");
        }

        public static void RenderConsoleProgress(int percentage, char progressBarCharacter,
                                                 ConsoleColor color, string message)
        {
            Console.CursorVisible = false;
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.CursorLeft = 0;
            var width = Console.WindowWidth - 1;
            var newWidth = (int) ((width*percentage)/100d);
            var progBar = new string(progressBarCharacter, newWidth) +
                             new string(' ', width - newWidth);
            Console.Write(progBar);
            if (string.IsNullOrEmpty(message)) message = "";
            Console.CursorTop++;
            OverwriteConsoleMessage(message);
            Console.CursorTop--;
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = true;
        }


    }

    public class TemplateCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

}