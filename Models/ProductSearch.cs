using System.ComponentModel.DataAnnotations;

namespace Tarefa.Models
{
    public class ProductSearch
    {
        
        [Required(ErrorMessage = "Digite um termo para buscar")]
        public string SearchText { get; set; }

        public string SearchType{ get; set; }
        
        
    }
}