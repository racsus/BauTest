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
        public List<Models.Engineer> getAll()
        {
            BAU.Data.Engineers context = new BAU.Data.Engineers();
            return context.getAll();
        }

            /// <summary>
            /// Get engineers paginated
            /// </summary>
            /// <param name="pageNumber"></param>
            /// <returns></returns>
        public Models.EngineerWithPaging getPaginated(int pageNumber)
        {
            BAU.Data.Engineers context = new BAU.Data.Engineers();
            return context.getPaginated(pageNumber);
        }

        /// <summary>
        /// Insert a engineer in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Models.Engineer model)
        {
            BAU.Data.Engineers context = new BAU.Data.Engineers();
            return context.Insert(model);
        }

        /// <summary>
        /// Delete a engineer in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(Models.Engineer model)
        {
            BAU.Data.Engineers context = new BAU.Data.Engineers();
            return context.Insert(model);
        }

        /// <summary>
        /// Delete all records (Only for testing)
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            BAU.Data.Engineers context = new BAU.Data.Engineers();
            return context.DeleteAll();
        }

        /// <summary>
        /// Get a random engineer that accomplish stablished rules
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Models.Engineer getRandomEngineer(DateTime date)
        {
            Models.Engineer res = null;
            BAU.Data.Engineers contextEngineers = new BAU.Data.Engineers();
            BAU.Data.Calendar contextCalendar = new BAU.Data.Calendar();
            Calendar cal = new Calendar();

            //We get all engineers.
            List<Models.Engineer> listAll = getAll();

            //We get all engineers that we have to remove becouse of the rules.
            List<Models.Engineer> listUsedByDay = contextCalendar.getUsedByDay(date); //Rule 1 "An engineer can do at most one half day shift in a day."
            List<Models.Engineer> listUsedByDayBefore = contextCalendar.getUsedByDay(date.AddDays(-1)); //Rule 2 "An engineer cannot have half day shifts on consecutive days."
            List<Models.Engineer> listUsedCompleteDayTwoWeeksBefore = cal.getUsedCompleteDayTwoWeeksBefore(date); //Rule 3 "Each engineer should have completed one whole day of support in any 2 week period."

            //We remove rule 1
            if ((listAll.Count > 1) && (listUsedByDay.Count > 0))
            {
                foreach (Models.Engineer ele in listUsedByDay)
                {
                    if (listAll.Contains(ele))
                        listAll.Remove(listAll.Single(x => x.Id == ele.Id));
                }
            }

            //We remove rule 2
            if ((listAll.Count > 3) && (listUsedByDayBefore.Count > 0) )
            {
                foreach (Models.Engineer ele in listUsedByDayBefore)
                {
                    if (listAll.Contains(ele))
                        listAll.Remove(listAll.Single(x => x.Id == ele.Id));
                }
            }

            //We remove rule 3
            if ( (listUsedCompleteDayTwoWeeksBefore.Count > 0) && (listUsedCompleteDayTwoWeeksBefore != listAll) )
            {
                foreach (Models.Engineer ele in listUsedCompleteDayTwoWeeksBefore)
                {
                    if (listAll.Contains(ele))
                        listAll.Remove(listAll.Single(x => x.Id == ele.Id));
                }
            }

            //Get random
            if (listAll.Count > 0)
            {
                Random rnd = new Random();
                int num = rnd.Next(listAll.Count);
                res = listAll[num];
            }

            return res;
        }

    }
}
