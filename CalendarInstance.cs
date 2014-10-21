using System;
using System.Collections.Generic;

namespace Calendar
{
    class CalendarInstance
    {
        List<Event> _myEventList = new List<Event>();
        string owner = System.IO.File.ReadAllText(@"C:\Users\Starseal\Documents\GitHub\CSharpCalendar\owner.txt");
        

        public void Authorize()
        {

            Console.WriteLine("Identify yourself");
            while (Console.ReadLine() != owner)
            {
                Console.WriteLine("You're not the owner, infidel!!!");
            }

        }

        public void AddEvent()
        {
            Console.WriteLine("Input date (DD-MM-YYYY)");
            Date temp = new Date(Console.ReadLine());
            while (temp.Valid == false)
            {
                Console.WriteLine("Date is invalid");
                Console.WriteLine("Input date (DD-MM-YYYY)");
                temp = new Date(Console.ReadLine());
            }

            Console.WriteLine("Input event information");
            Event temp2 = new Event(temp, Console.ReadLine());
            _myEventList.Add(temp2);

            Console.WriteLine(temp);
            Console.WriteLine(temp2.Description);
        }
            
    }
}
