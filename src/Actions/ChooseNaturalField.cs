using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput(Farm farm, ICompostProducing plant) {
            Console.Clear();

            for (int i = 1; i <= farm.NaturalFields.Count; i++) {
                if (farm.NaturalFields[i - 1].Capacity > farm.NaturalFields[i - 1].numOfPlants()) {
                    Console.WriteLine($"{i}. Natural Field {farm.NaturalFields[i-1].shortId()} has {(farm.NaturalFields[i - 1].numOfPlants() / 6)} rows of plants.");
                } else {
                    Console.WriteLine($"{i}. Natural Field {farm.NaturalFields[i-1].shortId()} is at capacity with {farm.NaturalFields[i - 1].numOfPlants()} plants.");
                }
            }

            Console.WriteLine();

            // How can I output the type of seed chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.NaturalFields[choice - 1].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}