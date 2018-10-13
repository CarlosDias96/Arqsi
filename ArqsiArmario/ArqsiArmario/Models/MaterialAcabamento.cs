using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.Models
{
    public class MaterialAcabamento
    {
        public MaterialAcabamento(Material Material, Acabamento Acabamento)
        {
            this.Material = Material;
            this.Acabamento = Acabamento;
        }
        public MaterialAcabamento() { }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }

        public int? AcabamentoId { get; set; }
        public Acabamento Acabamento{ get;set }
    }
}
