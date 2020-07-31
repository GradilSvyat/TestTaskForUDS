using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestStartDateEqualWeekEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 1;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 21), new DateTime(2017, 4, 22))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 23)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"No working days")]
        public void TestDurationIs0()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 0;

            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2014, 12, 4), new DateTime(2014, 12, 5))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);
        }
    }
}
