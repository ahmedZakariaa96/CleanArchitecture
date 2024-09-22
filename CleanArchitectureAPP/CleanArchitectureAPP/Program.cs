using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection
builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddDomainDependencies(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
#endregion


#region MSAL
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddMicrosoftIdentityWebApi(options =>
                   {
                       builder.Configuration.Bind("AzureAd", options);
                       options.Events = new JwtBearerEvents();
                   }, options => { builder.Configuration.Bind("AzureAd", options); })
                    .EnableTokenAcquisitionToCallDownstreamApi(options => builder.Configuration.Bind("AzureAd", options))
                    .AddInMemoryTokenCaches();
#endregion

#region CORS



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins(
                    "https://127.0.0.1:4200",
                    "http://localhost:4200",
                    "https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
});
#endregion

#region Swagger Config
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MoESchoolsAuditAPP API",
        Version = "v1"
    });




});
#endregion

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    #region Automatic Migrations Applying & Seeding Default Users And Roles -- Seeding Cancelled
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

        db.Database.Migrate();
        //await DBSeed.SeedUsers(userManager, roleManager, app.Services);
    }
    #endregion

    app.UseSwagger();
    app.UseSwaggerUI();
}

//Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

#region CORS
app.UseCors(MyAllowSpecificOrigins);
#endregion

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();