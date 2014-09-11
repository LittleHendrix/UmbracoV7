namespace UmbracoV7Demo.DAL.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;

    [TableName("BlogComments")]
    [PrimaryKey("BlogCommentId", autoIncrement = true)]
    [ExplicitColumns]
    public class BlogComment
    {
        [Column("BlogCommentId")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int BlogCommentId { get; set; }

        [Column("BlogPostUmbracoId")]
        public int BlogPostUmbracoId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Message")]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Message { get; set; }

        [Column("DatePosted")]
        [DataType(DataType.DateTime)]
        public DateTime DatePosted { get; set; }
    }
}