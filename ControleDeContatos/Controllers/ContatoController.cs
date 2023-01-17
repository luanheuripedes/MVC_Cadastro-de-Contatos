using ControleDeContatos.Entities;
using ControleDeContatos.Models;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorie _contatoRepositorie;

        public ContatoController(IContatoRepositorie contatoRepositorie)
        {
            _contatoRepositorie = contatoRepositorie;
        }

        //Metodos por natureza GET AO CARREGAR A TELA
        public async Task<IActionResult> Index()
        {
            var contatosEntitie = await _contatoRepositorie.BuscarTodosAsync();
            var contatos = new List<ContatoModel>();

            if (contatosEntitie.Count > 0)
            {
                
                foreach (var item in contatosEntitie)
                {
                    contatos.Add(new ContatoModel()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Celular= item.Celular,
                        Email = item.Email
                    });
                }
            }
            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult EditarContato()
        {
            return View();
        }

        public IActionResult ApagarContatoConfirmacao()
        {
            return View();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> CriarContato(ContatoModel contato)
        {
            var contatoEntite = new ContatoEntitie()
            {
                Nome = contato.Nome,
                Celular= contato.Celular,
                Email= contato.Email,
            };
            await _contatoRepositorie.AdicionarAsync(contatoEntite);
            return RedirectToAction("Index");
            
        }
    }
}
