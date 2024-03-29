using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using System.Threading;

namespace Trestlebridge {
    public class ChooseChickenHouse {
        public static void CollectInput(Farm farm, Chicken chicken) {
            Utils.Clear();

            try 
            {
                for (int i = 1; i <= farm.ChickenHouses.Count; i++)
                {
                    if (farm.ChickenHouses[i - 1].Capacity > farm.ChickenHouses[i - 1].numOfAnimals())
                    {
                        Console.WriteLine($"{i}. Chicken House {farm.ChickenHouses[i - 1].shortId()} has {farm.ChickenHouses[i - 1].numOfAnimals()} animals.");
                    }
                    else
                    {
                        Console.WriteLine($"{i}. Chicken House {farm.ChickenHouses[i - 1].shortId()} is at capacity with {farm.ChickenHouses[i - 1].numOfAnimals()} animals.");
                    }
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                farm.ChickenHouses[choice - 1].AddResource(chicken);
            }
            catch
            {
                Console.WriteLine("Please enter a valid selection.");
                Thread.Sleep(1000);
                CollectInput(farm, chicken);
            }
            

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}