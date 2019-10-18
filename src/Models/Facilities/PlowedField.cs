using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<ISeedProducing> {
        private int _capacity = 65;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(ISeedProducing resource) {
            throw new NotImplementedException();
        }

        public void AddResource(List<ISeedProducing> resources) {
            throw new NotImplementedException();
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