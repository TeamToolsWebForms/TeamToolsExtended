using System;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class DateService : IDateService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
