using System.ComponentModel.DataAnnotations;

namespace RestAPI_Nov2022.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
