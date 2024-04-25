using Cepedi.RabbitMQ;
using Cepedi.RabbitMQ.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMessageProducer, ProducerRabbitMQ>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", context => {
    context.Response.Redirect("/api/menssage");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();
