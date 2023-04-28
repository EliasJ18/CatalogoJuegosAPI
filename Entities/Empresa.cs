using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CatalogoJuegos.Entities
{
    public class Empresa
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
