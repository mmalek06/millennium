using Millennium.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>options.RespectBrowserAcceptHeader = true)
    .AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IThingRepository, ThingRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
