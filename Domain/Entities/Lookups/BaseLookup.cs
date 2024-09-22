using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Lookups
{
    public abstract class BaseLookup
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string TitleEN { get; set; } = null!;
        [MaxLength(200)]
        public string TitleAR { get; set; } = null!;
        public bool IsActive { get; set; } = true;

    }
}