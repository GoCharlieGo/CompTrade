using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название товара")]
        public string ProductName { get; set; }

        [Display(Name = "Стоимость")]
        public double ProductPrice { get; set; }

        [Display(Name = "Описание")]
        public string ShortDiscription { get; set; }

        [Display(Name = "Рэйтинг")]
        public double Rating { get; set; }

        [Display(Name = "Колличество оценок")]
        public int RatingCount { get; set; }

        [Display(Name = "Категория")]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}