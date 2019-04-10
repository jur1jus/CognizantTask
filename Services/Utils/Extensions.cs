using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Utils
{
    public static class Extensions
    {
		public static string LongDateTime(this DateTime dateTime)
		{
			var month = dateTime.Month < 10 ? "0" + dateTime.Month : dateTime.Month.ToString();
			var day = dateTime.Day < 10 ? "0" + dateTime.Day : dateTime.Day.ToString();
			var hour = dateTime.Hour < 10 ? "0" + dateTime.Hour : dateTime.Hour.ToString();
			var minute = dateTime.Minute < 10 ? "0" + dateTime.Minute : dateTime.Minute.ToString();
			var second = dateTime.Second < 10 ? "0" + dateTime.Second : dateTime.Second.ToString();
			return $"{dateTime.Year}{month}{day}_{hour}{minute}{second}";
		}
    }
}
