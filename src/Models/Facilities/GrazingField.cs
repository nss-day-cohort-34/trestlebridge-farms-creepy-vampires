using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Trestlebridge.Actions;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing> {
        private int _capacity = 20; // changed capacity from 50 to 20.
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public List<IGrazing> Animals {
            get {
                return _animals;
            }
        }
        public int numOfAnimals() {
            return _animals.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }

        public int Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(IGrazing animal) {
            // Take in an IGrazing animal and add it to the field's _animal List
            if (_animals.Count < Capacity) {
                _animals.Add(animal);
                Console.WriteLine($"{animal} has been added to grazing field {shortId()}");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This grazing field is at capacity.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(List<IGrazing> animals) {
            // Take in a list of Igrazing animals and add each one to the field's _animal List
            foreach (IGrazing animal in animals) {
                if (_animals.Count < Capacity) {
                    _animals.Add(animal);
                    Console.WriteLine($"{animal} has been added to grazing field {shortId()}");
                    Thread.Sleep(2000);
                } else {
                    Console.WriteLine("This grazing field is at capacity.");
                    Thread.Sleep(2000);
                }
            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            // Print out the counts of each type of animal
            var counts = Animals.GroupBy(animal => animal.Type)
                .Select(group => new PrintReport {
                    Name = group.Key,
                        Count = group.Count()
                });

            // this._animals.ForEach(a => output.Append($"   {a}\n"));
            foreach (PrintReport report in counts) {
                output.Append($"   {report.Name}: {report.Count}\n");
            }

            return output.ToString();
        }
    }
}