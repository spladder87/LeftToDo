using System;

namespace LeftToDo
{
    public class DateFormat
    {
        public static string CreateDate()
        {
            Console.WriteLine("Please enter date in format dd/MM/yyyy when this task should be finished");
            string date = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                date = Console.ReadLine();
            }

            return date;

        }
    }
}