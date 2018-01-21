using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Logic
{
    public class Engineers
    {
        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getList()
        {
            BAU.Data.Engineers obj = new BAU.Data.Engineers();
            return obj.getList();
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getListPaginated(Models.Pagination page)
        {
            BAU.Data.Engineers obj = new BAU.Data.Engineers();
            return obj.getListPaginated(page);
        }

        public Models.EngineerWithPaging getPaginated(int pageNumber)
        {
            BAU.Data.Engineers obj = new BAU.Data.Engineers();
            return obj.getPaginated(pageNumber);
        }

    }
}
