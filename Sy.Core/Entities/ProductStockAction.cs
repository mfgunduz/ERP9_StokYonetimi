using Sy.Core.Abstracts;
using Sy.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sy.Core.Entities
{
    [Table (name: "ProductStockActions")]
    public class ProductStockAction : BaseEntity<long>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public StockActionType StockActionType { get; set; }


        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
