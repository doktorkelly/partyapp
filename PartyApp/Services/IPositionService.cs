using PartyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApp.Services
{
    public interface IPositionService
    {
        IEnumerable<Position> FindByUser(int userId);
        Position FindByUserIssue(int userId, int issueId);
        bool Update(Position pos);
        bool Add(Position pos);
        bool AddOrUpdate(Position pos);
        bool Delete(int userId, int issueId);
    }
}
