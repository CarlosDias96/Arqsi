using System.Collections.Generic;
namespace ArqsiArmario.DTOs
{
    public class AcabamentoDto
    {
        public AcabamentoDto() { }

        public AcabamentoDto(string Nome)
        {
            this.Nome = Nome;
        }
       
        public string Nome { get; set; }
        public int Id { get; set; }
    }
}