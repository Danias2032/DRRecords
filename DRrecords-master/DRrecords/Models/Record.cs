namespace DRrecords.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public int LengthInSeconds { get; set; }

        public void Validation()
        {
            if (LengthInSeconds <= -1)
            {
                throw new ArgumentOutOfRangeException("Length is invalid less than 0");
            }
        }
    }
}
