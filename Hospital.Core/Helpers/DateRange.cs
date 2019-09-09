using System;

namespace Hospital.Core.Helpers
{
    public class DateRange
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public DateRange(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
        }

        public DateTime GetStart()
        {
            return _start;
        }

        public DateTime GetEnd()
        {
            return _end;
        }
    }
}
