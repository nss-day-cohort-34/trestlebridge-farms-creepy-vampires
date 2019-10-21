using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput(Farm farm, IGrazing animal) {
            Console.Clear();

            for (int i = 1; i <= farm.GrazingFields.Count; i++) {
                if (farm.GrazingFields[i - 1].Capacity > farm.GrazingFields[i - 1].numOfAnimals()) {
                    Console.WriteLine($"{i}. Grazing Field{farm.GrazingFields[i-1].shortId()} has {farm.GrazingFields[i - 1].numOfAnimals()} animals.");
                } else {
                    Console.WriteLine($"{i}. Grazing Field{farm.GrazingFields[i-1].shortId()} is at capacity with {farm.GrazingFields[i - 1].numOfAnimals()} animals.");
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            farm.GrazingFields[choice - 1].AddResource(animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}