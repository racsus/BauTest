using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data
{
    public class Engineers
    {
        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getList()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Engineer.ToList();
            }
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="page">Pagination data (page number, order, etc.)</param>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getListPaginated(Models.Pagination page)
        {
            IEnumerable<Models.Engineer> res = null;
            using (var context = new ApplicationDbContext())
            {
                res = context.Engineer.OrderBy(u => u.Name)
                    .Skip(page.pageNumber)
                    .Take(page.pageSize)
                    .ToList();
            }
            return res;
        }

        public Models.EngineerWithPaging getPaginated(int pageNumber)
        {
            Models.EngineerWithPaging res = null;
            int totalPage, totalRecord, pageSize;
            pageSize = 5;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                totalRecord = context.Engineer.Count();
                totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
                var record = (from a in context.Engineer
                              orderby a.Name
                              select a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                res = new Models.EngineerWithPaging
                {
                    Engineers = record,
                    TotalPage = totalPage
                };
            }
            return res;
        }

        public int Insert(Models.Engineer model)
        {
            int res = 0;
            using (var context = new ApplicationDbContext())
            {
                context.Engineer.Add(model);
                res = context.SaveChanges();
            }
            return res;
        }

        public int Delete(Models.Engineer model)
        {
            int res = 0;
            using (var context = new ApplicationDbContext())
            {
                context.Engineer.Remove(model);
                res = context.SaveChanges();
            }
            return res;
        }
    }
}
