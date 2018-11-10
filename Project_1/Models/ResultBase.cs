using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
      public class ResultBase<T> where T : class, new()
        {
            //TODO: this would be better as int like in the official documentation
            public string Code { get; set; }
            public string Status { get; set; }
            public string Copyright { get; set; }
            public string AttributionText { get; set; }
            public string AttributionHtml { get; set; }
            public DataContainer<T> Data { get; set; }
            public string Etag { get; set; }
        }
}