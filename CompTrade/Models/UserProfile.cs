using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompTrade.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Имя")]
        public string FistName { get; set; }

        [Required]
        [Display(Name ="Фамилия")]
        public string SecondName { get; set; }

        [Required]
        public string ImgPath { get; set; }

        [Required]
        [Display(Name = "О себе")]
        public string Info { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public  virtual ApplicationUser User { get; set; }
    }
}