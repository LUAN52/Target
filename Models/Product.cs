using System.Security.AccessControl;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefa.Models
{
    public class Product
    {
        
        public Product(string name, string Category, decimal price)
        {
            this.Name = name;
            this.Category = Category;
            this.Price = price;
            

        }

        public int Id { get; private set; }
        
        
        public string Name { get; set; }
        public string Category { get; set; }

        public decimal Price { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public Client Client {get;set;}

       
        
        
    }
}