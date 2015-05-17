using System;
using System.Collections.Generic;

namespace TD.CTS.WebUI.Models
{
    public class ScheduleCalend

    {
        public List<ScheduleCalendDate> dateList = new List<ScheduleCalendDate>();

        public DateTime MonthYearDate { get; private set; }

        public DateTime MinColDate { get; private set; }

        public DateTime MaxColDate { get; private set; }

        public ScheduleCalend(int? year, int? month)
        {


            //DateTime defaultDate;
            if (year.HasValue && month.HasValue)
            {
                MonthYearDate = new DateTime(year.Value, month.Value, 1);

            }
            else
            {
                MonthYearDate = DateTime.Today;
            }



            //var datestart=defaultDate.
            var firstDayOfMonth = new DateTime(MonthYearDate.Year, MonthYearDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            int delta = 0 - GetDayOfWeek(firstDayOfMonth);
            DateTime mondayBeforeFirstDayOfMonth = firstDayOfMonth.AddDays(delta);

            DateTime mondayAfterLastDayOfMonth = lastDayOfMonth.AddDays(6 - GetDayOfWeek(lastDayOfMonth));
            MinColDate = mondayBeforeFirstDayOfMonth;
            MaxColDate = mondayAfterLastDayOfMonth;

            FillCallend(MinColDate, MaxColDate);

        }

        private int GetDayOfWeek(DateTime date)
        {
            return (int) (date.DayOfWeek + 6)%7;
        }

        //Заполняем даты для календаря
        public ScheduleCalend(DateTime from, DateTime to)
        {
            //Дату начала как первый понедельник
            int delta = DayOfWeek.Monday - from.DayOfWeek;
            DateTime mondayBeforeFirstDayOfMonth = from.AddDays(delta);
            FillCallend(mondayBeforeFirstDayOfMonth, to);

        }


        private void FillCallend(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
            {
                dateList.Add(
                    new ScheduleCalendDate
                    {
                        CalendDate = day,
                        LastDayInWeek = GetDayOfWeek(day) == 6
                    }
                    );
            }
        }

    }

    //Класс даты календаря для расширения возмозностей
    public class ScheduleCalendDate
    {
        public DateTime CalendDate { get; set; }
        public bool LastDayInWeek { get; set; }
    }
}