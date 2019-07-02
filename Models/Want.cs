using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Want
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "书名")]
        public string Name { get; set; }

        [Display(Name = "预期价格")]

        public double Price { get; set; }
    }
}
