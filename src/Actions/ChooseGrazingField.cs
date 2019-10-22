using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput(Farm farm, IGrazing animal) {
            Utils.Clear();
            try {
                for (int i = 1; i <= farm.GrazingFields.Count; i++) {
                    GrazingField field = farm.GrazingFields[i - 1];
                    if (field.Capacity > field.numOfAnimals()) {
                        // Print out the number of total animals
                        Console.WriteLine($"{i}. Grazing Field {field.shortId()} has {field.numOfAnimals()} animals.");
                        // Print out the counts of each type of animal
                        var counts = field.Animals.GroupBy(animal => animal.Type)
                            .Select(group => new PrintReport {
                                Name = group.Key,
                                    Count = group.Count()
                            });

                        foreach (PrintReport report in counts) {
                            Console.WriteLine($"{report.Name}: {report.Count}");
                        }

                    } else {
                        Console.WriteLine($"{i}. Grazing Field {field.shortId()} is at capacity with {field.numOfAnimals()} animals.");
                        var counts = field.Animals.GroupBy(animal => animal.Type)
                            .Select(group => new PrintReport {
                                Name = group.Key,
                                    Count = group.Count()
                            });

                        foreach (PrintReport report in counts) {
                            Console.WriteLine($"{report.Name}: {report.Count}");
                        }
                    }
                }

                Console.WriteLine();

                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                farm.GrazingFields[choice - 1].AddResource(animal);
            } catch {
                Console.WriteLine("Please enter a valid selection.");
                Thread.Sleep(1000);
                CollectInput(farm, animal);
            }
        }
    }
}