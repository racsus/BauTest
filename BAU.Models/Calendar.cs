using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sorry! The date is required! Come on! Wake up! :)")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Sorry! The engineer's Id is required! What are you thinking about? :)")]
        public int IdEngineer { get; set; }
        [Required(ErrorMessage = "Sorry! The shift is required! Good try! :)")]
        public int Shift { get; set; }
    }
}
