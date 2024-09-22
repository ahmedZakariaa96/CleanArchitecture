


global using Application.Handlers.StudentFeature.Commends;
global using Application.Handlers.StudentFeature.Queries;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {


        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<StudentDTO>>>> GetAll(PaginatedRequest paginatedRquest)
        {
            return Single(await QueryAsync(new GetAllStudent(paginatedRquest.PageNumber, paginatedRquest.PageSize)));
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Result<StudentDTO>>> GetById(int Id)
        {
            return Single(await QueryAsync(new GetStudentById(Id)));
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Result<string>>> AddStudent(CreateStudent createStudent)
        {
            return Single(await CommandAsync(createStudent));
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Result<string>>> UpdateStudent(UpdateStudent updateStudent)
        {
            return Single(await CommandAsync(updateStudent));
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<Result<string>>> DeleteStudent(int id)
        {
            return Single(await CommandAsync(new DeleteStudent(id)));
        }
    }
}
