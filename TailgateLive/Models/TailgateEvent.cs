using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class TailgateEvent
    {
        [Key]
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }

        [ForeignKey("Teams")]
        public int TeamsId { get; set; }
        public Teams Teams { get; set; }

        
        [ForeignKey("FoodItems")]
        public int FoodId { get; set; }
        public FoodItems FoodItems { get; set; }

        public bool EventStatus { get; set; }
        public int EventRating { get; set; }
        public string EventComments { get; set; }
        [ForeignKey("UserInformation")]
        public int UserInformationId { get; set; }
        public TailgateEvent userInformation { get; set; }

    }
}