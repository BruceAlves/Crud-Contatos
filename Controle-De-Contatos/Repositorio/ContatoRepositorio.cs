using Controle_De_Contatos.Data;
using Controle_De_Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_De_Contatos.Repositorio
{
    public class ContatoRepositorio : IContatosRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contatoModel)
        {
            //gravar no banco de dados

            _bancoContext.Contatos.Add(contatoModel); //Adicionando um conatato
            _bancoContext.SaveChanges(); //Salve as alterações
            return contatoModel;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorID(id);

            if (contatoDb == null) throw new System.Exception("Erro ao deletar contato!");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorID(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na atialização do contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarPorID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
