using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Material
    {
      
        public int Id { get; set; }

        public string Nome { get; set; }

        public Acabamento Acabamento { get; set; }

        public int? AcabamentoId { get; set; }
        public Material() { }
        public Material(string Nome, Acabamento Acabamento)
        {
            this.Nome = Nome;
            this.Acabamento = Acabamento;
        }

    }
}