using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Nov_2022.Models
{
    public class Vendor
    {
        [DisplayName("Id")]
        [Key]
        public int V_code { get; set; }
        [DisplayName("Name")]
        public string? V_name { get; set; }
        [DisplayName("Contact")]
        public string? V_contact { get; set; }
        [DisplayName("Area")]
        public int V_AreaCode { get; set; }
        [DisplayName("Phone #")]
        public string? V_phone { get; set; }
        [DisplayName("State")]
        public string? V_state { get; set; }
        [DisplayName("Order")]
        public string? V_order { get; set; }
    }
}
