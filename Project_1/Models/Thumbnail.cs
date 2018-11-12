using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
    public class Thumbnail
    {
        [Required]
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}