using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroUGB232.Models;

namespace SistemaFinanceiroUGB232.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options) { }
        public DbSet<Instituicao> Instituicoes { get; set; }

    }
}
