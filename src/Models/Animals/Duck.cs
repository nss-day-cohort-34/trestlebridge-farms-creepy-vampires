using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Duck : IResource, IFeed, IEggProducing, IFeatherProducing {

        private Guid _id = Guid.NewGuid();
        private double _feathersProduced = 0.75;
        private int _eggsProduced = 6;

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public string Type { get; } = "Duck";
        public double FeedPerDay { get; set; } = 0.8;

        // Methods
        public double Pluck() {
            return _feathersProduced;
        }

        public double CollectEggs() {
            return _eggsProduced;
        }

        public override string ToString() {
            return $"Duck {this._shortId}. Quack!";
        }

        public void Feed() {
            Console.WriteLine($"Duck {this._shortId} just ate {this.FeedPerDay}kg of feed.");
        }
    }
}