using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Mail { get; set; }

        public bool Status { get; set; }

        //public ICollection<SaleAction> SaleActions { get; set; }
    }
}