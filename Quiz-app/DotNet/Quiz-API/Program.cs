using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuizDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("defaultcon")));

builder.Services.AddCors((corsOptions) =>
{
	corsOptions.AddPolicy("Mypolicy", (policyoption) =>
	{
		policyoption.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("Mypolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
