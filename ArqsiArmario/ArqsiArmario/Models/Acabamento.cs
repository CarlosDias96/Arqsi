using System.Collections.Generic;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Acabamento
    {



        public int Id { get; set; }
        public string Nome { get; set; }
        
        public Acabamento(string Nome) { this.Nome = Nome; }
        public Acabamento()
        {
        }

        public AcabamentoDto toDTO()
        {
            AcabamentoDto acabamentoDto = new AcabamentoDto(this.Nome);
            return acabamentoDto;
        }
        public static Acabamento fromDTO(AcabamentoDto acabamentoDto)
        {
            Acabamento acabamento = new Acabamento(acabamentoDto.Nome);
            return acabamento;
        }
        public override bool Equals(object obj)
        {
            var acabamento = obj as Acabamento;
            return acabamento != null && this.Id == acabamento.Id && EqualityComparer<string>.Default.Equals(Nome, acabamento.Nome);
        }
    }
}