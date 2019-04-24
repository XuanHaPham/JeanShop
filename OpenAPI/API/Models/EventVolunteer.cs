namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventVolunteer")]
    public partial class EventVolunteer
    {
        public int ID { get; set; }

        public string AccountID { get; set; }

        public int? EventID { get; set; }

        public DateTime? TimeCreated { get; } = DateTime.Now;

        public bool? Checked { get; set; }

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual Event Event { get; set; }
    }
}
