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

        public async Task<IActionResult> EditarContato(int id)
        {
            var contato = await _contatoRepositorie.BuscarPorIdAsync(id);

            var contatoModel = new ContatoModel()
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Celular = contato.Celular,
                Email = contato.Email
            };
            return View(contatoModel);
        }

        public async Task<IActionResult> ApagarContato(int id)
        {
            var contato = await _contatoRepositorie.BuscarPorIdAsync(id);

            var contatoModel = new ContatoModel()
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Celular = contato.Celular,
                Email = contato.Email
            };
            return View(contatoModel);
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

        [HttpPost]
        public async Task<IActionResult> EditarContato(ContatoModel contato)
        {
            var contatoEntite = new ContatoEntitie()
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Celular = contato.Celular,
                Email = contato.Email,
            };
            await _contatoRepositorie.AtualizarAsync(contatoEntite);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> ApagarContatoConfirmacao(int id)
        {

             await _contatoRepositorie.ApagarAsync(id);
            return RedirectToAction("Index");
        }
    }
}
