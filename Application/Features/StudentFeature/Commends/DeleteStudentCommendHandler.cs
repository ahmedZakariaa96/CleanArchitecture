 

namespace  Application.Handlers.StudentFeature.Commends
{
    public record DeleteStudent(int Id) : IRequest<Result<string>>;

    internal class DeleteStudentCommendHandler : IRequestHandler<DeleteStudent, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;


 
        private readonly IMapper mapper;

        public DeleteStudentCommendHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
 
        }
        public async Task<Result<string>> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            using (var trans = this.unitOfWork.Repository<Student>().BeginTransaction())
            {

                try
                {
                    var result = Result<string>.Info(null, StatusResult.Exist, "Exist");

                    var cureentStudent = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.StudId == request.Id).FirstOrDefaultAsync();
                    if (cureentStudent == null)
                    {
                        return Result<string>.Info(request.Id.ToString(), StatusResult.NotExists, "NotExists");
                    }
                    else
                    {
                        this.unitOfWork.Repository<Student>().Delete(cureentStudent);
                        result = await unitOfWork.CompleteAsync(cancellationToken) >= (int)StatusResult.Success ?
                                   Result<string>.Success(cureentStudent.StudId.ToString())
                                   : Result<string>.Falid(null);

                    }
                    return result;
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    return Result<string>.Falid(ex.Message.ToString());
                }
            }


        }
    }
}
