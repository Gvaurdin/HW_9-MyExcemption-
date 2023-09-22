using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HW_9_My_Excemption
{
    abstract class FoodProduct : Commodity
    {
        public string Country_of_Origin { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public FoodProduct() { }
        public FoodProduct(string description,string name, double weight, double price, int count, string country_of_origin,
            DateTime production_date, DateTime expiration_date)
            : base(description,name,weight, price, count)
        {
            ExpirationDate = expiration_date;
            Country_of_Origin = country_of_origin;
            ProductionDate = production_date;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Country_of_Origin,-35}{ProductionDate.ToShortDateString(),-20}{ExpirationDate.ToShortDateString(),-15}";
        }
    }

    class BakeryCommodity : FoodProduct, ICommodityManagement
    {

        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "B1CY";

        public BakeryCommodity() { }
        public BakeryCommodity(string description, string name, double weight, double price, int count, string country_of_origin,DateTime production_date, DateTime expirationdate)
            : base(description,name,weight, price, count, country_of_origin,production_date, expirationdate)
        {
            ID += 1;
            CurrentID = ID;
        }

        public void Add(int count)
        {
            Count += count;
            Console.WriteLine($"Name commodity : {Name}\nQuantity added : : {count}");
        }

        public void Dispose(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity written off : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods to be debited");
        }

        public void Sell(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods for sale");
        }

        public void Transfer(int count, string export)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count} | Exported to the {export}");
            }
        }

        public override string ToString()
        {
            return $"{CurrentID,-5}" + base.ToString();
        }

    }

    class CandyCommodity : FoodProduct, ICommodityManagement
    {
        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "C2CY";
        public CandyCommodity() { }
        public CandyCommodity(string description, string name, double weight, double price, int count, string country_of_origin, DateTime production_date, DateTime expirationdate)
            : base(description, name,weight, price, count, country_of_origin, production_date, expirationdate)
        {
            ID += 1;
            CurrentID = ID;
        }

        public void Add(int count)
        {
            Count += count;
            Console.WriteLine($"Name commodity : {Name}\nQuantity added : : {count}");
        }

        public void Dispose(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity written off : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods to be debited");
        }

        public void Sell(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods for sale");
        }

        public void Transfer(int count, string export)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count} | Exported to the {export}");
            }
        }
        public override string ToString()
        {
            return $"{CurrentID,-5}" + base.ToString();
        }
    }

    class MilkCommodity : FoodProduct, ICommodityManagement
    {
        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "M3CY";
        public MilkCommodity() { }
        public MilkCommodity(string description, string name, double weight, double price, int count, string country_of_origin,DateTime production_date, DateTime expirationdate)
            : base(description,name,weight, price, count, country_of_origin,production_date, expirationdate)
        {
            ID += 1;
            CurrentID = ID;
        }

        public void Add(int count)
        {
            Count += count;
            Console.WriteLine($"Name commodity : {Name}\nQuantity added : : {count}");
        }

        public void Dispose(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity written off : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods to be debited");
        }

        public void Sell(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods for sale");
        }

        public void Transfer(int count, string export)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {count} | Exported to the {export}");
            }
        }

        public override string ToString()
        {
            return $"{CurrentID,-5}" + base.ToString();
        }
    }
}
