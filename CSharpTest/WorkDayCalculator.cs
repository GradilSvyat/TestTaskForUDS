using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount < 1)                   // check input value dayCount
                throw new ArgumentException("No working days"); 
            DateTime result = startDate.AddDays(dayCount-1);
            if (weekEnds != null)
            {
                List<DateTime> allWeekEnds = new List<DateTime>();
                foreach (var item in weekEnds)      // creating a list of all holidays
                {
                    allWeekEnds.Add(item.StartDate);
                    while (item.StartDate < item.EndDate)
                    {
                        item.StartDate = item.StartDate.AddDays(1);
                        allWeekEnds.Add(item.StartDate);
                    }
                }
                foreach (var day in allWeekEnds)         // changing the end date by the number of days off
                {
                    if (day >= startDate && day <= result)
                        result = result.AddDays(1);
                }
            }
            return result;
        }
    }
}
