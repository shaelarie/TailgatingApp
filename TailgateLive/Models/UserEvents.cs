using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class UserEvents
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserInformation")]
        public int UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
        [ForeignKey("TailgateEvent")]
        public int EventId { get; set; }
        public TailgateEvent TailgateEvent { get; set; }
    }
}