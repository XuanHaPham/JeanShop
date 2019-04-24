namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? EventID { get; set; }

        public bool? Status { get; set; }

        public virtual Event Event { get; set; }
    }
}
