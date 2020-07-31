using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount < 1)
                throw new ArgumentException("No working days"); 
            DateTime result = startDate;
            List<DateTime> allWeekEnds = new List<DateTime>();
            if (weekEnds != null)
            {
                DateTime oneDayOff;
                foreach (var item in weekEnds)
                {
                    oneDayOff = item.StartDate;
                    allWeekEnds.Add(oneDayOff);
                    while (oneDayOff < item.EndDate)
                    {
                        oneDayOff = oneDayOff.AddDays(1);
                        allWeekEnds.Add(oneDayOff);
                    }
                }
            }
            while (allWeekEnds.Contains(result))
            {
                result = result.AddDays(1);
            }
            for (int i = 1; i <dayCount;)
            {
                if(allWeekEnds.Contains(result))
                {
                    result = result.AddDays(1);
                    continue;
                }
                else
                {
                    result = result.AddDays(1);
                    i++;
                }
            }
            return result;
        }
    }
}
