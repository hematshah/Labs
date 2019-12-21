namespace  Lab_34_GymWebsite_MVC_Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public bool? InductionCompleted { get; set; }
        // bool      True,  false,
        // bool?     True,  false, null

        public DateTime? DateJoined { get; set; }
    }
}
