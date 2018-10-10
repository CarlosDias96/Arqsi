namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categoria CategoriaPai { get; set; }
    }
}