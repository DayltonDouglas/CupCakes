using Microsoft.AspNetCore.Identity;

namespace HappyCakes.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
