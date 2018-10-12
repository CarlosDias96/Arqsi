using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Material
    {
      
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Acabamento> Acabamentos { get; set; }

        public int AcabamentoId { get; set; }
        public Material() { }
        public Material(string Nome, List<Acabamento> Acabamentos)
        {
            this.Nome = Nome;
            this.Acabamentos = Acabamentos;
        }

    }
}