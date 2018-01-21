using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Logic
{
    public class Calendar
    {
        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getList()
        {
            BAU.Data.Calendar obj = new BAU.Data.Calendar();
            return obj.getList();
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getListPaginated(Models.Pagination page)
        {
            BAU.Data.Calendar obj = new BAU.Data.Calendar();
            return obj.getListPaginated(page);
        }
    }
}
