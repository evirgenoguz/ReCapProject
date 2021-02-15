using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car
    {
        public int CarId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public float DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
