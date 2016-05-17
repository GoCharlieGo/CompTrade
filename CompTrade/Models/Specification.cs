using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("Specification")]
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название характеристики")]
        public string CategoryName { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}