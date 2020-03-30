using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string BrandName { get; set; }
        public virtual Category Category { get; set; }
    }
}
