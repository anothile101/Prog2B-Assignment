using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using prog_practice.Data;
using prog_practice.Models;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Claims;
using System;

namespace prog_practice.Controllers
{
    public class ManagerController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ManagerController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            var claims = _context.Claims
                .Include(c => c.ClaimHistories)
                .OrderByDescending(c => c.DateSubmitted)
                .ToList();

            ViewBag.TotalApproved = claims.Count(c => c.Status == "Approved");
            ViewBag.PendingProcessing = claims.Count(c => c.Status == "Approved");
            ViewBag.Processed = claims.Count(c => c.Status == "Processed");
            ViewBag.RecentActivity = _context.ClaimHistories.Include(h => h.Claim)
                .OrderByDescending(h => h.Timestamp).Take(5).ToList();

            return View(claims);
        }

        

        
        // GET: VerifyClaim/5
        public IActionResult VerifyClaim(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim == null)
                return NotFound();

            return View(claim);
        }


        // POST: VerifyClaim (Mark as Processed)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyClaim(int id, string actionType)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim == null)
                return NotFound();

            if (actionType == "Process")
            {
                claim.Status = "Processed";
                claim.LastUpdated = DateTime.Now;
                claim.UpdatedBy = "Manager";

                // Add to claim history
                _context.ClaimHistories.Add(new ClaimHistory
                {
                    ClaimID = claim.ClaimID,
                    Action = "Claim marked as Processed by Manager",
                    PerformedBy = "Manager",
                    Timestamp = DateTime.Now
                });

                _context.SaveChanges();

                TempData["Success"] = $"Claim #{claim.ClaimID} has been successfully processed.";
            }

            return RedirectToAction("Dashboard");
        }
        // Download Reports
        public IActionResult DownloadReports()
        {
            var path = Path.Combine(_environment.WebRootPath, "sample-report.pdf");
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf", "ClaimsReport.pdf");
        }
    }
}
