using GoNet.BL;
using GoNet.BusinessLogic.Services;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.DataAccess;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.net
// регаем зависимости
builder.Services.AddScoped<IRoulette, Ruletka>();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<IRepositoryPlayer, Repository>();

// регаем базу
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DataContext)));
});

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

