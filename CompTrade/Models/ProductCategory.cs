using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Категория")]
        public string Name { get; set; }
    }
}