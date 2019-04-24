namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsComment")]
    public partial class NewsComment
    {
        public int ID { get; set; }

        public int NewsID { get; set; }

        public string AccountID { get; set; }

        public string Content { get; set; }

        public DateTime? TimeCreated { get; } = DateTime.Now;

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual News News { get; set; }
    }
}
