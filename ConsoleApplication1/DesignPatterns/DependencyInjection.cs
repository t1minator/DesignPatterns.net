using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonUnitTestProject
{
    public class Diary
    {
        private readonly LocalDatePattern outputPattern = LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd");
        private readonly IClock clock;
        private readonly CalendarSystem calendar;
        private readonly DateTimeZone timeZone;

        public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone)
        {
            this.calendar = calendar;
            this.clock = clock;
            this.timeZone = timeZone;
        }

        public string FormatToday()
        {
            LocalDate date = this.clock.GetCurrentInstant().InZone(timeZone, calendar).LocalDateTime.Date;
            Console.WriteLine(outputPattern.Format(date));
            return outputPattern.Format(date);
        }
    }
}
