using minuos_api.DTOs;
using minuos_api.Dominio.Entidades;

namespace minuos_api.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculos> Todos(int? pagina = 1, string? nome = null, string? marca = null);
        Veiculos? BuscaPorId(int id);

        void Incluir(Veiculos veiculo);
        void Atualizar(Veiculos veiculo);
        void Apagar(Veiculos veiculo);
    }
}

