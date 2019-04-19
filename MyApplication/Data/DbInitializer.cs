using MyApplication.Models;
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
            if (context.RelaxRooms.Any())
            {
                return;
            }

            var relaxRooms = new RelaxRoom[]
            {
                new RelaxRoom {Name="Желтая комната"},
                new RelaxRoom {Name="Зеленая комната"}
            };
            foreach (RelaxRoom s in relaxRooms)
            {
                context.RelaxRooms.Add(s);
            }
            context.SaveChanges();

            var microwaves = new Microwave[]
            {
                new Microwave{Mark="LG", RelaxRoonId=1}
            };
            foreach(Microwave e in microwaves)
            {
                context.Microwaves.Add(e);
            }
            context.SaveChanges();

            var usingTimes = new UsingTime[]
            {
                new UsingTime{Value=1},
                new UsingTime{Value=2},
                new UsingTime{Value=3},
                new UsingTime{Value=5}
            };
            foreach(UsingTime c in usingTimes)
            {
                context.UsingTimes.Add(c);
            }
            context.SaveChanges();

            var queues = new Queue[]
            {
                new Queue{User="Пирожок",StartDate=DateTime.Parse("19.04.2017 12:03:00"),UsingTimeId=1,MicrowaveId=1},
                new Queue{User="Саша",StartDate=DateTime.Parse("19.04.2019 12:10:00"),UsingTimeId=2,MicrowaveId=1},
                new Queue{User="Паша",StartDate=DateTime.Parse("19.04.2019 14:01:00"),UsingTimeId=3,MicrowaveId=1}
            };
            foreach (Queue q in queues)
            {
                context.Queues.Add(q);
            }
            context.SaveChanges();
        }
    }
}
