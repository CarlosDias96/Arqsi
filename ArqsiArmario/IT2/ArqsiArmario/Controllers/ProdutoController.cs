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
        private ArqsiContext context;
        private ICategoriaRepository repCategoria;
        private IDimensaoRepository repDimensao;
        private IProdutoMaterialRepository repMaterial;
        private IProdutoRepository repProduto;

        public ProdutoController(IProdutoRepository produtoRepository,IDimensaoRepository dimensaoRepository, IProdutoMaterialRepository produtoMaterialRepository,ICategoriaRepository categoriaRepository,ArqsiContext context)
        {
            this.context = context;
            this.repProduto = produtoRepository;
            this.repDimensao = dimensaoRepository;
            this.repMaterial = produtoMaterialRepository;
            this.repCategoria = categoriaRepository;
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

            Produto produto = repProduto.GetProdutoByID(id);

            if (produto == null)
            {
                return NotFound();
            }

            ProdutoDto produtoDto = new ProdutoDto();
            produtoDto.Nome = produto.Nome;
           
            return Ok(produtoDto);
        }


        // GET: api/Produto/?nome={nome}
        [HttpGet("nome={name}")]
        public IEnumerable<Produto> GetProdutosPorNome([FromRoute] string name)
        {
            var produto = context.Produtos.Include(p => p.Categoria).Include(p => p.ProdutosMateriais).Include(p => p.Produtos).Where(p => p.Nome.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            return produto;
        }


        [HttpGet("{id}/{Produtos}", Name = "GetProdutoPartes")]
        public async Task<ActionResult<List<ProdutoDto>>> GetProdutoPartes([FromRoute] int id)
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

            if (produto.Composto == false) { return Content("Não tem"); } else { 
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach (Produto p in produto.Produtos)
            {
                ListaP.Add(p.toDTO());
            }
                return ListaP;
            }
          
        }

        [HttpGet("{id}/Produtos={Produtos}", Name = "GetProdutoParteEM")]
        public async Task<ActionResult<ICollection<Produto>>> GetProdutosPai([FromRoute] int id)
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

        
            if (Produto.Produtos == null)
            {
                Produto.Composto = false;
            }
            else
            {
                Produto.Composto = true;
            }
            if (Produto.Composto == true) { 
            foreach (int id in Produto.ProdutosId)
            {
                var aux = repProduto.GetProdutoByID(id);
                Produto.Produtos.Add(aux);

            }
            }
            Produto.Categoria = repCategoria.GetCategoriaByID(Produto.CategoriaId);
            //Produto.Dimensao = repDimensao.GetDimensoesByID(Produto.DimensaoId);
           // Produto.ProdutosMateriais.Add(repMaterial.GetMaterialByProduto(Produto));

            //bool auxB = caber(Produto);

            //if (auxB == true)
            //{
                repProduto.InsertProduto(Produto);
                repProduto.Save();

            //}
            //else
            //{

            //return Content("Não Cabe!!");
            //}




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


            var temp = repProduto.GetProdutos().Where<Produto>(a => a.Id == id);

            Produto aux = temp.First<Produto>();
            aux.Nome = item.Nome;
             aux.Dimensao = item.Dimensao;
            aux.Categoria = item.Categoria;
            List<ProdutoMaterialDto> ListaPm = new List<ProdutoMaterialDto>();
       /*     foreach (ProdutoMaterial pm in aux.ProdutosMateriais)
            {
                ListaPm.Add(pm.toDTO());
            }
            List<ProdutoDto> ListaP = new List<ProdutoDto>();
            foreach (Produto p in aux.Produtos)
            {
                ListaP.Add(p.toDTO());
            }*/
            
            try
            {
                repProduto.UpdateProduto(aux);
                repProduto.Save();
                return NoContent();
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