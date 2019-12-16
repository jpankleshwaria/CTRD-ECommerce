using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime GetUTCDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
