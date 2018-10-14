using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.DTOs;
using ArqsiArmario.Models;
using System.Threading.Tasks;
using ArqsiArmario.Repository;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
    
        private ICategoriaRepository repCategoria;
        private IDimensaoRepository repDimensao;
        private IProdutoMaterialRepository repMaterial;
        private IProdutoRepository repProduto;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.repProduto = produtoRepository;
        }

        [HttpGet]
        public IEnumerable<ProdutoDto> GetProdutos()
        {
            IEnumerable<ProdutoDto> ListaProdutosDTO = Enumerable.Empty<ProdutoDto>();
            ProdutoDto aux = new ProdutoDto();
            foreach (Produto produto in repProduto.GetProdutos())
            {
                aux = new ProdutoDto();
                aux.Nome = produto.Nome;
                ListaProdutosDTO = ListaProdutosDTO.Concat(new[] { aux });
            }
            return ListaProdutosDTO;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByID(id);

            if (produto == null)
            {
                return NotFound();
            }

            ProdutoDto produtoDto = new ProdutoDto();
            produtoDto.Nome = produto.Nome;
            produtoDto.Categoria = produto.Categoria.toDTO();
            produtoDto.Composto = produto.Composto;
            produtoDto.Dimensao = produto.Dimensao.toDTO();
            List<ProdutoMaterialDto> ListaPm = new List<ProdutoMaterialDto>();
            foreach (ProdutoMaterial pm in produto.ProdutosMateriais)
            {
                ListaPm.Add(pm.toDTO());
            }
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach(Produto p in produto.Produtos)
            {
                ListaP.Add(p.toDTO());
            }
            return Ok(produtoDto);
        }

        [HttpGet("{nome}", Name = "GetProdutoByName")]
        public async Task<IActionResult> GetProdutoByName(String nome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByNome(nome);

            if (produto == null)
            {
                return NotFound();
            }

            ProdutoDto produtoDto = new ProdutoDto();
            produtoDto.Nome = produto.Nome;
            produtoDto.Categoria = produto.Categoria.toDTO();
            produtoDto.Composto = produto.Composto;
            produtoDto.Dimensao = produto.Dimensao.toDTO();
            List<ProdutoMaterialDto> ListaPm = new List<ProdutoMaterialDto>();
            foreach (ProdutoMaterial pm in produto.ProdutosMateriais)
            {
                ListaPm.Add(pm.toDTO());
            }
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach (Produto p in produto.Produtos)
            {
                ListaP.Add(p.toDTO());
            }
            return Ok(produtoDto);
        }

        [HttpGet("{Produtos}", Name = "GetProdutoPartes")]
        public async Task<ActionResult<List<ProdutoDto>>> GetProdutoPartes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByID(id);

            if (produto == null)
            {
                return NotFound();
            }

            
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach (Produto p in produto.Produtos)
            {
                ListaP.Add(p.toDTO());
            }
            return ListaP;
        }

        [HttpGet("{Produtos}", Name = "GetProdutoParteEM")]
        public async Task<ActionResult<ICollection<Produto>>> GetProdutosPai(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByID(id);

            if (produto == null)
            {
                return NotFound();
            }
            List<Produto> resultado = new List<Produto>();
            
            foreach (Produto P in repProduto.GetProdutos())
            {
                foreach (Produto P1 in P.Produtos)
                {
                    if (P1.Id == produto.Id)
                    {
                       resultado.Add(P);
                    }
                }
            }

            return resultado;
        }

                     
        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto Produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto.Categoria = repCategoria.GetCategoriaByID(Produto.Categoria.Id);
             
            var auxDimensao = repDimensao.GetDimensoesByID(Produto.Dimensao.Id);
            Produto.Dimensao = auxDimensao;
            var auxMaterial = repMaterial.GetMaterialByProduto(Produto);
            Produto.ProdutosMateriais.Add(auxMaterial);
            foreach (int id in Produto.ProdutosId)
            {
                var aux = repProduto.GetProdutoByID(id);
                aux.Categoria = repCategoria.GetCategoriaByID(aux.Categoria.Id);
                aux.Dimensao = repDimensao.GetDimensoesByID(aux.Dimensao.Id);
                aux.ProdutosMateriais.Add(repMaterial.GetMaterialByProduto(Produto));
                Produto.Produtos.Add(aux);

            }

            bool auxB = caber(Produto);

            if (auxB == true)
            {
                repProduto.InsertProduto(Produto);
                repProduto.Save();

            }
            else
            {

                return Content("Não Cabe!!");
            }




            return CreatedAtAction("GetProduto", new { id = Produto.Id }, Produto);
        }
        private bool caber(Produto Produto)
        {
            bool auxB = true;
            foreach (Produto aux in Produto.Produtos)
            {
                if (aux.Dimensao.Altura.AlturaMin <= Produto.Dimensao.Altura.AlturaMin && aux.Dimensao.Largura.AlturaMin <= Produto.Dimensao.Largura.AlturaMin)
                {
                    auxB = true;
                }
                else
                {
                    auxB = false;
                }
            }
            return auxB;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByID(id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = item.Nome;
            produto.Composto = item.Composto;
            produto.Dimensao = item.Dimensao;
            produto.Categoria = item.Categoria;
            List<ProdutoMaterialDto> ListaPm = new List<ProdutoMaterialDto>();
            foreach (ProdutoMaterial pm in produto.ProdutosMateriais)
            {
                ListaPm.Add(pm.toDTO());
            }
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach (Produto p in produto.Produtos)
            {
                ListaP.Add(p.toDTO());
            }
            repProduto.UpdateProduto(produto);
            try
            {
                repProduto.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = repProduto.GetProdutoByID(id);
            if (produto == null)
            {
                return NotFound();
            }

            repProduto.DeleteProduto(id);
            repProduto.Save();

            return Ok(produto);
        }
        private bool ProdutoExists(int id)
        {
            return repProduto.GetProdutos().Any(e => e.Id == id);
        }
    }
}