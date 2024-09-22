

using Application.Handlers.StudentFeature.Services;

namespace Application.Handlers.StudentFeature.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> IsNameExist(string stdName)
        {
            var haveRecord = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.NameEn == stdName).AnyAsync();
            return haveRecord;
        }
        public async Task<bool> IsNameExist(string stdName, int StudId)
        {
            var haveRecord = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.NameEn == stdName && x.StudId != StudId).AnyAsync();
            return haveRecord;
        }
    }
}
