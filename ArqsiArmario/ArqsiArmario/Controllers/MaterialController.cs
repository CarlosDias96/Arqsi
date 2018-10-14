using System;
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
    public class MaterialController : ControllerBase
    {
        private IMaterialRepository repmaterial;

        public MaterialController(IMaterialRepository materialRepository)
        {
            this.repmaterial = materialRepository;
        }

        [HttpGet]
        public IEnumerable<MaterialDto> GetMaterials()
        {
            IEnumerable<MaterialDto> ListaMateriasDto = Enumerable.Empty<MaterialDto>();
            MaterialDto aux = new MaterialDto();
            foreach (Material material in repmaterial.GetMateriais())
            {
                aux = new MaterialDto();
                aux.Nome = material.Nome;
                ListaMateriasDto = ListaMateriasDto.Concat(new[] { aux });
            }
            return ListaMateriasDto;
        }

        // GET: api/Material/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = repmaterial.GetMaterialByID(id);

            if (material == null)
            {
                return NotFound();
            }

            MaterialDto materialDto = new MaterialDto();
            materialDto.Nome = material.Nome;

            return Ok(materialDto);
        }

        // PUT: api/Material/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial([FromRoute] int id, [FromBody] Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.Id)
            {
                return BadRequest();
            }

            repmaterial.UpdateMaterial(material);

            try
            {
                repmaterial.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Material
        [HttpPost]
        public async Task<IActionResult> PostMaterial([FromBody] Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repmaterial.InsertMaterial(material);
            repmaterial.Save();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Material/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = repmaterial.GetMaterialByID(id);
            if (material == null)
            {
                return NotFound();
            }

            repmaterial.DeleteMaterial(id);
            repmaterial.Save();

            return Ok(material);
        }

        private bool MaterialExists(int id)
        {
            return repmaterial.GetMateriais().Any(e => e.Id == id);
        }
    }
}
