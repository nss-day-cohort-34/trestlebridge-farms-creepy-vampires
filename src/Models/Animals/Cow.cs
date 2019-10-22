using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Cow : IResource, IGrazing, IMeatProducing {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 18.25;
        public double GrassPerDay { get; set; } = 5.4;
        public string Type { get; } = "Cow";
        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        // Methods
        public void Graze() {
            Console.WriteLine($"Cow {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }
        public double Butcher() {
            return _meatProduced;
        }
        public override string ToString() {
            return $"Cow {this._shortId}. Mooo!";
        }
    }
}