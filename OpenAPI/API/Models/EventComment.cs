namespace API.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventComment")]
    public partial class EventComment
    {
        public int ID { get; set; }

        public int? EventID { get; set; }

        public string AccountID { get; set; }

        public string Content { get; set; }

        public bool? Status { get; set; }

        public DateTime? TimeCreated { get; } = DateTime.Now;

        public virtual Account Account { get; set; }

        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
