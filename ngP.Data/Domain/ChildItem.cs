using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class ChildItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Item Item { get; set; }
    }
}
