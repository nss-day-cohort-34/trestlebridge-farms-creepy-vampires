namespace Trestlebridge.Interfaces {
    public interface ICompostProducing {
        string Type { get; }
        double Compost();
    }
}