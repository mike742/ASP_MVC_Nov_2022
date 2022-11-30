using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVC_Nov_2022.Models
{
    public class Product
    {
        [DisplayName("Id")]
        [Key]
        public string? P_code { get; set; }
        
        public string? P_descript { get; set; }
        public DateTime P_InDate { get; set; }
        public int P_QOH { get; set; }
        public int P_Min { get; set; }
        public double P_Price { get; set; }
        public double P_Discount { get; set; }
        [ForeignKey("Vendor")]
        public int? V_code { get; set; }
        public Vendor Vendor { get; set; }
    }
}
