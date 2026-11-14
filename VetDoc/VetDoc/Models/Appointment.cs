using System.ComponentModel.DataAnnotations;

namespace VetDoc.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        [StringLength(300)]
        public string? Reason { get; set; }

        public bool IsCancelled { get; set; }

        public int VetId { get; set; }
        public Vet Vet { get; set; } = null!;

        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;
    }
}
