using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyApp.Models;

namespace PartyApp.Services
{
    public class PositionServiceInMemory : IPositionService
    {
        private static readonly IList<Position> Positions = new List<Position>()
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

        public bool Add(Position pos)
        {
            if (! Positions.Any(p => p.UserId == pos.UserId && p.IssueId == pos.IssueId)) {
                Positions.Add(pos);
                return true;
            }
            return false;
        }

        public bool Update(Position pos)
        {
            Position posInList = Positions
                .FirstOrDefault(p => p.UserId == pos.UserId && p.IssueId == pos.IssueId);
            if (posInList != null) {
                posInList = pos;
                return true;
            }
            else {
                Positions.Add(pos);
                return true;
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
