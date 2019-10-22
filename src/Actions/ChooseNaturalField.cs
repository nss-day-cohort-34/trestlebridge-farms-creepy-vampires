using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput(Farm farm, IPlant plant) {
            Utils.Clear();

            for (int i = 1; i <= farm.NaturalFields.Count; i++) {
                NaturalField field = farm.NaturalFields[i - 1];
                if (field.Capacity > field.numOfPlants()) {
                    Console.WriteLine($"{i}. Natural Field {field.shortId()} has {(field.numOfPlants() / 6)} rows of plants.");

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
                    Console.WriteLine($"{i}. Natural Field {field.shortId()} is at capacity with {field.numOfPlants()} plants.");
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