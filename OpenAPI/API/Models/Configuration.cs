namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Configuaration")]
    public partial class Configuration
    {
        public int ID { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public bool? status { get; set; }
    }
}
