using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.DTOs;

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
        public Acabamento Acabamento{ get; set; }

        public MaterialAcabamentoDto toDTO()
        {
            MaterialAcabamentoDto MaterialAcabamentoDto = new MaterialAcabamentoDto(this.Material.toDTO(),this.Acabamento.toDTO());
            return MaterialAcabamentoDto;
        }
        public static MaterialAcabamento fromDTO(MaterialAcabamentoDto materialAcabamentoDto)
        {
            MaterialAcabamento materialAcabamento = new MaterialAcabamento(Material.fromDTO(materialAcabamentoDto.Material),Acabamento.fromDTO(materialAcabamentoDto.Acabamento));
            return materialAcabamento;
        }
        public override bool Equals(object obj)
        {
            var materialAcabamento = obj as MaterialAcabamento;
            return materialAcabamento != null && this.AcabamentoId==materialAcabamento.AcabamentoId && this.MaterialId==materialAcabamento.MaterialId;
        }
    }
}
