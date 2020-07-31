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
                throw new Exception("No working days"); 
            DateTime result = startDate;
            List<DateTime> allWeekEnds = new List<DateTime>();
            DateTime _weekEnd;
            if (weekEnds != null)
            {
                foreach (var item in weekEnds)
                {
                    _weekEnd = item.StartDate;
                    allWeekEnds.Add(_weekEnd);
                    while (_weekEnd < item.EndDate)
                    {
                        _weekEnd.AddDays(1);
                        allWeekEnds.Add(_weekEnd);
                    }
                }
            }
            while (allWeekEnds.Contains(result))
            {
                result.AddDays(1);
            }
            int i = 1;
            while (i<dayCount)
            {
                if(allWeekEnds.Contains(result))
                {
                    result.AddDays(1);
                    continue;
                }
                else
                {
                    result.AddDays(1);
                    i++;
                }
            }
            return result;
        }
    }
}
