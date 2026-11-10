using System.ComponentModel.DataAnnotations;

namespace VetDoc.Models
{
    // A veterinary clinic in a city. One clinic has many vets.
    public class Clinic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Име на клиниката")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Град")]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(200)]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;

        [StringLength(20)]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        // All vets who work in this clinic
        public List<Vet> Vets { get; set; } = new List<Vet>();
    }
}
