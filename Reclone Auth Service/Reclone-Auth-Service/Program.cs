var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("UserMicroservice", client =>
{
    client.BaseAddress = new Uri("http://localhost:43090"); // Replace with the base address of Microservice1
});

builder.Services.AddHttpClient("SearchMicroservice", client =>
{
    client.BaseAddress = new Uri(""); // Replace with the base address of Microservice2
});


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
