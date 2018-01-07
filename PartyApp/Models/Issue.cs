using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApp.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }

        public Issue(int id, string title, string text, string cat)
        {
            this.Id = id;
            this.Title = title;
            this.Text = text;
            this.Category = cat;
        }
    }
}
