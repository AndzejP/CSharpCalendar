using System;
using System.Collections;

namespace Calendar
{

    public class Events : IEnumerable
    {
        private string[] _events;

        public Events(string[] myArray)
        {
            _events = new string[myArray.Length];
            for (int i = 0; i < myArray.Length; i++)
            {
                _events[i] = myArray[i];
            }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        public EventsEnum GetEnumerator()
        {
            return new EventsEnum(_events);
        }
    }

    public class EventsEnum : IEnumerator
    {
        public string[] _events;
        int position = -1;

        public EventsEnum(string[] list)
        {
            _events = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _events.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return _events[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
