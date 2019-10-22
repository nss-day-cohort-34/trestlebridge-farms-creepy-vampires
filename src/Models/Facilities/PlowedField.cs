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

        public int PlantsPerRow { get; } = 5;

        public string Type { get; set; } = "Plowed Field";

        public void AddResource(ISeedProducing resource) {
            if (_plants.Count < Capacity)
            {
                for (int i = 0; i < 5; i++)
                {
                    _plants.Add(resource);
                }
                string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                Console.WriteLine($"5 {resource} added to plowed field {shortId}.");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This plowed field is at capacity.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(List<ISeedProducing> resources)
        {
            foreach (ISeedProducing resource in resources)
            {
                if (_plants.Count < Capacity)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _plants.Add(resource);
                    }
                    string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                    Console.WriteLine($"5 {resource} added to plowed field {shortId}.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("This plowed field is at capacity.");
                    Thread.Sleep(2000);
                }

            }
        }

        public void AddResource(Sunflower sunflower) {
            if (_plants.Count < Capacity)
            {
                for (int i = 0; i < 5; i++) {
                    _plants.Add(sunflower);
                }
                string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                Console.WriteLine($"5 sunflowers add to plowed field {shortId}.");
                Thread.Sleep(2000);
            } else {
                Console.WriteLine("This plowed field is at capacity.");
                Thread.Sleep(2000);
            }
        }

        public void AddResource(List<Sunflower> resources)
        {
            foreach (Sunflower resource in resources)
            {
                if (_plants.Count < Capacity)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _plants.Add(resource);
                    }
                    string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
                    Console.WriteLine($"5 {resource} added to plowed field {shortId}.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("This plowed field is at capacity.");
                    Thread.Sleep(2000);
                }
            }
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