
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace minuos_api.DTOs;
public record VeiculoDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;        
        
        public string Nome { get; set; } = default!;

        public string Marca { get; set; } = default!;
    
    
        public int Ano { get; set; } = default!;
}