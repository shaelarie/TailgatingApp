using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class Teams
    {
        [Key]
        public int Id { get; set; }
        public string Team { get; set; }
    }
}