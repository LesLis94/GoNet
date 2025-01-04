using GoNet.BL;
using GoNet.BL.Services.Abstract.Interfaces;
using GoNet.DAL;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped <IRoulette, Ruletka>();


/* AddSingeton - пока наше приложение работает, будет возвращать один и тот же экземпляр
 * AddScoped - запрос - новый экземпляр
 * AddTransient - создает каждый раз экземпляр при обращении к нему
 */


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

