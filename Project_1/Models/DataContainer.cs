using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
        public class DataContainer<T> where T : class, new()
        {
            public string Offset { get; set; }
            public string Limit { get; set; }
            public string Total { get; set; }
            public string Count { get; set; }
            public List<T> Results { get; set; }
        }
}