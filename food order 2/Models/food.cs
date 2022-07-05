using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace food_order_2.Models
{
    public class food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(50)]
        public string Review { get; set; }
        [MaxLength(100)]
        public string Imageurl { get; set; }

    }
}
