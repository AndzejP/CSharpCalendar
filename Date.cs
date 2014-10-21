using System;

namespace Calendar
{
    struct Date : IEquatable<Date>
    {
        int day, month, year;
        public bool Valid{ get; private set; }


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
            Validate();
            

        }

        private void Validate()
        {

            if (day > 31 || day < 1 || month < 1 || month > 12)
                Valid = false;
            else if (day > 28 && month == 2 && year % 4 != 0)
                Valid = false;

            else if (day == 31)
            {
                switch (month)
                {
                    case 2:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        Valid = false;
                        break;
                    default:
                        Valid = true;
                        break;
                }
            }
            else
                Valid = true;
       }

        public bool Equals(Date other)
        {
            if (ToString() == other.ToString())
                return true;
            return false;
        }

        public override string ToString()
        {
            return day + "-" + month + "-" + year;
        }

        public int Representation()
        {
            int temp = day;
            switch (month-1)
            {
                case 0:
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 10:
                case 12:
                    temp += 31;
                    break;
                case 2:
                    if (year%4 == 0)
                        temp += 29;
                    else
                        temp += 28;
                    break;
                default : temp+=30;
                    break;
            }
            temp += Convert.ToInt32(Math.Truncate(year*365.25));
            return temp;
        }
    }
}
