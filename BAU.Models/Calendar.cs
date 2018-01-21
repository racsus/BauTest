using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    /// <summary>
    /// Class for calendar manager.
    /// </summary>
    public class Calendar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sorry! The date is required! Come on! Wake up! :)")]
        public DateTime Date { get; set; }
        //[Required(ErrorMessage = "Sorry! The engineer's Id is required! What are you thinking about? :)")]
        //public int IdEngineer { get; set; }
        [Required(ErrorMessage = "Sorry! The shift is required! Good try! :)")]
        public int Shift { get; set; }
        [Required(ErrorMessage = "Sorry! The engineer's Id is required! What are you thinking about? :)")]
        public Engineer EngineerAssigned { get; set; }

        public Calendar()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDate">Date</param>
        /// <param name="pEngineerAssinged">Engineer assigned</param>
        /// <param name="pShift">Shift (1 or 2)</param>
        public Calendar(DateTime pDate, Engineer pEngineerAssinged, int pShift)
        {
            Date = pDate;
            EngineerAssigned = pEngineerAssinged;
            Shift = pShift;
        }
    }
}
