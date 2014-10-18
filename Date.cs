using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    struct Date
    {
        int day, month, year;
        public bool valid{ get; private set; }


        public Date(string input) : this()
        {
            string[] temp = input.Split('-');
            
            try
            {
                day = Convert.ToInt32(temp[0]);
                month = Convert.ToInt32(temp[1]);
                year = Convert.ToInt32(temp[2]);
            }
            catch (Exception e)
            {
                day = 0;
                month = 0;
                year = 0;
            }
            validate();
            

        }

        private void validate()
        {

            if (day > 31 || day < 1 || month < 1 || month > 12)
                valid = false;
            else if (day > 28 && month == 2 && year % 4 != 0)
                valid = false;

            else if (day == 31)
            {
                switch (month)
                {
                    case 2:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        valid = false;
                        break;
                    default:
                        valid = true;
                        break;
                }
            }
            else
                valid = true;
       }

        public override string ToString()
        {
            return day.ToString() + "-" + month.ToString() + "-" + year.ToString();
        }
    }
}
