using AutoMapper;
using ControleDeContatos.Filters;
using ControleDeContatos.Models.Contato;
using ControleDeContatos.Models.Usuario;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IContatoService contatoService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _contatoService = contatoService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioDTO = await _usuarioService.GetAllAsync();

            var usuariosModel = _mapper.Map<List<UsuarioModel>>(usuarioDTO);


            return View(usuariosModel);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        public async Task<IActionResult> EditarUsuario(int id)
        {
            var usuario = await _usuarioService.GetAsync(id);

            var usuarioModel = _mapper.Map<EditarUsuarioModel>(usuario);

            return View(usuarioModel);
        }

        public async Task<IActionResult> ApagarUsuario(int id)
        {
            var usuario = await _usuarioService.GetAsync(id);
            var usuarioModel = _mapper.Map<UsuarioModel>(usuario);

            return View(usuarioModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListarContatosPorUsuarioId(int id)
        {
            var contatos = await _contatoService.BuscarContatosPorUsuarioAsync(id);
            var contatosModel = _mapper.Map<List<ContatoModel>>(contatos);
            return PartialView("_ContatosUsuario", contatosModel);
        }


        public async Task<IActionResult> ApagarUsuarioConfirmacao(int id)
        {
            try
            {
                var apagado = await _usuarioService.RemoveAsync(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário! {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //model.SetSenhaHash();
                    var entitieDTO = _mapper.Map<UsuarioDTO>(model);

                    await _usuarioService.CreateAsync(entitieDTO);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index", "Usuario");
                }

                return View(model);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao cadastrar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioModel usuarioEditarModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioEditarModel);

                    await _usuarioService.UpdateAsync(usuarioDTO);

                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("EditarUsuario", usuarioEditarModel);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao atualizar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
