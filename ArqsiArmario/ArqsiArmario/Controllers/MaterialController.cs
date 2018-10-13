using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;
using ArqsiArmario.DTOs;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ArqsiContext _context;

        public MaterialController(ArqsiContext context)
        {
            _context = context;

            if (_context.Materiais.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Materiais.Add(new MaterialDto {});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<MaterialDto>> GetMateriais()
        {
            return _context.Materiais.ToList();
        }

        [HttpGet("{id}", Name = "GetMaterial")]
        public ActionResult<MaterialDto> GetMaterialById(int id)
        {
            var item = _context.Materiais.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(MaterialDto item)
        {
            _context.Materiais.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMaterial", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, MaterialDto item)
        {
            var todo = _context.Materiais.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nome = item.Nome;
            todo.Acabamento = item.Acabamento;
            todo.AcabamentoId = item.AcabamentoId;

            _context.Materiais.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Materiais.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Materiais.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
