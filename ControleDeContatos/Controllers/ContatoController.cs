using AutoMapper;
using ControleDeContatos.Filters;
using ControleDeContatos.Models.Contato;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Sessao;
using Services.Servicies.Interfaces;


namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;
        private readonly ISessao _sessao;

        public ContatoController(IContatoService contatoService, IMapper mapper, ISessao sessao)
        {
            _contatoService = contatoService;
            _mapper = mapper;
            _sessao = sessao;
        }



        //Metodos por natureza GET AO CARREGAR A TELA
        public async Task<IActionResult> Index()
        {
            var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var contatosDTO = await _contatoService.BuscarContatosPorUsuarioAsync(usuarioLogado.Id);
            var contatos = _mapper.Map<List<ContatoModel>>(contatosDTO);

            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        //View
        public async Task<IActionResult> EditarContato(int id)
        {
            var contato = await _contatoService.GetAsync(id);

            var contatoModel = _mapper.Map<ContatoModel>(contato);

            return View(contatoModel);
        }

        //View
        public async Task<IActionResult> ApagarContato(int id)
        {
            var contato = await _contatoService.GetAsync(id);
            var contatoModel = _mapper.Map<ContatoModel>(contato);

            return View(contatoModel);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> CriarContato(ContatoModel contatoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contatoModel.UsuarioId = usuarioLogado.Id;
                    var contatoDTO = _mapper.Map<ContatoDTO>(contatoModel);

                    await _contatoService.CreateAsync(contatoDTO);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(contatoModel);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao cadastrar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditarContato(ContatoModel contatoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contatoModel.UsuarioId = usuarioLogado.Id;
                    var contatoDTO = _mapper.Map<ContatoDTO>(contatoModel);

                    await _contatoService.UpdateAsync(contatoDTO);

                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("EditarContato", contatoModel);
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
                var apagado = await _contatoService.RemoveAsync(id);

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
