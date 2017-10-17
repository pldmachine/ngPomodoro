using System;
using System.Collections.Generic;
using System.Text;

namespace ngP.Data.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TimeLog> TimeLogs{ get; set; }
    }
}
