using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace prog_practice.Models
{
    public class ClaimHistory
    {
       

            [Key]
            public int HistoryID { get; set; }

            [ForeignKey("Claim")]
            public int ClaimID { get; set; }

            public string? Action { get; set; }
            public string? PerformedBy { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.Now;

            public Claim? Claim { get; set; }
        }
    }


