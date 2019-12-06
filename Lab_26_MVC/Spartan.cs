namespace Lab_26_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spartan
    {
        [Key]
        public int SpartansID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UniversityAttended { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseTaken { get; set; }

        [Required]
        [StringLength(50)]
        public string GradeAchieved { get; set; }

        [Column(TypeName = "date")]
        public DateTime GraduationDate { get; set; }
    }
}
