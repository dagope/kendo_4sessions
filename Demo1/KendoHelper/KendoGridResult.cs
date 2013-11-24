using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo1.KendoHelper
{
    public class KendoGridResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}