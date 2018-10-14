using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Valor
    {
        public int Id { get; set; }
        public int ValorDiscreto { get; set; }

        public Valor() { }
        public Valor(int ValorDiscreto)
        {
            this.ValorDiscreto = ValorDiscreto;
        }
        public ValorDto toDTO()
        {
            ValorDto valorDto = new ValorDto(this.ValorDiscreto);
            return valorDto;
        }
        public static Valor fromDTO(ValorDto valorDto)
        {
            Valor valor = new Valor(valorDto.ValorDiscreto);
            return valor;
        }
        public override bool Equals(object obj)
        {
            var valor = obj as Valor;
            return valor != null && this.Id == valor.Id;
        }
    }
}
