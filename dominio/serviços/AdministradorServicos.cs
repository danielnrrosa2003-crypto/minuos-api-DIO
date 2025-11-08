using minuos_api.Dominio.Entidades;
using minuos_api.DTOs;
using minuos_api.infraestrutura.Db;
using minuos_api.Dominio.Interfaces;


namespace minuos_api.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }


        public Administrador? Login(LoginDTO loginDTO)
{
    return _contexto.Administradores
        .FirstOrDefault(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
}

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

    int tamanhoPagina = 10;
    int paginaAtual = pagina ?? 1; 

    return query
        .Skip((paginaAtual - 1) * tamanhoPagina)
        .Take(tamanhoPagina)
        .ToList();
        }

    }
}
