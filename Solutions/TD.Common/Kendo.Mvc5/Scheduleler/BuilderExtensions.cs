using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;

namespace TD.Common.Kendo.Mvc5.Scheduler
{
    public static class BuilderExtensions
    {
        public static SchedulerBuilder<T> Month<T>(this SchedulerBuilder<T> builder, string name) 
            where T : class, ISchedulerEvent
        {
            return builder
                .Name(name)
                .Views(views =>
                {
                    views.MonthView(m => m.Title("Месяц")
                        .DayTemplate("<span>#=kendo.toString(date, \"dd\")#</span>"));                        
                })
                .Messages(messages =>
                {
                    messages.Today("Сегодня");
                })
                .Editable(false)
                .Selectable(false);
        }
    }
}
