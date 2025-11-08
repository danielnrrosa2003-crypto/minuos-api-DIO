
using minuos_api.Dominio.Enuns;

namespace minuos_api.DTOs;
public class AdministradorDTO
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public Perfil? Perfil { get; set; } = default!;
}