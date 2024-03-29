using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;
using Trestlebridge.Actions;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<IPlant>, IPlantable {
        private int _capacity = 60;
        private Guid _id { get; } = Guid.NewGuid();

        private List<IPlant> _plants = new List<IPlant>();
        public int numOfPlants() {
            return _plants.Count;
        }

        public List<IPlant> Plants {
            get {
                return _plants;
            }
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

        public int PlantsPerRow { get; } = 6;

        public void AddResource(IPlant resource) {
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

        public void AddResource(List<IPlant> resources) {
            foreach (IPlant resource in resources) {
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
            foreach (IPlant resource in resources)
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
            // Print out the counts of each type of animal
            var counts = Plants.GroupBy(plant => plant.Type)
                .Select(group => new PrintReport
                {
                    Name = group.Key,
                    Count = group.Count()
                });

            

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            // this._plants.ForEach(a => output.Append($"   {a}\n"));

            foreach (PrintReport report in counts)
            {
                output.Append($"  {report.Name}: {report.Count}\n");
            }

            return output.ToString();
        }
    }
}