namespace Trestlebridge.Interfaces {
    public interface IFeed {
        double FeedPerDay { get; set; }
        void Feed();
    }
}