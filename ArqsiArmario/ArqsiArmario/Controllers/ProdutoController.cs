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
                _context.Produtos.Add(new Produto { Nome = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return _context.Produtos.ToList();

        }

        [HttpGet]
        public IEnumerable<Produto> GetProdutosIEnum()
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

        [HttpGet("{Produtos}", Name = "GetProdutoParts")]
        public ActionResult<List<Produto>> GetProdutoParts(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            List<Produto> P = (List<Produto>) item.Produtos;
            return P;
        }

        //[HttpGet("{Produtos}", Name = "GetProdutoParteEM")]
        //public ActionResult<List<Produto>> GetProdutosPai(int id)
        //{
        //    var item = _context.Produtos.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    ActionResult<List<Produto>> resultado;
        //    //ActionResult<List<Produto>> todos = GetProdutos();
        //    //foreach (ActionResult<List<Produto>> A in todos)
        //    //{

        //    //}


        //    //IEnumerable<List<Produto>> copia = GetProdutos();
        //    foreach (ActionResult<List<Produto>> P in (IEnumerable<List<Produto>>)todos)
        //    {
        //        foreach (Produto P1 in P.getProdutos())
        //        {
        //            if (P1.getId() == item.getId())
        //            {
        //                resultado.add(P);
        //            }
        //        }
        //    }

        //    return resultado;
        //}

        [HttpGet("{Produtos}", Name = "GetProdutoParteEM")]
        public ActionResult<List<Produto>> GetProdutosPai(int id)
        {
            var item = _context.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            List<Produto> resultado = null;
            IEnumerable<Produto> todos = GetProdutosIEnum();


            foreach (IEnumerable<Produto> P in todos)
            {
                foreach (Produto P1 in P)
                {
                    if (P1.Id == item.Id)
                    {
                        //resultado.Add(P);  ainda sem solução
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