using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseDuckHouse {
        public static void CollectInput(Farm farm, Duck duck) {
            Console.Clear();

            for (int i = 1; i <= farm.DuckHouses.Count; i++) {
                if (farm.DuckHouses[i - 1].Capacity > farm.DuckHouses[i - 1].numOfAnimals()) {

                    Console.WriteLine($"{i}. Duck House {farm.DuckHouses[i-1].shortId()} has {farm.DuckHouses[i - 1].numOfAnimals()} animals.");
                } else {
                    Console.WriteLine($"{i}. Duck House {farm.DuckHouses[i-1].shortId()} is at capacity with {farm.DuckHouses[i - 1].numOfAnimals()} animals.");
                }

            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.DuckHouses[choice - 1].AddResource(duck);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}