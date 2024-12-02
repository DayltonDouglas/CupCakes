
namespace HappyCakes.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int CupcakeId { get; set; }
        public int Quantidade { get; set; }
        public CupCake Cupcake { get; set; }
    }
}
