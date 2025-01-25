using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entites
{
    public class Order
    {

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string OrderDate { get; set; }

        public decimal TotalAmount { get; set; }


        public ICollection<Product> products { get; set;}


    }
}
