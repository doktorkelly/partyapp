using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PartyApp.Models
{
    public class IssuePosition
    {
        //[Required]
        //[ReadOnly(true)]
        public int IssueId { get; set; }

        //[Required]
        //[ReadOnly(true)]
        public string Title { get; set; }

        //[ReadOnly(true)]
        public string Text { get; set; }

        [Range(0, 5)]
        public int? ConsentLevel { get; set; }

        [Range(0, 5)]
        public int? Weight { get; set; }

        public IssuePosition()
        {
        }

        public IssuePosition(int id, string title, string text, int? consent, int? weight)
        {
            this.IssueId = id;
            this.Title = title;
            this.Text = text;
            this.ConsentLevel = consent;
            this.Weight = weight;
        }
    }
}
