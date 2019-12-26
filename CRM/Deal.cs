using System;
using System.Collections.Generic;
using System.Text;

namespace CRM
{
    class Deal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
