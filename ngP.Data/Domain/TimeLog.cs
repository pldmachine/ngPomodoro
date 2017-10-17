using System;
using System.Collections.Generic;
using System.Text;

namespace ngP.Data.Domain
{
    public class TimeLog
    {
        public int Id { get; set; }
        public int Minutes  { get; set; }
        public DateTime StartDate { get; set; }
        public Project Project { get; set; }
    }
}
