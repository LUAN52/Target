using System.ComponentModel.DataAnnotations;

namespace Tarefa.Models
{
    public class ProductSearch
    {
        
        [Required(ErrorMessage = "Digite um termo para buscar")]
        public string SearchText { get; set; }

        [Required(ErrorMessage = "Selecione um tipo de busca")]
        public string SearchType{ get; set; }
        
        
    }
}