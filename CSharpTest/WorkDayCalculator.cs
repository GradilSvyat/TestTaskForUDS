using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount < 1)
                throw new ArgumentException("No working days"); 
            DateTime result = startDate.AddDays(dayCount-1);
            List<DateTime> allWeekEnds = new List<DateTime>();
            if (weekEnds != null)
            {
                foreach (var item in weekEnds)
                {
                    allWeekEnds.Add(item.StartDate);
                    while (item.StartDate < item.EndDate)
                    {
                        item.StartDate = item.StartDate.AddDays(1);
                        allWeekEnds.Add(item.StartDate);
                    }
                }
            }
            foreach(var day in allWeekEnds)
            {
                if (day >= startDate && day <= result)
                    result = result.AddDays(1);
            }
            return result;
        }
    }
}
