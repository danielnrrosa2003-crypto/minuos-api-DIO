using Dm.util;
using Microsoft.EntityFrameworkCore;
using minuos_api.Dominio.Entidades;
namespace minuos_api.infraestrutura.Db;

public class DbContexto : DbContext
{

    private readonly IConfiguration _configuracaoAppSettings;

    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    
    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculos> Veiculos { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("MySql")?.toString();
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(stringConexao,
                ServerVersion.AutoDetect(stringConexao));

            }
        }
    }
}