using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuParvaldnieksDB
{
    public class UzvevumiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = ConfigurationManager.ConnectionStrings["UzdevumuCon"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Uzdevums> Uzdevumi { get; set; }
    }

}
