using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Sheep : IResource, IGrazing, IMeatProducing
    {
        private Guid _id = Guid.NewGuid();

        private double _meatProduced = 5.00;
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 4.00;
        public string Type { get; } = "Sheep";

        public double Butcher()
        {
            throw new System.NotImplementedException();
        }

        public void Graze()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"Sheep {this._shortId}. Baahh!";
        }
    }
}