using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jewelry_shop
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }

        [Required]
        public string Name { get; set; }

        public int GramPrice { get; set; }
    }
}
