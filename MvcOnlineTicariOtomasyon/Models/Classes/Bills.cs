using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bills
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1, ErrorMessage = "En fazla 1 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string SerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "En fazla 6 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string RowNumber { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60, ErrorMessage = "En fazla 60 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5, ErrorMessage = "En fazla 5 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string HourTime { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Receiver { get; set; }

        public decimal Total { get; set; }

        public ICollection<BillDetail> BillDetails { get; set; }
    }
}