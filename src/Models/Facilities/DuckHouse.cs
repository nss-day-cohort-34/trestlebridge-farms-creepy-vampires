using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12; // max capacity of 12 ducks
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public void AddResource(Duck resource)
        {
            throw new NotImplementedException();
        }

        public void AddResource(List<Duck> resources)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} animals\n");
            this._ducks.ForEach(duck => output.Append($"   {duck}\n"));

            return output.ToString();
        }
    }
}