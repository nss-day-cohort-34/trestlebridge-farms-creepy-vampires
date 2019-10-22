using Trestlebridge.Models.Plants;
namespace Trestlebridge.Interfaces

{
    public interface IPlantable {
        void AddResource(Sunflower sunflower);
        public int numOfPlants();
        public string shortId();
        public int Capacity {get;}
        public string Type { get; set; }
        public int PlantsPerRow { get; }

    }
}