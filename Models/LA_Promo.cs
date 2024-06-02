using System.ComponentModel.DataAnnotations;
using System;

namespace LeonardoAndradeBackendMVC.Models
{
    public class LA_Promo
    {
        [Key]
        public int PromoID { get; set; }

        public string? Descripcion { get; set; }
        public int FechaPromo { get; set; }

        public int BurgerID { get; set; }
        public LA_Burger? burger { get; set; }
    }
}
