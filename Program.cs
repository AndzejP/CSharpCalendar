using System;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            CalendarInstance myCalendarInstance = new CalendarInstance();
            myCalendarInstance.Authorize();
            char key = 'z';
            while ( key != 'q')
            {
                Displayinfo();
                key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case 'a':
                        Console.Clear();
                        myCalendarInstance.AddEvent();
                        break;
                    case 'l':
                        Console.Clear();
                        myCalendarInstance.ListEvents();
                        break;
                    case 's':
                        Console.Clear();
                        myCalendarInstance.SortEvents();
                        break;
                    case 'f':
                        Console.Clear();
                        myCalendarInstance.SearchByDate();
                        break;

                }

            }
        }

        private static void Displayinfo()
        {
            Console.WriteLine("press a to add event");
            Console.WriteLine("press l to list events");
            Console.WriteLine("press s to sort events");
            Console.WriteLine("press f to find events by Date");
            Console.WriteLine("Press q to quit");
        }
    }
}
