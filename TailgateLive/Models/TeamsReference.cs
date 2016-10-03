using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class TeamsReference
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserInformation")]
        public int UserId { get; set; }
        public UserInformation UserInfo { get; set; }
        [ForeignKey("Teams")]
        public int TeamId { get; set; }
        public Teams Teams { get; set; }
    }
}