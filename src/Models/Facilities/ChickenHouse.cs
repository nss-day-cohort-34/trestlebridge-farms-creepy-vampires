using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : IFacility<Chicken>
    {
        private int _capacity = 15; // max capacity of 15 chickens
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _chickens = new List<Chicken>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public void AddResource(Chicken resource)
        {
            _chickens.Add(resource);
        }

        public void AddResource(List<Chicken> resources)
        {
            foreach(Chicken chicken in resources)
            {
                _chickens.Add(chicken);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken House {shortId} has {this._chickens.Count} animals\n");
            this._chickens.ForEach(chicken => output.Append($"   {chicken}\n"));

            return output.ToString();
        }
    }
}