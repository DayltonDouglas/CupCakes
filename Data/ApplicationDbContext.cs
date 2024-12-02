using HappyCakes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HappyCakes.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CupCake> CupCakes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }
    }
}
