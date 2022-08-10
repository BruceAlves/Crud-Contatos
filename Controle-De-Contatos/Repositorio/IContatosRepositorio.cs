using Controle_De_Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_De_Contatos.Repositorio
{
    public interface IContatosRepositorio
    {
        ContatoModel Adicionar(ContatoModel contatoModel);

        ContatoModel Atualizar(ContatoModel contato);

        List<ContatoModel> BuscarTodos();

        ContatoModel ListarPorID(int id);

        bool Apagar(int id);

    }
}
