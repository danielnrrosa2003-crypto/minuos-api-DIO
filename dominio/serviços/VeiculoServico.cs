using minuos_api.Dominio.Entidades;
using minuos_api.infraestrutura.Db;
using minuos_api.Dominio.Interfaces;

namespace minuos_api.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Veiculos> Todos(int? pagina = 1, string? nome = null, string? marca = null)
{
    var query = _contexto.Veiculos.AsQueryable();

    if (!string.IsNullOrEmpty(nome))
        query = query.Where(v => v.Nome.Contains(nome));

    if (!string.IsNullOrEmpty(marca))
        query = query.Where(v => v.Marca.Contains(marca));

    int tamanhoPagina = 10;
    int paginaAtual = pagina ?? 1; // 👈 garante valor padrão

    return query
        .Skip((paginaAtual - 1) * tamanhoPagina)
        .Take(tamanhoPagina)
        .ToList();
}



        public Veiculos? BuscaPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculos veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
            
        }

        public void Atualizar(Veiculos veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
            
        }

        public void Apagar(Veiculos veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
            
        }
    }
}