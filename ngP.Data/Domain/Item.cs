using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ChildItem> Childs { get; set; }
    }
}
