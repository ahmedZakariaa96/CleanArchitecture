

namespace Domain.Entities
{
    public class Student : GenericLocalizable
    {

        public int StudId { get; set; }
        public required string NameEn { get; set; }
        public required string? NameAr { get; set; }

        public required string? Phone { get; set; }
        public required string? Address { get; set; }
        public int? DepId { get; set; }
 




    }
}
