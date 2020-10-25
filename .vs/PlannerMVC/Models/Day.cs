using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerMVC.Models
{
    public class Day
    {
        [Key, Required]
        public int DayId { get; set; }

        [StringLength(maximumLength: 10)]
        public string Days { get; set; }

    }
}
