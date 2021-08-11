using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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

        [Remote("EmailValidation","Home",ErrorMessage = "email já existe")]
        [EmailAddress(ErrorMessage ="ensira um email válido")]
        [Required(ErrorMessage = "email é obrigatorio")]
        public override string Email { get => base.Email; set => base.Email = value; }

        
        [StringLength(30, MinimumLength = 4, ErrorMessage = "nome deve conter no minimo 4 caracteres")]
        [Remote("NameValidation","Home",ErrorMessage ="usuário já existe")]
        [Required(ErrorMessage ="nome é obigatorio")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        
        [StringLength(256,MinimumLength =6,  ErrorMessage = "dever ao minimo 6 carateres")]
        public override string PasswordHash {get=>base.PasswordHash;set=>base.PasswordHash=value;}
        
        
        
        public DateTime RegisterDate { get; private set; }

        public bool Status { get; set; }

        public List<Product> Products { get; set; }

    }
}