using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.LogicTests
{
    class ConnectionTools
    {
        public static void initializeDatabaseTest(int pNumEngineers = 10)
        {
             //Delete all engineers
            BAU.Logic.Engineers contextEngineers = new BAU.Logic.Engineers();
            contextEngineers.DeleteAll();

            //Create engineers
            for (int i = 1; i <= pNumEngineers; i++)
            {
                Models.Engineer ele = new Models.Engineer { Id = i, Name = "Engineer " + Convert.ToString(i) };
                contextEngineers.Insert(ele);
            }
        }
    }
}
