using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string City { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [Required]
        [Range(0000000001, 9999999999)]
        public decimal Phone { get; set; }
        [Required]
        public int Pincode { get; set; }
    }
}
