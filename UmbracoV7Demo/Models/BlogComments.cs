﻿namespace UmbracoV7Demo.Models
{
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;

    [TableName("BlogCommments")]
    [PrimaryKey("BlogCommentId", autoIncrement = true)]
    [ExplicitColumns]
    public class BlogComments
    {
        [Column("id")]
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
    }
}