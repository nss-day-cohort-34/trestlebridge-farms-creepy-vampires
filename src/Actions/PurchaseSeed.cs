using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using System.Threading;

namespace Trestlebridge.Actions {
    public class PurchaseSeed {
        public static void CollectInput (Farm farm) {
            try
            {
                Console.WriteLine("1. Sunflower");
                Console.WriteLine("2. Wildflower");
                Console.WriteLine("3. Sesame");

                Console.WriteLine();
                Console.WriteLine("What are you buying today?");

                Console.Write("> ");
                string choice = Console.ReadLine();

                switch (Int32.Parse(choice))
                {
                    case 1:
                        ChooseSunflowerField.CollectInput(farm, new Sunflower());
                        break;
                    case 2:
                        ChooseNaturalField.CollectInput(farm, new Wildflower());
                        break;
                    case 3:
                        ChoosePlowedField.CollectInput(farm, new Sesame());
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selction.");
                        Thread.Sleep(1000);
                        Utils.Clear();
                        CollectInput(farm);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid selection.");
                Thread.Sleep(1000);
                Utils.Clear();
                CollectInput(farm);
            }
            
        }
    }
}
