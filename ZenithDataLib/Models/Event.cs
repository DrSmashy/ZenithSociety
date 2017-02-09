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
        public int EventId { get; set; }
        public DateTime EventFromDate { get; set; }
        public DateTime EventToDate { get; set; }
        public string EnteredByUsername { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
