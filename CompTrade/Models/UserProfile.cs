using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompTrade.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FistName { get; set; }

        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        public string ImgPath { get; set; }

        [Display(Name = "О себе")]
        public string Info { get; set; }
    }
}