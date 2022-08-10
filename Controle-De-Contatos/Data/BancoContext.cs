using Controle_De_Contatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_De_Contatos.Data
{
    public class BancoContext : DbContext   //Herdando o contexto do EntityFramework do banco de dados
    {
                              // Tipando o Dbcontext
        public BancoContext(DbContextOptions<BancoContext> options ) : base(options) // passando as informações que vem do options para dentro do Dbcontext
        {                
        }

        //importando
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
