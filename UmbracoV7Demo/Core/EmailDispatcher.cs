// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailDispatcher.cs" company="">
//   
// </copyright>
// <summary>
//   The email dispatcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Core
{
    using System.Configuration;

    using Umbraco.Core;
    using Umbraco.Core.Models;
    using Umbraco.Core.Services;

    using umbraco.NodeFactory;

    using UmbracoV7Demo.ViewModels;

    /// <summary>
    /// The email dispatcher.
    /// </summary>
    public class EmailDispatcher
    {
        #region Public Methods and Operators

        /// <summary>
        /// The send contact email.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public static void SendContactEmail(ContactViewModel model)
        {
            string to = ConfigurationManager.AppSettings["ContactEmailAddress"] ?? "luchen_sv@msn.com";
            var em = new EmailManager();
            em.SendMail(to, "Umbraco V7 Demo Contact", "EmailContact", model);

            SaveContact(model);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The save contact.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        private static void SaveContact(ContactViewModel model)
        {
            const string msgDocTypeAlias = "Message";
            const string namePropperty = "name";
            const string emailPropperty = "email";
            const string subjectPropperty = "subject";
            const string messagePropperty = "message";
            const string datetimePropperty = "submitDate";

            IContentService cs = ApplicationContext.Current.Services.ContentService;

            // Make sure a docType of ContactUs exist
            Node node = Node.GetNodeByXpath("//ContactUs[1]");

            IContent content = cs.CreateContent(model.EmailAddress, node.Id, msgDocTypeAlias);
            content.Name = "from: " + model.EmailAddress;
            if (content.HasProperty(namePropperty))
            {
                content.SetValue(namePropperty, model.Name);
            }

            if (content.HasProperty(emailPropperty))
            {
                content.SetValue(emailPropperty, model.EmailAddress);
            }

            if (content.HasProperty(subjectPropperty))
            {
                content.SetValue(subjectPropperty, model.Subject);
            }

            if (content.HasProperty(messagePropperty))
            {
                content.SetValue(messagePropperty, model.Message);
            }

            if (content.HasProperty(datetimePropperty))
            {
                content.SetValue(datetimePropperty, model.SubmitDate.ToString("f"));
            }

            // cs.SaveAndPublishWithStatus(content);
            cs.Save(content);
        }

        #endregion
    }
}