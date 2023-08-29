using AtividadeAPI1.API.Model;
using AtividadeAPI1.Data;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeAPI1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("/")]

        public List<TaskModel> Get(
          [FromServices] AppDbContext context) => context.Tasks.ToList();

        [HttpPost("/")]
        public TaskModel Post ([FromBody] TaskModel model,
            [FromServices] AppDbContext context)
        {
            context.Tasks!.Add(model);
            context.SaveChanges();
            return model;
        }
    
        }
    }

