using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        [StringLength(20,MinimumLength =5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string LastName { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 10)]
        public string CompanyName { get; set; }
    }
}