using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Utility
{
    public static class TimeFormatter
    {
        public static string PrettyPrint(DateTimeOffset time)
        {
            string FormatParts(double amount, string unit)
            {
                return $"{amount:F0} {unit}{(amount >= 2D ? "s" : string.Empty)} ago";
            }

            var timeSpan = DateTime.Now - time;

            if (timeSpan.TotalSeconds < 60)
                return FormatParts(timeSpan.TotalSeconds, "second");

            if (timeSpan.TotalMinutes < 60)
                return FormatParts(timeSpan.TotalMinutes, "minute");

            return FormatParts(timeSpan.TotalHours, "hour");
        }
    }
}
