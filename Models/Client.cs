using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "email é obrigatorio")]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Required(ErrorMessage ="nome é obigatorio")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Required(ErrorMessage ="nome é obigatorio")]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        public DateTime RegisterDate { get; private set; }

        public bool Status { get; set; }

        public List<Product> Products { get; set; }

    }
}