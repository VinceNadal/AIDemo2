using API.Data;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add the repository as a scoped
builder.Services.AddScoped<JsonFileService>();

// Add the JsonFileRepository as a scoped
builder.Services.AddScoped<JsonFileRepository>();

// add automapper as a scoped
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
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

// add a CORS policy to accept http requests from localhost:3000
app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();


