 
namespace Application.Handlers.StudentFeature.Commends
{
    public class UpdateStudent : IRequest<Result<string>>, IMapFrom<Student>
    {
        public int Id { get; set; }

        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public int? DepartmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, UpdateStudent>()
                .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepId))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudId))
                .ReverseMap();
        }
    }
    internal class UpdateStudentCommendHandler : IRequestHandler<UpdateStudent, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;



        private readonly IMapper mapper;

        public UpdateStudentCommendHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
         }

 
        public async Task<Result<string>> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.Exist, "Exists");

            var checkStudent = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.StudId == request.Id).AnyAsync();
            if (checkStudent == false)
            {
                return Result<string>.Info(request.Id.ToString(), StatusResult.NotExists, "NotExists");
            }
            else
            {
                var currentStudent = mapper.Map<Student>(request);
                this.unitOfWork.Repository<Student>().Update(currentStudent);
                result = await unitOfWork.CompleteAsync(cancellationToken) >= (int)StatusResult.Success ?
         Result<string>.Success(currentStudent.StudId.ToString())
         : Result<string>.Falid(null);
            }
            return result;

        }
    }
}
