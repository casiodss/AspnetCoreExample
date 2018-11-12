using System;
using System.Collections.Generic;

namespace AspNetCoreExample.SqlData.Vega
{
    public partial class Models
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }

        public Makes Make { get; set; }
    }
}
