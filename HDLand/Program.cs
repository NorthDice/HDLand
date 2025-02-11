using HDLand.Application.Services;
using HDLand.Logic.Interfaces;
using HDLand.Logic.Interfaces.JWT;
using HDLand.Logic.Models;
using HDLand.Logic.Models.Connection;
using HDLand.Logic.Models.JWT;
using HDLand.Logic.Models.Password;
using HDLand.Persistance.Data;
using HDLand.Persistance.Mapper;
using HDLand.Persistance.Repositories;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5174")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<UserService>();

string? connection = builder.Configuration.GetConnectionString(ConnectionString.connectionString)
    ?? throw new InvalidOperationException($"Connection string {ConnectionString.connectionString} is missing.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connection));


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions)));



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.UseSwagger();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});



app.UseAuthorization();
app.UseAuthentication();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HDLand");
    c.RoutePrefix = string.Empty;
});

app.MapRazorPages();

app.MapControllers();

app.Run();
