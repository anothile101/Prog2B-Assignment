using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using prog_practice.Controllers;
using prog_practice.Data;
using System;
using prog_practice.Models;
using Moq;


namespace prog_practice.Tests
{
    public class UnitTest1
    {
    }
}
//        private AppDbContext GetDbContext()  // Temporary database
//        {
//            var options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
//                .Options;
//            return new AppDbContext(options);
//        }

//        [Fact]
//        public void Test1_AddClaim() 
//        {
//            var db = GetDbContext();
//            var env = new Mock<IWebHostEnvironment>().Object;
//            var controller = new LecturerController(db, env);
//            var claim = new Claim
//            {
//                LecturerName = "Siyanda Mkhize",
//                Title = "Invigilator",
//                HoursWorked = 50,
//                HourlyRate = 60,
//                Month = "June 2025",
//                ClaimDate = DateTime.Now
//            };
//            controller.SubmitClaim(claim, null);

//            // Assert Equals
//            Assert.Single(db.Claims);
//            Assert.Equal(500, db.Claims.First().Amount);
//        }
//        [Fact]
//        public void Test2_ApproveClaim()
//        {
//            var db = GetDbContext();
//            var claim = new Claim { ClaimID = 1, Status = "Pending" };
//            db.Claims.Add(claim);
//            db.SaveChanges();
//            int claimId = claim.ClaimID;

//            var env = new Mock<IWebHostEnvironment>().Object;
//            var controller = new CoordinatorController(db, env);
//            controller.VerifyClaim(1, "Approve");

//            // Assert Equals
//            var updated = db.Claims.First();
//            Assert.Equal("Approved", updated.Status);
//        }
//        [Fact]
//        public void Test3_RejectClaim()
//        {
//            var db = GetDbContext();
            
           
//            var claim = new Claim { ClaimID = 2, Status = "Pending" };
//            db.Claims.Add(claim);
//            db.SaveChanges();
//            int claimId = claim.ClaimID;
//            var env = new Mock<IWebHostEnvironment>().Object;
//            var controller = new CoordinatorController(db, env);
//            controller.VerifyClaim(2, "Reject");

//            var updated = db.Claims.First();
//            Assert.Equal("Rejected", updated.Status);
//        }
//        [Fact]
//        public void Test4_ProcessClaim()
//        {
//            var db = GetDbContext();
//            var claim = new Claim { ClaimID = 3, Status = "Approved" };
//            db.Claims.Add(claim);
//            db.SaveChanges();
//            int claimId = claim.ClaimID;
//            var env = new Mock<IWebHostEnvironment>().Object;
//            var controller = new ManagerController(db, env);
//            controller.VerifyClaim(3, "Process");

//            var updated = db.Claims.First();
//            Assert.Equal("Processed", updated.Status);
//        }
//     [Fact]
//     public void Test5_EncryptionandDecryption()
//        {
//            string original = "Sensitive Data";
//            string encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(original));
//            string decrypted = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encrypted));

//            // Assert Equals
//            Assert.Equal(original, decrypted);
//        }
//    }
//}

            
