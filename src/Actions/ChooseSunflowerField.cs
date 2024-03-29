using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput(Farm farm, IPlant sunflower) {
            Utils.Clear();

            try
            {
                for (int i = 1; i <= farm.PlantFields.Count; i++) {
                IPlantable field = farm.PlantFields[i - 1];
                if (field.Capacity > field.numOfPlants()) {
                    Console.WriteLine($"{i}. {field.Type} {field.shortId()} has {field.numOfPlants() / field.PlantsPerRow } rows of plants.");

                    // Print out the counts of each type of animal
                    var counts = field.Plants.GroupBy(plant => plant.Type)
                        .Select(group => new PrintReport
                        {
                            Name = group.Key,
                            Count = group.Count()
                        });

                    foreach (PrintReport report in counts)
                    {
                        Console.WriteLine($"{report.Name}: {report.Count}");
                    }
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

            }
            catch
            {
                Console.WriteLine ("Please enter a valid selection.");
                Thread.Sleep (1000);
                CollectInput (farm, sunflower);
            }

            
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}