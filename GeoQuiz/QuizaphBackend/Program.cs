using GeoQuizBackend.EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuizaphBackend.EntityFramework;
using QuizaphBackend.Services;

var builder = WebApplication.CreateBuilder(args);
  
// Authorization     
builder.Services.AddAuthorization();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Semantic Kernel Service
builder.Services.AddScoped<ISemanticKernelService, SemanticKernelService>();

// EF Core DbContext (InMemory for now)
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseInMemoryDatabase("TestDb")
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information);
});
var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
    DbInitializer.Seed(context);
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();