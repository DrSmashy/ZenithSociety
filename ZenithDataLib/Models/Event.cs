using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models {
    public class Event {
        [Key]
        public int EventId { get; set; }
        public DateTime EventFromDate { get; set; }
        public DateTime EventToDate { get; set; }
        public string EnteredByUsername { get; set; }
        public int Activity { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
