using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter !")]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250,ErrorMessage = "URL 250 karakterden uzun olamaz !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Image { get; set; }
        //public ICollection<SaleAction> SaleActions { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        
    }
}