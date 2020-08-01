using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessSystem.Models
{
    public class OrderItem
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public virtual OrderCategory Category { get; set; }
    }
}
