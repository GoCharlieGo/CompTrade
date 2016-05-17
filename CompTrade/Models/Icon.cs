using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("Icon")]
    public class Icon
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Фото продукта")]
        public string IconPath { get; set; }
    }
}