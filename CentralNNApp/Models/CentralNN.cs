namespace CentralNNApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CentralNN : DbContext
    {
        public CentralNN()
            : base("name=CentralNN")
        {
        }

        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<Mother> Mothers { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intervention>()
                .Property(e => e.Notes_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Mother>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Mother>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Mother>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Mother>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Mother>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Mother>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Survey>()
                .Property(e => e.OBGYN)
                .IsUnicode(false);

            modelBuilder.Entity<Survey>()
                .Property(e => e.Age)
                .IsUnicode(false);
        }
    }
}
