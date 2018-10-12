using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ArqsiContext _context;

        public CategoriaController(ArqsiContext context)
        {
            _context = context;

            if (_context.Categorias.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Categorias.Add(new Categoria {});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> GetCategoriaById(int id)
        {
            var item = _context.Categorias.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(Categoria item)
        {
            _context.Categorias.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategorias", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Categoria item)
        {
            var todo = _context.Categorias.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nome = item.Nome;
           

            _context.Categorias.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Categorias.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

