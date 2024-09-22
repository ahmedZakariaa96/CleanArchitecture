using Application.Handlers.LookupsFeature.Services;
using Application.Handlers.StudentFeature.Services;
using Application.Handlers.UserFeature.Services;
 
namespace Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddMediator();
            services.AddAutoMapper();
            services.AddHandleException();
            services.AddValidators();
 
            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
             services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IStudentService, StudentService>();


        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }

        private static void AddHandleException(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        }

      
    }
}
