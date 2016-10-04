using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class EventUser
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TailgateEvent")]
        public int TailgateEventId { get; set; }
        public TailgateEvent tailgateEvent { get; set; }
        [ForeignKey("UserInformation")]
        public int UserInformationId { get; set; }
        public TailgateEvent userInformation { get; set; }
    }
}