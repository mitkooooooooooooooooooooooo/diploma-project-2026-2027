using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VetDoc.Models
{
    // A pet that belongs to one owner (a registered user).
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string Name { get; set; } = null!;

        // Type of animal, e.g. "Куче", "Котка"
        [Required]
        [StringLength(30)]
        [Display(Name = "Вид")]
        public string Species { get; set; } = null!;

        [StringLength(50)]
        [Display(Name = "Порода")]
        public string? Breed { get; set; }

        [Range(0, 50)]
        [Display(Name = "Възраст (години)")]
        public int Age { get; set; }

        // The owner of the pet
        [Required]
        public string OwnerId { get; set; } = null!;
        public IdentityUser Owner { get; set; } = null!;

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
