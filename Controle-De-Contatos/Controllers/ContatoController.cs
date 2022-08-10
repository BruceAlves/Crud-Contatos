using Controle_De_Contatos.Models;
using Controle_De_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_De_Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatosRepositorio _contatosRepositorio;

        public ContatoController(IContatosRepositorio contatosRepositorio)
        {
            _contatosRepositorio = contatosRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatosRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatosRepositorio.ListarPorID(id);
            return View(contato);
        }

        public IActionResult ApagarComfirmacao(int id)
        {
            ContatoModel contato = _contatosRepositorio.ListarPorID(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado =  _contatosRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MenssagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MenssagemErro"] = $"Ops não foi possível apagar o contato tente novamente";
                    
                }
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Detalhes: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Adicionar(contato);
                    TempData["MenssagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops não foi possível cadastrar o contato tente novamente, {erro.Message}";           
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Atualizar(contato);
                    TempData["MenssagemSucesso"] = "Contato alterado com sucesso com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops não foi possível atualizar o contato tente novamente, {erro.Message}";         
                return RedirectToAction("Index");
            }
        }

    }
}
