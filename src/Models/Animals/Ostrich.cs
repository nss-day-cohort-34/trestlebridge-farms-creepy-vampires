using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Ostrich : IResource, IGrazing, IEggProducing, IMeatProducing {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 2.6;
        private int _eggsProduced = 3;
        public double GrassPerDay { get; set; } = 2.3;
        public string Type { get; } = "Ostrich";
        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        // Methods
        public void Graze() {
            Console.WriteLine($"Ostrich {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }
        public double Butcher() {
            return _meatProduced;
        }
        public double CollectEggs() {
            return _eggsProduced;
        }
        public override string ToString() {
            return $"Ostrich {this._shortId}. Squack!";
        }

    }
}