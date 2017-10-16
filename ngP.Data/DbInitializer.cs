using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public static class DbInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
            {
                return;
            }

            var items = new Item[]
            {
                new Item{Name="Name1", Date = DateTime.Parse("2017-01-01")},
                new Item{Name="Name2", Date = DateTime.Parse("2017-01-01")},
                new Item{Name="Name3", Date = DateTime.Parse("2017-01-01")},
                new Item{Name="Name4", Date = DateTime.Parse("2017-01-01")}
            };

            foreach (Item item in items)
            {
                context.Items.Add(item);
            }

            context.SaveChanges();


        }
    }
}
