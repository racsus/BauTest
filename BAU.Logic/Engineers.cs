using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Logic
{
    public class Engineers
    {
        public IEnumerable<Models.Engineer> getList()
        {
            BAU.Data.Engineers obj = new BAU.Data.Engineers();
            return obj.getList();
        }

    }
}
