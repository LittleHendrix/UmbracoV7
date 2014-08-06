namespace UmbracoV7Demo.Core
{
    using System.Configuration;
    using UmbracoV7Demo.ViewModels;

    public class EmailDispatcher
    {
        public static void SendContactEmail(ContactViewModel model)
        {
            var to = ConfigurationManager.AppSettings["ContactEmailAddress"] ?? "luchen_sv@msn.com";
            var em = new EmailManager();
            em.SendMail(to, "Umbraco V7 Demo Contact", "EmailContact", model);
        }
    }
}