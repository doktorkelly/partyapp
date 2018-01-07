using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyApp.Services;
using PartyApp.Models;

namespace PartyApp.Controllers
{
    public class IssuePositionController : Controller
    {
        private IIssueService IssueService { get; }
        private IPositionService PositionService { get; }
        private static readonly int MyUserId = 0;

        public IssuePositionController(IIssueService issueService, IPositionService issuePositionService)
        {
            this.IssueService = issueService;
            this.PositionService = issuePositionService;
        }

        public ActionResult Index()
        {
            IEnumerable<Issue> issues = IssueService.GetAllIssues();
            IEnumerable<Position> positions = PositionService.FindByUser(MyUserId);
            IEnumerable<IssuePosition> issuePositions = issues
                .Select(issue => CreateIssuePosition(issue, 
                    positions?.FirstOrDefault(pos => pos.IssueId == issue.Id)))
                .ToList();
            return View(issuePositions);
        }

        public ActionResult Details(int id)
        {
            Issue issue = IssueService.FindById(id);
            Position pos = PositionService.FindByUserIssue(MyUserId, id);
            IssuePosition issuePos = CreateIssuePosition(issue, pos);
            return View(issuePos);
        }

        public ActionResult Edit(int id)
        {
            Issue issue = IssueService.FindById(id);
            Position pos = PositionService.FindByUserIssue(MyUserId, id);
            IssuePosition issuePos = CreateIssuePosition(issue, pos);
            return View(issuePos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IssuePosition issuePos)
        {
            if (id != issuePos.IssueId) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                try {
                    Position pos = ToPosition(issuePos, MyUserId);
                    bool ok = PositionService.Update(pos);
                    return RedirectToAction(nameof(Index));
                }
                catch {
                    return View();
                }
            }
            return View();
        }

        #region helper

        private static IssuePosition CreateIssuePosition(Issue issue, Position position)
        {
            if (issue != null) {
                IssuePosition issuePos = new IssuePosition(
                    id: issue.Id,
                    title: issue.Title,
                    text: issue.Text,
                    consent: position?.ConsentLevel,
                    weight: position?.Weight
                    );
                return issuePos;
            }
            return null;
        }

        private static Position ToPosition(IssuePosition issuePos, int userId)
        {
            if (issuePos != null) {
                Position pos = new Position(
                    userId: userId,
                    issueId: issuePos.IssueId,
                    pos: issuePos.ConsentLevel,
                    weight: issuePos.Weight
                    );
                return pos;
            }
            return null;
        }

        #endregion
    }
}