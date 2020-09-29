using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyBookStore.Models
{
    class PriceDetail
    {
        public int Id { get; set; }
        public int OldBookDiscount { get; set; }
        public int NewBookDiscount { get; set; }

        public int NewBookDiscountAmmount { get; set; }
    }
}
