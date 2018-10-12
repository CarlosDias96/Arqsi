using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ArqsiContext _context;

        public ProdutoController(ArqsiContext context)
        {
            _context = context;

            if (_context.Produtos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Produtos.Add(new Produto {});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Produto> GetProdutoById(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(Produto item)
        {
            _context.Produtos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Produto item)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nome = item.Nome;
            todo.Material = item.Material;
            todo.MaterialId = item.MaterialId;
            todo.Categoria = item.Categoria;
            todo.CategoriaId = item.CategoriaId;
            todo.Produtos = item.Produtos;

            _context.Produtos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}