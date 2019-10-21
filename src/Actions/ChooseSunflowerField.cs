using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput(Farm farm, Sunflower sunflower) {
            Console.Clear();

            for (int i = 1; i <= farm.PlantFields.Count; i++) {
                if (farm.PlantFields[i - 1].Capacity > farm.PlantFields[i - 1].numOfPlants()) {

                    Console.WriteLine($"{i}. {farm.PlantFields[i-1].Type} {farm.PlantFields[i-1].shortId()} has {farm.PlantFields[i - 1].numOfPlants()} plants.");
                } else {
                    Console.WriteLine($"{i}. {farm.PlantFields[i-1].Type} {farm.PlantFields[i-1].shortId()} is at capacity with {farm.PlantFields[i - 1].numOfPlants()} plants.");
                }
            }

            // for (int i = 1; i <= farm.PlantFields.Count; i++) {
            //     Console.WriteLine($"{i}. {farm.PlantFields[i - 1].Type} {farm.PlantFields[i - 1].shortId()} has {farm.PlantFields[i - 1].numOfPlants()} plants.");
            // }

            Console.WriteLine();

            // How can I output the type of seed chosen here?
            Console.WriteLine($"Place the plant where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.PlantFields[choice - 1].AddResource(sunflower);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}