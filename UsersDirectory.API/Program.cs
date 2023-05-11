using UsersDirectory.API;
using UsersDirectory.API.Mappings;
using UsersDirectory.API.Repository;
using UsersDirectory.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserProfile>();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IActiveDirectoryService, ActiveDirectoryService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<UserDbContext>();
        SeedData.Initialize(context);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
