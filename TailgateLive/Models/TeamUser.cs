using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class TeamUser
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Teams")]
        public int TeamsId { get; set; }
        public Teams teams { get; set; }
        [ForeignKey("UserInformation")]
        public int UserInformationId { get; set; }
        public TailgateEvent userInformation { get; set; }
    }
}