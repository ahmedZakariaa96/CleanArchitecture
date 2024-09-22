using System.Security.Claims;

namespace Application.Handlers.UserFeature.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public string? UserId => getUserId();

        private string? getUserId()
        {
            var NameIdentifier = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();
            return NameIdentifier;
        }
    }
}
