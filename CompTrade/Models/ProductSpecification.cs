using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("ProductSpecification")]
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Товар")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Display(Name = "Характеристика")]
        public int SpecificationId { get; set; }
        [ForeignKey("SpecificationId")]
        public virtual Specification Specification { get; set; }

        [Display(Name = "Зачение")]
        public string Value { get; set; }
    }
}