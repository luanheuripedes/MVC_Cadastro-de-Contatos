using AutoMapper;
using ControleDeContatos.Models;
using Data.Entities;
using Data.Repositories;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorie _usuarioRepositorie;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepositorie usuarioRepositorie, IMapper mapper)
        {
            _usuarioRepositorie = usuarioRepositorie;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioModel = await _usuarioRepositorie.BuscarTodosAsync();

            var usuarios = _mapper.Map<List<UsuarioModel>>(usuarioModel);


            return View(usuarios);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entitie = _mapper.Map<UsuarioEntitie>(model);

                    await _usuarioRepositorie.AdicionarAsync(entitie);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao cadastrar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
