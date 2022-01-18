using System.ComponentModel.DataAnnotations;

namespace TimeSeries.Model
{
    // should this be keyless or not???
    public class DataPoint
    {
        [Key]
        public Guid Id { get; set; }
        public string? name { get; set; }
        public long t { get; set; } // timestamp as epoch
        public float v { get; set; } // value
    }
}
