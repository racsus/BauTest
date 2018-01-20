using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    public class Pagination
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public String orderBy { get; set; }
        public String direction { get; set; }
        public String whereClause { get; set; }
    }
}
