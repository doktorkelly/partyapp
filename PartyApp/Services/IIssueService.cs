using PartyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApp.Services
{
    public interface IIssueService
    {
        IEnumerable<Issue> GetAllIssues();
        Issue FindById(int id);
    }
}
