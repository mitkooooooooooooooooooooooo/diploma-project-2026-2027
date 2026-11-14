using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VetDoc.Models
{
    public class Vet
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required, StringLength(50)]
        public string Specialty { get; set; } = null!;

        [Required, StringLength(100)]
        public string AnimalTypes { get; set; } = null!;

        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
