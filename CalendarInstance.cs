using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("You're not the owner\nThe calendar could contain private information");

            }

        }

        public void AddEvent()
        {
            Console.WriteLine("Input date (Day-Month-Year)");
            Date temp = new Date(Console.ReadLine());
            while (temp.Valid == false)
            {
                Console.WriteLine("Date is invalid");
                Console.WriteLine("Input date (Day-Month-Year)");
                temp = new Date(Console.ReadLine());
            }

            Console.WriteLine("Input event information");
            Event temp2 = new Event(temp, Console.ReadLine());
            _myEventList.Add(temp2);
        }

        public void SortEvents()
        {
            _myEventList.Sort();
            Console.WriteLine("List sorted");
        }

        public void ListEvents()
        {
            if (_myEventList.Capacity == 0)
                Console.WriteLine("List is empty");
            else
            foreach (Event temp in _myEventList)
            {
                Console.WriteLine(temp.date+"\n"+temp.Description);
            }
        }

        public void SearchByDate()
        {
            Console.WriteLine("Input date in (Day-Month-Year)");
            Date tempDate = new Date(Console.ReadLine());
            while (tempDate.Valid == false)
            {
                Console.WriteLine("Date is invalid");
                Console.WriteLine("Input date (Day-Month-Year)");
                tempDate = new Date(Console.ReadLine());
            }
            Console.WriteLine("your input"+tempDate);

            var queryResult =
                from temp in _myEventList
                    where (tempDate.Equals(temp.date)) 
                    select temp.Description;
            foreach (string s in queryResult)
            {
                Console.WriteLine(s);
            }

        }
            
    }
}
