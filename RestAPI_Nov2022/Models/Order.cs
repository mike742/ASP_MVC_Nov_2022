using System.ComponentModel.DataAnnotations;

namespace RestAPI_Nov2022.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
