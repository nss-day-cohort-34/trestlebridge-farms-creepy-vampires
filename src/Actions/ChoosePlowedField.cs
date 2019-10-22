using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput (Farm farm, IPlant plant) {
            Utils.Clear ();

            try {
                for (int i = 1; i <= farm.PlowedFields.Count; i++) {
                    PlowedField field = farm.PlowedFields[i - 1];
                    if (field.Capacity > field.numOfPlants ()) {
                        Console.WriteLine ($"{i}. Plowed Field {field.shortId()} has {(field.numOfPlants() / 5)} rows of plants.");

                        // Print out the counts of each type of animal
                        var counts = field.Plants.GroupBy (plant => plant.Type)
                            .Select (group => new PrintReport {
                                Name = group.Key,
                                    Count = group.Count ()
                            });

                        foreach (PrintReport report in counts) {
                            Console.WriteLine ($"{report.Name}: {report.Count}");
                        }
                    } else {
                        Console.WriteLine ($"{i}. Plowed Field {field.shortId()} is at capacity with {field.numOfPlants()} plants.");

                        // Print out the counts of each type of animal
                        var counts = field.Plants.GroupBy (plant => plant.Type)
                            .Select (group => new PrintReport {
                                Name = group.Key,
                                    Count = group.Count ()
                            });

                        foreach (PrintReport report in counts) {
                            Console.WriteLine ($"{report.Name}: {report.Count}");
                        }
                    }
                }

                Console.WriteLine ();

                // How can I output the type of seed chosen here?
                Console.WriteLine ($"Place the plant where?");

                Console.Write ("> ");
                int choice = Int32.Parse (Console.ReadLine ());

                farm.PlowedFields[choice - 1].AddResource (plant);
            } catch {
                Console.WriteLine ("Please enter a valid selection.");
                Thread.Sleep (1000);
                CollectInput (farm, plant);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}