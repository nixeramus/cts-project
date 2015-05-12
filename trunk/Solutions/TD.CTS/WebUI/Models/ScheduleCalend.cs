using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TD.CTS.WebUI.Models
{
    public class ScheduleCalend
    {
        public List<ScheduleCalendDate> dateList=new List<ScheduleCalendDate>();
        //Заполняем даты для календаря
        public ScheduleCalend(DateTime from, DateTime end)
        {
            for (var day = from.Date; day.Date <= end.Date; day = day.AddDays(1))
            {
                dateList.Add(new ScheduleCalendDate(){CalendDate = day});
            }
        }
       
    }
    //Класс даты календаря для расширения возмозностей
    public class ScheduleCalendDate
    {
        public DateTime CalendDate { get; set; }
    }
}