

namespace Application.DTO
{
    public class StudentDTO : IMapFrom<Student>
    {
        public int StudId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
 
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDTO>()
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localizable(src.NameEn, src.NameAr)));

        }


    }
}
