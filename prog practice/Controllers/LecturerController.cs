using Microsoft.AspNetCore.Mvc;
using prog_practice.Data;
using prog_practice.Models;

namespace prog_practice.Controllers
{

        public class LecturerController : Controller
        {
        
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _environment;

            public LecturerController(AppDbContext context, IWebHostEnvironment environment)
            {
                _context = context;
                _environment = environment;
            }

            // GET: SubmitClaim
            public IActionResult SubmitClaim()
            {
                return View();
            }

        // POST: SubmitClaim
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitClaim(Claim model, IFormFile? ClaimDocument)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Auto-calculate
            model.Amount = model.HoursWorked * model.HourlyRate;
            model.Status = "Pending";
            model.DateSubmitted = DateTime.Now;

            // Handle file upload
            if (ClaimDocument != null && ClaimDocument.Length > 0)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                string uniqueFile = $"{Guid.NewGuid()}_{ClaimDocument.FileName}";
                string filePath = Path.Combine(uploadFolder, uniqueFile);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ClaimDocument.CopyTo(stream);
                }

                model.DocumentPath = "/Uploads/" + uniqueFile;
            }

            // Save the claim itself first
            _context.Claims.Add(model);
            _context.SaveChanges();

            //  Then log the claim submission in ClaimHistory
            _context.ClaimHistories.Add(new ClaimHistory
            {
                ClaimID = model.ClaimID,
                Action = "Claim submitted by Lecturer",
                PerformedBy = "Lecturer",
                Timestamp = DateTime.Now
            });

            _context.SaveChanges(); // save the history entry

            TempData["Success"] = "Claim submitted successfully!";
            return RedirectToAction("Dashboard");
        }



        // GET: MyClaims
        public IActionResult MyClaims(DateTime? searchDate, string? status)
        {
            var claims = _context.Claims.AsQueryable();

            if (searchDate.HasValue)
                claims = claims.Where(c => c.ClaimDate.Date == searchDate.Value.Date);

            if (!string.IsNullOrEmpty(status))
                claims = claims.Where(c => c.Status == status);

            return View(claims.OrderByDescending(c => c.DateSubmitted).ToList());
        }


        // GET: Dashboard
        public IActionResult Dashboard()
            {
                var claims = _context.Claims.ToList();
                ViewBag.TotalClaims = claims.Count;
                ViewBag.Pending = claims.Count(c => c.Status == "Pending");
                ViewBag.Approved = claims.Count(c => c.Status == "Approved");
                ViewBag.Rejected = claims.Count(c => c.Status == "Rejected");
                ViewBag.RecentClaims = claims.OrderByDescending(c => c.DateSubmitted).Take(5).ToList();

                return View();
            }
        }
    }