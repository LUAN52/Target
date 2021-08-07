using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Tarefa.Models
{
    public class Client : IdentityUser
    {

        public Client()

        {

        }
        public Client(string userName) : base(userName)
        {
            this.RegisterDate = DateTime.Today;
            this.Status = true;
            this.Products = new List<Product>();
        }

        public DateTime RegisterDate { get; private set; }

        public bool Status { get; set; }

        public List<Product> Products { get; set; }

    }
}