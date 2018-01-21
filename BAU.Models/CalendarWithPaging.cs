using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    public class CalendarWithPaging
    {
        public List<Calendar> Calendars { get; set; }
        public int TotalPage { get; set; }
    }
}
