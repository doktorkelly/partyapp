using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyApp.Models;

namespace PartyApp.Services
{
    public class PositionServiceInMemory : IPositionService
    {
        private readonly IList<Position> Positions = new List<Position>()
        {
            //user has id 0:
            new Position(0, 1, 0, 0),
            //...
            //party 1
            new Position(1, 1, 0, 0),
            new Position(1, 2, 0, 0),
            new Position(1, 3, 0, 0),
            new Position(1, 4, 0, 0),
            new Position(1, 5, 0, 0),
            new Position(1, 6, 0, 0),
            new Position(1, 7, 0, 0),
            new Position(1, 8, 0, 0),
            new Position(1, 9, 0, 0),
            new Position(1, 10, 0, 0),
            //party 2
            new Position(2, 1, 0, 0),
            new Position(2, 2, 0, 0),
            new Position(2, 3, 0, 0),
            new Position(2, 4, 0, 0),
            new Position(2, 5, 0, 0),
            new Position(2, 6, 0, 0),
            new Position(2, 7, 0, 0),
            new Position(2, 8, 0, 0),
            new Position(2, 9, 0, 0),
            new Position(2, 10, 0, 0),
            //...
        };

        public IEnumerable<Position> FindByUser(int userId)
        {
            IEnumerable<Position> userPositions = Positions
                .Where(pos => pos.UserId == userId)
                .ToList();
            return userPositions;
        }

        public Position FindByUserIssue(int userId, int issueId)
        {
            Position position = Positions
                .FirstOrDefault(pos => pos.UserId == userId && pos.IssueId == issueId);
            return position;
        }

        private Position FindByUserIssue(Position pos)
        {
            if (pos != null) {
                return Positions.FirstOrDefault(p => p.UserId == pos.UserId && p.IssueId == pos.IssueId);
            }
            return null;
        }

        public bool Add(Position pos)
        {
            if (pos != null && FindByUserIssue(pos) == null) {
                Positions.Add(pos);
                return true;
            }
            return false;
        }

        public bool Update(Position pos)
        {
            if (pos != null) {
                Position posInList = FindByUserIssue(pos.UserId, pos.IssueId);
                if (posInList != null) {
                    posInList.ConsentLevel = pos.ConsentLevel;
                    posInList.Weight = pos.Weight;
                    return true;
                }
            }
            return false;
        }

        public bool AddOrUpdate(Position pos)
        {
            if (FindByUserIssue(pos) != null) {
                return Update(pos);
            }
            else {
                return Add(pos);
            }
        }

        public bool Delete(int userId, int issueId)
        {
            Position posInList = Positions
                .FirstOrDefault(p => p.UserId == userId && p.IssueId == issueId);
            if (posInList != null) {
                Positions.Remove(posInList);
            }
            return false;
        }
    }
}
