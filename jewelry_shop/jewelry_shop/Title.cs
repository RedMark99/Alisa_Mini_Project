using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewelry_shop
{
    public class Title
    {
        [Key]

        public int TitleId { get; set; }

        [Required]

        public string Name { get; set; }
            
        public string Type { get; set; }
    }
}
