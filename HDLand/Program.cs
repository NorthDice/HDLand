using HDLand.Application.Services;
using HDLand.Logic.Interfaces;

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

builder.Services.AddScoped<IMovieService, MovieService>();

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


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HDLand");
    c.RoutePrefix = string.Empty;
});

app.MapRazorPages();

app.MapControllers();

app.Run();
