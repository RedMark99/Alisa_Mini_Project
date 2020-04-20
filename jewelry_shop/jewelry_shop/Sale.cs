using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jewelry_shop
{
    public class Sale
    {
        [Key]
        public int Numeric { get; set; }

        [ForeignKey("Title")]
        public int TitleId { get; set; }
        public Title Title { get; set; }

        [Required]

        [Column(TypeName = "date")]

        public DateTime SaleDate { get; set; }

        public string SName { get; set; }

        public string Name { get; set; }

        public string FName { get; set; }
    }
}
