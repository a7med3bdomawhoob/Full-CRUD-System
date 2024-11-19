
using BLL.Interface;
using BLL.Repository;
using DAL.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using  PL.Helpers;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.AddDbContext<NamaaContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddSingleton<ErrorHandlingMiddleware>();
builder.Services.AddControllers();







builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>

        {
            builder.WithOrigins("http://localhost:4200", "http://localhost:64252", "http://localhost:62699", "http://192.168.10.6:8076","http://192.168.10.6:8077")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        }); 

    /*    options.AddPolicy("AllowAllOrigins",
         policy =>
         {
             policy.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
         });*/



});


builder.Services.AddTransient<EmailService>();
builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
builder.Services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
builder.Services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));
builder.Services.AddScoped(typeof(INewsRepository), typeof(NewsRepository));
builder.Services.AddScoped(typeof(ICareerRepository), typeof(CareerRepository));
builder.Services.AddScoped(typeof(IEquipmentsRepository), typeof(EquipmentsRepository));
/*builder.Services.AddScoped(typeof(IAreaRepository), typeof(AreaRepository));*/

builder.Services.AddScoped<IAreaRepository, AreaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseStaticFiles();


/*app.UseCors("AllowSpecificOrigins"); // Apply the CORS policy*/

app.UseCors("AllowAllOrigins");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}














app.UseHttpsRedirection();

app.UseAuthorization();





app.MapControllers();

app.Run();
