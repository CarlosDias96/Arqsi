namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Categoria
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Categoria CategoriaPai { get; set; }
    }
}