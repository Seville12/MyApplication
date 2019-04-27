using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize (ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.DRelaxRooms.Any())
            {
                return;
            }

            var relaxRooms = new DRelaxRoom[]
            {
                new DRelaxRoom {Name="Желтая комната"},
                new DRelaxRoom {Name="Зеленая комната"}
            };
            foreach (DRelaxRoom s in relaxRooms)
            {
                context.DRelaxRooms.Add(s);
            }
            context.SaveChanges();

            var microwaves = new DMicrowave[]
            {
                new DMicrowave{Mark="LG", RelaxRoonId=1}
            };
            foreach(DMicrowave e in microwaves)
            {
                context.DMicrowaves.Add(e);
            }
            context.SaveChanges();

            var usingTimes = new DUsingTime[]
            {
                new DUsingTime{Value=1},
                new DUsingTime{Value=2},
                new DUsingTime{Value=3},
                new DUsingTime{Value=5}
            };
            foreach(DUsingTime c in usingTimes)
            {
                context.DUsingTimes.Add(c);
            }
            context.SaveChanges();

            var queues = new DQueue[]
            {
                new DQueue{User="Пирожок",StartDate=DateTime.Parse("19.04.2017 12:03:00"),UsingTimeId=1,MicrowaveId=1},
                new DQueue{User="Саша",StartDate=DateTime.Parse("19.04.2019 12:10:00"),UsingTimeId=2,MicrowaveId=1},
                new DQueue{User="Паша",StartDate=DateTime.Parse("19.04.2019 14:01:00"),UsingTimeId=3,MicrowaveId=1}
            };
            foreach (DQueue q in queues)
            {
                context.DQueues.Add(q);
            }
            context.SaveChanges();
        }
    }
}
