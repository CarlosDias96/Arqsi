using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensaoController : ControllerBase
    {
        private readonly ArqsiContext _context;

        public DimensaoController(ArqsiContext context)
        {
            _context = context;

            if (_context.Dimensoes.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Dimensoes.Add(new Dimensao { });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Dimensao>> GetDimensoes()
        {
            return _context.Dimensoes.ToList();
        }

        [HttpGet("{id}", Name = "GetDimensao")]
        public ActionResult<Dimensao> GetDimensaoByYd(int id)
        {
            var item = _context.Dimensoes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(Dimensao item)
        {
            _context.Dimensoes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetDimensoes", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Dimensao item)
        {
            var todo = _context.Dimensoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Altura = item.Altura;
            todo.Largura = item.Largura;
            todo.Profundidade = item.Profundidade;

            _context.Dimensoes.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Dimensoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Dimensoes.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}