using AutoMapper;
using ControleDeContatos.Models;
using Data.Entities;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorie _contatoRepositorie;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepositorie contatoRepositorie, IMapper mapper)
        {
            _contatoRepositorie = contatoRepositorie;
            _mapper = mapper;
        }

        //Metodos por natureza GET AO CARREGAR A TELA
        public async Task<IActionResult> Index()
        {
            var contatosEntitie = await _contatoRepositorie.BuscarTodosAsync();

            var contatos = _mapper.Map<ContatoModel>(contatosEntitie);

            
            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public async Task<IActionResult> EditarContato(int id)
        {
            var contato = await _contatoRepositorie.BuscarPorIdAsync(id);

            var contatoModel = _mapper.Map<ContatoModel>(contato);

            return View(contatoModel);
        }

        public async Task<IActionResult> ApagarContato(int id)
        {
            var contato = await _contatoRepositorie.BuscarPorIdAsync(id);
            var contatoModel = _mapper.Map<ContatoModel>(contato);
            
            return View(contatoModel);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> CriarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contatoEntite = _mapper.Map<ContatoEntitie>(contato);
                    
                    await _contatoRepositorie.AdicionarAsync(contatoEntite);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao cadastrar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> EditarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contatoEntite = _mapper.Map<ContatoEntitie>(contato);
                    
                    await _contatoRepositorie.AtualizarAsync(contatoEntite);

                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("EditarContato", contato);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao atualizar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
            

        }

        public async Task<IActionResult> ApagarContatoConfirmacao(int id)
        {
            try
            {
                bool apagado = await _contatoRepositorie.ApagarAsync(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato! {e.Message}";
                return RedirectToAction("Index");
            }
             
        }
    }
}
