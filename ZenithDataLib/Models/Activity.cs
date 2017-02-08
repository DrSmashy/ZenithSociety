using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZenithDataLib.Models {
    public class Activity {
        [Key]
        public int ActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
