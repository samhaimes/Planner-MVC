using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerMVC.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string ActivityName { get; set; }

        [StringLength(30)]
        public string ActivityDetails { get; set; }
    }
}
