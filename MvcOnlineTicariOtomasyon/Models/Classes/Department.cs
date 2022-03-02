using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Department
    {
        [Key] 
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter !")]
        [Required(ErrorMessage = "Bu alan boş geçilemez !")]
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}