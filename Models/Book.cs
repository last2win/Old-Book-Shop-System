using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "书名")]
        public string Name { get; set; }
        [Display(Name = "原价")]

        public double Price { get; set; }
        [Display(Name = "卖价")]
        public double SoldPrice { get; set; }
        [Display(Name = "介绍")]
        public string Content { get; set; }
        [Display(Name = "作者")]
        public string Author { get; set; }
    }
}
