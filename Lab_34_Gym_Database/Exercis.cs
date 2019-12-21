namespace Lab_34_Gym_Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercises")]
    public partial class Exercis
    {
        [Key]
        public int ExerciseId { get; set; }

        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
