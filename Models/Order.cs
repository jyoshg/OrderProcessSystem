using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessSystem.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        public int Quantity { get; set; }

        public int ItemId { get; set; }

        public virtual OrderItem Product { get; set; }

        public int accountId { get; set; }

        public string accountName { get; set; }
    }
}
