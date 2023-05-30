using AlAnonAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlAnonAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ApplicationUser> Miembros { get; set; }
        public DbSet<Informacion> Informacion { get; set; }
        public DbSet<Inicio> Inicio { get; set; }
        public DbSet<CalendarioEvento> CalendarioEventos { get; set; }
        public DbSet<Boletin> Boletin { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Invitacion> Invitaciones { get; set; }

    }
}