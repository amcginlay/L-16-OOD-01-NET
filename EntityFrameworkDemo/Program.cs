using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // add Matt (Matt does not exist at this point)
            using (var context = new tradingsystemEntities())
            {
                broker b = new broker() { id = 4, name = "Matt" };
                context.brokers.Add(b);
                context.SaveChanges();
            }

            // list brokers
            using(var context = new tradingsystemEntities())
            {
                foreach (var broker in context.brokers)
                {
                    Console.WriteLine(broker.name);
                }
            }

            // delete Matt
            using (var context = new tradingsystemEntities())
            {
                var brokers = context.brokers.Where(b => b.name == "Matt");
                foreach (broker b in brokers)
                {
                    context.brokers.Remove(b);
                }
                context.SaveChanges();
            }

            // relations
            Console.WriteLine("relations");
            using (var context = new tradingsystemEntities())
            {
                var query = (from b in context.brokers
                             where b.company.city == "Redmond"
                             select b); 

                foreach (var broker in query)
                {
                    Console.WriteLine(broker.name);
                }

            }


        }
    }
}
