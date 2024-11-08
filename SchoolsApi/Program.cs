using SchoolApi.Core.Services.Interfaces;
using SchoolApi.Core.Services;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using SchoolApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ITeacherService, TeacherService>();
builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();


builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

builder.Services.AddSingleton<ISchoolService, SchoolService>();
builder.Services.AddSingleton<ISchoolRepository, SChoolRepository>();

builder.Services.AddSingleton<INoteService, NoteService>();
builder.Services.AddSingleton<INoteRepository, NoteRepository>();

builder.Services.AddSingleton<ICourseService, CourseService>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();



var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
