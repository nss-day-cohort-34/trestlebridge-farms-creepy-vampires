using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck> {
        private int _capacity = 2; // max capacity of 12 ducks
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public int numOfAnimals() {
            return _ducks.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }

        public int Capacity {
            get {
                return _capacity;
            }
        }
        public void AddResource(Duck resource) {
            if (_ducks.Count < Capacity) {
                _ducks.Add(resource);
            } else {
                Console.WriteLine("This duck house is at capacity.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(List<Duck> resources) {
            foreach (Duck duck in resources) {
                if (_ducks.Count < Capacity) {
                    _ducks.Add(duck);
                } else {
                    Console.WriteLine("This duck house is at capacity.");
                    Thread.Sleep(2000);
                }
            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} animals\n");
            this._ducks.ForEach(duck => output.Append($"   {duck}\n"));

            return output.ToString();
        }
    }
}