using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAU.Models.Enumerables;

namespace BAU.Data
{
    public class Calendar
    {

        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Calendar.Include("EngineerAssigned").ToList();
            }
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="pageNumber">Index page</param>
        /// <returns></returns>
        public Models.CalendarWithPaging getPaginated(int pageNumber, int limitPage)
        {
            Models.CalendarWithPaging res = null;
            int totalPage, totalRecord, pageSize;
            pageSize = limitPage;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                totalRecord = context.Calendar.Count();
                totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
                var record = (from a in context.Calendar.Include("EngineerAssigned")
                              orderby a.Date
                              select a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                res = new Models.CalendarWithPaging
                {
                    Calendars = record,
                    TotalPage = totalPage
                };
            }
            return res;
        }

        /// <summary>
        /// Get engineers used in a specific day
        /// </summary>
        /// <param name="date">Specific date</param>
        /// <returns></returns>
        public List<Models.Engineer> getUsedByDay(DateTime date)
        {
            List<Models.Engineer> res = new List<Models.Engineer>();
            using (var context = new ApplicationDbContext())
            {
                var query = from cal in context.Calendar
                            where cal.Date.Year == date.Year && cal.Date.Month == date.Month && cal.Date.Day == date.Day
                            group cal.EngineerAssigned.Id by cal.EngineerAssigned.Id into EngineerGroup
                            orderby EngineerGroup.Key
                            select EngineerGroup.Key;
                foreach (int id in query)
                {
                    Engineers contextEngineers = new Engineers();
                    Models.Engineer element = contextEngineers.getById(id);
                    res.Add(element);
                }

            }
            return res;
        }

        /// <summary>
        /// Get engineers used in a specific range of dates
        /// </summary>
        /// <param name="dateIni">Specific initial date</param>
        /// /// <param name="dateFin">Specific finish date</param>
        /// <returns></returns>
        public List<Models.Engineer> getBetweenDates(DateTime dateIni, DateTime dateFin)
        {
            List<Models.Engineer> res = new List<Models.Engineer>();
            if (dateIni != null)
                dateIni = new DateTime(dateIni.Year, dateIni.Month, dateIni.Day, 0, 0, 0);
            if (dateFin != null)
                dateFin = new DateTime(dateFin.Year, dateFin.Month, dateFin.Day, 23, 59, 59);

            using (var context = new ApplicationDbContext())
            {
                var query = from cal in context.Calendar
                            where cal.Date >= dateIni && cal.Date <= dateFin
                            group cal.EngineerAssigned.Id by cal.EngineerAssigned.Id into EngineerGroup
                            orderby EngineerGroup.Key
                            select EngineerGroup.Key;
                foreach (int id in query)
                {
                    Engineers contextEngineers = new Engineers();
                    Models.Engineer element = contextEngineers.getById(id);
                    res.Add(element);
                }

            }
            return res;
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

        /// <summary>
        /// Get the free shift in the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ShiftsTypes getFreeShiftDay(DateTime date)
        {
            ShiftsTypes res = 0;

            using (var context = new ApplicationDbContext())
            {
                List<Models.Calendar> query = (from cal in context.Calendar
                                               where cal.Date.Year == date.Year && cal.Date.Month == date.Month && cal.Date.Day == date.Day
                                               select cal).ToList<Models.Calendar>();
                if (query.Count == 0)
                {
                    res = ShiftsTypes.Morning;
                } else if (query.Count == 1)
                {
                    res = ShiftsTypes.Afternoon;
                }

            }
            return res;
        }

        /// <summary>
        /// Get the last date used in calendar
        /// </summary>
        /// <returns></returns>
        public DateTime getLastUsedDate()
        {
            DateTime res = DateTime.MinValue;

            using (var context = new ApplicationDbContext())
            {
                Models.Calendar query = (from cal in context.Calendar
                                         orderby cal.Date descending, cal.Shift descending
                                         select cal).FirstOrDefault();
                if ((query != null) && (query.Shift == (int)ShiftsTypes.Morning))
                {
                    res = query.Date;
                }
                else if ((query != null) && (query.Shift == (int)ShiftsTypes.Afternoon))
                {
                    res = query.Date.AddDays(1);
                }
                return res;
            }
        }

            /// <summary>
            /// Insert record in database context
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            public int Insert(Models.Calendar model)
            {
                int res = 0;
                using (var context = new ApplicationDbContext())
                {
                    context.Calendar.Add(model);
                    context.Engineer.Attach(model.EngineerAssigned);
                    context.SaveChanges();
                    res = model.Id;
                }
                return res;
            }

            /// <summary>
            /// Delete record in database context
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
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

        /// <summary>
        /// Delete all records (Only for testing)
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            int res = 0;
            using (var context = new ApplicationDbContext())
            {
                foreach(Models.Calendar cal in getAll())
                {
                    context.Calendar.Attach(cal);
                    context.Calendar.Remove(cal);
                    res = context.SaveChanges();
                }                                
            }
            return res;
        }
    }
    }
