using System;
using System.Collections.Generic;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            CalendarInstance myCalendarInstance = new CalendarInstance();
            myCalendarInstance.Authorize();
            myCalendarInstance.AddEvent();
        }
    }
}
