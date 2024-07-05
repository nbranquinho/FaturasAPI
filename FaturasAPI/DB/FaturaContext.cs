using FaturasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaturasAPI.DB
{
    /// <summary>
    /// Context for the FaturasItem
    /// </summary>
    public class FaturaContext : DbContext
    {
        public FaturaContext(DbContextOptions<FaturaContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    /*modelBuilder.Entity<FaturaItem>()
        //        .HasIndex(f => new { f.G_IdentificacaoUnicaDocumento, f.F_DataDocumento });*/
        //}


        public DbSet<FaturaItem> FaturaItems { get; set; } = null!;
    }
}