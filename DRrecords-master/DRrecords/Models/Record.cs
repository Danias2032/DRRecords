namespace DRrecords.Models
{
    public class Record
    {
        public int id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public int releaseYear { get; set; }
        public string genre { get; set; }
        public int lengthInMin { get; set; }
    }
}
