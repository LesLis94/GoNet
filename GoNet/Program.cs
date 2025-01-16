using GoNet.BL;
using GoNet.BusinessLogic;
using GoNet.BusinessLogic.Services;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.DataAccess;
using GoNet.Middlewares;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.net
// регаем зависимости
builder.Services.AddScoped<IRoulette, Ruletka>();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<IRepositoryPlayer, RepositoryPlayer>();
builder.Services.AddScoped<IThingsPlayersService, ThingsPlayersService>();
builder.Services.AddScoped<IRepositoryThingPlayer, RepositoryThingPlayer>();
builder.Services.AddScoped<IBank, Bank>();

// регаем базу
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DataContext)));
}); 
//builder.Services.AddDbContext<DataContext>();

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

// подключаем слушатель ошибок
app.UseMiddleware<ExeptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

