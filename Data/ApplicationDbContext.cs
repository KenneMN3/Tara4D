using Biblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
   : base(options)
    {
    }
    public DbSet<LibrosModels> Libros { get; set; }
    public DbSet<AutoresModels> Autores { get; set; }
    public DbSet<EditorialesModels> Editoriales { get; set; }
    public DbSet<UsuariosModels> Usuarios { get; set; }
    public DbSet<PrestamosModels> Prestamos { get; set; }
   
}