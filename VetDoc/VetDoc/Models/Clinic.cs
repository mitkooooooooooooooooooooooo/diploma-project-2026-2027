using System.ComponentModel.DataAnnotations;

namespace VetDoc.Models
{
    public class Clinic
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        [Required, StringLength(50)]
        public string City { get; set; } = null!;

        [Required, StringLength(200)]
        public string Address { get; set; } = null!;

        [StringLength(20)]
        public string? Phone { get; set; }

        public List<Vet> Vets { get; set; } = new List<Vet>();
    }
}
