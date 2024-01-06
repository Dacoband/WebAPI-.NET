using System.ComponentModel.DataAnnotations;

namespace WebAPISix.DBUtils
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        public string author { get; set; }
        public string? description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
