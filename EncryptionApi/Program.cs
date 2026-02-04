var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- HÄR ÄR FIXEN ---
// Vi kör alltid Swagger, oavsett om det är Development eller Production
app.UseSwagger();
app.UseSwaggerUI();
// --------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();