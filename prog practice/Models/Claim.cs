using System.ComponentModel.DataAnnotations;

namespace prog_practice.Models
{
    public class Claim
    {
       
            [Key]
            public int ClaimID { get; set; }

        [Required]
        public string? LecturerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }


        [Required]
            public string? Title { get; set; }

            [Required]
            public string? Month { get; set; }

            [Required]
            public string? Description { get; set; }

            [Required]
            public decimal HoursWorked { get; set; }

            [Required]
            public decimal HourlyRate { get; set; }

            public decimal Amount { get; set; }

            public string? Status { get; set; }

            public string? DocumentPath { get; set; }

            public DateTime DateSubmitted { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }


        public ICollection<ClaimHistory>? ClaimHistories { get; set; }
    }
    }
