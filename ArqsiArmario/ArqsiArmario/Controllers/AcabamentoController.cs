using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;
using ArqsiArmario.DTOs;
using ArqsiArmario.Repository;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcabamentoController : ControllerBase
    {
        private readonly ArqsiContext _context;
        private AcabamentoRepository repacabamento;

        public AcabamentoController(ArqsiContext context)
        {

            _context = context; 
            if (_context.Acabamentos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Acabamentos.Add(new AcabamentoDto {});
                _context.SaveChanges();
            }


            this.repacabamento = new AcabamentoRepository(_context);
        }

        [HttpGet]
        public ActionResult<List<AcabamentoDto>> GetAcabamentos()
        {
            return _context.Acabamentos.ToList();
        }

        [HttpGet("{id}", Name = "GetAcabamento")]
        public ActionResult<AcabamentoDto> GetAcabamentoById(int id)
        {
            var item = _context.Acabamentos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(AcabamentoDto item)
        {
            _context.Acabamentos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAcabamento", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, AcabamentoDto item)
        {
            var todo = _context.Acabamentos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nome = item.Nome;
          
            _context.Acabamentos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Acabamentos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Acabamentos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}