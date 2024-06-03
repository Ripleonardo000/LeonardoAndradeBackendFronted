using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace LeonardoAndradeBackendMVC.Models
{
    public class LA_Burger
    {
        [Key]
        public int BurgerID { get; set; }


        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Costo { get; set; }
        public List<LA_Promo>? LA_Promo { get; set; }
       
    }
}
