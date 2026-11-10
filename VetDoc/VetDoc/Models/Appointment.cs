using System.ComponentModel.DataAnnotations;

namespace VetDoc.Models
{
    // A booked 30-minute visit of a pet at a vet.
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Дата и час")]
        public DateTime StartTime { get; set; }

        [StringLength(300)]
        [Display(Name = "Причина за посещението")]
        public string? Reason { get; set; }

        // A cancelled appointment stays in the history, but the time becomes free again
        [Display(Name = "Отказан")]
        public bool IsCancelled { get; set; }

        public int VetId { get; set; }
        public Vet Vet { get; set; } = null!;

        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;
    }
}
