
using System.Reflection.Metadata.Ecma335;

namespace PooWork.Core
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }


        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour, int minute)

        {
            Hour = hour;
            Minute = minute;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour, int minute, int second)

        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = 0;
        }


        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

        }

        public int Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                _hour = ValidHour(value);
            }
        }

        public int Millisecond
        {
            get
            {
                return _millisecond;
            }
            set
            {
                _millisecond = ValidMillisecond(value);
            }
        }

        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = ValidMinute(value);
            }
        }

        public int Second
        {
            get
            {
                return _second;
            }
            set
            {
                _second = ValidSecond(value);
            }
        }

        public override string ToString()
        {
            DateTime dateTime = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
            return dateTime.ToString("hh:mm:ss.fff tt", System.Globalization.CultureInfo.InvariantCulture);
        }


        public int ToMilliseconds()
        {
            return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
        }

        public int ToSeconds()
        {
            return (Hour * 3600) + (Minute * 60) + Second;
        }

        public int ToMinutes()
        {
            return (Hour * 60) + Minute;
        }

        public bool IsOtherDay(Time other)

        {
            long totalMilliseconds = ToMilliseconds();

            long addTotal = other.ToMilliseconds();

            long newTotal = totalMilliseconds + addTotal;

            long oneDay = 86400000L;

            return newTotal >= oneDay;
        }

        public Time Add(Time other)

        {
            long totalMilliseconds = ToMilliseconds();
            long addTotal = other.ToMilliseconds();
            long newTotal = (totalMilliseconds + addTotal) % 86400000L;

            int newHour = (int)(newTotal / 3600000);
            newTotal %= 3600000;

            int newMinute = (int)(newTotal / 60000);
            newTotal %= 60000;

            int newSecond = (int)(newTotal / 1000);
            int newMillisecond = (int)(newTotal % 1000);

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }


        private int ValidHour(int hour)
        { 
            if (hour < 0 || hour > 23)
             throw new Exception($"The hour: {hour}, is not valid.");
            return hour;
        }

        private int ValidMinute(int minute)
        { 
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("Minute must be between 0 and 59.");
            return minute;
        }

        private int ValidSecond(int second)

        {  
            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException("Second must be between 0 and 59.");
            return second;
        }

        private int ValidMillisecond(int millisecond)

        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentOutOfRangeException("Millisecond must between 0 and 999");
            return millisecond;
        }

       
    }
}   
