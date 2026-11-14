using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VetDoc.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = null!;

        [Required, StringLength(30)]
        public string Species { get; set; } = null!;

        [StringLength(50)]
        public string? Breed { get; set; }

        public int Age { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;
        public IdentityUser Owner { get; set; } = null!;

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
