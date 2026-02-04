var builder = WebApplication.CreateBuilder(args);

// LÄGG TILL DENNA RAD (ADD THIS LINE)
// Detta gör att .NET vet att vi använder Controllers
builder.Services.AddControllers();

// Lägg till Swagger om du vill ha det (bra för testning)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// LÄGG TILL DENNA RAD (ADD THIS LINE)
// Detta aktiverar routingen till din CipherController
app.MapControllers();

app.Run();