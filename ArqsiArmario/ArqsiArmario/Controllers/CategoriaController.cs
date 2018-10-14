using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;
using ArqsiArmario.DTOs;
using ArqsiArmario.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository repcategoria;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.repcategoria = categoriaRepository;
        }

        [HttpGet]
        public IEnumerable<CategoriaDto> GetCategorias()
        {
            IEnumerable<CategoriaDto> ListaCategoriasDto = Enumerable.Empty<CategoriaDto>();
            CategoriaDto aux = new CategoriaDto();
            foreach (Categoria categoria in repcategoria.GetCategorias())
            {
                aux = new CategoriaDto();
                aux.Nome = categoria.Nome;
                ListaCategoriasDto = ListaCategoriasDto.Concat(new[] { aux });
            }
            return ListaCategoriasDto;
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<IActionResult> GetCategoriaById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = repcategoria.GetCategoriaByID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            CategoriaDto categoriaDto = new CategoriaDto();
            categoriaDto.Nome = categoria.Nome;

            return Ok(categoriaDto);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            repcategoria.UpdateCategoria(categoria);

            try
            {
                repcategoria.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repcategoria.InsertCategoria(categoria);
            repcategoria.Save();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);

        }
        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = repcategoria.GetCategoriaByID(id);
            if (categoria == null)
            {
                return NotFound();
            }

            repcategoria.DeleteCategoria(id);
            repcategoria.Save();

            return Ok(categoria);
        }

        private bool CategoriaExists(int id)
        {
            return repcategoria.GetCategorias().Any(e => e.Id == id);
        }
    }
}


