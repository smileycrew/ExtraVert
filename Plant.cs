public class Plant
{
    public string Species { get; set; }
    // LightNeeds on a scale of 1-5 (1 being shade 5 being full sun)
    public int LightNeeds { get; set; }
    // AskingPrice int
    public decimal AskingPrice { get; set; }
    // City string
    public string City { get; set; }
    // ZIP int
    public int ZIP { get; set; }
    // Sold bool
    public bool Sold { get; set; }
    public DateTime AvailableUntil { get; set; }
}