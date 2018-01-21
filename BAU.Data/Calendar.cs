using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data
{
    public class Calendar
    {
        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getList()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Calendar.ToList();
            }
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="page">Pagination data (page number, order, etc.)</param>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getListPaginated(Models.Pagination page)
        {
            IEnumerable<Models.Calendar> res = null;
            using (var context = new ApplicationDbContext())
            {
                res = context.Calendar.OrderBy(u => u.Id)
                    .Skip(page.pageNumber)
                    .Take(page.pageSize)
                    .ToList();
            }
            return res;
        }

        public int Insert(Models.Calendar model)
        {
            int res = 0;
            using (var context = new ApplicationDbContext())
            {
                context.Calendar.Add(model);
                res = context.SaveChanges();
            }
            return res;
        }

        public int Delete(Models.Calendar model)
        {
            int res = 0;
            using (var context = new ApplicationDbContext())
            {
                context.Calendar.Remove(model);
                res = context.SaveChanges();
            }
            return res;
        }
    }
}
