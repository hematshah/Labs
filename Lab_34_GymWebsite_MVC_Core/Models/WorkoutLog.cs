using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_34_GymWebsite_MVC_Core
{
    public class WorkoutLog
    {
        public int WorkoutLogId { get; set; }

        public DateTime? DateTime { get; set; }

        public int ExerciseId { get; set; }
    }
}
