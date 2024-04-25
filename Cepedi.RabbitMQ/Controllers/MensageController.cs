using Cepedi.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.RabbitMQ.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenssageController : Controller
{
    private readonly IMessageProducer _messageProducer;

    public MenssageController(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Menssage Menssage = new Menssage
        {
            Id = 1,
            Value = 1000,
            Description = "Uma mensagem"
        };
        _messageProducer.SendMessage(Menssage);
        return Ok(Menssage);
    }

    [HttpPost]
    public IActionResult Post([FromQuery] int id, [FromQuery] decimal value, [FromQuery] string description)
    {
        Menssage menssage = new Menssage
        {
            Id = id,
            Value = value,
            Description = description
        };
        _messageProducer.SendMessage(menssage);
        return Ok(menssage);
    }
}

public class Menssage
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
}