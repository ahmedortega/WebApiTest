using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ModelYear { get; set; }
        public string Color { get; set; }
    }
}
