using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Context _context;
        public HomeController(Context context)
            => _context = context;


        [HttpGet]
        [Route("/")]
        public IActionResult Get()
            => Ok(_context.Todos.ToList());


        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound(new { Error = "Esse registro não existe" });

            return Ok(todo);
        }

        [HttpPost]
        [Route("/")]
        public IActionResult Post(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();

                return Created($"/{todo.Id}",todo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Não foi possível salvar o registro", ex.Message });
            }
        }

        [HttpPut]
        [Route("/{id}")]
        public IActionResult Put(Todo todo, int id)
        {
            var model = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound(new { Error = "Esse registro não existe" });
            try
            {
                model.Title = todo.Title;
                model.Done = todo.Done;

                _context.Todos.Update(model);
                _context.SaveChanges();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Não foi possível atualizar o registro", ex.Message });
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound(new { Error = "Esse registro não existe" });
            try
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = "Não foi possível excluir o registro", ex.Message});
            }
        }
    }
}