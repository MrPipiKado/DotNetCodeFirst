using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstThisOneForSure
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DecorationCount { get; set; }

    }

    public class OrderDBContext : DbContext
    {
        public DbSet<Order> orders { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order model = new Order();
            using (OrderDBContext db = new OrderDBContext())
            {
                while (true)
                {
                    Console.WriteLine("Select action: 1 - Add, 2 - Update, 3 - Delete, 4 - Select");
                    int action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            model.Name = "name1";
                            model.Price = 1000;
                            model.DecorationCount = 2;
                            db.orders.Add(model);
                            db.SaveChanges();
                            Console.WriteLine("New entity was successfully added");
                            break;
                        case 2:
                            model = db.orders.Where(x => x.ID == 1).FirstOrDefault();
                            model.Name = "newName";
                            db.orders.Add(model);
                            db.SaveChanges();
                            Console.WriteLine("Entity was successfully updated");
                            break;
                        case 3:
                            db.orders.Remove(model);
                            db.SaveChanges();
                            Console.WriteLine("Entity was successfully deleted");
                            break;
                        case 4:
                            var orderList = db.orders.ToList<Order>();
                            foreach (var order in orderList)
                            {
                                Console.WriteLine(order.ID + " " + order.Name + " " + order.DecorationCount + " " + order.Price);
                            }
                            Console.WriteLine("Entity was successfully loaded");
                            break;
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
