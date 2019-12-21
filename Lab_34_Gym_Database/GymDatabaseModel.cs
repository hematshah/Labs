namespace Lab_34_Gym_Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GymDatabaseModel : DbContext
    {
        public GymDatabaseModel()
            : base("name=GymDatabasesModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .Property(e => e.CategoryName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Exercises)
            //    .WithRequired(e => e.Category)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Exercis>()
            //    .Property(e => e.ExerciseName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .Property(e => e.UserName)
            //    .IsUnicode(false);
        }
    }
}
