using System;
using System.Text;

namespace CSharpTimeLib
{
    public class Time
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;


        }
        private uint seconds;

        public Time()
        {
            seconds = 0;
        }

        public Time(int h, int m, int s)
        {
            seconds = (uint)((h * 60 + m) * 60 + s);
        }

        public Time(string buffer)
        {
            string[] tmp = buffer.Split(':');

            if (tmp.Length == 3 && int.TryParse(tmp[0], out int h) && int.TryParse(tmp[1], out int m) && int.TryParse(tmp[2], out int s))
            {
                int seconds = (h * 60 + m) * 60 + s;
                
            }
            else
            {
               throw new FormatException();
            }
        }

        public int Hours
        {
            get
            {
                return (int)seconds / 3600;
            }
        }

        public int Minutes
        {
            get
            {
                return (int)seconds / 60 % 60;
            }
        }

        public int Seconds
        {
            get
            {
                return (int)seconds % 60;
            }
        }

        public Time AddTime(Time t1)
        {
            int totalSeconds = (int)this.seconds + (int)t1.seconds;
            return new Time(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public Time SubtractTime(Time t1)
        {
            int totalSeconds = (int)this.seconds - (int)t1.seconds;
            return new Time(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public int ToSeconds()
        {
            return (int)this.seconds;
        }

        public static Time FromSeconds(int totalSeconds)
        {
            return new Time(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public override string ToString()
        {
            uint hours, minutes, sec = seconds % 60;
            minutes = (seconds / 60) % 60;
            hours = (seconds / 3600);
            return $"{hours:D2}:{minutes:D2}:{sec:D2}";
        }
    }
}
