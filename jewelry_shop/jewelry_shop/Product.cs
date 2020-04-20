using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jewelry_shop
{
    public class Product
    {
        [Key]
        public int RollNo { get; set; }

        [ForeignKey("Title")]
        public int TitleId { get; set; }
        public Title Title { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        [Required]
        public int Weight { get; set; }

        public int Price { get; set; }
    }
}
