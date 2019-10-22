using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using System.Threading;

namespace Trestlebridge.Actions {
    public class PurchaseStock {
        public static void CollectInput (Farm farm) {
            try
            {
                Console.WriteLine("1. Cow");
                Console.WriteLine("2. Ostrich");
                Console.WriteLine("3. Pig");
                Console.WriteLine("4. Sheep");
                Console.WriteLine("5. Goat");
                Console.WriteLine("6. Duck");
                Console.WriteLine("7. Chicken");

                Console.WriteLine();
                Console.WriteLine("What are you buying today?");

                Console.Write("> ");
                string choice = Console.ReadLine();

                switch (Int32.Parse(choice))
                {
                    case 1:
                        ChooseGrazingField.CollectInput(farm, new Cow());
                        break;
                    case 2:
                        ChooseGrazingField.CollectInput(farm, new Ostrich());
                        break;
                    case 3:
                        ChooseGrazingField.CollectInput(farm, new Pig());
                        break;
                    case 4:
                        ChooseGrazingField.CollectInput(farm, new Sheep());
                        break;
                    case 5:
                        ChooseGrazingField.CollectInput(farm, new Goat());
                        break;
                    case 6:
                        ChooseDuckHouse.CollectInput(farm, new Duck());
                        break;
                    case 7:
                        ChooseChickenHouse.CollectInput(farm, new Chicken());
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selction.");
                        Thread.Sleep(1000);
                        CollectInput(farm);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid selction.");
                Thread.Sleep(1000);
                CollectInput(farm);
            }
                
            
            
        }
    }
}