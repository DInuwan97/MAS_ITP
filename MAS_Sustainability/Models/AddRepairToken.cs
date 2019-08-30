namespace MAS_Sustainability.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddRepairToken")]
    public partial class AddRepairToken
    {
        [Key]
        [StringLength(50)]
        public string RepairId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RecievedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Deadline { get; set; }
    }
}
