using BAU.Data;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BAU.Models.Enumerables;
using System.Collections.Generic;

namespace BAU.LogicTests
{
    [TestClass]
    public class CalendarTests
    {
        [TestMethod()]
        public void getFirstFreeDateTest()
        {
            DateTime expectedValue = DateTime.MinValue;
            DateTime actValue = DateTime.MinValue;
            BAU.Logic.Calendar contextCalendar = new BAU.Logic.Calendar();

            //Initialize test value
            ConnectionTools.initializeDatabaseTest(1);

            //Check if not dates get now date
            expectedValue = DateTime.Now;
            actValue = contextCalendar.getFirstFreeDate();
            Assert.AreEqual(expectedValue.Date, actValue.Date);

            //Check with 1 date get last date
            contextCalendar.InsertRandomEngineer();
            expectedValue = DateTime.Now;
            actValue = contextCalendar.getFirstFreeDate();
            Assert.AreEqual(expectedValue.Date, actValue.Date);

            //Check if last date 2 shifts get next date
            ConnectionTools.initializeDatabaseTest(1);
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            expectedValue = DateTime.Now.AddDays(1);
            actValue = contextCalendar.getFirstFreeDate();
            Assert.AreEqual(expectedValue.Date, actValue.Date);
        }

        [TestMethod()]
        public void getFreeShiftDayTest()
        {
            ShiftsTypes expectedValue;
            ShiftsTypes actValue;
            BAU.Logic.Calendar contextCalendar = new BAU.Logic.Calendar();

            //Initialize test value
            ConnectionTools.initializeDatabaseTest(1);


            //Check if not dates get Morning
            expectedValue = ShiftsTypes.Morning;
            actValue = contextCalendar.getFreeShiftDay(DateTime.Now);
            Assert.AreEqual(expectedValue, actValue);

            //Check if one date, get afternoo
            contextCalendar.InsertRandomEngineer();
            expectedValue = ShiftsTypes.Afternoon;
            actValue = contextCalendar.getFreeShiftDay(DateTime.Now);
            Assert.AreEqual(expectedValue, actValue);
        }

        [TestMethod()]
        public void getUsedByDayTest()
        {
            int expectedValue = 0;
            int actValue = 0;
            BAU.Logic.Calendar contextCalendar = new BAU.Logic.Calendar();

            //Initialize test value
            ConnectionTools.initializeDatabaseTest(1);


            //Check if get correct engineers
            expectedValue = 1;
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Engineer> list1 = contextCalendar.getUsedByDay(DateTime.Now);
            foreach (Models.Engineer ele in list1)
                actValue += 1;
            Assert.AreEqual(expectedValue, actValue);

            expectedValue = 2;
            actValue = 0;
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Engineer> list2 = contextCalendar.getUsedByDay(DateTime.Now);
            foreach (Models.Engineer ele in list2)
                actValue += 1;
            Assert.AreEqual(expectedValue, actValue);
        }

        [TestMethod()]
        public void getBetweenDatesTest()
        {
            int expectedValue = 0;
            int actValue = 0;
            BAU.Logic.Calendar contextCalendar = new BAU.Logic.Calendar();

            //Check if get correct engineers
            ConnectionTools.initializeDatabaseTest(1);
            expectedValue = 1;
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Engineer> list1 = contextCalendar.getBetweenDates(DateTime.Now, DateTime.Now);
            foreach (Models.Engineer ele in list1)
                actValue += 1;
            Assert.AreEqual(expectedValue, actValue);

            ConnectionTools.initializeDatabaseTest(2);
            expectedValue = 2;
            actValue = 0;
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Engineer> list2 = contextCalendar.getBetweenDates(DateTime.Now, DateTime.Now);
            foreach (Models.Engineer ele in list2)
                actValue += 1;
            Assert.AreEqual(expectedValue, actValue);

            ConnectionTools.initializeDatabaseTest(5);
            expectedValue = 4;
            actValue = 0;
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            contextCalendar.InsertRandomEngineer();
            IEnumerable<Models.Engineer> list3 = contextCalendar.getBetweenDates(DateTime.Now, DateTime.Now.AddDays(1));
            foreach (Models.Engineer ele in list3)
                actValue += 1;
            Assert.AreEqual(expectedValue, actValue);
        }
    }
}
