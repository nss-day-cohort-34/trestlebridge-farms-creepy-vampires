using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : IResource, ISeedProducing
    {
        private int _seedsProduced = 520;
        public string Type { get; } = "Sesame";
        public double Harvest () {
            return _seedsProduced;
        }
        public override string ToString () {
            return $"sesame";
        }
    }
}