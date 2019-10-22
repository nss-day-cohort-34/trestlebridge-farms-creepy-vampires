using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<ICompostProducing>, IPlantable {
        private int _capacity = 6;
        private Guid _id { get; } = Guid.NewGuid();

        private List<ICompostProducing> _plants = new List<ICompostProducing>();
        public int numOfPlants() {
            return _plants.Count;
        }
        public string shortId() {
            return _id.ToString().Substring(this._id.ToString().Length - 6);
        }
        public string Type { get; set; } = "Natural Field";

        public int Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(ICompostProducing resource) {
            if (_plants.Count < Capacity) {
                for (int i = 0; i < 6; i++) {
                    _plants.Add(resource);
                }
                string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                Console.WriteLine($"6 {resource} added to natural field {shortId}.");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This natural field is at capacity.");
                Thread.Sleep(2000);
            }
            
        }

        public void AddResource(List<ICompostProducing> resources) {
            foreach (ICompostProducing resource in resources) {
                if (_plants.Count < Capacity) {
                    for (int i = 0; i < 6; i++) {
                        _plants.Add(resource);
                    }
                    string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                    Console.WriteLine($"6 {resource} added to natural field {shortId}.");
                    Thread.Sleep(2000);
                } else {
                    Console.WriteLine("This natural field is at capacity.");
                    Thread.Sleep(2000);
                }
                
            }
        }

        public void AddResource(Sunflower sunflower) {
            if (_plants.Count < Capacity) {
                for (int i = 0; i < 6; i++)
                {
                    _plants.Add(sunflower);
                }
                string shortId = this._id.ToString().Substring(this._id.ToString().Length - 6);
                Console.WriteLine($"6 sunflowers add to natural field {shortId}.");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This natural field is at capacity.");
                Thread.Sleep(2000);
            }
            
        }

        public void AddResource(List<Sunflower> resources)
        {
            foreach (ICompostProducing resource in resources)
            {
                if (_plants.Count < Capacity)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        _plants.Add(resource);
                    }
                    string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                    Console.WriteLine($"6 {resource} added to natural field {shortId}.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("This natural field is at capacity.");
                    Thread.Sleep(2000);
                }

            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}