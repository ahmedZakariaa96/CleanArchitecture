 


namespace Application.Handlers.StudentFeature.Commends
{
    public class CreateStudent : IRequest<Result<string>>, IMapFrom<Student>
    {
        public string NameEn { get; set; }
        public string? NameAr { get; set; }


        public string Phone { get; set; }

        public string Address { get; set; }
        public int? DepartmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, CreateStudent>()
                .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepId))
                .ReverseMap();
        }
    }
    internal class CreateStudentCommendHandler : IRequestHandler<CreateStudent, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;



        private readonly IMapper mapper;

        public CreateStudentCommendHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
         }

 
        public async Task<Result<string>> Handle(CreateStudent request, CancellationToken cancellationToken)
        {

            var result = Result<string>.Info(null, StatusResult.Exist, "Exist");

            var cureentStudent = await this.unitOfWork.Repository<Student>()
                .FindByCondition(x => x.NameEn.ToLower() == request.NameEn.ToLower()).FirstOrDefaultAsync();
            if (cureentStudent != null)
            {
                return Result<string>.Info(cureentStudent.StudId.ToString(), StatusResult.Exist, "Exist");
            }
            else
            {

                var newStudent = mapper.Map<Student>(request);
                this.unitOfWork.Repository<Student>().Create(newStudent);
                result = await unitOfWork.CompleteAsync(cancellationToken) >= (int)StatusResult.Success ?
                    Result<string>.Success(newStudent.StudId.ToString())
                    : Result<string>.Falid(null);

            }
            return result;

        }
    }
}
