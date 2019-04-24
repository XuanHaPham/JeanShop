namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            NewsComments = new HashSet<NewsComment>();
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageURL { get; set; }

        public int? OrganizationMemberID { get; set; }

        public bool? Public { get; set; }

        public DateTime? TimeCreated { get; } = DateTime.Now;

        public bool? Status { get; set; }

        public virtual OrganizationMember OrganizationMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}
