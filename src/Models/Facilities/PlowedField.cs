using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<ISeedProducing>, IPlantable {
        private int _capacity = 65;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(ISeedProducing resource) {
            for (int i = 0; i < 5; i++) {
                _plants.Add(resource);
            }
        }

        public void AddResource(List<ISeedProducing> resources) {
            foreach (ISeedProducing resource in resources) {
                for (int i = 0; i < 5; i++) {
                    _plants.Add(resource);
                }
            }
        }

        public void AddResource(Sunflower sunflower) {
            for (int i = 0; i < 5; i++) {
                _plants.Add(sunflower);
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