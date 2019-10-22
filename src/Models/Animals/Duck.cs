using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Duck : IResource, IFeed, IEggProducing, IFeatherProducing {

        private Guid _id = Guid.NewGuid();
        private double _feathersProduced = 0.75;
        private int _eggsProduced = 6;
        public double FeedPerDay { get; set; } = 0.8;
        public string Type { get; } = "Duck";
        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        // Methods
        public double Pluck() {
            return _feathersProduced;
        }
        public double CollectEggs() {
            return _eggsProduced;
        }
        public void Feed() {
            Console.WriteLine($"Duck {this._shortId} just ate {this.FeedPerDay}kg of feed.");
        }
        public override string ToString() {
            return $"Duck {this._shortId}. Quack!";
        }

    }
}