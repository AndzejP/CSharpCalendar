using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Event> myEventList = new List<Event>();
            string owner = System.IO.File.ReadAllText(@"C:\Users\Starseal\Documents\GitHub\CSharpCalendar\owner.txt");
            //while();

            Console.WriteLine("Input date (DD-MM-YYYY)");
            Date temp = new Date(Console.ReadLine());
            while (temp.valid == false)
            {
                Console.WriteLine("Date is invalid");
                Console.WriteLine("Input date (DD-MM-YYYY)");
                temp = new Date(Console.ReadLine());
            }

        Console.WriteLine("Input event information");
        Event temp2 = new Event(temp, Console.ReadLine());
        myEventList.Add(temp2);
                
        Console.WriteLine(temp);
        Console.WriteLine(temp2.description);
        }
            



    }
}
