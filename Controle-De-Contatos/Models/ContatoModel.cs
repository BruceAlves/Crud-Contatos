using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_De_Contatos.Models
{
    public class ContatoModel
    { 
        //Criando nosso modelo contato, que vai representar a nossa tabela no bando de dados

        public int  Id { get; set; } // ela vai representar o codigo do contato (Auto Imcrement)
        [Required(ErrorMessage ="Digite o nome do contato")] // Campos Obrigatórios
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="O e-mail informado não e válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o telefone do contato")]
        [Phone(ErrorMessage ="O telefone informado não e válido!")]
        public string Celular { get; set; }
    }
}
