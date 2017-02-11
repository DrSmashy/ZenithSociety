using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenithDataLib.Models {
    public class Event {
        [Key]
        [Display(Name = "Event")]
        public int EventId { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime EventFromDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public DateTime EventToDate { get; set; }

        [Display(Name = "Created By")]
        public string EnteredByUsername { get; set; }

        [Display(Name = "ActivityId")]
        [Required]
        public int ActivityId { get; set; }


        [Display(Name = "Activity")]
        public virtual Activity Activity { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
