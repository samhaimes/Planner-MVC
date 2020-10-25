using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PlannerMVC.Models
{
    public class Link
    {
        [Key, Required]
        public int LinkId { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }

        [ForeignKey("Day")]
        public int DayId { get; set; }

        [IgnoreDataMember]
        public virtual Day Day { get; set; }
        [IgnoreDataMember]
        public virtual Activity Activity { get; set; }
    }
}