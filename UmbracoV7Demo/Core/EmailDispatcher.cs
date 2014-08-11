namespace UmbracoV7Demo.Core
{
    using System.Configuration;

    using Umbraco.Core;

    using UmbracoV7Demo.ViewModels;

    public class EmailDispatcher
    {
        public static void SendContactEmail(ContactViewModel model)
        {
            const string msgDocTypeAlias = "Message";
            const string namePropperty = "name";
            const string emailPropperty = "email";
            const string subjectPropperty = "subject";
            const string messagePropperty = "message";
            const string datetimePropperty = "submitDate";

            var to = ConfigurationManager.AppSettings["ContactEmailAddress"] ?? "luchen_sv@msn.com";
            var em = new EmailManager();
            em.SendMail(to, "Umbraco V7 Demo Contact", "EmailContact", model);

            var cs = ApplicationContext.Current.Services.ContentService;

            var content = cs.CreateContent(model.EmailAddress, 1096, msgDocTypeAlias);
            content.Name = model.EmailAddress;
            content.SetValue(namePropperty, model.Name);
            content.SetValue(emailPropperty, model.EmailAddress);
            content.SetValue(subjectPropperty, model.Subject);
            content.SetValue(messagePropperty, model.Message);
            content.SetValue(datetimePropperty, model.SubmitDate.ToString("f"));

            cs.SaveAndPublishWithStatus(content);

        }
    }
}