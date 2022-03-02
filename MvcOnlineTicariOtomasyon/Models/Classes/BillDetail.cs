using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(120)]
        public string Description { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int BillID { get; set; }
        public virtual Bills Bills { get; set; }
    }
}