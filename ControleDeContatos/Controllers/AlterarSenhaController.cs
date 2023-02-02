using AutoMapper;
using ControleDeContatos.Helper.Session;
using ControleDeContatos.Models.Alterar;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public AlterarSenhaController(ISessao sessao, IMapper mapper, IUsuarioService usuarioService)
        {
            _sessao = sessao;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSenhaUsuario(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    alterarSenhaModel.Id = usuarioLogado.Id;

                    var alterarDTO = _mapper.Map<AlterarSenhaDTO>(alterarSenhaModel);

                    var result = await _usuarioService.AlterarSenhaAsync(alterarDTO);

                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);

                    //TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    //return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar sua senha. Por favor, tente novamente.";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
