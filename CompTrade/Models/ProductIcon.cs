using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("ProductIcon")]
    public class ProductIcon
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Продукт")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Display(Name = "Фото")]
        public int IconId { get; set; }
        [ForeignKey("IconId")]
        public virtual Icon Icon { get; set; }
    }
}