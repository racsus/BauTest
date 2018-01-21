using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    public class EngineerWithPaging
    {
            public List<Engineer> Engineers { get; set; }
            public int TotalPage { get; set; }
    }
}
