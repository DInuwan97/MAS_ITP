namespace MAS_Sustainability.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AddRepairTokenModel : DbContext
    {
        public AddRepairTokenModel()
            : base("name=AddRepairToken")
        {
        }

        public virtual DbSet<AddRepairToken> AddRepairTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddRepairToken>()
                .Property(e => e.RepairId)
                .IsUnicode(false);

            modelBuilder.Entity<AddRepairToken>()
                .Property(e => e.UserId)
                .IsUnicode(false);
        }
    }
}
