namespace Trestlebridge.Interfaces
{
    public interface ISeedProducing
    {
        string Type { get; }
        double Harvest ();
    }
}