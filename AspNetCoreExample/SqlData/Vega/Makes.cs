using System;
using System.Collections.Generic;

namespace AspNetCoreExample.SqlData.Vega
{
    public partial class Makes
    {
        public Makes()
        {
            Models = new HashSet<Models>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Models> Models { get; set; }
    }
}
