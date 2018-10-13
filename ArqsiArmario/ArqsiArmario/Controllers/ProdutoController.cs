using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.DTOs;
using ArqsiArmario.Models;
using System.Threading.Tasks;

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
                _context.Produtos.Add(new ProdutoDto {});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<ICollection<ProdutoDto>> GetProdutos()
        {
            return _context.Produtos.ToList(); ;

        }

        [HttpGet]
        public ICollection<ProdutoDto> GetProdutosIEnum()
        {
            return _context.Produtos.ToList();
        }





        [HttpGet("{id}", Name = "GetProdutoById")]
        public ActionResult<ProdutoDto> GetProdutoById(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("{nome}", Name = "GetProdutoByName")]
        public ActionResult<ProdutoDto> GetProdutoByName(String nome)
        {
            var item = _context.Produtos.Find(nome);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("{Produtos}", Name = "GetProdutoPartes")]
        public ActionResult<List<ProdutoDto>> GetProdutoPartes(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            List<ProdutoDto> P = (List<ProdutoDto>) item.Produtos;
            return P;
        }

        [HttpGet("{Produtos}", Name = "GetProdutoParteEM")]
        public ICollection<ProdutoDto> GetProdutosPai(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return null;
            }
            ICollection<ProdutoDto> resultado = new List<ProdutoDto>();
            
            foreach (ProdutoDto P in GetProdutosIEnum())
            {
                foreach (ProdutoDto P1 in P)
                {
                    if (P1.Id == item.Id)
                    {
                       resultado.Add(P);
                    }
                }
            }

            return resultado;
        }



        [HttpPost]
        public IActionResult Create(ProdutoDto item)
        {
            _context.Produtos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new
            {
                id = item.Id,
                nome = item.Nome,
                produtos = item.Produtos,
                material = item.Material,
                categoria = item.Categoria,
                categoriaID = item.Categoria
            }, item);
        }
        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto Produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var auxCategoria = CategoriaRepository.GetCategoriaByID(Produto.CategoriaId);
            Produto.Categoria = auxCategoria;
            var auxDimensao = DimensaoRepository.GetDimensoesByID(Produto.DimensaoId);
            Produto.Dimensao = auxDimensao;
            var auxMaterial = MaterialRepository.GetMaterialByID(Produto.MaterialId);
            Produto.Material = auxMaterial;
            foreach (int id in Produto.ProdutosId)
            {
                var aux = ProdutoRepository.GetProdutoByID(id);
                aux.Categoria = CategoriaRepository.GetCategoriaByID(aux.CategoriaId);
                aux.Dimensoes = DimensaoRepository.GetDimensoesByID(aux.DimensoesId);
                aux.Material = MaterialRepository.GetMaterialByID(aux.MaterialId);
                Produto.Produtos.Add(aux);

            }

            bool auxB = caber(Produto);

            if (auxB == true)
            {
                ProdutoRepository.InsertProduto(Produto);
                ProdutoRepository.Save();

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
        public IActionResult Update(int id, ProdutoDto item)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nome = item.Nome;
            todo.Material = item.Material;
            todo.Categoria = item.Categoria;
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