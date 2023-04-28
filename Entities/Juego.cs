using System.ComponentModel.DataAnnotations;

namespace CatalogoJuegos.Entities
{
    public class Juego
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string Languages { get; set; }
        [Required]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        
    }
}
