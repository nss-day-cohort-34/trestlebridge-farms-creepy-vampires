using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge {
    public class ChooseDuckHouse {
        public static void CollectInput(Farm farm, Duck duck) {
            Utils.Clear();

            try {
                for (int i = 1; i <= farm.DuckHouses.Count; i++) {
                    if (farm.DuckHouses[i - 1].Capacity > farm.DuckHouses[i - 1].numOfAnimals()) {

                        Console.WriteLine($"{i}. Duck House {farm.DuckHouses[i-1].shortId()} has {farm.DuckHouses[i - 1].numOfAnimals()} animals.");
                    } else {
                        Console.WriteLine($"{i}. Duck House {farm.DuckHouses[i-1].shortId()} is at capacity with {farm.DuckHouses[i - 1].numOfAnimals()} animals.");
                    }

                }

                Console.WriteLine();

                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                farm.DuckHouses[choice - 1].AddResource(duck);

            } catch {
                Console.WriteLine("Please enter a valid selection.");
                Thread.Sleep(1000);
                CollectInput(farm, duck);
            }
        }
    }
}