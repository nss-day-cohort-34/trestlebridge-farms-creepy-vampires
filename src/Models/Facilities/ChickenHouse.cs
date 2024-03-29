using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken> {
        private int _capacity = 15; // max capacity of 15 chickens
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _chickens = new List<Chicken>();

        public int Capacity {
            get {
                return _capacity;
            }
        }
        public int numOfAnimals() {
            return _chickens.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }
        public void AddResource(Chicken resource) {
            if (_chickens.Count < Capacity) {
                _chickens.Add(resource);
                Console.WriteLine($"{resource} has been added to chicken house {shortId()}");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This chicken house is at capacity.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(List<Chicken> resources) {
            foreach (Chicken chicken in resources) {
                if (_chickens.Count < Capacity) {
                    _chickens.Add(chicken);
                    Console.WriteLine($"{resources} has been added to chicken house {shortId()}");
                    Thread.Sleep(2000);
                } else {
                    Console.WriteLine("This chicken house is at capacity.");
                    Thread.Sleep(2000);
                }
            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken House {shortId} has {this._chickens.Count} chickens\n");
            // this._chickens.ForEach(chicken => output.Append($"   {chicken}\n"));

            return output.ToString();
        }
    }
}