using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9_My_Excemption
{
    abstract class HouseHoldChemical: Commodity
    {
        public string Manufacturer { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public HouseHoldChemical() { }
        public HouseHoldChemical(string description,string name, double weight, double price, int count, string manufacturer,
            DateTime production_date, DateTime expiration_date) 
            : base(description, name,weight, price, count)
        {
            Manufacturer = manufacturer;
            ProductionDate = production_date;
            ExpirationDate = expiration_date;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Manufacturer,-35}{ProductionDate.ToShortDateString(),-20}{ExpirationDate.ToShortDateString(),-15}";
        }

    }

    class DetergentCommodity : HouseHoldChemical, ICommodityManagement
    {
        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "D4CY";
        public DetergentCommodity() { }
        public DetergentCommodity(string description, string name, double weight, double price, int count, string manufacturer,DateTime production_date, DateTime expirationdate)
            : base(description, name,weight, price, count, manufacturer,production_date, expirationdate)
        {
            ID += 1;
            CurrentID = ID;
        }

        public void Add(int count)
        {
            Count += count;
            Console.WriteLine($"Name commodity : {Name}\nQuantity added : : {Count}");
        }

        public void Dispose(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity written off : {Count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods to be debited");
        }

        public void Sell(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {Count}");
            }
            else Console.WriteLine($"Insufficient quantity of goods for sale");
        }

        public void Transfer(int count, string export)
        {
            if (Count >= count)
            {
                Count -= count;
                Console.WriteLine($"Name commodity : {Name}\nQuantity sold : {Count} | Exported to the {export}");
            }
        }

        public override string ToString()
        {
            return $"{CurrentID,-5}" + base.ToString();
        }
    }

    class LaundryCommodity : HouseHoldChemical, ICommodityManagement
    {
        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "L5CY";
        public LaundryCommodity() { }
        public LaundryCommodity(string description, string name, double weight, double price, int count, string manufacturer, DateTime production_date, DateTime expirationdate)
            : base(description, name,weight, price, count, manufacturer, production_date, expirationdate)
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

    class SanitaryCommodity : HouseHoldChemical, ICommodityManagement
    {
        public int CurrentID { get; private set; }
        public static string ProductCode { get; private set; } = "S6CY";
        public SanitaryCommodity() { }
        public SanitaryCommodity(string description, string name, double weight, double price, int count, string manufacturer,DateTime production_date, DateTime expirationdate)
            : base(description, name,weight, price, count, manufacturer,production_date ,expirationdate)
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
