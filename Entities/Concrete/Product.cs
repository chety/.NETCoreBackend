using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return $"Id: {ProductId}\nName: {ProductName}\nStock: {UnitsInStock}\nPrice: {UnitPrice}\n";
        }
    }
}
