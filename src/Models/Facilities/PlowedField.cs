using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<ISeedProducing>, IPlantable {
        private int _capacity = 65;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public int numOfPlants() {
            return _plants.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }

        public int Capacity {
            get {
                return _capacity;
            }
        }

        public string Type { get; set; } = "Plowed Field";

        public void AddResource(ISeedProducing resource) {
            for (int i = 0; i < 5; i++) {
                if (_plants.Count < Capacity) {
                    _plants.Add(resource);
                } else {
                    Console.WriteLine("This plowed field is at capacity.");
                }
            }
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            Console.WriteLine($"5 {resource} added to plowed field {shortId}.");
            Thread.Sleep(2000);
        }

        public void AddResource(List<ISeedProducing> resources) {
            foreach (ISeedProducing resource in resources) {
                for (int i = 0; i < 5; i++) {
                    if (_plants.Count < Capacity) {
                        _plants.Add(resource);
                    } else {
                        Console.WriteLine("This plowed field is at capacity.");
                    }
                }
                string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                Console.WriteLine($"5 {resource} added to plowed field {shortId}.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(Sunflower sunflower) {
            for (int i = 0; i < 5; i++) {
                _plants.Add(sunflower);
            }
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
            Console.WriteLine($"5 sunflowers add to plowed field {shortId}.");
            Thread.Sleep(2000);

        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}