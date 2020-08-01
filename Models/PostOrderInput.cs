using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessSystem.Models
{
    public class PostOrderInput
    {
        public int accountId { get; set; }
        public OrderItem product { get; set; }
        public int quantity { get; set; }
        public string accountName { get; set; }
    }
}
