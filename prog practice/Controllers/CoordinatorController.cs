using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prog_practice.Data;
using prog_practice.Models;


namespace prog_practice.Controllers
{
   
    
        public class CoordinatorController : Controller
        {
       
            private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CoordinatorController(AppDbContext context, IWebHostEnvironment environment)
            {
                _context = context;
            _environment = environment;
        }

            // GET: Dashboard
            public IActionResult Dashboard()
            
        {
            var claims = _context.Claims.ToList();

            ViewBag.TotalClaims = claims.Count;
            ViewBag.Pending = claims.Count(c => c.Status == "Pending");
            ViewBag.Approved = claims.Count(c => c.Status == "Approved");
            ViewBag.Rejected = claims.Count(c => c.Status == "Rejected");

            // Include Claim so we can access Claim.Title in the history
            var recentHistory = _context.ClaimHistories
                .Include(h => h.Claim)
                .OrderByDescending(h => h.Timestamp)
                .Take(5)
                .ToList();

            ViewBag.RecentActivity = recentHistory;

            return View(claims);
        }

        // GET: VerifyClaim/5
        public IActionResult VerifyClaim(int id)
            {
                var claim = _context.Claims.FirstOrDefault(c => c.ClaimID == id);
                if (claim == null) return NotFound();

                return View(claim);
            }

        // POST: VerifyClaim
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyClaim(int id, string actionType)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim == null) return NotFound();

            if (actionType == "Approve")
                claim.Status = "Approved";
            else if (actionType == "Reject")
                claim.Status = "Rejected";

            claim.LastUpdated = DateTime.Now;
            claim.UpdatedBy = "Coordinator";

            // Log history
            var historyEntry = new ClaimHistory
            {
                ClaimID = claim.ClaimID,
                Action = $"Claim {claim.Status} by Coordinator",
                PerformedBy = "Coordinator",
                Timestamp = DateTime.Now
            };
            _context.ClaimHistories.Add(historyEntry);

            //  Save all changes together
            _context.SaveChanges();

            TempData["Success"] = $"Claim #{claim.ClaimID} has been {claim.Status.ToLower()} successfully.";
            return RedirectToAction("Dashboard");
        }
        public IActionResult ClaimHistory()
        {
            var history = _context.ClaimHistories
                .OrderByDescending(h => h.Timestamp)
                .ToList();
            return View(history);
        }
        public IActionResult ManageLecturers()
        {
            return Content("List of lecturers and their claim statistics will appear here.");
        }

        public IActionResult Reports()
        {
            return Content("Reports dashboard coming soon.");
        }

        public IActionResult DownloadReports()
        {
            var path = Path.Combine(_environment.WebRootPath, "sample-report.pdf");
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf", "MonthlyReport.pdf");
        }

    }
}
    