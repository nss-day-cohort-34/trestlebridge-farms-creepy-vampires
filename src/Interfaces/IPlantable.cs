using Trestlebridge.Models.Plants;
using System.Collections.Generic;
namespace Trestlebridge.Interfaces

{
    public interface IPlantable {
        void AddResource(IPlant sunflower);
        public int numOfPlants();
        public string shortId();
        public int Capacity {get;}
        public string Type { get; set; }
        public int PlantsPerRow { get; }
        List<IPlant> Plants { get; }
    }
}