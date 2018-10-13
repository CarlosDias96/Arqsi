using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.DTOs;
using ArqsiArmario.Models;
using System.Threading.Tasks;
using ArqsiArmario.Repository;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ArqsiContext _context;
        private CategoriaRepository catrep;
        private DimensaoRepository dimrep;
        private MaterialRepository matrep;
        private ProdutoRepository prorep;

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

            catrep = new CategoriaRepository(_context);
            dimrep = new DimensaoRepository(_context);
            matrep = new MaterialRepository(_context);
            prorep = new ProdutoRepository(_context);
        }

        [HttpGet]
        public ActionResult<ICollection<Produto>> GetProdutos()
        {
            return _context.Produtos.ToList(); ;

        }

        [HttpGet]
        public ICollection<Produto> GetProdutosIEnum()
        {
            return _context.Produtos.ToList();
        }





        [HttpGet("{id}", Name = "GetProdutoById")]
        public ActionResult<Produto> GetProdutoById(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("{nome}", Name = "GetProdutoByName")]
        public ActionResult<Produto> GetProdutoByName(String nome)
        {
            var item = _context.Produtos.Find(nome);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("{Produtos}", Name = "GetProdutoPartes")]
        public ActionResult<List<Produto>> GetProdutoPartes(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            List<Produto> P = (List<Produto>) item.Produtos;
            return P;
        }

        [HttpGet("{Produtos}", Name = "GetProdutoParteEM")]
        public ICollection<Produto> GetProdutosPai(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return null;
            }
            ICollection<Produto> resultado = new List<Produto>();
            
            foreach (Produto P in GetProdutosIEnum())
            {
                foreach (Produto P1 in P.Produtos)
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
        public IActionResult Create(Produto item)
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

            Produto.Categoria = catrep.GetCategoriaByID(Produto.CategoriaId);
             
            var auxDimensao = dimrep.GetDimensoesByID(Produto.DimensaoId);
            Produto.Dimensao = auxDimensao;
            var auxMaterial = matrep.GetMaterialByID(Produto.MaterialId);
            Produto.Material = auxMaterial;
            foreach (int id in Produto.ProdutosId)
            {
                var aux = prorep.GetProdutoByID(id);
                aux.Categoria = catrep.GetCategoriaByID(aux.CategoriaId);
                aux.Dimensao = dimrep.GetDimensoesByID(aux.DimensaoId);
                aux.Material = matrep.GetMaterialByID(aux.MaterialId);
                Produto.Produtos.Add(aux);

            }

            bool auxB = caber(Produto);

            if (auxB == true)
            {
                prorep.InsertProduto(Produto);
                prorep.Save();

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
        public IActionResult Update(int id, Produto item)
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