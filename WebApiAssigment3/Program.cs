using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Context;
using WebApiAssigment3.Interface;
using WebApiAssigment3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IStudent, StudentService>();
builder.Services.AddScoped<ITeacher, TeacherService>();
builder.Services.AddScoped<IClasse,ClassService>();
builder.Services.AddScoped<ISubject, SubjectService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddDbContext<SchoolManagmentDBContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
