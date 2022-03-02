using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000, ErrorMessage = "En fazla 2000 karakter !")]
        public string Detail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "URL en fazla 50 karakter olabilir !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SaleAction> SaleActions { get; set; }
    }
}