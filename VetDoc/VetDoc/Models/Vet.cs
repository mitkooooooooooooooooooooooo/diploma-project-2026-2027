using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VetDoc.Models
{
    // A vet works in one clinic and has many appointments.
    public class Vet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Специалност")]
        public string Specialty { get; set; } = null!;

        // Which animals the vet treats, e.g. "Кучета, Котки"
        [Required]
        [StringLength(100)]
        [Display(Name = "Видове животни")]
        public string AnimalTypes { get; set; } = null!;

        // Working hours (same every working day). Used to build the free slots.
        [Display(Name = "Начало на работа")]
        public TimeSpan WorkStart { get; set; }

        [Display(Name = "Край на работа")]
        public TimeSpan WorkEnd { get; set; }

        // The clinic where the vet works
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        // The login account of the vet (empty until the admin links one)
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
