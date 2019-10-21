using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing> {
        private int _capacity = 20; // changed capacity from 50 to 20.
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();
        public int numOfAnimals() {
            return _animals.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(IGrazing animal) {
            // Take in an IGrazing animal and add it to the field's _animal List
            if (Capacity < _animals.Count) {
                _animals.Add(animal);
            } else {
                Console.WriteLine("This grazing field is at capacity.");
            }
        }

        public void AddResource(List<IGrazing> animals) {
            // Take in a list of Igrazing animals and add each one to the field's _animal List
            foreach (IGrazing animal in animals) {
                if (Capacity < _animals.Count) {
                    _animals.Add(animal);
                } else {
                    Console.WriteLine("This grazing field is at capacity.");
                }
            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}