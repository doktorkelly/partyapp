using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApp.Models
{
    public class Position
    {
        //[Required]
        public int UserId { get; set; }

        //[Required]
        public int IssueId { get; set; }

        [Range(-5, 5)]
        public int? ConsentLevel { get; set; }

        [Range(0, 5)]
        public int? Weight { get; set; }

        public Position(int userId, int issueId, int? pos, int? weight)
        {
            this.UserId = userId;
            this.IssueId = issueId;
            this.ConsentLevel = pos;
            this.Weight = weight;
        }
    }
}
