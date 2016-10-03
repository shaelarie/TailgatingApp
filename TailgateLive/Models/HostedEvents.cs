using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class HostedEvents
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TailgateEvent")]
        public int TailgateEventId { get; set; }
        public TailgateEvent TailgateEvent { get; set; }
    }
}