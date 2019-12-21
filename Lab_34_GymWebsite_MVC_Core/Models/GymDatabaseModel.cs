
    using System;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.SqlServer;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


namespace Lab_34_GymWebsite_MVC_Core
{
    public partial class GymDatabaseModel : DbContext
    {

        public GymDatabaseModel(DbContextOptions<GymDatabaseModel> options) : base(options)
        {

        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<WorkoutLog> WorkoutLog { get; set;}

        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .Property(e => e.CategoryName)
        //        .IsUnicode(false);


        //    modelBuilder.Entity<Exercis>()
        //        .Property(e => e.ExerciseName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.UserName)
        //        .IsUnicode(false);
        //}
    }
}
