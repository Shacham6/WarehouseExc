using System;

namespace WarehouseKings
{
    public class WorkingHours
    {
        public int TimeOpening { get; private set; }
        public int TimeClosing { get; private set; }
        
        /// <summary>
        /// Creates a WorkingHours where timeOpening and timeClosing represented as integers like:
        /// 1750 -- hour:17, minute:50
        /// 2230 -- hour:22, minute:30
        /// </summary>
        public WorkingHours(int timeOpening, int timeClosing)
        {
            TimeOpening = timeOpening;
            TimeClosing = timeClosing;
        }

        public bool IsCurrentlyWorkingHours(DateTime currentTime)
        {
            // the time represented as an int (just like our TimeFrom and TimeTo)
            int timeAsInt = ((int)currentTime.Hour * 100) + (int)currentTime.Minute;

            return timeAsInt >= TimeOpening && timeAsInt <= TimeClosing;
        }
    }
}