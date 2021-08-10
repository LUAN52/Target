using System.Security.AccessControl;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefa.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, string Category, decimal price, Client client)
        {
            this.Name = name;
            this.Category = Category;
            this.Price = price;
            this.Client = client;
            

        }

        public int Id { get; private set; }
        
        
        [Required(ErrorMessage =" campo nome é obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "campo categoria é obrigatorio")]
        public string Category { get; set; }

        [Required(ErrorMessage = "campo preço é obrigatorio")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public Client Client {get;set;}

       
        
        
    }
}