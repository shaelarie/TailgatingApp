using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class UserInformation
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ZipCode { get; set; }
        public int Rating { get; set; }

        [ForeignKey("HostedEvents")]
        public int HostedEventsId { get; set; }
        public HostedEvents HostedEvents { get; set; }

    }
}