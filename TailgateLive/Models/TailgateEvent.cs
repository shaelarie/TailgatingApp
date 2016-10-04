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
        [ForeignKey("UserEvents")]
        public int UserEventsId { get; set; }
        public UserEvents UserEvents { get; set; }
        public bool EventStatus { get; set; }
        public int EventRating { get; set; }
        public string Comments { get; set; }
        [ForeignKey("FoodItems")]
        public int FoodItemsId { get; set; }
        public FoodItems foodItems { get; set; }
    }
}