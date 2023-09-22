using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;

namespace HW_9_My_Excemption
{

    internal class Sources
    {
        public static List<Commodity> ReadCommoditiesFromFile(string path)
        {
            List<Commodity> commodities = new List<Commodity>();
            try
            {
                string file_path = Path.Combine(Environment.CurrentDirectory, path);
                string[] lines = File.ReadAllLines(file_path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length < 9) continue;

                    string code = parts[0];
                    string description = parts[1];
                    string name = parts[2];
                    double weight = double.Parse(parts[3]);
                    double price = double.Parse(parts[4]);
                    int count = int.Parse(parts[5]);
                    string country_of_original = parts[6];
                    DateTime prod_date = DateTime.Parse(parts[7]);
                    DateTime exp_date = DateTime.Parse(parts[8]);

                    Commodity commodity = CreateIProduct(code, description, name, weight, price, count,
                        country_of_original, prod_date, exp_date);

                    if (commodity != null)
                    {
                        commodities.Add(commodity);
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error read file : " + e.Message);
            }
            catch (MyException e)
            {
                Console.WriteLine("Error : " + e.Message);
                Console.ReadKey();
            }
            return commodities;
        }


        static Commodity CreateIProduct(string product_code, string description,
            string name, double weight, double price, int count, string country_of_original,
            DateTime prod_date, DateTime exp_date)
        {

            if (BakeryCommodity.ProductCode == product_code)
            {
                return new BakeryCommodity(
                    description,name,weight,price,count,country_of_original,prod_date,exp_date);
            }
            else if (CandyCommodity.ProductCode == product_code)
            {
                return new CandyCommodity(
                    description, name, weight, price, count, country_of_original, prod_date, exp_date);
            }
            else if (MilkCommodity.ProductCode == product_code)
            {
                return new MilkCommodity(
                    description, name, weight, price, count, country_of_original, prod_date, exp_date);
            }
            else if (DetergentCommodity.ProductCode == product_code)
            {
                return new DetergentCommodity(
                    description, name, weight, price, count, country_of_original, prod_date, exp_date);
            }
            else if (LaundryCommodity.ProductCode == product_code)
            {
                return new LaundryCommodity(
                    description, name, weight, price, count, country_of_original, prod_date, exp_date);
            }
            else if (SanitaryCommodity.ProductCode == product_code)
            {
                return new SanitaryCommodity(
                    description, name, weight, price, count, country_of_original, prod_date, exp_date);
            }
            else return null;
        }

        public static int SetCount()
        {
            int number = 0;

            Console.Write("Enter to count number for current operation  : ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0 || number < 100)
            {
                return number;

            }
            else
            {
                Console.WriteLine("Error input number count");
                return 0;
            }
        }
        
        public static string GetLine()
        {
            string line = "";
            for (int i = 0; i < 150; i++)
            {
                if (i == 0) line += "\n";
                else if (i == 149) line += "\n";
                else line += "=";
            }
            return line;
        }

        public static string MenuHeader()
        {
            string menu_header = ($"{GetLine()}{"ID",-4}{"Description",-27}{"Name",-15}{"Weight",-10}{"Price",-10}{"Count",-10}{"Manufacturer(country of origin)",-35}" +
            $"{"Production date",-20}{"Expiration date",-20}{GetLine()}");
            return menu_header;
        }

        public static void InterfaceMenu(Commodity obj)
        {
            List<string> MenuItems = new List<string>
            {
                "Adding commodity",
                "Realisation commodity",
                "Despose commodity",
                "Transfer commodity",
                "Exit"
            };
            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine(MenuHeader() + obj + GetLine() +
                    "Select action :");
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(MenuItems[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < MenuItems.Count - 1)
                        {
                            selected_item_index++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (selected_item_index == MenuItems.Count-1)
                        {
                            return;
                        }
                        else
                        {
                            switch (selected_item_index)
                            {
                                case 0:
                                    {
                                        int number = SetCount();
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Add(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        int number = SetCount();
                                        if(number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Sell(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        int number = SetCount();
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Dispose(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        int number = SetCount();
                                        string destination = "Shop";
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Transfer(number,destination);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        public static void MenuLevel_2(List<Commodity> list)
        {
            //List<Commodity> list = new List<Commodity>
            //{
            //    new CandyCommodity("Candy","Snikers",0.1,50.5,10,"USA",new DateTime(2023,9,20),new DateTime(2024,9,20)),
            //    new DetergentCommodity("Detergent","Fairy",1.8,198.7,20,"Germany",new DateTime(2023,5,6), new DateTime(2025,5,6)),
            //    new BakeryCommodity("Sunflower oil","Sloboda",0.9, 140.5,10,"Russia",new DateTime(2023,5,20),new DateTime(2024,5,20)),
            //    new MilkCommodity("Milk","Prostokvashino",0.9,120.5,30,"Russia",new DateTime(2023,9,21),new DateTime(2023,10,5)),
            //    new LaundryCommodity("Washing powder","Tide",0.5,150.5,30,"Germany",new DateTime(2023,1,1),new DateTime(2025,10,5)),
            //    new SanitaryCommodity("Floor cleaning agent","Mr.Proper",1.0,215.3,20,"USA",new DateTime(2023,5,23),new DateTime(2025,5,23) )
            //};

            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tOrder list commodity\t Click escape if you need to exit the program\n" +
                    "Select action :");
                Console.Write(MenuHeader());
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(list[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        else selected_item_index = list.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < list.Count)
                        {
                            selected_item_index++;
                        }
                        if (selected_item_index == list.Count)
                        {
                            selected_item_index = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            return;
                        }

                    case ConsoleKey.Enter:
                        {
                            InterfaceMenu(list.ElementAt(selected_item_index));
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        public static void SetCommodityCode(ref string ProductCode)
        {
            List<string> MenuItems = new List<string>
            {
                "B1CY - Bakery commodity",
                "C2CY - Candy commodity",
                "M3CY - Milk commodity",
                "D4CY - Detergent commodity",
                "L5CY - Laundry commodity",
                "S6CY - Sanitary commodity",
                "Exit"
            };
            int selected_item_index = 0;
            bool flag = true;

            while (flag == true)
            {
                Console.Clear();

                Console.WriteLine("\tChange to code commodity\n" +
                    "Select action :");
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(MenuItems[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < MenuItems.Count - 1)
                        {
                            selected_item_index++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (selected_item_index == MenuItems.Count - 1)
                        {
                            return;
                        }
                        else
                        {
                            switch (selected_item_index)
                            {
                                case 0:
                                    {
                                        ProductCode = "B1CY";
                                        Console.WriteLine("ProductCode = B1CY");
                                        flag = false;

                                    }
                                    break;
                                case 1:
                                    {
                                        ProductCode = "C2CY";
                                        Console.WriteLine("ProductCode = C2CY");
                                        flag = false;
                                    }
                                    break;
                                case 2:
                                    {
                                        ProductCode = "M3CY";
                                        Console.WriteLine("ProductCode = M3CY");
                                        flag = false;
                                    }
                                    break;
                                case 3:
                                    {
                                        ProductCode = "D4CY";
                                        Console.WriteLine("ProductCode = D4CY");
                                        flag = false;
                                    }
                                    break;
                                case 4:
                                    {
                                        ProductCode = "L5CY";
                                        Console.WriteLine("ProductCode = L5CY");
                                        flag = false;
                                    }
                                    break;
                                case 5:
                                    {
                                        ProductCode = "S6CY";
                                        Console.WriteLine("ProductCode = S6CY");
                                        flag = false;
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static Commodity Set_Commodity()
        {
            string product_code = "", description = "", name = "", country_of_origin = "";
            double weight = 0, price = 0;
            int count = 0;
            DateTime prod_date = new DateTime(), exp_date = new DateTime();
            try
            {
                SetCommodityCode(ref product_code);
                if (product_code == "")
                {
                    throw new MyException("The file does not contain information about the product code");
                }
                else
                {
                    Console.Write("Enter to description of commodity : ");
                    description = Console.ReadLine();
                    Console.Write(GetLine());
                    Console.Write("Enter to name commodity : ");
                    name = Console.ReadLine();
                    Console.Write(GetLine());
                    Console.Write("Enter to weight commodity (kg or liter) :");
                    string input = Console.ReadLine();
                    if(!double.TryParse(input, out weight))
                    {
                        throw new MyException("Input incorrect value!");
                    }
                    else
                    {
                        if(weight < 0 || weight > 5)
                        {
                            throw new MyException("The value entered is out of range");
                        }
                    }
                    Console.Write(GetLine());
                    Console.Write("Enter to price commodity : ");
                    input = Console.ReadLine();
                    if (!double.TryParse(input, out price))
                    {
                        throw new MyException("Input incorrect value!");
                    }
                    else
                    {
                        if (price < 0 || price > 20000)
                        {
                            throw new MyException("The value entered is out of range");
                        }
                    }
                    Console.Write(GetLine());
                    Console.Write("Enter to count commodity : ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input,out count))
                    {
                        throw new MyException("Input incorrect value!");
                    }
                    else
                    {
                        if (count < 0 || count > 100)
                        {
                            throw new MyException("The value entered is out of range");
                        }
                    }
                    Console.Write(GetLine());
                    Console.Write("Enter to country original commodity : ");
                    country_of_origin = Console.ReadLine();
                    Console.Write("Enter to production date in format (YYYY-MM-DD) : ");
                    input = Console.ReadLine();
                    prod_date = DateTime.Parse(input);
                    Console.Write(GetLine());
                    Console.Write("Enter to expiration date in format (YYYY-MM-DD) : ");
                    input = Console.ReadLine();
                    exp_date = DateTime.Parse(input);
                    Console.Write(GetLine());
                    Commodity commodity = CreateIProduct(product_code, description, name, weight, price, count,
                        country_of_origin, prod_date, exp_date);
                    return commodity;
                }
            }
            catch (MyException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                Console.ReadKey();
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                Console.ReadKey();
                return null;

            }
        }


        public static void MenuLevel_1()
        {
            string path = "commodities.txt";
            List<Commodity> list = ReadCommoditiesFromFile(path);
            List<string> MenuItems = new List<string>
            {
                "Create new commodity",
                "Open list commodities",
                "Exit"
            };
            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("\t1C User version\n" +
                    "Select action :");
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(MenuItems[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < MenuItems.Count - 1)
                        {
                            selected_item_index++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (selected_item_index == MenuItems.Count - 1)
                        {
                            return;
                        }
                        else
                        {
                            switch (selected_item_index)
                            {
                                case 0:
                                    {
                                        try
                                        {
                                            Console.Clear();
                                            Commodity commodity = Set_Commodity();
                                            if (commodity != null)
                                            {
                                                list.Add(commodity);
                                                Console.WriteLine("Commodity is created!");
                                                Console.ReadKey();
                                            }
                                            else throw new MyException("Commodity not created");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Error : " + ex.Message);
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        MenuLevel_2(list);
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
