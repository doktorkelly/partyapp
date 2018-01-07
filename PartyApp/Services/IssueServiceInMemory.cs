using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyApp.Models;

namespace PartyApp.Services
{
    public class IssueServiceInMemory : IIssueService
    {
        private static readonly IEnumerable<Issue> IssueList = new List<Issue>() {
            new Issue(1, "issue01", "desc01", "cat1"),
            new Issue(2, "issue02", "desc02", "cat1"),
            new Issue(3, "issue03", "desc03", "cat1"),
            new Issue(4, "issue04", "desc04", "cat2"),
            new Issue(5, "issue05", "desc05", "cat2"),
            new Issue(6, "issue06", "desc06", "cat2"),
            //from wahlomat bundestag 2017:
            new Issue(10, "Bundeswehr im Inneren", "Bei der Terrorismusbekämpfung soll die Bundeswehr im Inland eingesetzt werden dürfen.", "cat3"),
            new Issue(11, "Besteuerung von Pkw-Diesel", "Dieselkraftstoff für Pkw soll höher besteuert werden.", "cat3"),
            new Issue(12, "Obergrenze für Asylsuchende", "Für die Aufnahme von neuen Asylsuchenden soll eine jährliche Obergrenze gelten.", "cat3"),
            new Issue(13, "Ausbau erneuerbarer Energien", "Der Ausbau erneuerbarer Energien soll vom Bund dauerhaft finanziell gefördert werden.", "cat3"),
        };


        public IEnumerable<Issue> GetAllIssues()
        {
            return IssueList;
        }

        public Issue FindById(int id)
        {
            Issue issue = IssueList
                .FirstOrDefault(i => i.Id == id);
            return issue;
        }
    }
}
