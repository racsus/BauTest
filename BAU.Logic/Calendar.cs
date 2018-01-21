using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAU.Models.Enumerables;

namespace BAU.Logic
{
    public class Calendar
    {
        /// <summary>
        /// Get all engineers. Carefull! Not recommended.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getAll()
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getAll();
        }

        public Models.CalendarWithPaging getPaginated(int pageNumber)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getPaginated(pageNumber);
        }

        /// <summary>
        /// Get engineers used in a specific day
        /// </summary>
        /// <param name="date">Specific date</param>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getUsedByDay(DateTime date)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getUsedByDay(date);
        }

        /// <summary>
        /// Get engineers used in a specific day
        /// </summary>
        /// <param name="date">Specific date</param>
        /// <returns></returns>
        public IEnumerable<Models.Engineer> getBetweenDates(DateTime dateIni, DateTime dateFin)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getBetweenDates(dateIni, dateFin);
        }

        /// <summary>
        /// Get engineers that have complete a complete day(2 shifts) in last 2 weeks before the specificied date
        /// </summary>
        /// <param name="date">Specific date</param>
        /// <returns></returns>
        public List<Models.Engineer> getUsedCompleteDayTwoWeeksBefore(DateTime date)
        {
            BAU.Data.Engineers contextEngineers = new BAU.Data.Engineers();
            List<Models.Engineer> res = new List<Models.Engineer>();

            //Get last monday
            DateTime monday = GetFirstDayOfWeek(date.AddDays(-7));
            var data = getBetweenDates(monday, date);
            foreach (var line in data.GroupBy(info => info.Id)
                        .Select(group => new {
                            Id = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Id))
            {
                //We add only engineers with two shifts done (Complete day)
                if (line.Count > 1)
                {
                    res.Add(contextEngineers.getById(line.Id));
                }
                Console.WriteLine("{0} {1}", line.Id, line.Count);
            }

            return res;
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            DayOfWeek firstDay = DayOfWeek.Monday;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Models.Calendar> getListPaginated(Models.Pagination page)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getListPaginated(page);
        }

        /// <summary>
        /// Get the free shift in the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ShiftsTypes getFreeShiftDay(DateTime date)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.getFreeShiftDay(date);
        }

        /// <summary>
        /// Get the free shift in the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime getFirstFreeDate()
        {
            DateTime res = DateTime.MinValue;
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            res = context.getLastUsedDate();
            if (res == DateTime.MinValue)
                res = DateTime.Now;
            return res;
        }

        /// <summary>
        /// Insert in Database a random engineer in the free shift
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int InsertRandomEngineer()
        {
            Models.Calendar calendar = null;
            DateTime firstFreeDate = getFirstFreeDate();
            int currentShift = (int)getFreeShiftDay(firstFreeDate); //Get free shift in specified date
            if (currentShift > 0)
            {
                Engineers contextEngineers = new Engineers();
                Models.Engineer engineerSelected = contextEngineers.getRandomEngineer(firstFreeDate);
                calendar = new Models.Calendar(firstFreeDate, engineerSelected, currentShift);
            }
            return Insert(calendar);
        }

        public int Insert(Models.Calendar model)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.Insert(model);
        }

        public int Delete(Models.Calendar model)
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.Insert(model);
        }

        /// <summary>
        /// Delete all records (Only for testing)
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            BAU.Data.Calendar context = new BAU.Data.Calendar();
            return context.DeleteAll();
        }
    }
}
