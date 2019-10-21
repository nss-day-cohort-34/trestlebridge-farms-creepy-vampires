using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput(Farm farm, ISeedProducing plant) {
            Console.Clear();

            for (int i = 1; i <= farm.PlowedFields.Count; i++) {
                if (farm.PlowedFields[i - 1].Capacity > farm.PlowedFields[i - 1].numOfPlants()) {
                    Console.WriteLine($"{i}. Plowed Field {farm.PlowedFields[i-1].shortId()} has {farm.PlowedFields[i - 1].numOfPlants()} plants.");
                } else {
                    Console.WriteLine($"{i}. Plowed Field {farm.PlowedFields[i-1].shortId()} is at capacity with {farm.PlowedFields[i - 1].numOfPlants()} plants.");
                }
            }

            Console.WriteLine();

            // How can I output the type of seed chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.PlowedFields[choice - 1].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}