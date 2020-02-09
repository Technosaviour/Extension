using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.Helpers
{
    public static class DateX
    {
        public static string FormatDate(this string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                date = DateTime.Parse(date).ToString("dd-MM-yyyy");
            }
            return date;
        }

        public static string FormatDateWithMonthName(this string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                date = DateTime.Parse(date).ToString("dd MMM yyyy");
            }
            return date;
        }
    }
}
