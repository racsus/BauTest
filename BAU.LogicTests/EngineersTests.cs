using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAU.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BAU.LogicTests;

namespace BAU.Logic.Tests
{
    [TestClass()]
    public class EngineersTests
    {
        [TestMethod()]
        public void getRandomEngineerTest()
        {
            string expectedValue = String.Empty;
            Models.Engineer actValue = null;

            //Change database to test
            ConnectionTools.initializeDatabaseTest(1);

            BAU.Logic.Engineers contextEngineers = new BAU.Logic.Engineers();
            BAU.Logic.Calendar contextCalendar = new BAU.Logic.Calendar();

            //If we have only one engineer we get the same ever (independent rule 1)
            contextCalendar.InsertRandomEngineer();
            expectedValue = "Engineer 1";
            actValue = contextEngineers.getRandomEngineer(DateTime.Now);
            Assert.AreEqual(expectedValue, actValue.Name);

            //If we have two engineer or more we can not repeat same engineer in same day
            ConnectionTools.initializeDatabaseTest(2);
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Calendar> currentCalendar1 = contextCalendar.getAll();
            var query1 = from cal in currentCalendar1
                        group cal.EngineerAssigned.Id by cal.EngineerAssigned.Id into EngineerGroup
                        select EngineerGroup.Key;
            if (query1.ToList().Count < 2)
                Assert.Fail();

            //If we have more than 3 engineers, we can not repeat engineers in consecutive days
            ConnectionTools.initializeDatabaseTest(4);
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Calendar> currentCalendar2 = contextCalendar.getAll();
            var query2 = from cal in currentCalendar2
                        group cal.EngineerAssigned.Id by cal.EngineerAssigned.Id into EngineerGroup
                        select EngineerGroup.Key;
            if (query2.ToList().Count < 4)
                Assert.Fail();
        }
    }
}