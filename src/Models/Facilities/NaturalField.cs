using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<ICompostProducing>, IPlantable {
        private int _capacity = 60;
        private Guid _id = Guid.NewGuid ();

        private List<ICompostProducing> _plants = new List<ICompostProducing> ();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (ICompostProducing resource) {
            for (int i = 0; i < 6; i++) {
                _plants.Add (resource);
            }
        }

        public void AddResource (List<ICompostProducing> resources) {
            foreach (ICompostProducing resource in resources) {
                for (int i = 0; i < 6; i++) {
                    _plants.Add (resource);
                }
            }
        }

        public void AddResource(Sunflower sunflower)
        {
            for (int i = 0; i < 6; i++) {
                _plants.Add (sunflower);
            }
        }

        public override string ToString () {
            StringBuilder output = new StringBuilder ();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append ($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach (a => output.Append ($"   {a}\n"));

            return output.ToString ();
        }
    }
}